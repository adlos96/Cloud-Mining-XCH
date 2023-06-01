using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Form1 : Form
    {   // Email - Wallet
        #region
        string wallet_ricezione = "aa";
        string email_Invio = "aa";
        string email_ricezione = "aa";
        //Costanti Speciali
        const int Costante_Base_Prezzo = 200;     //Costante calcolo daily payment
        const int Costante_Base_Chia = 1;         //Costante calcolo chia amount
        const double Costante_Base = 0.10;        //Costante calcolo daily payment
        const double Costante_AutoUP_price = 2.11;
        const double Min_prezzo_chia = 20;
        //variabili
        double somma_investita = 1;         //Somma investita dalla persona
        double credito_cliente = 0.0;       //Credito cliente + bonus
        double daily_payment = 0;           //Pagamento giornaliero 0.10€
        int bonus = 0;                     //Bonus del 10% valori da 0-100
        double prezzo_chia_API = 0.00;
        #endregion
        private static void log(string sText)
        {
            Variabili.testo_log = sText; // permette il salvataggio di dati su una stringa, che poi verrà assegnata al .text della casella o chi per essa
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, new EventArgs());
            lbl_ID.Text = trackBar_ID.Value.ToString();
            text_log.Text = text_log.Text + Variabili.testo_log;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_timer.Text = (Variabili.attesa - Variabili.tempo_calcolato).ToString();
            //btn_Load_Payment.Enabled = true;
            //Versione e nomi Form
            this.Text = Variabili.nome_software;
            text_wallet_id.Text = Variabili.Wallet_ID.ToString();

            if (Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Salvato == true)
                Variabili.impostazioni_utente();

            Variabili.Controlla_percorso_database();        //Controlla e crea le cartelle se non esistono
            Variabili.file_indispensabili();                //

            // VISIVO - CAMBIA IL NUMERO MIN MAX VISUALIZZATI
            lbl_min_trackbar.Text = bonus_trackbar.Minimum.ToString();
            lbl_max_trackbar.Text = bonus_trackbar.Maximum.ToString();

            lbl_max_ID.Text = Variabili.conta_numero_elementi().ToString();
            int ID_Max = Variabili.conta_numero_elementi();
            lbl_min_ID.Text = (ID_Max - (ID_Max - 1)).ToString();
            lbl_ID.Text = lbl_min_ID.Text;

            trackBar_ID.Minimum = Convert.ToInt32(lbl_min_ID.Text);
            trackBar_ID.Maximum = Convert.ToInt32(lbl_max_ID.Text);

            //IMPOSTIAMO IL VALORE DELLA VARIABILE TANTUM A 0.00€
            Variabili.tantum = Convert.ToDouble(text_Tantum.Text);
            Variabili.prezzo_chia_API_EURO();

            lbl_ID.Text = trackBar_ID.Value.ToString();
            if (System.IO.File.Exists(Variabili.price_chiaPath) == true)
            {
                text_Prezzo_Chia.Text = File.ReadAllText(Variabili.price_chiaPath);
                prezzo_chia_API = Convert.ToDouble(text_Prezzo_Chia.Text);
            }
            else
            {
                log("File: Chia_value.txt | File non trovato | Programma arrestato!\r\n");
                Console.WriteLine(Variabili.price_chiaPath);
                return;
            }

            if (System.IO.File.Exists(Variabili.plotPath) == true)
            {
                string numero_plot_Load = File.ReadAllText(Variabili.plotPath);          //Legge il valore dei plot dal percorso nella casella
                text_Numero_Plot.Text = numero_plot_Load;
            }else
                log("File: plot_number_adly.txt | File non trovato\r\n");

            if (System.IO.Directory.Exists(Variabili.percorso_database + @"Transaction") == false) // Controlla e crea la cartella se non c'è
              System.IO.Directory.CreateDirectory(Variabili.percorso_database + @"Transaction");
            
            comboBox1.Items.Clear();
            //legge i nomi nella cartella \Transaction
            string[] nomi_cartelle_riepilogo = Directory.GetDirectories(Variabili.percorso_database + @"Transaction\");
            if (Variabili.conta_numero_elementi_transaction() > 0)
            {
                for (int x = 0; x < Variabili.conta_numero_elementi_transaction(); x++) // 
                {
                    string nomi_cartelle = nomi_cartelle_riepilogo[x];
                    string cartelle = Path.GetFileName(nomi_cartelle);
                    comboBox1.Items.Add(cartelle);
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
                Variabili.nome_cartella_transazioni = comboBox1.Text;
            }
            else
                MessageBox.Show("Database transazioni Vuoto - Effettua delle transazioni per vedere il database");

        }
        private void bonus_trackbar_Scroll(object sender, EventArgs e)
        {
            // ASSEGNA IL VALORE DELLA TRACKBAR AL LABEL ED ALLA VARIABILE BONUS
            lbl_Bonus_trackbar.Text = bonus_trackbar.Value.ToString();
            bonus = Convert.ToInt32(lbl_Bonus_trackbar.Text);
        }
        private void btn_Add_DB_Click(object sender, EventArgs e)
        {
            #region CREAZIONE db .xml - INSERIMENTO DATI
            #region Controllo se il campo è vuoto o errato
            //CONTROLLIAMO CHE I SEGUENTI PERCORSI E CAMPI NON SIANO VUOI...
            if (text_Investimento.Text.Length == 0)
            {
                MessageBox.Show("Non è possibile lasciare vuoto il campo Investimento");
                return;
            }              //Campo
            if (Convert.ToInt32(text_Investimento.Text) <= 0.99) //Controlla che il valore dell'investimento sia superiore a 20€
            {
                MessageBox.Show("Inserire un valore superiore a 20 Euro");
                return;
            }   //Controlla che il valore dell'investimento sia superiore a 20€
            if (text_Xch_Fee.Text.Length == 0)
            {
                MessageBox.Show("Non è possibile lasciare vuoto il campo Xch Fee");
                return;
            }                   //Campo
            if (text_Nome_Utente.Text.Length == 0)
            {
                MessageBox.Show("Non è possibile lasciare vuoto il campo Nome Utente");
                return;
            }               //Campo
            if (Variabili.price_chiaPath.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -Chia_value.txt- in Chia Price");
                return;
            }           //Percorso (path)
            if (Variabili.pythonPath.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -python3.10.exe- in Python.exe");
                return;
            }               //Percorso (path)
            if (Variabili.scriptPath.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -prezzo_chia.py- in .py Chia API");
                return;
            }             //Percorso (path)
            if (Variabili.cmdPath.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -Pagamento.cmd- in .Cmd Payment");
                return;
            }          //Percorso (path)
            if (Variabili.plotPath.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -plot_number_adly.txt- in Percorso Plot");
                return;

            }        //Percorso (path)
            #endregion

            //Calcolo Daily Payment e Credito Cliente
            somma_investita = Convert.ToDouble(text_Investimento.Text);
            daily_payment = Costante_Base * somma_investita / Costante_Base_Prezzo;       //Quantità pagata giornalmente
            text_Daily_Reward.Text = daily_payment.ToString();
            credito_cliente = somma_investita + (somma_investita * bonus / 100);    //Calcola il credito + il bonus
            text_Credito.Text = credito_cliente.ToString();

            //Ottenimento Email e Wallet
            Variabili.Wallet_ID = text_wallet_id.Text.ToString();
            wallet_ricezione = text_Address_Receiver.Text.ToString();
            email_Invio = text_Mail_Sender.Text.ToString();
            email_ricezione = text_Mail_Receiver.Text.ToString();

            Variabili.impostazioni_utente();
            Variabili.Controlla_percorso_database();                            //Controlla e crea le cartelle se non esistono

            //Prepara file Xml ed inserisci i dati
            XDocument documento_xml = new XDocument(new XElement("Cliente",
                new XElement("Utente", text_Nome_Utente.Text),
                new XElement("Investimento", text_Investimento.Text.Replace(".",",")),
                new XElement("Credito", credito_cliente.ToString("0.0000").Replace(".", ",")),
                new XElement("Credito_Rimanente", credito_cliente.ToString("0.0000").Replace(".", ",")),
                new XElement("Daily_Reward", daily_payment.ToString("0.0000").Replace(".", ",")),
                new XElement("Email", email_ricezione),
                new XElement("Indirizzo_Xch", wallet_ricezione),
                new XElement("Bonus", bonus),
                new XElement("Tantum", text_Tantum.Text.Replace(".", ",")),
                new XElement("Fee", text_Xch_Fee.Text),
                new XElement("BoolAPY", false)
                ));

            //Controlla ID
            int id_file = 1;
            while(System.IO.File.Exists(Variabili.percorso_database + id_file + ".xml") == true)
                id_file++; //Se già esiste incrementa di 1 e riprova
            
            documento_xml.Save(Variabili.percorso_database + id_file + ".xml"); //Crea - Salva file + path + nome + .xml
            #endregion
            //Ricalcola il valore del min-max ID dopo l'inserimento nel DB
            lbl_max_ID.Text = Variabili.conta_numero_elementi().ToString();
            int ID_Max = Variabili.conta_numero_elementi();
            lbl_min_ID.Text = (ID_Max - (ID_Max - 1)).ToString();
            trackBar_ID.Minimum = Convert.ToInt32(lbl_min_ID.Text);
            trackBar_ID.Maximum = Convert.ToInt32(lbl_max_ID.Text);

            MessageBox.Show("Eureka! Dati inseriti correttamente");
        }
        private void menu_Apri_DB_Click(object sender, EventArgs e)
        {
            // INIZIALIZZA ED APRE IL FORM DATABASE
            Database database = new Database();
            database.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {   // ASSEGNA IL VALORE DELLA TRACKBAR ID AL LABEL ID
            lbl_ID.Text = trackBar_ID.Value.ToString();
        }
        private async void btn_Load_Payment_Click(object sender, EventArgs e)
        {
            btn_Load_Payment.Enabled = false;
            //Assegnazione bool check box API - Pagamento
            int id = Convert.ToInt32(lbl_ID.Text);
            bool api = false;
            api = check_box_Chia_py.Checked;
            bool cmd = false;
            cmd = check_box_Cmd.Checked;
            Variabili.testo_log = "";
            text_log.Text = Variabili.testo_log;
            text_log.Text = text_log.Text + Variabili.testo_log;
            //Assegnazione valori path
            Variabili.prezzo_chia_API_EURO(); // API prezzo chia
            if (System.IO.File.Exists(Variabili.price_chiaPath) == true)
            {
                string Lettura_Chia = File.ReadAllText(Variabili.price_chiaPath).Replace(".", ",");
                text_Prezzo_Chia.Text = Lettura_Chia;
                prezzo_chia_API = Convert.ToDouble(Lettura_Chia); //usiamo variabile pubblica
            }
            else
                text_log.Text = text_log.Text + "File: Chia_value.txt | File non trovato\r\n";

            if (prezzo_chia_API < Min_prezzo_chia) //lettura variabile pubblica, qui sopra
            {
                MessageBox.Show("Prezzo Chia troppo basso... Programma Arrestato...");
                btn_Load_Payment.Enabled = true;
                return;
            }
            else
            {
                text_log.Text = text_log.Text + "Controllo percorsi...\r\n";
                Variabili.Controlla_percorso_database();
                text_log.Text = text_log.Text + "Istruzioni pagamento...\r\n";
                var Pagamento = Istruzioni(id, api, cmd, Costante_Base_Chia, Costante_AutoUP_price, Min_prezzo_chia); //Esegue l'istruzione - se presenti 3 task, vengono lanciati tuttu in parallelo
                await Pagamento; //Aspetta la sua conclusione del task
                text_log.Text = text_log.Text + "Pagamento ciclo completato...\r\n";
                btn_Load_Payment.Enabled = true;
            }
            if (Variabili.loop_pagamenti == false)
                Variabili.loop_pagamenti = true;

        }
        public static Task Istruzioni(int id, bool api, bool cmd, double Costante_Base_Chia, double Costante_AutoUP_price, double Min_prezzo_chia) // IStanza la quale esegue loop pagamento + salvataggio dati xml
        {
            return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {   
                log("Inizializzazione pagamenti...\r\n");
                if (Variabili.conta_numero_elementi() == 0) // controlla in numero di utenti nel db - se 0 mostra messaggio
                    MessageBox.Show("Database vuoto... Pagamenti annullati... Prego inserire un utente nel database");
                    int numero_clienti = Variabili.conta_numero_elementi();
                while (Variabili.loop_pagamenti == true)
                {
                    int crediti_esauriti = 0;
                    #region - IL QUORE DEL PAGAMENTO -
                    for (int a = 0; a < numero_clienti; a++)
                    {
                        log("ID: " + id + "\r\n");
                        log("Contatore: " + crediti_esauriti + "\r\n");
                        Variabili.prezzo_chia_API_EURO();
                        string Lettura_Chia = File.ReadAllText(Variabili.price_chiaPath).Replace(".", ",");
                        double lettura_prezzo = Convert.ToDouble(Lettura_Chia);
                        Thread.Sleep(1300); // 0.3 secondi
                        Variabili.tempo_calcolato = Variabili.tempo_calcolato + 1300;
                        if (lettura_prezzo < Min_prezzo_chia) // se il prezzo è inferiore, ferma i pagamenti
                        {
                            log("Prezzo Chia < 20 ...Pagamenti interrotti..." + "id: " + id + "\r\n");
                            MessageBox.Show("Prezzo Chia troppo basso... Pagamenti interrotti... " + "id: " + id + "");
                            return;
                        }else
                         {
                            XmlDocument Credito_rimasto = new XmlDocument();
                            Credito_rimasto.Load(Variabili.percorso_database + id + ".xml");
                            XmlNode nodeCredito_rimanente_verifica = Credito_rimasto.DocumentElement.SelectSingleNode("/Cliente/Credito_Rimanente");
                            XmlNode nodeDaily_Reward_temp = Credito_rimasto.DocumentElement.SelectSingleNode("/Cliente/Daily_Reward");
                            double credito_verifica = Convert.ToDouble(nodeCredito_rimanente_verifica.InnerText);
                            double verifica_pagamento = Convert.ToDouble(nodeDaily_Reward_temp.InnerText);

                            if (credito_verifica < verifica_pagamento) //se il credito è minore, errore e cambio id
                            {
                                log("Cliente : " + id + " Credito cliente insufficiente\r\n"); // Ex MessageBox.Show()
                                id = id + 1;
                                crediti_esauriti++;
                            }else
                             {
                                //Inizio ciclo for
                                //for (double i = 0; i < credito_cliente - 0.001;)
                                for (int i = 0; i < 1; i++)
                                {
                                    #region Load .xml ed assenazione su variabili
                                    XmlDocument DocumentoXml = new XmlDataDocument();
                                    DocumentoXml.Load(Variabili.percorso_database + id + ".xml");
                                    XmlNode nodeUtente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Utente");
                                    XmlNode nodeInvestimento = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Investimento");
                                    XmlNode nodeCredito_cliente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito");
                                    XmlNode nodeCredito_rimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito_Rimanente");
                                    XmlNode nodeDaily_Reward = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Daily_Reward");
                                    XmlNode nodeEmail_Cliente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Email");
                                    XmlNode nodeWallet_Xch = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Indirizzo_Xch");
                                    XmlNode nodeBonus = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Bonus");
                                    XmlNode nodeTantum = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Tantum");
                                    XmlNode nodeFee = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Fee");
                                    XmlNode nodeBoolAPY = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/BoolAPY");

                                    //Assegnazione da nodo a variabile
                                    string utente = nodeUtente.InnerText;
                                    double investimento = Convert.ToDouble(nodeInvestimento.InnerText.Replace(".", ","));
                                    double credito_cliente = Convert.ToDouble(nodeCredito_cliente.InnerText.Replace(".", ","));
                                    double credito_rimanente = Convert.ToDouble(nodeCredito_rimanente.InnerText.Replace(".", ","));
                                    double daily_reward = Convert.ToDouble(nodeDaily_Reward.InnerText.Replace(".", ","));
                                    string email = nodeEmail_Cliente.InnerText;
                                    string wallet = nodeWallet_Xch.InnerText;
                                    int bonus = Convert.ToInt32(nodeBonus.InnerText.Replace(".", ","));
                                    double tantum = Convert.ToDouble(nodeTantum.InnerText);
                                    string fee = nodeFee.InnerText.Replace(".", ",");
                                    bool _BoolAPY = Convert.ToBoolean(nodeBoolAPY.InnerText);

                                    Variabili.messaggio_server = utente + " | " + investimento + " | " + Variabili.Balance(); // test per leggere il nome utente e mandarlo al serever --> client

                                    double prezzo_Chia = 00.00;
                                    double chia_pay = 0.000000000000;
                                    bool eccezione = false;
                                    #endregion
                                    //Eseguire API prezzo chia -- Controlla se check Box è spuntata.
                                    if (api == false)
                                    {
                                        MessageBox.Show("API DIsattivato");
                                        Console.WriteLine("Ciclo interrotto...\r\n Nessun cambiamento nel database...\r\n");
                                        return;
                                    }else
                                     {
                                        log("Richiesta prezzo chia...\r\n");
                                        Variabili.prezzo_chia_API_EURO(); // API prezzo chia
                                        string Lettura_prezzo_Chia = File.ReadAllText(Variabili.price_chiaPath);
                                        prezzo_Chia = Convert.ToDouble(Lettura_prezzo_Chia.Replace(".", ","));
                                        if ((credito_rimanente / daily_reward) <= Costante_AutoUP_price)
                                        {   // se il credito è inferiore al rappporto, l'importo da pagare è pari al credito
                                            Variabili.reward_originale = daily_reward;
                                            daily_reward = credito_rimanente;
                                            chia_pay = (Costante_Base_Chia * daily_reward) / prezzo_Chia; // XCH
                                            eccezione = true;
                                            log("Credito inferiore al rapporto...\r\n il pagamento è stato incrementato...\r\n");
                                        }else
                                        {
                                            Variabili.reward_originale = daily_reward;
                                            //Calcolo quantità di xch da inviare...
                                            chia_pay = (Costante_Base_Chia * (daily_reward + tantum)) / prezzo_Chia; //Calcolo quantità di xch da inviare...
                                        }

                                    } //Richiamo API prezzo chia
                                    double credito_rimanente_temp;
                                    log("xch " + chia_pay + "\r\n");
                                    double importo_Pagato = 0;
                                    if (eccezione == true)
                                        credito_rimanente_temp = credito_rimanente - daily_reward;
                                    else
                                        credito_rimanente_temp = credito_rimanente - (daily_reward + tantum);
                                    importo_Pagato = importo_Pagato + daily_reward + tantum; //Importo Pagato €

                                    #region Creazione file per il .cmd
                                    //Creare i file relativi al pagamento .cmd ed email
                                    File.WriteAllText(Variabili.percorso_cmd + @"utente.txt", utente.ToString());
                                    File.WriteAllText(Variabili.percorso_cmd + @"Importo_Pagato.txt", importo_Pagato.ToString("0.0000").Replace(",", "."));// forse possibile eliminare, usando solamente credito_cliente - idem sopra
                                    File.WriteAllText(Variabili.percorso_cmd + @"Credito_Cliente.txt", credito_cliente.ToString("0.0000").Replace(",", "."));
                                    File.WriteAllText(Variabili.percorso_cmd + @"Credito_Cliente_Rimanente.txt", credito_rimanente_temp.ToString("0.0000").Replace(",", "."));
                                    File.WriteAllText(Variabili.percorso_cmd + @"daily_payment.txt", chia_pay.ToString().Replace(",", "."));
                                    File.WriteAllText(Variabili.percorso_cmd + @"email_invio.txt", Variabili.Email_invio.ToString());
                                    File.WriteAllText(Variabili.percorso_cmd + @"email_ricezione.txt", email);
                                    File.WriteAllText(Variabili.percorso_cmd + @"wallet_Invio.txt", Variabili.Wallet_ID.ToString());
                                    File.WriteAllText(Variabili.percorso_cmd + @"wallet_ricezione.txt", wallet.ToString());
                                    File.WriteAllText(Variabili.percorso_cmd + @"chia_fee.txt", fee.Replace(",", "."));

                                    File.WriteAllText(Variabili.percorso_cmd_path + @"cmd_path.txt", Variabili.percorso_cmd);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"log_path.txt", Variabili.percorso_log_path);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"email_path.txt", Variabili.percorso_email_path);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"email_code.txt", Variabili.Email_code);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"main_cmd.txt", Variabili.percorso_cmd_path);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"path_cmd_custom.txt", Variabili.percorso_programma);

                                    //Crea i file per i dati notifica email...
                                    #endregion
                                    //pagamento .cmd
                                    if (cmd == false)
                                        MessageBox.Show("Pagamento .cmd disattivato");
                                    else
                                    {
                                        log("Pagemnto in corso...\r\n");
                                        // Crea un nuovo processo
                                        var processStartInfo = new ProcessStartInfo(Variabili.cmdPath);
                                        // Esegui il processo
                                        using (var process2 = Process.Start(processStartInfo))
                                            process2.WaitForExit(); // Attendi che il processo termini
                                    } //Pagamento .cmd

                                    log("Utente: " + nodeUtente.InnerText + "\r\n"); // Prende il contenuto del nodo Utente salvata in variabile...
                                    log("Credito_Cliente: " + nodeCredito_rimanente.InnerText + "\r\n");
                                    log("Daily_Reward: " + nodeDaily_Reward.InnerText + "\r\n");
                                    log("Fee: " + nodeFee.InnerText + "\r\n");

                                    // Utilizzo pratico dello stato della transazione (SUCCESS)
                                    // Ottenimento - Conferma transazione - Transaction ID
                                    if (System.IO.File.Exists(Variabili.percorso_api + "payment.log") == true) // Controlla che il file esista prima della tentata lettura
                                    using (StreamReader lettura_file_payment = new StreamReader(Variabili.percorso_api + "payment.log"))
                                    {
                                        string transazione = lettura_file_payment.ReadToEnd();    // Leggi il contenuto del file
                                        Variabili.conferma_transazione_string = transazione.Substring(161, 7);  // Estrai avvenuta transazione [SUCCESS]
                                        Variabili.transaction_id = transazione.Substring(241, 66);  // Estrai transaction id [-tx 0x42f917d...]

                                        // Visualizza la parte estratta dal file
                                        log("Stato transazione: " + Variabili.conferma_transazione_string + "\r\n");
                                        log("transaction ID : " + "-tx: " + Variabili.transaction_id + "\r\n");
                                    }
                                    else
                                    {
                                        MessageBox.Show("File payment.log non trovato... programma arrestato...\r\n");
                                        return;
                                    }
                                    if (Variabili.conferma_transazione_string == "SUCCESS") // Controllo stato transazione
                                    {
                                        // Rendimento
                                        double rendimento = 0.0;
                                        // REGIONE RENDIMENTO GIORNALIERO
                                        if (Variabili.capitale_Depositato() >= Variabili.reward) // Limite abilitazione 25'000
                                            if (investimento >= Variabili.min_Deposit) //Somma depositata 1'250
                                                rendimento = Variabili.rendimento(id);
                                            else
                                                log("Rendimenti non attivi, capitale inferiore a 25'000€\r\n");
                                        if (_BoolAPY == true)
                                            rendimento = Variabili.rendimento(id);

                                        credito_rimanente_temp = credito_rimanente_temp + rendimento; // se la condizione è falsa aggiunge 0€ al credito

                                        #region Salvataggio dati in file .xml
                                        XDocument Salvataggio_Xml = new XDocument(new XElement("Cliente",
                                        new XElement("Utente", utente),
                                        new XElement("Investimento", investimento.ToString("0.0000")),
                                        new XElement("Credito", credito_cliente.ToString("0.0000")),
                                        new XElement("Credito_Rimanente", credito_rimanente_temp.ToString("0.0000")),
                                        new XElement("Daily_Reward", Variabili.reward_originale.ToString("0.0000")),
                                        new XElement("Email", email),
                                        new XElement("Indirizzo_Xch", wallet),
                                        new XElement("Bonus", bonus),
                                        new XElement("Tantum", tantum.ToString("0.0000")),
                                        new XElement("Fee", fee),
                                        new XElement("BoolAPY", _BoolAPY)
                                        ));
                                        Salvataggio_Xml.Save(Variabili.percorso_database + id + ".xml"); //Crea - Salva file | Database _path
                                        #endregion

                                        int id_resoconto_xml = 1;
                                        #region Creazione file .xml o .json per visuale (database / client / resoconto)
                                        //qui crea cartella transaction se non esiste
                                        if (System.IO.Directory.Exists(Variabili.percorso_database + @"Transaction") == false)
                                            System.IO.Directory.CreateDirectory(Variabili.percorso_database + @"Transaction");

                                        //creare cartella con nome utente
                                        if (System.IO.Directory.Exists(Variabili.percorso_database + @"Transaction\" + id + "_" + utente) == false)
                                            System.IO.Directory.CreateDirectory(Variabili.percorso_database + @"Transaction\" + id + "_" + utente);
                                        string data_Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                        //creare file per resoconto transazione
                                        XDocument Resoconto_transazione_xml = new XDocument(new XElement("Resoconto",
                                          new XElement("ID", id),
                                          new XElement("Nome_Utente", utente),
                                          new XElement("Wallet", wallet),
                                          new XElement("Transaction_id", Variabili.transaction_id),
                                          new XElement("Credito", credito_cliente.ToString("0.0000")), // Investimento + bonus = credito cliente
                                          new XElement("Deposito", investimento.ToString("0.0000")),
                                          new XElement("Importo_Accreditato_Xch", chia_pay.ToString("0.000000000000")), // XCH
                                          new XElement("Importo_Accreditato_euro", daily_reward.ToString("0.0000")), // EURO
                                          new XElement("Rimanente", credito_rimanente_temp.ToString("0.0000")), // credito rimanente
                                          new XElement("Prezzo_Chia", Lettura_Chia), // Prezzo chia,
                                          new XElement("Rendimento", rendimento.ToString("0.0000")),// Rendimento 24h (up 25'000€)
                                          new XElement("Data_Transazione", data_Time) // Data 
                                          ));
                                        while (System.IO.File.Exists(Variabili.percorso_database + @"Transaction\" + id + "_" + utente + @"\" + id_resoconto_xml + ".xml") == true)
                                            id_resoconto_xml++; //Se già esiste incrementa di 1 e riprova
                                        Resoconto_transazione_xml.Save(Variabili.percorso_database + @"Transaction\" + id + "_" + utente + @"\" + id_resoconto_xml + ".xml"); //Crea - Salva file | Transaction _path

                                        rendimento = 0.0;
                                        #endregion

                                        log("Pagamento: " + id + "\r\n");
                                        Thread.Sleep(2000); // 1S
                                        Variabili.tempo_calcolato = Variabili.tempo_calcolato + 2000;
                                        id++;
                                    }else
                                        MessageBox.Show("Stato transazione: " + Variabili.conferma_transazione_string + " \r\n...Programma interrotto... Controllare stato transazione blockchain...");
                                } 
                            }
                        }
                        #endregion
                    }//Fine ciclo pagamenti utenti ... attendere 24h dopo i controlli sotto
                    Console.WriteLine(crediti_esauriti);
                    Console.WriteLine(Variabili.conta_numero_elementi());

                    if (Variabili.conta_numero_elementi() != 0) // Se il db ha contatti allora riparte il ciclo
                    {
                        id = (Variabili.conta_numero_elementi() - (Variabili.conta_numero_elementi() - 1)); // Impostiamo l'id ad 1 e dorebbe ripartire il ciclo
                        Variabili.loop_pagamenti = true;
                    }
                    if(crediti_esauriti == Variabili.conta_numero_elementi())
                    //if (contatore == 2)
                    {
                        Variabili.loop_pagamenti = false;
                        crediti_esauriti = 0;
                        MessageBox.Show("Tutti gli utenti hanno esaurito il credito");
                        Console.WriteLine(crediti_esauriti);
                        Console.WriteLine(Variabili.conta_numero_elementi());
                        return; // se il bd è vuoto, ferma il programma
                    }
                    //Attendere 24h
                    log("Tempo: " + Variabili.tempo_calcolato + "\r\n");
                    log("Attesa: " + (Variabili.attesa - (Variabili.tempo_calcolato + (200 * Variabili.conta_numero_elementi()))) + "\r\n"); // 200 millisecondi per eseguire i pagamenti
                    Thread.Sleep(Variabili.attesa - Variabili.tempo_calcolato); //  <--- STRINGA CORRETTA
                }
                log("Ciclo clienti completati...\r\n");
            });
        }
        private void collegamentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impostazioni impostazioni = new Impostazioni();
            impostazioni.ShowDialog();
        }
        private void connettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
            ServerSocket server = new ServerSocket();
            server.Show();
        }
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tutorial tutorial = new Tutorial();
            tutorial.Show();
        }
        private void transazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variabili.nome_cartella_transazioni = comboBox1.Text;
            Transazioni transazioni = new Transazioni();
            transazioni.Show();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            text_log.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 1;
            string utente = "Pallino";
            Console.WriteLine(Variabili.rendimento(1).ToString("0.0000"));
            Console.WriteLine(Variabili.Balance());
        }
    }
}