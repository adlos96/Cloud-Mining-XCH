using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;

public static class Variabili
{
    public static bool loop_pagamenti = true;
    public static bool impostazioni_stato_salvataggio = false;
    public static bool conferma_transazione_bool = false;

    public static string conferma_transazione_string = "";
    public static string seconda_conferma_transazione = "";
    public static string pending_Transaction = "Pending";
    public static string transaction_id = "";
    public static string block_Confirmed = "";
    public static string txn_Hash = "";

    public static int id = 1; //Temporaneo solo per test, per salvare tanti file 1_ciao 2_ciao 3_ciao etc...

    public static double swap_chia_eur = 0;
    public static double swap_chia_usdt = 0;

    //public const int attesa = 1000 * 24 * 60 * 60; //Tempo da attendere prima del pagamento (24h)
    public const int attesa = 1000 * 24 * 60 * 60; //Tempo da attendere prima del pagamento (24h)
    public static int tempo_calcolato = 0;          //Tempo perso
    public static double tantum = 0.00;

    public const double slippage = 0.5; //Dichiarata ma non ancora implementata nel codice (Valore di cambio per effettuare uno swap)
    public const double bonus_Rendita = 1.75;
    public const double bonus_Rendita_Plus = 2.75;
    public const double bonus_Referal = 12.5;
    public const int reward = 24999;       //Raggiunta tale soglia viene abilitato il sistema di rendimento annuale
    public static int min_Deposit = 1249;  //Deposito minimo per applicare il calcolo del rendimento
    public static string testo_log;
    public static double reward_originale = 0.0000;

    public static string messaggio_server = "Vuoto"; // Test con server per manadare il nome utente al client


    //Richiamabile ovunque, scrivendo Variabili.percorso_database = "ciao"
    public static string percorso_appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); //AppData      | C:\Users\...\AppData
    public static string percorso_profilo_utente = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);   //Google Drive | C:\Users\...\Documents
    public static string percorso_programma = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);        //Documenti    | C:\Users\...\Documents


    public static string percorso_database = percorso_programma  + @"\Chia_AutoPayment\Database\";
    public static string percorso_api = percorso_programma + @"\Chia_AutoPayment\API\";
    public static string percorso_cmd = percorso_programma + @"\Chia_AutoPayment\Cmd\";
    public static string dati_client = percorso_programma + @"\Chia_AutoPayment\Client\";
    public static string percorso_cmd_path = percorso_programma + @"\Chia_AutoPayment\Cmd_path\";
    public static string percorso_log_path = percorso_programma + @"\Chia_AutoPayment\Log\";
    public static string percorso_email_path = percorso_programma + @"\Chia_AutoPayment\Email\";

    public static string nome_cartella_transazioni = "";

    public static string pythonPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Pyton_exe;          // percorso del file python.exe
    public static string API_XCH_EURO = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api + @"\prezzo_XCH_EURO.py";     // percorso del file Python da eseguire
    public static string API_EURO_USDT = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api + @"\prezzo_EURO_USDT.py";     // percorso del file Python da eseguire
    public static string price_Swap_XCH_EURO = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt; //Percorso | Swap XCH/EURO
    public static string price_Swap_EURO_USDT = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt; //Percorso | Swap EURO/USDT
    public static string cmdPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cmd;
    public static string plotPath = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Plot_Path;

    public static string Wallet_ID = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Wallet;
    public static string Email_invio = "thechannelofadlos@gmail.com";
    public static string Email_code = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Mail_code;
    public static string versione_software = "1.2.22";
    public static string Versione_client = "0.00.24";
    public static string Versione_server = "0.01.13";
    public static string nome_software = "Chia Cloud Mining " + versione_software;

    public static void impostazioni_utente() // imposta i percorsi specificati dall'utente
    {
        if (impostazioni_stato_salvataggio == true) // Reset impostazioni mettendo su false .... Impostazioni e percorsi da rivedere totalmente!!
        {
            percorso_programma = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Chia_AutoPayment\";
            percorso_database = percorso_programma + @"Database\";
            percorso_api = percorso_programma + @"API\";
            percorso_cmd = percorso_programma + @"Cmd\";
            dati_client = percorso_programma + @"Client\";
            percorso_cmd_path = percorso_programma + @"Cmd_path\";
            percorso_log_path = percorso_programma + @"Log\";
            percorso_email_path = percorso_programma + @"Email\";
            pythonPath = percorso_appdata + @"\Programs\Python\Python39\python.exe";
            API_XCH_EURO = percorso_api + "prezzo_XCH_EURO.py";
            API_EURO_USDT = percorso_api + "prezzo_EURO_USDT.py";
            price_Swap_XCH_EURO = percorso_api + "price_Swap_XCH_EURO.txt";
            price_Swap_EURO_USDT = percorso_api + "price_Swap_EURO_USDT.txt";
        }
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
            API_XCH_EURO = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api + @"\prezzo_XCH_EURO.py";     // percorso del file .py da eseguire
            API_EURO_USDT = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api + @"\prezzo_EURO_USDT.py";     // percorso del file .py da eseguire
            price_Swap_XCH_EURO = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt + @"\price_Swap_XCH_EURO.txt"; //Percorso del file prezzo XCH_EURO
            price_Swap_EURO_USDT = Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt + @"\price_Swap_EURO_USDT.txt"; //Percorso del file prezzo EURO_USDT

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
            System.IO.Directory.CreateDirectory(percorso_database);
        
        if (System.IO.Directory.Exists(percorso_api) == false)
            System.IO.Directory.CreateDirectory(percorso_api);

        if (System.IO.Directory.Exists(percorso_cmd) == false)
            System.IO.Directory.CreateDirectory(percorso_cmd);

        if (System.IO.Directory.Exists(dati_client) == false)
            System.IO.Directory.CreateDirectory(dati_client);

        if (System.IO.Directory.Exists(percorso_cmd_path) == false)
            System.IO.Directory.CreateDirectory(percorso_cmd_path);

        if (System.IO.Directory.Exists(percorso_log_path) == false)
            System.IO.Directory.CreateDirectory(percorso_log_path);

        if (System.IO.Directory.Exists(percorso_email_path) == false)
            System.IO.Directory.CreateDirectory(percorso_email_path);

        if (System.IO.Directory.Exists(percorso_log_path + @"\Crash") == false)
            System.IO.Directory.CreateDirectory(percorso_log_path + @"\Crash");
    }//Se non c'è la crea ... (percorso_database) - (percorso_api) - (percorso_cmd) - (dati_client) - (percorso_cmd_path)

    public static void file_indispensabili() //Copia i due file per avviare i pagamenti
    {
        string source_file = percorso_profilo_utente + @"\OneDrive\Adly\Importante\Crypto\AutoPayments\";

        if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Pagamento.cmd") == false)
            File.Copy(source_file + @"Pagamento.cmd", percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Pagamento.cmd");
        if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Unconfirmed_Transaction.cmd") == false)
            File.Copy(source_file + @"Unconfirmed_Transaction.cmd", percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Unconfirmed_Transaction.cmd");
        if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\txn_hash.py") == false)
            File.Copy(source_file + @"txn_hash.py", percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\txn_hash.py");

        if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Tx_Confirmed.cmd") == false)
            File.Copy(source_file + @"Tx_Confirmed.cmd", percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Tx_Confirmed.cmd");

        if (File.Exists(percorso_api + @"prezzo_XCH_EURO.py") == false)
            File.Copy(source_file + @"prezzo_XCH_EURO.py", percorso_api + @"prezzo_XCH_EURO.py");
        if (File.Exists(percorso_api + @"prezzo_EURO_USDT.py") == false)
            File.Copy(source_file + @"prezzo_EURO_USDT.py", percorso_api + @"prezzo_EURO_USDT.py");
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

    public static int test_mempool(string cartella)
    {
        return System.IO.Directory.GetFiles(percorso_database + @"Transaction\" + cartella + @"\").Length;
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
        DocumentoXml.Load(percorso_database + id + ".xml");
        XmlNode nodeDeposito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Investimento");
        XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito");
        XmlNode nodeCredito_rimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito_Rimanente");

        lettura_Deposito = Convert.ToDouble(nodeDeposito.InnerText);
        lettura_Credito = Convert.ToDouble(nodeCredito.InnerText);
        lettura_Credito_rimanente = Convert.ToDouble(nodeCredito_rimanente.InnerText);

        double bonus = lettura_Credito - lettura_Deposito; // Calcola il bonus applicato in €
        double _credito = lettura_Credito_rimanente - bonus;

        if (_credito > 1249)
            rendimento_24h = _credito * (bonus_Rendita_Plus - slippage) / 100 / 365;
        else
        rendimento_24h = _credito * (bonus_Rendita_Plus - slippage) / 100 / 365; // calcolo daily reward 
        return rendimento_24h;
    }

    public static void passaggio_FileXML_Server() //Da implementare
    {
        // Funzione di trasmissione dei file .xml dalla cartella transaction

    }

    public static async void swap_Chia_EURO_API()
    {
        if (pythonPath == "")
        {
            Console.WriteLine("Percorso vuoto python");
        }
        else
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath, API_XCH_EURO);

            // Opzionale: specifica le opzioni di avvio del processo
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            // Crea e avvia il processo
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            Console.WriteLine("swap_Chia_EURO_API");
            var API = chia_eur();
            await API;
        }
    }

    static async Task chia_eur()
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
                swap_chia_eur = Convert.ToDouble(price);
                File.WriteAllText(percorso_api + @"price_Swap_XCH_EURO.txt", swap_chia_eur.ToString("0.00").Replace(",", "."));

                // Stampa il prezzo
                Console.WriteLine($"Il prezzo di {coinId.ToUpper()} è {price} {vsCurrency.ToUpper()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante la richiesta dell'API: " + ex.Message);
            }
        }
    }
    static async Task chia_usd()
    {
        // Imposta la coppia di criptovalute desiderata
        string coinId = "chia";
        string vsCurrency = "usd";

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
                swap_chia_eur = Convert.ToInt32(price);

                // Stampa il prezzo
                Console.WriteLine($"Il prezzo di {coinId.ToUpper()} è {price} {vsCurrency.ToUpper()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante la richiesta dell'API: " + ex.Message);
            }
        }
    }
    public static void swap_EURO_USDT_API()
    {
        if (pythonPath == "")
        {
            Console.WriteLine("Percorso vuoto python");
        }
        else
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath, API_EURO_USDT);

            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            Console.WriteLine("swap_EURO_USDT_API");
        }
    }
    public static void Tx_log()
    {
        if (File.Exists(percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Tx_Confirmed.cmd") == true)
        {
            Console.WriteLine("Creazione file Transazione.log...\r\n");
            // Crea un nuovo processo
            var processStartInfo = new ProcessStartInfo(Variabili.percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Tx_Confirmed.cmd");
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

    public static void delete_unconfirmed_transactions()
    {
        Console.WriteLine("delete_unconfirmed_transactions...\r\n");
        // Crea un nuovo processo
        var processStartInfo = new ProcessStartInfo(Variabili.percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\Unconfirmed_Transaction.cmd");
        // Esegui il processo
        using (var process1 = Process.Start(processStartInfo))
        {
            Console.WriteLine(process1);
            process1.WaitForExit(); // Attendi che il processo termini
        }
    }



}