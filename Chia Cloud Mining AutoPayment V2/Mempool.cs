using System.Diagnostics;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TCPServer
{
    internal class Mempool
    {
        public static int attesa_Mempool = 1 * 60 * 1000;
        //public static int attesa_Mempool = 30 * 60 * 1000;
        static int mempool = 1;
        public static int totale_Transazioni_mempool = 0;

        public static string data = "";
        public static string tempo = "";
        public static string avvio_Mempool = "";

        public static bool loop_Mempool = true;
        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false;}
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void Transaction_Tx()
        {
            Variabili.loop_Mempool_Checker = true;
            Timer(); // Attesa 30 minuti (Test con 1 minuto)

            if (Variabili.loop_Mempool_Checker == false) return; //Controllo

            Variabili.mempool_Log.Add("");
            Variabili.mempool_Log.Add("Transazioni Mempool");
            Variabili.mempool_Log.Add("--------------------------------------");

            var usersToPay = Database.Get_Users_mempool();
            foreach (var user in usersToPay)
            {
                Mempool_Start(user);
            }
            mempool = 1;
            totale_Transazioni_mempool = 0;
            Variabili.loop_Mempool_Checker = false;
        }
        static void Mempool_Start(IReadOnlyList<string> Tx) {
            var id = Convert.ToInt32(Tx[0]);
            var txFirst = Tx[1];

            Variabili.mempool_Log.Add("-----------------------------------------------");
            var jsonOutput = Tx_log(txFirst);
            // string block_Number = Block_Number(output);
            var parentCoin = jsonOutput?.additions[0].parent_coin_info;
            var puzzleHash = jsonOutput?.additions[0].puzzle_hash;
            var amount = jsonOutput?.additions[0].amount;
            var blockNumber = jsonOutput?.confirmed_at_height;

            if (parentCoin == null || puzzleHash == null || amount == null)
            {
                Variabili.loop_Mempool_Checker = false;
                return;
            }
            var txnHash = ChiaUtils.GenerateTxnHash(parentCoin, puzzleHash, (int) amount);

            Variabili.mempool_Log.Add($"Transazione [{mempool}|{totale_Transazioni_mempool}]");
            Variabili.mempool_Log.Add($"txnHash: https://xchscan.com/txns/0x{txnHash}");

            Variabili.mempool_Log.Add("ID: " + id);
            Database.Update_Transaction_Block(id, blockNumber.ToString(), txnHash);
            mempool++;
        }
        static ChiaTxnResponse? Tx_log(string transactionId){
            var comando = Env.CHIA_PATH + @"\chia.exe";
            var argomenti = $"wallet get_transaction -tx {transactionId} -v";

            var startInfo2 = new ProcessStartInfo {
                FileName = comando,
                Arguments = argomenti,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process();
            process.StartInfo = startInfo2;
            process.Start();

            var allOutput = process.StandardOutput.ReadToEnd();
            allOutput = allOutput.Replace("': True,", "': true,");
            allOutput = allOutput.Replace("': False,", "': false,");
            allOutput = allOutput.Replace("None", "null");
            var stato_Transazione_Json = IsValidJson(allOutput);

            Variabili.mempool_Log.Add(stato_Transazione_Json.ToString());
            if (!IsValidJson(allOutput)) {
                Variabili.mempool_Log.Add($"[MEMPOOL|ERROR] > JSON from the command [chia {argomenti}] id invalid");
                System.Environment.Exit(0);
            }
            var txLog = JsonConvert.DeserializeObject<ChiaTxnResponse>(allOutput);
            process.WaitForExit();
            // int exitCode = process.ExitCode;
            return txLog;
        }
        public static void Timer()
        {
            data = DateTime.Now.ToString("HH:mm:ss");
            tempo = Payment.Secondi_In_Orario(attesa_Mempool / 1000);
            avvio_Mempool = Convert.ToDateTime(data).AddMinutes(attesa_Mempool / 60 / 1000).ToString("HH:mm:ss");

            Console.WriteLine("");
            Console.WriteLine("*** Mempool Start ****");
            Console.WriteLine("Orario avvio mempool: " + data);
            Console.WriteLine($"Mempool in avvio: {avvio_Mempool}");

            //Payment.timer = new Timer(1000); // Timer che scatta ogni secondo (1000 millisecondi)
            //Payment.timer.Elapsed += Payment.TimerElapsed;
            //Payment.timer.Start();
            Console.WriteLine("");

            Thread.Sleep(attesa_Mempool); // Timer 30 minuti prima dell'esecuzione della mempool
        }
        public static string Timer_Generale()
        {
            return avvio_Mempool;
        }

    }
}
