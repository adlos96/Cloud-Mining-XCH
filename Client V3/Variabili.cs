using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client_V3
{
    internal class Variabili
    {
        public static Queue<string> queue_Payment_Command { get; } = new Queue<string>(); //Code
        public static Queue<string> queue_Simulate_Command { get; } = new Queue<string>();

        public static string chia_prelevati = "0";
        public static string status_Pagamento = "Stato pagamento: Nessuno";
        public static string id_Client = "not connected";
        public static string importo_USDT = "";

        // -------------------- Fee Xch -----------------------
        public static string fee_A = "Null";
        public static string fee_B = "Null";
        public static string fee_C = "Null";

        // -------------------- Rendita -----------------------
        public static double Rendita_Base_A = 0.00;
        public static double Rendita_Base_B = 0.00;
        public static double Rendita_Base_C = 0.00;
        public static double Rendita_Base_D = 0.00;
        public static double Rendita_Base_E = 0.00;
        public static double bonus_Deposito = 0.00;
        public static double bonus_Innvito_Ref = 0.00;
        public static double bonus_Invitato_Ref = 0.00;

        // -------------------- xxx -----------------------

        public static string xch_Prelevabili = "0.0000000000";
        public static string xch_Pending     = "0.0000000000";

        // -------------------- Protocol Login -----------------------
        public static bool seed_Phrase = false; // Se la seed phrase inviata è corretta si potà resettare la password

        // -------------------- Protocol Balance -----------------------

        public static string CHIA       = "0.0000000000";
        public static string ATOM       = "0.0000000000";
        public static string CRO        = "0.0000000000";
        public static string LUNA       = "0.0000000000";
        public static string TIA        = "0.0000000000";
        public static string USDT       = "0.0000000000";
        public static string USDC       = "0.0000000000";
        public static string axlUSDC    = "0.0000000000";

        public static string XDLS       = "0.0000000000";
        public static string XUSDT      = "0.0000000000";

        // -------------------- Protocol Swap Price -----------------------

        public static string price_CHIA     = "0.0000000000";
        public static string price_ATOM     = "0.0000000000";
        public static string price_CRO      = "0.0000000000";
        public static string price_LUNA     = "0.0000000000";
        public static string price_TIA      = "0.0000000000";
        public static string price_USDT     = "0.0000000000";
        public static string price_USDC     = "0.0000000000";
        public static string price_axlUSDC  = "0.0000000000";

        public static string price_XDLS     = "0.0000000000";
        public static string price_XUSDT    = "0.0000000000";

        // -------------------- Protocol Balance Swap ----------------------- (Unicamente le coin disponibili o con un unlock rapido )
        public static string CHIA_Swap      = "0.0000000000";   //no-Unlock
        public static string ATOM_Swap      = "0.0000000000";
        public static string CRO_Swap       = "0.0000000000";
        public static string LUNA_Swap      = "0.0000000000";
        public static string TIA_Swap       = "0.0000000000";
        public static string USDT_Swap      = "0.0000000000";   //Unlock Rapido
        public static string USDC_Swap      = "0.0000000000";   //Unlock Rapido
        public static string axlUSDC_Swap   = "0.0000000000";   //Unlock Rapido

        public static string XDLS_Swap      = "0.0000000000";   //no-Unlock
        public static string XUSDT_Swap     = "0.0000000000";   //no-Unlock

        public static bool loop_Command_Payment = false;

        // -------------------- User Data Client -----------------------
        public static string invito_Referal         = "Null";
        public static string wallet                 = "Null";
        public static string password = "Null";
        public static string pagamento_Somma_USDT   = "Null";
        public static string numero_Plot            = "Null";
        public static string wallet_USDT            = "Null";
        public static string chain                  = "Null";

        // -------------------- User Data Client -----------------------
        public static double eur_usd = 0;
        public static double usd_usdt = 0;

        public static string percorso_database = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\A_Client\Transaction\";
        public static string test_Percorso_Cartella = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\A_Client\";
        public static string test_Percorso_Transazioni = test_Percorso_Cartella + @"Transaction";

        public static void Impostazioni()
        {
            if(Client_V3.Properties.Settings.Default.Salvataggio == false)
            {
                // Assegnazione valori default se in presenza di un nuovo utente
                invito_Referal = "Null";
                wallet = "Null";
                // email = "email@test.com"; // Deprecato
                Client_V3.Properties.Settings.Default.Salvataggio = false;
                Console.WriteLine("Nuovo utente, nessuna impostazione da caricare");
            }
            else
            {
                //Caricamento impostazioni se presente qualcosa in appdata

                wallet           =   Client_V3.Properties.Settings.Default.Wallet_Chia;
                invito_Referal   =   Client_V3.Properties.Settings.Default.Referal_Code;

                Client_V3.Properties.Settings.Default.Salvataggio = true;
                Console.WriteLine("Caricamento impostazioni dati utente...");
            }
        }

        public static int conta_numero_elementi()
        {
            if (System.IO.Directory.Exists(test_Percorso_Cartella));
                System.IO.Directory.CreateDirectory(test_Percorso_Cartella);
            if (System.IO.Directory.Exists(test_Percorso_Transazioni)) ;
            System.IO.Directory.CreateDirectory(test_Percorso_Transazioni);


            return System.IO.Directory.GetFiles(percorso_database).Length;
        }//Conta il numero di elementi all'interno della cartella database, restituendo un valore numerico

        public static string[] carica_contenuto_elementi()
        {

            string[] elementi_trovati = System.IO.Directory.GetFiles(percorso_database);
            return elementi_trovati;

        }

    }
}
