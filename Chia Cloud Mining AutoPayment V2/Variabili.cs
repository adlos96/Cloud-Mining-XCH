using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Xml;

public static class Variabili
{
    public static bool loop_pagamenti = true;
    public static bool impostazioni_stato_salvataggio = false;

    public static bool conferma_transazione_bool = false;
    public static string conferma_transazione_string = "";
    public static string transaction_id = "";
    //public const int attesa = 1000 * 24 * 60 * 60; //Tempo da attendere prima del pagamento
    public const int attesa = 1000 * 24 * 60 * 60; //Tempo da attendere prima del pagamento
    public static int tempo_calcolato = 0;          //Tempo perso
    public static double tantum = 0.00;

    public const int bonus_Rendita = 2;
    public const int reward = 25000;
    public static int min_Deposit = 1250;
    public static string testo_log;
    public static double reward_originale = 0.0000;

    public static string messaggio_server = "Vuoto"; // Test con server per manadare il nome utente al client


    //Richiamabile ovunque, scrivendo Variabili.percorso_database = "ciao"
    public static string percorso_appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //AppData      | C:\Users\...\AppData
    public static string percorso_profilo_utente = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);   //Google Drive | C:\Users\...\Documents
    public static string percorso_programma = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database;        //Documenti    | C:\Users\...\Documents

    public static string percorso_database = percorso_programma  + @"\Chia_AutoPayment\Database\";
    public static string percorso_api = percorso_programma + @"\Chia_AutoPayment\API\";
    public static string percorso_cmd = percorso_programma + @"\Chia_AutoPayment\Cmd\";
    public static string dati_client = percorso_programma + @"\Chia_AutoPayment\Client\";
    public static string percorso_cmd_path = percorso_programma + @"\Chia_AutoPayment\Cmd_path\";
    public static string percorso_log_path = percorso_programma + @"\Chia_AutoPayment\Log\";
    public static string percorso_email_path = percorso_programma + @"\Chia_AutoPayment\Email\";

    public static string nome_cartella_transazioni = "";

    public static string pythonPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Pyton_exe;          // percorso del file python.exe
    public static string scriptPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api;     // percorso del file Python da eseguire
    public static string price_chiaPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt; //Percorso del file prezzo chia
    public static string cmdPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cmd;
    public static string plotPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Plot_Path;

    public static string Wallet_ID = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Wallet;
    public static string Email_invio = "thechannelofadlos@mail";
    public static string Email_code = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Mail_code;
    public static string versione_software = "1.2.13";
    public static string Versione_client = "0.00.24";
    public static string Versione_server = "0.01.13";
    public static string nome_software = "Chia Cloud Mining " + versione_software;

    public static void impostazioni_utente() // imposta i percorsi specificati dall'utente
    {
        if (percorso_database == "")
            percorso_programma = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Chia_AutoPayment\";
        else
        {
            percorso_database = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database + @"\Chia_AutoPayment\Database\";
            percorso_api = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_api + @"\Chia_AutoPayment\API\";
            percorso_cmd = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_cmd + @"\Chia_AutoPayment\Cmd\";

            dati_client = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database + @"\Chia_AutoPayment\Client\";
            percorso_cmd_path = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database + @"\Chia_AutoPayment\Cmd_path\";
            percorso_log_path = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database + @"\Chia_AutoPayment\Log\";
            percorso_email_path = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database + @"\Chia_AutoPayment\Email\";

            pythonPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Pyton_exe;          // percorso del file python.exe
            scriptPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api;     // percorso del file Python da eseguire
            price_chiaPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt; //Percorso del file prezzo chia
            cmdPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cmd;
            plotPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Plot_Path;
            Wallet_ID = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Wallet;
            Email_code = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Mail_code;
        }
    }

    //Controlla se la cartella-percorso esiste
    public static void Controlla_percorso_database()
    {
        if (System.IO.Directory.Exists(percorso_database) == false)
        {
            System.IO.Directory.CreateDirectory(percorso_database);
        }
        if (System.IO.Directory.Exists(percorso_api) == false)
        {
            System.IO.Directory.CreateDirectory(percorso_api);
        }
        if (System.IO.Directory.Exists(percorso_cmd) == false)
        {
            System.IO.Directory.CreateDirectory(percorso_cmd);
        }
        if (System.IO.Directory.Exists(dati_client) == false)
        {
            System.IO.Directory.CreateDirectory(dati_client);
        }
        if (System.IO.Directory.Exists(percorso_cmd_path) == false)
        {
            System.IO.Directory.CreateDirectory(percorso_cmd_path);
        }
        if (System.IO.Directory.Exists(percorso_log_path) == false)
        {
            System.IO.Directory.CreateDirectory(percorso_log_path);
        }
        if (System.IO.Directory.Exists(percorso_email_path) == false)
        {
            System.IO.Directory.CreateDirectory(percorso_email_path);
        }
    }//Se non c'è la crea ... (percorso_database) - (percorso_api) - (percorso_cmd) - (dati_client) - (percorso_cmd_path)

    public static void file_indispensabili() //Copia i due file per avviare i pagamenti
    {
        string source_file = percorso_profilo_utente + @"\OneDrive\Adly\Importante\Crypto\AutoPayments\";

        if (File.Exists(percorso_appdata +@"\Programs\Chia\resources\app.asar.unpacked\daemon\Pagamento.cmd") == false)
            File.Copy(source_file + @"Pagamento.cmd", percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Pagamento.cmd");
        if (File.Exists(percorso_api + @"\prezzo_chia.py") == false)
            File.Copy(source_file + @"prezzo_chia.py", percorso_api + @"\prezzo_chia.py");
    }

    public static int conta_numero_elementi()
    {
        return System.IO.Directory.GetFiles(percorso_database).Length;
    }//Conta il numero di elementi all'interno della cartella database, restituendo un valore numerico
    public static int conta_numero_elementi_transaction()
    {
        return System.IO.Directory.GetDirectories(percorso_database + @"Transaction").Length;
    }//Conta il numero di elementi all'interno della cartella database, restituendo un valore numerico
    public static int conta_numero__transazioni()
    {
        return System.IO.Directory.GetFiles(percorso_database + @"Transaction\" + nome_cartella_transazioni).Length;
    }//Conta il numero di elementi all'interno della cartella database, restituendo un valore numerico

    public static string[] carica_contenuto_elementi()
    {
        string[] elementi_trovati = System.IO.Directory.GetFiles(percorso_database);
        return elementi_trovati;
    }
    public static string[] carica_transazioni()
    {
        string[] transazioni_trovate = System.IO.Directory.GetFiles(percorso_database + @"Transaction\" + nome_cartella_transazioni);
        return transazioni_trovate;
    }

    public static string Balance()
    {
        double totale_Chia = 0;
        string[] elementi_passati = new string[conta_numero__transazioni()];
        elementi_passati = carica_transazioni();
        for (int x = 0; x < elementi_passati.Length; x++)
        {   //Assegna ad una "stringa" nodo il valore del file .xml
            XmlDocument Carica_Bilancio = new XmlDataDocument();
            Carica_Bilancio.Load(elementi_passati[x]);
            XmlNode nodeImporto_Accreditato_Xch = Carica_Bilancio.DocumentElement.SelectSingleNode("/Resoconto/Importo_Accreditato_Xch");

            // Fa la somma tra tutte le transazioni inviate e restituisce il totale di xch mandati
            double lettura_Transazione_Xch = 0;
            lettura_Transazione_Xch = Convert.ToDouble(nodeImporto_Accreditato_Xch.InnerText) * 10000;
            lettura_Transazione_Xch.ToString("0.000000000000");
            Console.WriteLine(lettura_Transazione_Xch);
            totale_Chia = totale_Chia + lettura_Transazione_Xch;
        }
        return (totale_Chia / 10000).ToString();
    }
    public static double capitale_Depositato() //Capitale totale depisitato da tutti gli utenti
    {
        double _investimento = 0;
        string[] elementi_passati = new string[conta_numero_elementi()];
        elementi_passati = carica_contenuto_elementi();
        for (int x = 0; x < elementi_passati.Length; x++)
        {
            //Assegna ad una "stringa" nodo il valore del file .xml
            XmlDocument DocumentoXml = new XmlDataDocument();
            DocumentoXml.Load(elementi_passati[x]);
            XmlNode nodeInvestimento = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Investimento");
            double lettura_Investimento = 0;
            lettura_Investimento = Convert.ToDouble(nodeInvestimento.InnerText);
            _investimento = _investimento + lettura_Investimento;
        }
        return _investimento;
    }
    public static double accredito() //Credito totale che il programma deve ancora pagare
    {
        double _credito = 0;
        string[] elementi_passati = new string[conta_numero_elementi()];
        elementi_passati = carica_contenuto_elementi();
        for (int x = 0; x < elementi_passati.Length; x++)
        {
            //Assegna ad una "stringa" nodo il valore del file .xml
            XmlDocument DocumentoXml = new XmlDataDocument();
            DocumentoXml.Load(elementi_passati[x]);
            XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito");
            double lettura_Credito = 0;
            lettura_Credito = Convert.ToDouble(nodeCredito.InnerText);
            _credito = _credito + lettura_Credito;
        }
        return _credito;
    }
    public static double rendimento(int id) //Calcola il rendimento giornaliero dell'utente
    {
        double rendimento_24h = 0;
        double lettura_Credito = 0;
        double lettura_Deposito = 0;
        double lettura_Credito_rimanente = 0;

        //Assegna ad una "stringa" nodo il valore del file .xml
        XmlDocument DocumentoXml = new XmlDataDocument();
        DocumentoXml.Load(Variabili.percorso_database + id + ".xml");
        XmlNode nodeDeposito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Investimento");
        XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito");
        XmlNode nodeCredito_rimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito_Rimanente");

        lettura_Deposito = Convert.ToDouble(nodeDeposito.InnerText);
        lettura_Credito = Convert.ToDouble(nodeCredito.InnerText);
        lettura_Credito_rimanente = Convert.ToDouble(nodeCredito_rimanente.InnerText);

        double bonus = lettura_Credito - lettura_Deposito; // Calcola il bonus applicato in €
        double _credito = lettura_Credito_rimanente - bonus;
        rendimento_24h = _credito * bonus_Rendita / 100 / 365; // calcolo daily reward 
        return rendimento_24h;
    }

    public static void prezzo_chia_API_EURO()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath, scriptPath);

        // Opzionale: specifica le opzioni di avvio del processo
        //startInfo.UseShellExecute = false;
        //startInfo.CreateNoWindow = true;

        // Crea e avvia il processo
        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();
    }
}