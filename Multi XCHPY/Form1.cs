using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Multi_XCHPY
{
    public partial class Main_Form : Form
    {

        public static string percorso_appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //AppData
        public static string percorso_Documenti = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string percorso_profilo_utente = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string source_file = percorso_profilo_utente + @"\OneDrive\Adly\Importante\Crypto\AutoPayments\";

        public Main_Form()
        {
            InitializeComponent();
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            Comb_Loop_Number.Items.Clear();
            int loop = Convert.ToInt32(text_N_transazioni.Text);

            if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Aux_Payment.cmd") == false)
                File.Copy(source_file + @"Aux_Payment.cmd", percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Aux_Payment.cmd");

            //Loop per ottenere i numeri da 1 a x per eseguire un determinato numero di transazioni
            for (int x = 1; x <= loop; x++) //Legge tutte le cartelle
            {
                Console.WriteLine("BOOOH: " + x);
                Comb_Loop_Number.Items.Add(x); // Assegna il nome delle cartelle alla combobox
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string xch_Payment = txt_Send_XCH.Text;
            string xch_Fee = txt_Fee_XCH.Text;
            string xch_Address_Send = txt_Send_XCH.Text;
            string xch_Address_receive = txt_Wallet_Receive.Text;

            Console.WriteLine(Comb_Loop_Number.Text); //Test correttezza dato su Combobox

            int pagamenti = Convert.ToInt32(Comb_Loop_Number.Text);
            var test = refill(pagamenti);
            await test;
        }

        public static Task refill(int pagamenti) // IStanza la quale esegue loop pagamento + salvataggio dati xml
        {
            return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {
                for (int x = 1; x <= pagamenti; x++) //Legge tutte le cartelle
                {
                    if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Aux_Payment.cmd") == true)
                    {
                        Console.WriteLine("Creazione file Transazione.log...\r\n");
                        // Crea un nuovo processo
                        var processStartInfo = new ProcessStartInfo(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Aux_Payment.cmd");
                        // Esegui il processo
                        using (var process1 = Process.Start(processStartInfo))
                        {
                            Console.WriteLine(process1);
                            process1.WaitForExit(); // Attendi che il processo termini
                        }
                    }
                    else
                        Console.WriteLine("il file (Tx_Confirmed.cmd) non è stato trovato ...\r\n");
                }
            });
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            Main_Form_Load(sender, new EventArgs());
        }
    }
}       
