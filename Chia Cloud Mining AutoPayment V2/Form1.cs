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
            int ID_Max = Convert.ToInt32(lbl_max_ID.Text);
            lbl_min_ID.Text = (ID_Max - (ID_Max - 1)).ToString();
            lbl_ID.Text = lbl_min_ID.Text;

            trackBar_ID.Minimum = Convert.ToInt32(lbl_min_ID.Text);
            trackBar_ID.Maximum = Convert.ToInt32(lbl_max_ID.Text);

            //IMPOSTIAMO IL VALORE DELLA VARIABILE TANTUM A 0.00€
            Variabili.tantum = Convert.ToDouble(text_Tantum.Text);
            Variabili.swap_Chia_EURO_API();

            lbl_ID.Text = trackBar_ID.Value.ToString();
            if (System.IO.File.Exists(Variabili.price_Swap_XCH_EURO) == true)
            {
                text_Prezzo_Chia.Text = File.ReadAllText(Variabili.price_Swap_XCH_EURO);
                prezzo_chia_API = Convert.ToDouble(text_Prezzo_Chia.Text);
                prezzo_chia_API = prezzo_chia_API + (prezzo_chia_API * Variabili.slippage / 100); //Applichiamo Slippage
            }
            else
            {
                log("File: price_Swap_XCH_EURO.txt | File non trovato | Programma arrestato!\r\n");
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
                for (int x = 0; x < Variabili.conta_numero_elementi_transaction(); x++) //Legge tutte le cartelle
                {
                    string nomi_cartelle = nomi_cartelle_riepilogo[x];
                    string cartelle = Path.GetFileName(nomi_cartelle);
                    bool test = cartelle.Contains("Variabile indirizzo XCH"); //Dovrebbe controllare se, nel nome della cartella, è presente la stringa / variabile (Funzionante)
                    Console.WriteLine("BOOOH: " + test);
                    comboBox1.Items.Add(cartelle); // Assegna il nome delle cartelle alla combobox
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
            bool rendimento = false;
            #region CREAZIONE db .xml - INSERIMENTO DATI
            #region Controllo se il campo è vuoto o errato
            //CONTROLLIAMO CHE I SEGUENTI PERCORSI E CAMPI NON SIANO VUOI...
            //text_Prezzo_Chia
            if (text_Prezzo_Chia.Text.Length == 0)
            {
                MessageBox.Show("Il prezzo di chia non può essere vuoto");
                return;
            }
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
            if (Variabili.price_Swap_XCH_EURO.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -price_Swap_XCH_EURO.txt- in Chia Price");
                return;
            }           //Percorso (path)
            if (Variabili.pythonPath.Length == 0)
            {
                MessageBox.Show("Inserire il percorso file -python3.10.exe- in Python.exe");
                return;
            }               //Percorso (path)
            if (Variabili.API_XCH_EURO.Length == 0)
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

            Variabili.Controlla_percorso_database();                            //Controlla e crea le cartelle se non esistono
            rendimento = CB_Rendimento.Checked;
            #region Aggiunta credito REFERAL
            double credito = 0;
            double credito_rimasto = 0;
            //Controllo referal
            if (Variabili.conta_numero_elementi() > 0)
            {
                int x = 1;
                for (int i = 1; i <= Variabili.conta_numero_elementi(); i++)
                {
                    //Caricamento dati 
                    XmlDocument DocumentoXml = new XmlDataDocument();
                    DocumentoXml.Load(Variabili.percorso_database + x + ".xml");
                    XmlNode nodeUtente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Utente");
                    XmlNode nodeInvestimento = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Investimento");
                    XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito");
                    XmlNode nodeCredito_Rimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito_Rimanente");
                    XmlNode nodeDaily_Reward = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Daily_Reward");
                    XmlNode nodeEmail = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Email");
                    XmlNode nodeIndirizzo_Xch = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Indirizzo_Xch");
                    XmlNode nodeBonus = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Bonus");
                    XmlNode nodeTantum = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Tantum");
                    XmlNode nodeReferal = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Referal");
                    XmlNode nodeRef_Invite = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Ref_Invite");
                    XmlNode nodeFee = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Fee");
                    XmlNode nodeBoolAPY = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/BoolAPY");

                    if (text_Referal.Text != "")
                        if (nodeReferal.InnerText == text_Referal.Text)
                        {
                            credito = Convert.ToDouble(nodeCredito.InnerText) + (Convert.ToDouble(text_Investimento.Text) * Variabili.bonus_Referal / 100); //Calcolo bonus da aggiungere
                            credito_rimasto = Convert.ToDouble(nodeCredito_Rimanente.InnerText) + (credito_rimasto * Variabili.bonus_Referal / 100); //Calcolo bonus da aggiungere
                            Console.WriteLine("Credito: " + credito);
                            Console.WriteLine("Credito Rimasto: " + credito_rimasto);
                            log("Referal trovato, aggiunti: " + nodeCredito.InnerText + " al cliente: " + "cliente");
                        
                            XDocument save_Data = new XDocument(new XElement("Cliente",
                            new XElement("Utente", nodeUtente.InnerText),
                            new XElement("Investimento", nodeInvestimento.InnerText),
                            new XElement("Credito", credito.ToString("0.0000").Replace(".", ",")),
                            new XElement("Credito_Rimanente", credito_rimasto.ToString("0.0000").Replace(".", ",")),
                            new XElement("Daily_Reward", nodeDaily_Reward.InnerText),
                            new XElement("Email", nodeEmail.InnerText),
                            new XElement("Indirizzo_Xch", nodeIndirizzo_Xch.InnerText),
                            new XElement("Bonus", nodeBonus.InnerText),
                            new XElement("Tantum", nodeTantum.InnerText),
                            new XElement("Referal", nodeReferal.InnerText),
                            new XElement("Ref_Invite", nodeRef_Invite.InnerText),
                            new XElement("Fee", nodeFee.InnerText),
                            new XElement("BoolAPY", nodeBoolAPY.InnerText)
                            ));
                            save_Data.Save(Variabili.percorso_database + x + ".xml"); //Crea - Salva file + path + nome + .xml

                            #region Creazione trasazione Referal
                            //Creamo anche un file transazione per mostrare l'avvenuta inclusione del referal al credito dell'utente
                            Variabili.nome_cartella_transazioni = x + "_" + nodeUtente.InnerText;
                            int transazione = Variabili.conta_numero__transazioni() + 1;
                            string data_Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                            XDocument Resoconto_transazione_xml = new XDocument(new XElement("Resoconto",
                                        new XElement("ID", transazione),
                                        new XElement("Nome_Utente", nodeUtente.InnerText),
                                        new XElement("Wallet", "Referal"),
                                        new XElement("Transaction_id", "Aggiunto"),
                                        new XElement("Transaction_hash", (Convert.ToDouble(text_Investimento.Text) * Variabili.bonus_Referal / 100)),
                                        new XElement("Credito", "None"), // Investimento + bonus = credito cliente
                                        new XElement("Deposito", Convert.ToDouble(text_Investimento.Text)),
                                        new XElement("Importo_Accreditato_Xch", "None"), // XCH
                                        new XElement("Importo_Accreditato_euro", "None"), // EURO
                                        new XElement("Rimanente", "None"), // credito rimanente
                                        new XElement("Prezzo_Chia", "None"), // Prezzo chia,
                                        new XElement("Rendimento", "None"),// Rendimento 24h (up 25'000€)
                                        new XElement("Stato_Transazione", "Confirmed"),// stato transazione
                                        new XElement("Block_Number", "None"),// numero blocco
                                        new XElement("Data_Transazione", data_Time) // Data
                                    ));
                            string percorso_transazioni = Variabili.percorso_database + @"Transaction\";
                            Resoconto_transazione_xml.Save(percorso_transazioni + x + "_" + nodeUtente.InnerText + @"\" + transazione + "_" + "Confirmed" + ".xml");
                            #endregion
                            i = Variabili.conta_numero_elementi() + 1;
                        }
                        else
                            x++;
                }
            }
            #endregion
            //Prepara file Xml ed inserisci i dati
            XDocument dati_cliente_Db = new XDocument(new XElement("Cliente", 
                new XElement("Utente", text_Nome_Utente.Text),
                new XElement("Investimento", text_Investimento.Text.Replace(".",",")),
                new XElement("Credito", credito_cliente.ToString("0.0000").Replace(".", ",")),
                new XElement("Credito_Rimanente", credito_cliente.ToString("0.0000").Replace(".", ",")),
                new XElement("Daily_Reward", daily_payment.ToString("0.0000").Replace(".", ",")),
                new XElement("Email", email_ricezione),
                new XElement("Indirizzo_Xch", wallet_ricezione),
                new XElement("Bonus", bonus),
                new XElement("Tantum", text_Tantum.Text.Replace(".", ",")),
                new XElement("Referal", "test123"),
                new XElement("Ref_Invite", text_Referal.Text),
                new XElement("Fee", text_Xch_Fee.Text),
                new XElement("BoolAPY", rendimento)
                ));

            //Controlla ID
            int id_file = 1;
            while(System.IO.File.Exists(Variabili.percorso_database + id_file + ".xml") == true)
                id_file++; //Se già esiste incrementa di 1 e riprova

            dati_cliente_Db.Save(Variabili.percorso_database + id_file + ".xml"); //Crea - Salva file + path + nome + .xml
            #endregion
            //Ricalcola il valore del min-max ID dopo l'inserimento nel DB
            lbl_max_ID.Text = Variabili.conta_numero_elementi().ToString();
            int ID_Max = Convert.ToInt32(lbl_max_ID.Text);
            lbl_min_ID.Text = (ID_Max - (ID_Max - 1)).ToString();
            trackBar_ID.Minimum = Convert.ToInt32(lbl_min_ID.Text);
            trackBar_ID.Maximum = Convert.ToInt32(lbl_max_ID.Text);

            Form1_Load(sender, new EventArgs());
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
            Variabili.swap_Chia_EURO_API(); // API prezzo chia
            if (System.IO.File.Exists(Variabili.price_Swap_XCH_EURO) == true)
            {
                string Lettura_Chia = File.ReadAllText(Variabili.price_Swap_XCH_EURO).Replace(".", ",");
                text_Prezzo_Chia.Text = Lettura_Chia;
                prezzo_chia_API = Convert.ToDouble(Lettura_Chia) + (Convert.ToDouble(Lettura_Chia) * Variabili.slippage / 100);
            }
            else
                text_log.Text = text_log.Text + "File: price_Swap_XCH_EURO.txt | File non trovato\r\n";

            if (prezzo_chia_API < Min_prezzo_chia) //lettura variabile pubblica, qui sopra
            {
                MessageBox.Show("Prezzo Chia troppo basso... Programma Arrestato...");
                btn_Load_Payment.Enabled = true;
                return;
            }
            else
            {
                text_log.Text = text_log.Text + "Istruzioni pagamento...\r\n";
                var Pagamento = Istruzioni(id, api, cmd, Costante_AutoUP_price, Min_prezzo_chia); //Esegue l'istruzione - se presenti 3 task, vengono lanciati tutti in parallelo
                await Pagamento; //Aspetta la sua conclusione del task

                text_log.Text = text_log.Text + "Pagamento ciclo completato...\r\n";
                btn_Load_Payment.Enabled = true;
            }
            if (Variabili.loop_pagamenti == false)
                Variabili.loop_pagamenti = true;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var _Mempool = Mempool();
            await _Mempool;
            button1.Enabled = true;
        }
        public static Task Mempool()
        {
            return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {
                #region Variabili Mempool
                int id_resoconto_xml = 1;
                int id_cartella = 0;
                int transazioni_eseguite = 0; // Incrementa ogni volta che viene eseguita una transazione
                int transazioni_saltate = 0; // Incrementa ogni volta che non viene eseguita una transazione
                int transazioni_Totale = 0;
                int timer_attesa = 1000 * 60 * 60 * 24;
                int primo_timer = 1000 * 60 * 30;
                int giorni_Senza_Transazioni = 0; // Quando viene incrementato significa che un ciclo è terminato 
                string stato_Transazione = "Confirmed";
                string percorso_transazioni = Variabili.percorso_database + @"Transaction\";
                bool loop = true;

                timer_attesa = timer_attesa - primo_timer;
                #endregion
                while (loop == true)
                {
                    //Ottenimento nomi cartelle da analizzare [0|1|2|3|...]
                    int numero_elementi_Cartella = Variabili.conta_numero_elementi_transaction();
                    string[] nomi_Cartelle_Transazioni = Directory.GetDirectories(Variabili.percorso_database + @"Transaction\");

                    Thread.Sleep(primo_timer); //30 minuti di attesa prima di eseguire il controllo
                    if (numero_elementi_Cartella > 0)
                    {
                        String[] lista_Utenti = new String[numero_elementi_Cartella];
                        for (int x = 0; x < numero_elementi_Cartella; x++) //Legge tutte le cartelle
                        {
                            string nomi_cartelle = nomi_Cartelle_Transazioni[x];
                            string cartelle = Path.GetFileName(nomi_cartelle);
                            lista_Utenti[x] = cartelle;
                        }

                        string cartella = lista_Utenti[id_cartella]; //estrazione nome cartella
                        for (int i = 0; i < numero_elementi_Cartella; i++) //Eseguo un ciclo per ogni cartella utente trovata
                        {
                            string[] nomi_Transazioni = Directory.GetFiles(Variabili.percorso_database + @"Transaction\" + lista_Utenti[id_cartella] + @"\");
                            if (id_cartella < numero_elementi_Cartella)//legge i nomi dei singoli file nella cartella \Transaction
                            {
                                for (int x = 0; x < nomi_Transazioni.Length; x++) //Esegue un ciclo per tutte le transazioni che trova
                                {
                                    //Rimane nell'if se il numero transazioni da fare è uguale al numero transazioni eseguite (pending --> confirmed)
                                    if (x < nomi_Transazioni.Length)
                                    {
                                        string nomi_cartelle = nomi_Transazioni[x];     //Legge tutte le transazioni
                                        string cartelle = Path.GetFileName(nomi_cartelle);
                                        bool Controllo = cartelle.Contains("Pending"); //Dovrebbe controllare se, nel nome della cartella, è presente la stringa / variabile (Funzionante)

                                        if (Controllo == true) //Controllo che salta le transazioni Confermate
                                        {
                                            
                                            #region Caricamento dati transazione
                                            //Caricamento dati 
                                            XmlDocument DocumentoXml = new XmlDataDocument();
                                            DocumentoXml.Load(percorso_transazioni + lista_Utenti[id_cartella] + @"\" + cartelle);
                                            XmlNode nodeId = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/ID");
                                            XmlNode nodeUtente = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Nome_Utente");
                                            XmlNode nodeWallet = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Wallet");
                                            XmlNode nodeTransaction_id = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Transaction_id");
                                            XmlNode nodeTransaction_hash = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Transaction_hash");
                                            XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Credito");
                                            XmlNode nodeDeposito = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Deposito");
                                            XmlNode nodeImporto_Accreditato_Xch = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Importo_Accreditato_Xch");
                                            XmlNode nodeImporto_Accreditato_euro = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Importo_Accreditato_euro");
                                            XmlNode nodeRimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Rimanente");
                                            XmlNode nodePrezzo_Chia = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Prezzo_Chia");
                                            XmlNode nodeRendimento = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Rendimento");
                                            XmlNode nodeStato_Transazione = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Stato_Transazione");
                                            XmlNode nodeBlock_Number = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Block_Number");
                                            XmlNode nodeData_Transazione = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Data_Transazione");
                                            #endregion
                                            id_resoconto_xml = Convert.ToInt32(nodeId.InnerText);

                                            File.WriteAllText(Variabili.percorso_cmd + @"transaction_ID.txt", nodeTransaction_id.InnerText);
                                            //Creazione file .log
                                            Variabili.Tx_log();
                                            //Controllo se il file .log è stato creato
                                            string transazione = "";
                                            if (File.Exists(Variabili.percorso_api + @"Transazione.log") == true) // Controlla che il file esista prima della tentata lettura
                                                using (StreamReader lettura_file_payment = new StreamReader(Variabili.percorso_api + @"Transazione.log"))
                                                {
                                                    transazione = lettura_file_payment.ReadToEnd();    // Leggi il contenuto del file
                                                    if (transazione.Length == 0)
                                                    {
                                                        // Controllo che il file log non sia vuoto
                                                        Console.WriteLine("Il Transazione.log è vuoto");
                                                        return;
                                                    }
                                                    else
                                                        Console.WriteLine(transazione);
                                                }
                                            else
                                            {
                                                MessageBox.Show("il file Transazione.log non è stato trovato ...\r\n");
                                                return;
                                            }
                                            #region "txn_hash.py" legge il file "Transazione.log"
                                            //Ottenimento dati in output da python
                                            var percorso_File_log = Variabili.percorso_api + @"Transazione.log";
                                            var pythonFilePath = Variabili.percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\txn_hash.py";

                                            string risultato = "Blocco|Hash";
                                            using (Process process = new Process())
                                            {
                                                process.StartInfo.FileName = "python";
                                                process.StartInfo.Arguments = $"{pythonFilePath} {percorso_File_log}";
                                                process.StartInfo.UseShellExecute = false;
                                                process.StartInfo.RedirectStandardOutput = true;
                                                process.Start();

                                                risultato = process.StandardOutput.ReadToEnd();
                                                process.WaitForExit();
                                            }
                                            Console.WriteLine(risultato);
                                            #endregion
                                            // Utilizza la stringa in output qui come necessario
                                            char[] delimiterChars = { '|' };

                                            string[] parts = risultato.Split(delimiterChars); // Composto da 3 part1 0|1|2 -> 0 = percorso file 
                                            string block_Number = parts[1]; // block number
                                            string txn_Hash = parts[2]; // txn hash

                                            if (nodeStato_Transazione.InnerText == "Pending")
                                            {
                                                if (block_Number != "")    //Abilitare quando completo
                                                {
                                                    if (txn_Hash != "")   //Abilitare quando completo
                                                    {
                                                        #region Salvataggio dati della transazione manipolati
                                                        //Salvataggio dati
                                                        XDocument Resoconto_transazione_xml = new XDocument(new XElement("Resoconto",
                                                            new XElement("ID", nodeId.InnerText),
                                                            new XElement("Nome_Utente", nodeUtente.InnerText),
                                                            new XElement("Wallet", nodeWallet.InnerText),
                                                            new XElement("Transaction_id", nodeTransaction_id.InnerText),
                                                            new XElement("Transaction_hash", txn_Hash),
                                                            new XElement("Credito", nodeCredito.InnerText), // Investimento + bonus = credito cliente
                                                            new XElement("Deposito", nodeDeposito.InnerText),
                                                            new XElement("Importo_Accreditato_Xch", nodeImporto_Accreditato_Xch.InnerText), // XCH
                                                            new XElement("Importo_Accreditato_euro", nodeImporto_Accreditato_euro.InnerText), // EURO
                                                            new XElement("Rimanente", nodeRimanente.InnerText), // credito rimanente
                                                            new XElement("Prezzo_Chia", nodePrezzo_Chia.InnerText), // Prezzo chia,
                                                            new XElement("Rendimento", nodeRendimento.InnerText),// Rendimento 24h (up 25'000€)
                                                            new XElement("Stato_Transazione", stato_Transazione),// stato transazione
                                                            new XElement("Block_Number", block_Number),// block number
                                                            new XElement("Data_Transazione", nodeData_Transazione.InnerText) // Data 
                                                            ));
                                                        if (System.IO.File.Exists(percorso_transazioni + lista_Utenti[id_cartella] + @"\" + id_resoconto_xml + "_" + stato_Transazione + ".xml"))
                                                        {
                                                            MessageBox.Show("Errore mempool - Il file da salvare già esiste... Ricontrollare transazioni");
                                                            return;
                                                        }
                                                        Resoconto_transazione_xml.Save(percorso_transazioni + lista_Utenti[id_cartella] + @"\" + id_resoconto_xml + "_" + stato_Transazione + ".xml");
                                                        transazioni_eseguite++; // Incrementa se la transazione ha avuto successo

                                                        //eliminazione vecchio file 
                                                        File.Delete(percorso_transazioni + lista_Utenti[id_cartella] + @"\" + id_resoconto_xml + "_" + Variabili.pending_Transaction + ".xml");
                                                        #endregion
                                                        id_resoconto_xml++;
                                                        Console.WriteLine("La transazione risulta inclusa in un blocco");
                                                        Console.WriteLine("Blocco: " + block_Number);
                                                        Console.WriteLine("Hash: " + txn_Hash);
                                                        Console.WriteLine("file convertiti\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Hash Transazione: " + txn_Hash);
                                                        Console.WriteLine("Mempool interrotta!");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Numero Blocco: " + block_Number);
                                                    Console.WriteLine("Mempool interrotta!");
                                                    return;
                                                }
                                            }
                                            else
                                                Console.WriteLine("Transazione annullata, è già stata pagata");
                                        }
                                        else
                                        {
                                            Console.WriteLine("File saltato:\n" + nomi_Transazioni[x] + "\n");
                                            transazioni_saltate++;
                                            id_resoconto_xml++;
                                        }
                                        Controllo = false;
                                    }
                                }
                                Console.WriteLine("Controllo transazioni " + lista_Utenti[i] + " Completato...");
                                id_resoconto_xml = 1;
                            }
                            if (id_cartella < numero_elementi_Cartella - 1)
                                id_cartella++;
                            else
                                Console.WriteLine("Cambio cartella");
                        }

                        if (giorni_Senza_Transazioni == 1 & transazioni_eseguite == 0) //Conclude il ciclo se per 48h non vengono avvengono "transazioni_eseguite"
                            loop = false;
                        if (transazioni_eseguite > 0) //Se avvengono delle transazioni, resettiamo il contatore (se non avvengono dopo 24h si interrompe il ciclo)
                            giorni_Senza_Transazioni = 0;

                        int _transazioni_totali = transazioni_eseguite + transazioni_saltate; //Calcolo totale transazioni eseguite prima di uscire ed attendere 24h
                        transazioni_Totale += _transazioni_totali; //Tutte le transazioni che sono state eseguire (Pending --> Confirmed)

                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Tutte le transazioni in Mempool sono state eseguite correttamente!");
                        Console.WriteLine("*****************************************************************************\n");

                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine("Transazioni Eseguite: " + transazioni_eseguite);
                        Console.WriteLine("Transazioni Saltate: " + transazioni_saltate);
                        Console.WriteLine("Transazioni Totali: " + _transazioni_totali);
                        Console.WriteLine("Transazioni Mempool: " + transazioni_Totale);
                        Console.WriteLine("------------------------------------------------------");

                        // Creazione file debug e resoconto mempool
                        string data_Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        string percorso = Variabili.percorso_log_path + Variabili.id + "Mempool.log";
                        File.WriteAllText(Variabili.percorso_cmd + "transaction_ID.txt", Variabili.transaction_id);
                        File.WriteAllText(percorso , "Data: " + data_Time + "\r\n" + "Transazioni Eseguite: " + transazioni_eseguite + "\r\n"
                           + "Transazioni Saltate: " + transazioni_saltate + "\r\n" + "Transazioni Totali: " + _transazioni_totali + "\r\n"
                           + "Transazioni Mempool: " + transazioni_Totale);
                        Variabili.id++;
                    }
                    else
                    {
                        MessageBox.Show("Database transazioni Vuoto - Effettua delle transazioni per vedere il database");
                        return;
                    }
                    if (transazioni_eseguite == 0)
                        giorni_Senza_Transazioni++;
                    id_cartella = 0;
                    transazioni_eseguite = 0;
                    transazioni_saltate = 0;
                    Thread.Sleep(timer_attesa); //24 ore di dopo l'esecuzione del codice
                }
                // QUi siamo fuori dal loop infinito
                MessageBox.Show("Ciclo mempool terminato | Nessuna transazione è stata processata per 48 ore");
            });
        }
        public static Task Istruzioni(int id, bool api, bool cmd, double Costante_AutoUP_price, double Min_prezzo_chia) // IStanza la quale esegue loop pagamento + salvataggio dati xml
        {
            return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {   
                log("Inizializzazione pagamenti...\r\n");
                if (Variabili.conta_numero_elementi() == 0) // controlla in numero di utenti nel db - se 0 mostra messaggio
                    MessageBox.Show("Database vuoto... Pagamenti annullati... Prego inserire un utente nel database");

                    int numero_clienti = Variabili.conta_numero_elementi();
                while (Variabili.loop_pagamenti == true)
                {
                    log("Richiesta prezzo chia...\r\n");
                    Variabili.swap_Chia_EURO_API(); // API prezzo chia
                    if (Variabili.conta_numero_elementi() == 0) // controlla in numero di utenti nel db - se 0 mostra messaggio
                        MessageBox.Show("Database vuoto... Pagamenti annullati... Prego inserire un utente nel database");

                    numero_clienti = Variabili.conta_numero_elementi();

                    int crediti_esauriti = 0;
                    #region - IL QUORE DEL PAGAMENTO -
                    for (int a = 0; a < numero_clienti; a++)
                    {
                        log("ID: " + id + "\r\n");
                        log("Contatore: " + crediti_esauriti + "\r\n");
                        string Lettura_Chia = File.ReadAllText(Variabili.price_Swap_XCH_EURO).Replace(".", ",");
                        double lettura_prezzo = Convert.ToDouble(Lettura_Chia);
                        lettura_prezzo = lettura_prezzo + (lettura_prezzo * Variabili.slippage / 100); //Applichiamo Slippage
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
                                    XmlNode nodeReferal = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Referal");
                                    XmlNode nodeRef_Invite = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Ref_Invite");
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

                                    Variabili.messaggio_server = utente + " | " + investimento + " | "; // test per leggere il nome utente e mandarlo al serever --> client

                                    double prezzo_Chia = 00.00;
                                    double chia_pay = 0.000000000000;
                                    bool eccezione = false;
                                    #endregion
                                    //Eseguire API prezzo chia -- Controlla se check Box è spuntata.
                                    if (api == false)
                                    {
                                        MessageBox.Show("API DIsattivato");
                                        log("Ciclo interrotto...\r\n Nessun cambiamento nel database...\r\n");
                                        return;
                                    }else
                                     {
                                        string Lettura_prezzo_Chia = File.ReadAllText(Variabili.price_Swap_XCH_EURO);
                                        prezzo_Chia = Convert.ToDouble(Lettura_prezzo_Chia.Replace(".", ","));
                                        prezzo_Chia = prezzo_Chia + (prezzo_Chia * Variabili.slippage / 100); //Applichiamo Slippage

                                        if ((credito_rimanente / daily_reward) <= Costante_AutoUP_price)
                                        {   // se il credito è inferiore al rappporto, l'importo da pagare è pari al credito
                                            Variabili.reward_originale = daily_reward;
                                            daily_reward = credito_rimanente;
                                            chia_pay = daily_reward / (prezzo_Chia + prezzo_Chia * Variabili.slippage / 100); // XCH
                                            eccezione = true;
                                            log("Credito inferiore al rapporto...\r\n il pagamento è stato incrementato...\r\n");
                                        }else
                                        {
                                            Variabili.reward_originale = daily_reward;
                                            //Calcolo quantità di xch da inviare...
                                            chia_pay = daily_reward / (prezzo_Chia + prezzo_Chia * Variabili.slippage / 100); //Calcolo quantità di xch da inviare...
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
                                    File.WriteAllText(Variabili.percorso_cmd + @"daily_payment.txt", chia_pay.ToString("0.000000000000").Replace(",", "."));
                                    if (Variabili.Email_invio.Length > 0)
                                        File.WriteAllText(Variabili.percorso_cmd + @"email_invio.txt", Variabili.Email_invio.ToString());
                                    if (email.Length > 0)
                                        File.WriteAllText(Variabili.percorso_cmd + @"email_ricezione.txt", email);
                                    File.WriteAllText(Variabili.percorso_cmd + @"wallet_Invio.txt", Variabili.Wallet_ID.ToString());
                                    File.WriteAllText(Variabili.percorso_cmd + @"wallet_ricezione.txt", wallet.ToString());
                                    File.WriteAllText(Variabili.percorso_cmd + @"chia_fee.txt", fee.Replace(",", "."));

                                    File.WriteAllText(Variabili.percorso_cmd_path + @"cmd_path.txt", Variabili.percorso_cmd);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"log_path.txt", Variabili.percorso_log_path);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"email_path.txt", Variabili.percorso_email_path);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"email_code.txt", Variabili.Email_code);
                                    File.WriteAllText(Variabili.percorso_cmd_path + @"main_cmd.txt", Variabili.percorso_cmd_path);
                                    File.WriteAllText(Variabili.percorso_appdata + @"\Programs\Chia\resources\app.asar.unpacked\daemon\path_cmd_custom.txt", Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database);

                                    File.Delete("utente.txt");
                                    //Crea i file per i dati notifica email...
                                    #endregion
                                    //pagamento .cmd
                                    if (cmd == false)
                                        MessageBox.Show("Pagamento .cmd disattivato");
                                    else
                                    {
                                        log("Pagemnto in corso...\r\n");
                                        // Crea un nuovo processo
                                        var processStartInfo = new ProcessStartInfo(Variabili.cmdPath + @"\Pagamento.cmd");
                                        // Esegui il processo
                                        using (var process3 = Process.Start(processStartInfo))
                                        process3.WaitForExit(); // Attendi che il processo termini
                                    } //Pagamento .cmd

                                    log("Utente: " + nodeUtente.InnerText + "\r\n"); // Prende il contenuto del nodo Utente salvata in variabile...
                                    log("Credito_Cliente: " + nodeCredito_rimanente.InnerText + "\r\n");
                                    log("Daily_Reward: " + nodeDaily_Reward.InnerText + "\r\n");
                                    log("Fee: " + nodeFee.InnerText + "\r\n");

                                    string data_Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                    // Utilizzo pratico dello stato della transazione (SUCCESS)
                                    // Ottenimento - Conferma transazione - Transaction ID
                                    #region Stato transazione
                                    if (System.IO.File.Exists(Variabili.percorso_api + "payment.log") == true) // Controlla che il file esista prima della tentata lettura
                                    using (StreamReader lettura_file_payment = new StreamReader(Variabili.percorso_api + "payment.log"))
                                    {
                                        string transazione = lettura_file_payment.ReadToEnd();    // Leggi il contenuto del file
                                            if (transazione.Length == 0)
                                            {
                                                Console.WriteLine("Il file payment è vuoto");
                                                Variabili.delete_unconfirmed_transactions();
                                                return;
                                            }
                                            else
                                            {
                                                string targetText = "-tx ";
                                                string txHash = "";
                                                string line;
                                                using (StreamReader reader = new StreamReader(Variabili.percorso_api + "payment.log"))

                                                    while ((line = reader.ReadLine()) != null)
                                                    {
                                                        int startIndex = line.IndexOf(targetText);
                                                        if (startIndex != -1)
                                                        {
                                                            txHash = line.Substring(startIndex + targetText.Length);
                                                            txHash = txHash.Substring(0, 66);
                                                            Console.WriteLine("Test: " + txHash);
                                                        }
                                                    }
                                                Variabili.conferma_transazione_string = transazione.Substring(161, 7);  // Estrai avvenuta transazione [SUCCESS]
                                                Variabili.transaction_id = txHash;  // Estrai transaction id [-tx 0x42f917d...]
                                            }

                                        // Visualizza la parte estratta dal file
                                        log("Stato transazione: " + Variabili.conferma_transazione_string + "\r\n");
                                        log("transaction ID : " + "-tx: " + Variabili.transaction_id + "\r\n");
                                    }
                                    else
                                    {
                                        MessageBox.Show("File payment.log non trovato... programma arrestato...\r\n");
                                        File.WriteAllText(Variabili.percorso_log_path + @"\Crash\" + id + "_File.txt", "Payment.log non trovato... :\r\n " + data_Time + " || " + "Utente: " + utente + " ID: " + id + "------------------------------------\r\n");
                                        Variabili.delete_unconfirmed_transactions();
                                        return;
                                    }
                                    #endregion
                                    // Rendimento
                                    double rendimento = 0.0;

                                    // REGIONE RENDIMENTO GIORNALIERO
                                    if (Variabili.capitale_Depositato() >= Variabili.reward) // Limite abilitazione 25'000
                                        if (investimento >= Variabili.min_Deposit) //Somma depositata 1'250
                                            rendimento = Variabili.rendimento(id);
                                        else
                                            log("Rendimenti non attivi, il capitale totale depositato è inferiore a 25'000€\r\n");
                                    if (_BoolAPY == true)
                                        rendimento = Variabili.rendimento(id); //Rendimento applicato ugualmente se risultra true da database
                                    credito_rimanente_temp = credito_rimanente_temp + rendimento; // se la condizione è falsa aggiunge 0€ al credito

                                    //APPLICARE SECONDO CONTROLLO TRANSAZIONE SE AVVENUTA CON SUCCESSO
                                    File.WriteAllText(Variabili.percorso_cmd + "transaction_ID.txt", Variabili.transaction_id);

                                    int id_resoconto_xml = 1;
                                    #region Creazione file .xml o .json per visuale (database / client / resoconto)
                                    //qui crea cartella transaction se non esiste
                                    if (System.IO.Directory.Exists(Variabili.percorso_database + @"Transaction") == false)
                                        System.IO.Directory.CreateDirectory(Variabili.percorso_database + @"Transaction");

                                    //creare cartella con nome utente
                                    if (System.IO.Directory.Exists(Variabili.percorso_database + @"Transaction\" + id + "_" + utente) == false)
                                        System.IO.Directory.CreateDirectory(Variabili.percorso_database + @"Transaction\" + id + "_" + utente);

                                    string stato_transazione = Variabili.pending_Transaction;
                                    string percorso_transazioni = Variabili.percorso_database + @"Transaction\";

                                    while (System.IO.File.Exists(percorso_transazioni + id + "_" + utente + @"\" + id_resoconto_xml + "_" + "Confirmed" + ".xml") == true)
                                        id_resoconto_xml++; //Se già esiste incrementa di 1 e riprova
                                    while (System.IO.File.Exists(percorso_transazioni + id + "_" + utente + @"\" + id_resoconto_xml + "_" + "Pending" + ".xml") == true)
                                        id_resoconto_xml++;
                                    //creare file per resoconto transazione
                                    XDocument Resoconto_transazione_xml = new XDocument(new XElement("Resoconto",
                                        new XElement("ID", id_resoconto_xml),
                                        new XElement("Nome_Utente", utente),
                                        new XElement("Wallet", wallet),
                                        new XElement("Transaction_id", Variabili.transaction_id),
                                        new XElement("Transaction_hash", ""),
                                        new XElement("Credito", credito_cliente.ToString("0.0000")), // Investimento + bonus = credito cliente
                                        new XElement("Deposito", investimento.ToString("0.0000")),
                                        new XElement("Importo_Accreditato_Xch", chia_pay.ToString("0.000000000000")), // XCH
                                        new XElement("Importo_Accreditato_euro", daily_reward.ToString("0.0000")), // EURO
                                        new XElement("Rimanente", credito_rimanente_temp.ToString("0.0000")), // credito rimanente
                                        new XElement("Prezzo_Chia", Lettura_Chia), // Prezzo chia,
                                        new XElement("Rendimento", rendimento.ToString("0.0000")),// Rendimento 24h (up 25'000€)
                                        new XElement("Stato_Transazione", "Pending"),// stato transazione
                                        new XElement("Block_Number", "Pending"),// numero blocco
                                        new XElement("Data_Transazione", data_Time) // Data
                                    ));

                                    Resoconto_transazione_xml.Save(percorso_transazioni + id + "_" + utente + @"\" + id_resoconto_xml + "_" + stato_transazione + ".xml"); //Crea - Salva file | Transaction _path
                                    rendimento = 0.0;
                                    #endregion

                                    log("Pagamento: " + id + "\r\n");
                                    Thread.Sleep(2000); // 1S
                                    Variabili.tempo_calcolato = Variabili.tempo_calcolato + 2000;
                                    id++;
                                } 
                            }
                        }
                        #endregion
                    }//Fine ciclo pagamenti utenti ... attendere 24h dopo i controlli sotto

                    if (Variabili.conta_numero_elementi() != 0) // Se il db ha contatti allora riparte il ciclo
                    {
                        id = (Variabili.conta_numero_elementi() - (Variabili.conta_numero_elementi() - 1)); // Impostiamo l'id ad 1 e dorebbe ripartire il ciclo
                        Variabili.loop_pagamenti = true;
                    }
                    if(crediti_esauriti == Variabili.conta_numero_elementi())
                    {
                        Variabili.loop_pagamenti = false;
                        crediti_esauriti = 0;
                        MessageBox.Show("Tutti gli utenti hanno esaurito il credito");
                        return; // se il bd è vuoto, ferma il programma
                    }
                    
                    //Attendere 24h
                    log("Tempo: " + Variabili.tempo_calcolato + "\r\n");
                    log("Attesa: " + (Variabili.attesa - (Variabili.tempo_calcolato + 75 * (Variabili.conta_numero_elementi() - crediti_esauriti))) + "\r\n"); // 200 millisecondi per eseguire i pagamenti
                    Thread.Sleep(Variabili.attesa - (Variabili.tempo_calcolato + 75 * (Variabili.conta_numero_elementi() - crediti_esauriti))); //  <--- STRINGA CORRETTA
                    //Thread.Sleep(1000 * 60 * 6); //  <--- STRINGA TEST 6 minuti
                    Variabili.tempo_calcolato = 0;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}