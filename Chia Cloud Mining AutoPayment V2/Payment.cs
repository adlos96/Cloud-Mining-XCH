using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using Timer = System.Timers.Timer;

namespace TCPServer
{
    internal class Payment {
        static bool wallet_Status_connection = false;
        static string conferma_Transazione = "";
        static string transaction_id = "";
        public static string transaction_Hash = "";
        public static string numero_Blocco = "";

        static int pagamento = 1;

        public static int numero_Max_Utenti = 0;
        const int deposito_Minimo = 1250;
        static double balance_Protocol = 0.0;
        static double prezzo_Chia_Euro = 0.0;
        static double protocol_Pay_Xch = 0.0;
        public static double protocol_Pay_Euro = 0.0;
        static double slippage = 0.75;

        const double bonus_Rendita_Plus = 2.75;
        const double bonus_Rendita = 1.75;
        public const double bonus_Referal = 12.5;

        private static DateTime datetime = DateTime.Now.Add(new TimeSpan(0, 0, 2, 0)); // TODO usato solo per test (GG, HH, mm, ss)
        public static string orarioDesiderato = datetime.ToString("HH:mm:ss");
        public static Timer timer;
        public static DateTime scadenza;
        public static object lockObject = new object();

        public static async void Payment_Users() {
            Variabili.loop_Payment_Checker = true;
            while (Variabili.loop_Payment_Checker == true){

                Timer(); // 24h

                if(Variabili.loop_Payment_Checker == false) return; //Controllo

                //Controlla lo stato della connessione del wallet
                await Connection_Status_Chia();
                await Swap_Chia_Euro();
                await Database.Numero_Plot();

                var usersToPay = Database.Get_Users_To_Pay();
                
                Variabili.payment_Log.Add("Utendi Registrati: " + Database.Utenti_Registrati());
                await Numero_Coins_Protocol();
                await Balance_Protocol();
                await Protocol_Pay();

                foreach (var user in usersToPay)
                    Payment_Tizio(user);
                
                Mempool.Transaction_Tx(); // mempool (Ricordare di aspettare almeno 10 minuti tra il pagamento e l'esecuzione della mempool)

                //Serve solo per forzare 1 pagamento ogni 7 minuti
                orarioDesiderato = DateTime.Now.AddMinutes(5).ToString("HH:mm:ss");
                pagamento = 1; //Numero Transazioni
            }
        }
        public static void Payment_Tizio(string[] user, int numero_tentativi = 0 )
        {
            int tentativi_Massimi = 1;
            string ID = user[0];
            string wallet = user[1];
            string deposito = user[2];
            string credito = user[3];
            string credito_Rimasto = user[4];
            double daily_Reward = Convert.ToDouble(user[5]);
            double tantum = Convert.ToDouble(user[6]);
            string fee = user[7];
            string rendimento_Bool = user[8];

            //Calcolo automatico daily_Payment || Si suppone che il prezzo base sia 30€/Xch
            double b = Convert.ToDouble(daily_Reward);
            double c = 30;
            double d = 1;
            double e = prezzo_Chia_Euro;
            double f = e * d / c;
            double a = f;

            double new_Daily_Payment = a * b;

            Variabili.payment_Log.Add($"Nuovo Daily Payment: {new_Daily_Payment}"); // Continuare e rivedere il codice sotto
            Variabili.payment_Log.Add($"Daily Payment:       {daily_Reward}");
            Variabili.payment_Log.Add($"Fee:                 {tantum}");

            //Calcolo XCH da pagare
            double prezzo_Chia = prezzo_Chia_Euro + (prezzo_Chia_Euro * slippage / 100);
            double chia_pay = (new_Daily_Payment + tantum) / prezzo_Chia; // XCH
            double new_Credito_Rimasto = Convert.ToDouble(credito_Rimasto) - Convert.ToDouble(new_Daily_Payment);
            double rendimento = 0.0;
            double block_Number = 0;
            string status = "Pending";

            Variabili.payment_Log.Add($"Chia_Pay: {chia_pay}");

            string data_Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            //Pagamento Utente

            bool pagamento_Eseguito = Start_Payment_Xch(wallet, chia_pay.ToString("0.000000000000").Replace(",","."), fee, ID, prezzo_Chia.ToString("0.00"));
            if(pagamento_Eseguito == false) {
                Variabili.payment_Log.Add($"Problem? [225588] --> ID: {ID} Wallet: {wallet} Credito: {credito_Rimasto} Data: {new_Daily_Payment}");
                Variabili.payment_Log.Add($"Tentativi massimi raggiunti: {numero_tentativi}/{tentativi_Massimi} --> User ID: {ID}");

                data_Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                if (numero_tentativi < tentativi_Massimi) Payment_Tizio(user, ++numero_tentativi);
                else Variabili.payment_Log.Add($"Tentativi massimi raggiunti --> User ID: {ID}");
                Variabili.loop_Mempool_Checker = false;
                return;
            }
            //Calcolo Rendimento Giornaliero
            if (rendimento_Bool == "1" || Convert.ToDouble(deposito) >= deposito_Minimo) //Somma depositata 1'250
                rendimento = Rendimento_Giornaliero(deposito, credito, credito_Rimasto);
            else
                Variabili.payment_Log.Add("Rendimenti Disattivati, il capitale depositato è inferiore a 1.250$");
            
            if (conferma_Transazione == "SUCCESS" || transaction_id != "") {
                //Aggiornamento DB
                Database.Update_User_Balance(Convert.ToInt32(ID), new_Credito_Rimasto.ToString("0.0000"));

                int Tx_ID = 1;
                string TX = transaction_id;
                string tx_Hash = "Pending";
                //Aggiornamento Transazioni
                Database.Add_New_Transaction(Convert.ToInt32(ID), TX, tx_Hash, chia_pay.ToString("0.000000000000"), new_Daily_Payment.ToString("0.00000000"), prezzo_Chia.ToString("0.00"), rendimento.ToString("0.0000"), status, block_Number.ToString(), data_Time);
                Variabili.payment_Log.Add("------------------------------------------");
            } else {
                Variabili.payment_Log.Add($"Stato Transazione: {conferma_Transazione}");
                Variabili.payment_Log.Add($"-tx: {transaction_id}");
            }
        }
        public static void Timer_General()
        {
            string orario_Corrente = DateTime.Now.ToString("HH:mm:ss");

            // Calcola il tempo che manca fino all'orario desiderato
            TimeSpan tempo_Rimanente = Tempo_Trascorso(orario_Corrente, orarioDesiderato);
            double millisecondi_Rimanenti = tempo_Rimanente.TotalMilliseconds;

            Console.WriteLine("");
            Console.WriteLine($"Timer Pagamenti:        {Secondi_In_Orario(Convert.ToInt32(millisecondi_Rimanenti / 1000))}");
            Console.WriteLine($"Orario Pagamenti:       {orarioDesiderato}");
            Console.WriteLine($"Avvio Mempool:          {Mempool.Timer_Generale()}");
        }
        static bool Start_Payment_Xch(string wallet_Ricezione, string xch_Amount, string xch_Fee, string ID, string prezzo_Chia)
        {
            var walletId = Environment.GetEnvironmentVariable("CHIA_WALLET_ID");
            Variabili.payment_Log.Add("");
            Variabili.payment_Log.Add($"*** Esecuzione Transazione [{pagamento}|{Database.Utenti_Registrati()}] ***");
            Variabili.payment_Log.Add("------------------------------------------");
            Variabili.payment_Log.Add($"User ID:        {ID}");
            Variabili.payment_Log.Add($"Chia:           {xch_Amount} xch");
            Variabili.payment_Log.Add($"Prezzo chia:    {prezzo_Chia} Euro");
            Variabili.payment_Log.Add($"Fee:            {xch_Fee} xch");
            Variabili.payment_Log.Add($"Wallet ID:      {walletId}");
            Variabili.payment_Log.Add($"Wallet Recive:  {wallet_Ricezione}");

            var comando = Env.CHIA_PATH + @"\chia.exe";
            var argomenti = $"wallet send -a {xch_Amount} -m {xch_Fee} -f {walletId} -i 1 -t {wallet_Ricezione}";

            ProcessStartInfo startInfo = new ProcessStartInfo{
                FileName = comando,
                Arguments = argomenti,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var processo = new Process();
            processo.StartInfo = startInfo;
            processo.Start();

            // Estrarre il Payment.log
            var all_output = processo.StandardOutput.ReadToEnd();
            processo.WaitForExit();
            var codiceUscita = processo.ExitCode;
            File.WriteAllText(Env.DOC_PATH + @"\Payment.log", all_output);

            if (codiceUscita == 0)
                Stato_Transazione(all_output);
            else
                Variabili.payment_Log.Add("Start_Payment|Errore > Pagamento fallito! " + all_output);
            pagamento++;
            return codiceUscita == 0;
        }
        static double Rendimento_Giornaliero(string deposito, string credito, string credito_Rimasto)
        {
            double rendimento_24h = 0;
            double lettura_Deposito = Convert.ToDouble(deposito);
            double lettura_Credito = Convert.ToDouble(credito);
            double lettura_Credito_rimanente = Convert.ToDouble(credito_Rimasto);

            double bonus = lettura_Credito - lettura_Deposito; // Calcola il bonus applicato in €
            double _credito = lettura_Credito_rimanente - bonus;

            if (lettura_Deposito > 1249)
                rendimento_24h = _credito * (bonus_Rendita_Plus - slippage) / 100 / 365;
            else
                rendimento_24h = _credito * (bonus_Rendita - slippage) / 100 / 365; // calcolo daily reward 
            return rendimento_24h;
        }
        static async Task Swap_Chia_Euro()
        {
            // Imposta la coppia di criptovalute desiderata
            string coinId = "chia";
            string vsCurrency = "eur";

            // Crea l'URL dell'API con la coppia di criptovalute
            string apiUrl = $"https://api.coingecko.com/api/v3/simple/price?ids={coinId}&vs_currencies={vsCurrency}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Effettua una richiesta GET all'API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    // Leggi la risposta come stringa
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Analizza la risposta JSON
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    // Estrai il prezzo dalla risposta JSON
                    decimal price = result[coinId][vsCurrency].ToObject<decimal>();
                    prezzo_Chia_Euro = Convert.ToDouble(price);

                    // Stampa il prezzo
                    Variabili.payment_Log.Add($"Il prezzo di {coinId.ToUpper()} è {price} {vsCurrency.ToUpper()}");
                }
                catch (Exception ex)
                {
                    Variabili.payment_Log.Add("Si è verificato un errore durante la richiesta dell'API: " + ex.Message);
                }
            }
        }
        public static async Task Connection_Status_Chia()
        {
            int timer = 1000 * 60 * 4;
            int not_Synced = 0;
            int tentativi = 3;
            bool ciclo = true;

            bool wallet_Status1 = false;
            bool wallet_Status2 = false;
            bool wallet_Status3 = false;

            //string comando = Env.CHIA_PATH + @"\chia.exe";
            string comando = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Programs\Chia\resources\app.asar.unpacked\daemon\chia.exe";  //TODO usato solo per test
            string argomenti = "wallet show";

            string connection_Error = "Connection error.";
            string sync_Status_Not_Sync = "Sync status: Not synced";
            string sync_Status_Sync = "Sync status: Synced";

            while (ciclo == true)
            {
                Console.WriteLine("");
                Console.WriteLine($"Check Connection");
                Console.WriteLine($"Tentativo: {not_Synced + 1}/{tentativi}");

                ProcessStartInfo startInfo1 = new ProcessStartInfo
                {
                    FileName = comando,
                    Arguments = argomenti,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var processo1 = new Process())
                {
                    processo1.StartInfo = startInfo1;
                    processo1.Start();
                    string all_output = processo1.StandardOutput.ReadToEnd();

                    wallet_Status1 = all_output.Contains(connection_Error);
                    wallet_Status2 = all_output.Contains(sync_Status_Not_Sync);
                    wallet_Status3 = all_output.Contains(sync_Status_Sync);

                    processo1.WaitForExit();
                    int codiceUscita = processo1.ExitCode;
                }

                if (not_Synced >= tentativi)
                {
                    ciclo = false;
                    Console.WriteLine("Controllo connessione wallet interrotto!");
                    Console.WriteLine("Riavvio Manuale Richiesto...");
                    Variabili.loop_Payment_Checker = false;
                    return;
                }
                if (wallet_Status3 == true)
                {
                    ciclo = false;
                    Console.WriteLine("Wallet Connesso!");
                    wallet_Status_connection = true;
                }
                if (wallet_Status2 == true || wallet_Status1 == true)
                {
                    not_Synced++;
                    Console.WriteLine("");
                    Console.WriteLine("Wallet Disconnesso!");
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Il controllo verrà rieseguito tra:");
                    Console.WriteLine($"Connection error      | {wallet_Status1}");
                    Console.WriteLine($"Sync status error     | {wallet_Status2}");
                    Console.WriteLine($"Timer: {timer / 1000 / 60} Minuti");
                    Console.WriteLine("------------------------------------------------------------");
                    Thread.Sleep(timer);
                }
            }
        }
        static void Stato_Transazione(string output_transaction) {
            var targetText = "-tx ";
            var txid = "";
            string? line;

            using (var reader = new StreamReader(Env.DOC_PATH + @"\Payment.log"))
            while ((line = reader.ReadLine()) != null) {
                var startIndex = line.IndexOf(targetText, StringComparison.Ordinal);
                if (startIndex == -1) continue;
                txid = line.Substring(startIndex + targetText.Length);
                txid = txid.Substring(0, 66);
            }

            conferma_Transazione = output_transaction.Substring(161, 7);  // Estrai avvenuta transazione [SUCCESS]
            transaction_id = txid;  // Estrai transaction id [-tx 0x42f917d...]
            
            // Visualizza la parte estratta dal file
            Console.WriteLine($"Stato transazione:  {conferma_Transazione}");
            Console.WriteLine($"Transaction ID:     {transaction_id}");
        }
        public static async Task Numero_Coins_Protocol()
        {
            // Definisci il pattern regex per cercare un numero intero nella riga
            string pattern = @"\d+";

            string comando = Env.CHIA_PATH + @"\chia.exe";
            string argomenti = "wallet coins list";

            ProcessStartInfo startInfo = new ProcessStartInfo{
                FileName = comando,
                Arguments = argomenti,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process processo = new Process())
            {
                processo.StartInfo = startInfo;
                processo.Start();

                // Estrarre solamente il numero di monete confermate
                string output = processo.StandardOutput.ReadLine();
                string confirmed_Coins = processo.StandardOutput.ReadLine();
                string unconfirmed_Additions = processo.StandardOutput.ReadLine();
                string unconfirmed_Removals = processo.StandardOutput.ReadLine();

                string all_output = processo.StandardOutput.ReadToEnd();

                // Crea l'oggetto Regex e cerca il pattern nella riga
                Match match1 = Regex.Match(confirmed_Coins, pattern);

                // Verifica se è stata trovata una corrispondenza
                if (match1.Success){
                    // Ottieni il valore trovato
                    string numero1 = match1.Value;

                    // Converte il valore in un numero intero (se necessario)
                    if (int.TryParse(numero1, out int risultato1))
                        numero_Max_Utenti = risultato1;
                    else
                        Console.WriteLine("Il valore trovato non è un numero intero valido.");
                }
                else
                    Console.WriteLine("Nessun numero trovato nella stringa.");

                //Console.WriteLine($"Totale coin: {confirmed_Coins}");
                //Console.WriteLine($"unconfirmed additions: {unconfirmed_Additions}");
                //Console.WriteLine($"0 unconfirmed removals: {unconfirmed_Removals}");

                processo.WaitForExit();
                int codiceUscita = processo.ExitCode;
            }
        }
        public static async Task Balance_Protocol()
        {
            string comando = Env.CHIA_PATH + @"\chia.exe";
            string argomenti = "wallet show";
            string pattern = @"Total Balance:\s+(\d+(\.\d+)?)\s+xch";

            ProcessStartInfo startInfo2 = new ProcessStartInfo
            {
                FileName = comando,
                Arguments = argomenti,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process processo1 = new Process())
            {
                processo1.StartInfo = startInfo2;
                processo1.Start();

                // Estrarre solamente il numero di monete confermate
                string wallet_Height = processo1.StandardOutput.ReadLine();
                string sync_Status = processo1.StandardOutput.ReadLine();
                string fingerprint = processo1.StandardOutput.ReadLine();
                string output1 = processo1.StandardOutput.ReadLine();
                string output2 = processo1.StandardOutput.ReadLine();
                string total_Balance = processo1.StandardOutput.ReadLine();

                string all_output = processo1.StandardOutput.ReadToEnd();

                // Crea l'oggetto Regex e cerca il pattern nella riga
                Match match1 = Regex.Match(total_Balance, pattern);

                // Verifica se è stata trovata una corrispondenza
                if (match1.Success)
                {
                    // Ottieni il valore trovato
                    string valorebalance = match1.Groups[1].Value;
                    valorebalance.Replace(",", ".");

                    // Converte il valore in un numero intero (se necessario)
                    if (double.TryParse(valorebalance, out double risultato1))
                        balance_Protocol = risultato1 / Math.Pow(10, 12);
                    else
                        Console.WriteLine("Il valore trovato non è un numero intero valido.");
                }
                else
                    Console.WriteLine("Nessun numero trovato nella riga.");

                processo1.WaitForExit();
                int codiceUscita = processo1.ExitCode;
            }
        }
        public static async Task<string> Protocol_Pay()
        {
            protocol_Pay_Xch = protocol_Pay_Euro / prezzo_Chia_Euro;
            double giorni_Fine_Credito = balance_Protocol / protocol_Pay_Xch;

            Console.WriteLine("");
            Console.WriteLine("*** Protocol Summary ***");
            Console.WriteLine($"-------------------------------------------------------------------");
            Console.WriteLine($"Totale pagato dal protocollo:   {protocol_Pay_Euro} Euro");
            Console.WriteLine($"Totale pagato dal protocollo:   {protocol_Pay_Xch.ToString("0.000000000000")} xch");
            Console.WriteLine($"Bilancio Protocollo:            {balance_Protocol.ToString("0.000000000000")} xch");
            Console.WriteLine($"Giorni fine Credito:            {giorni_Fine_Credito.ToString("0")}");
            Console.WriteLine($"Prezzo chia:                    {prezzo_Chia_Euro} Euro");
            Console.WriteLine($"Numero utenti registrati:       {Database.Utenti_Registrati()}");
            Console.WriteLine($"Numero utenti massimi:          {numero_Max_Utenti}");
            Console.WriteLine($"-------------------------------------------------------------------");
            return protocol_Pay_Xch.ToString("0.000000000000");
        }
        public static void Timer()
        {
            string orario_Corrente = DateTime.Now.ToString("HH:mm:ss");

            // Calcola il tempo che manca fino all'orario desiderato
            TimeSpan tempo_Rimanente = Tempo_Trascorso(orario_Corrente, orarioDesiderato);
            double millisecondi_Rimanenti = tempo_Rimanente.TotalMilliseconds;

            Console.WriteLine("");
            Console.WriteLine($"Timer: {Secondi_In_Orario(Convert.ToInt32(millisecondi_Rimanenti / 1000))}");
            Console.WriteLine($"Orario avvio pagamenti: {orarioDesiderato}");

            // Queste 3 righe son per mostrare lo scorrere del tempo + le 2 funzioni finali [Secondi_In_Orario() - TimerElapsed()]
            //timer = new Timer(1000); // Timer che scatta ogni secondo (1000 millisecondi)
            //timer.Elapsed += TimerElapsed_TEST;
            //timer.Start();
            
            Thread.Sleep(Convert.ToInt32(millisecondi_Rimanenti));
            Console.WriteLine("");
        }
        static TimeSpan Tempo_Trascorso(string data1, string data2)
        {
            string formato_Data = "HH:mm:ss";// Specifica il formato delle date in ingresso

            // Converte le date da stringhe a oggetti DateTime
            DateTime date_Time1 = DateTime.ParseExact(data1, formato_Data, System.Globalization.CultureInfo.InvariantCulture);
            DateTime date_Time2 = DateTime.ParseExact(data2, formato_Data, System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan intervallo = date_Time2 - date_Time1; // Calcola l'intervallo di tempo tra le due date
            if (date_Time2 < date_Time1)
            {
                // L'intervallo è negativo, aggiungi 24 ore a dateTime2
                intervallo = intervallo.Add(TimeSpan.FromHours(24));
            }
            return intervallo;
        }
        public static string Secondi_In_Orario(int totalSecondi)
        {
            // Calcola le ore, i minuti e i secondi
            int ore = totalSecondi / 3600 ;
            int minuti = (totalSecondi % 3600) / 60;
            int secondi = totalSecondi % 60 ;

            // Formatta l'orario nel formato "HH:mm:ss"
            string formatoData = $"{ore:D2}:{minuti:D2}:{secondi:D2}";
            scadenza = DateTime.Now.AddHours(ore).AddMinutes(minuti).AddSeconds(secondi);

            return formatoData;
        }
        public static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            TimeSpan tempoRimanente = scadenza - DateTime.Now;

            if (tempoRimanente.TotalSeconds <= 0) {
                Console.SetCursorPosition(0, Console.CursorTop);
                timer.Stop();
            }else {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write($"Avvio pagamenti a breve: {tempoRimanente.ToString(@"hh\:mm\:ss")}");
            }
        }
        public static string Generate_Random_Code(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            byte[] data = new byte[length];

            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                rng.GetBytes(data);
            
            StringBuilder code = new StringBuilder(length);

            foreach (byte byteValue in data)
                code.Append(characters[byteValue % characters.Length]);
            
            return code.ToString();
        }
        public static string Generate_Random_Transaction_Memo(int numWords, int wordLength, char separator)
        {
            StringBuilder randomString = new StringBuilder();

            for (int i = 0; i < numWords; i++)
            {
                string randomWord = Generate_Random_Code(wordLength);
                randomString.Append(randomWord);

                if (i < numWords - 1)
                    randomString.Append(separator);
                
            }
            return randomString.ToString();
        }
    }
}
