using Client_V3;
using Microsoft.Data.Sqlite;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Client.Forms
{
    public partial class Payment : Form
    {
        string address_USDT_TRC20 = "TRC-20";
        string address_USDT_ERC20 = "ERC-20";
        string address_USDT_Polygon = "Polygon";
        string address_USDT_Cronos = "Cronos";

        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            panel_Logo_Chain.Visible = false;
            panel_Plot_Manuali.Visible = false;
            pnl_Subtitle.Visible = false;

            trackBar2.Minimum = 1;
            trackBar2.Maximum = 100;
            lbl_Plot_MIN.Text = trackBar2.Minimum.ToString();
            lbl_Plot_MAX.Text = trackBar2.Maximum.ToString();
            lbl_Plot_Current_Selection.Text = trackBar2.Value.ToString();

            panel_Anteprima.Visible = false;
            panel_Numero_Plot_TrackBar.Visible = true;
            comboBox_Chain_Selection.Items.Add("ERC-20");
            comboBox_Chain_Selection.Items.Add("Polygon");
            comboBox_Chain_Selection.Items.Add("TRC-20");
            comboBox_Chain_Selection.Items.Add("Cronos");
            if (Variabili.status_Pagamento == "Stato pagamento: Nessuno")
                lbl_Stato_Pagamento_Timer.Text = Variabili.status_Pagamento;
            else
                lbl_Stato_Pagamento_Timer.Text = "Richiesta presente: " + Variabili.status_Pagamento + " Minuti " + Variabili.importo_USDT + "USDT";
            lbl_ID.Text = "ID: " + Variabili.id_Client;
        }

        private void comboBox_Chain_Selection_SelectedIndexChanged(object sender, EventArgs e) // Quando cambi la chain da utilizzare
        {
            if (comboBox_Chain_Selection.Text == address_USDT_ERC20) // Tether
            {
                txt_Address_Recive_USDT.Text = "0xcf10caa8e699b8089e408a6980d47672ffa99b3b";
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.ethereum_ERC_ico32;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Center;
                lbl_Stato_Rete_Anteprima.Text = "Active";
            }

            if (comboBox_Chain_Selection.Text == address_USDT_Polygon)
            {
                txt_Address_Recive_USDT.Text = "0xcf10caa8e699b8089e408a6980d47672ffa99b3b"; //Visualizzazione indirizzo wallet
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.Polygon_ico_32;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Center;
                lbl_Stato_Rete_Anteprima.Text = "Active";
            }

            if (comboBox_Chain_Selection.Text == address_USDT_TRC20) //Tron
            {
                txt_Address_Recive_USDT.Text = "Not Supported";
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.tron_TRX_ico_32;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Center;
                lbl_Stato_Rete_Anteprima.Text = "Active";
            }

            if (comboBox_Chain_Selection.Text == address_USDT_Cronos) //Tron
            {
                txt_Address_Recive_USDT.Text = "0xcf10caa8e699b8089e408a6980d47672ffa99b3b";
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.cronos_cro_logo;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Stretch; // --> Cronos e chia
                lbl_Stato_Rete_Anteprima.Text = "Active";
            }
        }

        private async void btn_Conferma_Plot_Click(object sender, EventArgs e)
        {
            int numero_Plot = 0;
            int contatore = 0;
            int controlli = 2;


            if (checkB_Plot_Manuale.Checked == true) numero_Plot = Convert.ToInt32(txt_Plot_Manuali.Text);
            else numero_Plot = Convert.ToInt32(lbl_Plot_Current_Selection.Text);

            lbl_Stato_Rete_Anteprima.Text = "Active";
            lbl_Stato_Rete_Anteprima.ForeColor = System.Drawing.Color.SeaGreen;
            btn_Conferma_Plot.Enabled = false;

            panel_Anteprima.Visible = false; // Disabilita anteprima
            pnl_Subtitle.Visible = false; // Disabilita pannello superiore

            lbl_Anteprima_Manuale.Text = numero_Plot.ToString();

            if (lbl_Plot_Current_Selection.Text == 0.ToString())
            {
                lbl_Avviso_Campi_Incompleti.Text = lbl_Plot_Current_Selection.Text + " Plot Selezionati";
                panel_Anteprima.Visible = false;
            } else contatore++;

            if (comboBox_Chain_Selection.Text == "")
            {
                lbl_Avviso_Campi_Incompleti.Text = "SELEZIONA UNA CHAIN";
                btn_Conferma_Plot.Enabled = true;
                lbl_Avviso_Campi_Incompleti.Visible = true;
                btn_Conferma_Plot.Enabled = true;
                return;
            } else
            {
                contatore++;
                lbl_Avviso_Campi_Incompleti.Visible = false;
            }

            if (checkB_Plot_Manuale.Checked == true) {
                if (numero_Plot != 0)
                {
                    controlli = 3;
                    contatore = 3;
                    txt_Plot_Anteprima.Text = numero_Plot.ToString();
                } else {
                    lbl_Avviso_Campi_Incompleti.Text = numero_Plot + " Plot Selezionati";
                    btn_Conferma_Plot.Enabled = true;
                    controlli = 2;
                    contatore = 3;
                }
            }
            if (comboBox_Chain_Selection.Text == address_USDT_ERC20) // Tether
            {
                txt_Address_Recive_USDT.Text = "0xcf10caa8e699b8089e408a6980d47672ffa99b3b";
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.ethereum_ERC_ico32;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Center;
                lbl_Anteprima_Rete.Text = "Active";
            }
            if (comboBox_Chain_Selection.Text == address_USDT_Polygon)
            {
                txt_Address_Recive_USDT.Text = "0xcf10caa8e699b8089e408a6980d47672ffa99b3b"; //Visualizzazione indirizzo wallet
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.Polygon_ico_32;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Center;
                lbl_Anteprima_Rete.Text = "Active";
            }
            if (comboBox_Chain_Selection.Text == address_USDT_TRC20) //Tron
            {
                txt_Address_Recive_USDT.Text = "Not Supported";
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.tron_TRX_ico_32;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Center;
            }
            if (comboBox_Chain_Selection.Text == address_USDT_Cronos) //Tron
            {
                txt_Address_Recive_USDT.Text = "0xcf10caa8e699b8089e408a6980d47672ffa99b3b";
                panel_Logo_Chain.BackgroundImage = Client_V3.Properties.Resources.cronos_cro_logo;
                panel_Logo_Chain.Visible = true;
                panel_Logo_Chain.BackgroundImageLayout = ImageLayout.Stretch; // --> Cronos e chia
                lbl_Anteprima_Rete.Text = "Active";
            }

            Console.WriteLine("Contatore1: " + contatore);
            Console.WriteLine("Controlli : " + controlli);

            if (contatore == controlli)
            {
                lbl_Anteprima_Rete.Text = comboBox_Chain_Selection.Text;
                txt_Plot_Anteprima.Text = numero_Plot.ToString();
                lbl_Referal_Code_Anteprima.Text = Variabili.invito_Referal;

                await ClientsConnection.TestClient.Send_Server($"auth|{Variabili.wallet}"); // Autenticazione
                await ClientsConnection.TestClient.Send_Server("plotPrice" + "|" + numero_Plot.ToString());
                await Conferma_btn(); //Connessione al server

                txt_USDT_Anteprima.Text = ClientsConnection.argomento_Ricevuto;
                
                if (comboBox_Chain_Selection.Text != "TRC-20")
                {
                    btn_Pay.Enabled = true;
                    pnl_Subtitle.Visible = true;
                }

                Console.WriteLine("[] Messaggio Ricevuto: " + ClientsConnection.argomento_Ricevuto);

                if (ClientsConnection.client_Connesso == true)
                {
                    lbl_Connessione_Server.Text = "Connesso";
                    lbl_Connessione_Server.ForeColor = System.Drawing.Color.BlueViolet;
                } else
                {
                    lbl_Connessione_Server.Text = "Disconnesso";
                    lbl_Connessione_Server.ForeColor = System.Drawing.Color.Tomato;
                }
                btn_Conferma_Plot.Enabled = true;

                if (comboBox_Chain_Selection.Text == "TRC-20" || comboBox_Chain_Selection.Text == "ERC-20" || comboBox_Chain_Selection.Text == "Cronos")
                {
                    lbl_Stato_Rete_Anteprima.Text = "Failed";
                    lbl_Stato_Rete_Anteprima.ForeColor = System.Drawing.Color.Red;
                    
                    lbl_Avviso_Campi_Incompleti.Text = "RETE NON SUPPORTATA";
                    lbl_Avviso_Campi_Incompleti.Visible = true;
                    btn_Pay.Enabled = false;

                }

                if (ClientsConnection.argomento_Ricevuto != "")
                    if (Convert.ToDouble(ClientsConnection.argomento_Ricevuto) > 1) //Controllo che il prezzo sia superiore ad 1$
                        panel_Anteprima.Visible = true;
                    else MessageBox.Show("Qualcosa è andato storto!...");
                else Console.WriteLine("[ERRORE] Messaggio Ricevuto" + ClientsConnection.argomento_Ricevuto);
                /*
                if (ClientsConnection.client_Connesso == true)
                    ClientsConnection.TestClient.Disconnetti();
                */
            }
        }

        public static Task Conferma_btn()
        {
            return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {   if (ClientsConnection.client_Connesso == false)
                {
                    ClientsConnection.TestClient.InitializeClient(); //Connessione Client al server
                    Thread.Sleep(1250);
                    ClientsConnection.TestClient.ComunicazioneServer(); //Invio dati al server
                } else
                    ClientsConnection.TestClient.ComunicazioneServer(); //Invio dati al server
                Thread.Sleep(1250);
            });
        }
        private async void btn_Pay_Click(object sender, EventArgs e)
        {
            bool avvenuto_Pagamento = false;
            //Atttende l'avvenuto pagamento della somma in usdt per il noleggio del plot
            //...
            //...
            avvenuto_Pagamento = true;
            Variabili.pagamento_Somma_USDT = txt_USDT_Anteprima.Text;
            Variabili.numero_Plot = txt_Plot_Anteprima.Text;
            Variabili.wallet_USDT = txt_Wallet_USDT_User.Text.ToLower();
            Variabili.chain = comboBox_Chain_Selection.Text;

            if (avvenuto_Pagamento == true)
            {
                //Invia i dati dell'untente al server
                ClientsConnection.argomento_Invio = "register" + "|" + Variabili.numero_Plot + "|" + Variabili.pagamento_Somma_USDT + "|" + Variabili.wallet + "|" + Variabili.invito_Referal + "|" + Variabili.wallet_USDT + "|" + Variabili.chain;
                await ClientsConnection.TestClient.ComunicazioneServer(); // Invia L'argomento al server
            }
            Console.WriteLine(ClientsConnection.argomento_Ricevuto);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lbl_Plot_MIN.Text = trackBar2.Minimum.ToString();
            lbl_Plot_MAX.Text = trackBar2.Maximum.ToString();
            lbl_Plot_Current_Selection.Text = trackBar2.Value.ToString();
        }
        private void checkB_Plot_Manuale_CheckedChanged(object sender, EventArgs e)
        {
            if(checkB_Plot_Manuale.Checked == true)
            {
                lbl_Plot_MAX.Visible = false;
                lbl_Plot_MIN.Visible = false;
                lbl_Plot_Current_Selection.Visible = false;
                label21.Visible = false;
                trackBar2.Visible = false;

                panel_Plot_Manuali.Visible = true;
                lbl_Testo_Manulale.Visible = true;
                txt_Plot_Manuali.Visible = true;
                lbl_Anteprima_Manuale.Visible = true;

                lbl_Anteprima_Manuale.Text = txt_Plot_Manuali.Text;
            }
            else
            {
                lbl_Plot_MAX.Visible = true;
                lbl_Plot_MIN.Visible = true;
                lbl_Plot_Current_Selection.Visible = true;
                label21.Visible = true;
                trackBar2.Visible = true;

                panel_Plot_Manuali.Visible = false;
                lbl_Testo_Manulale.Visible = false;
                txt_Plot_Manuali.Visible = false;
                lbl_Anteprima_Manuale.Visible = false;
            }
        }

        string path = "data_table.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\data_table.db";

        SqliteConnection con;
        SqliteCommand cmd;
        SqliteDataReader dr;
        private void Data_show()
        {
            var con = new SqliteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM test";
            var cmd = new SqliteCommand(stm, con);
            dr = cmd.ExecuteReader();
            while (dr.Read()) { Console.WriteLine(dr.GetString(0), dr.GetString(1)); }
        }

        private async void button1_Click(object sender, EventArgs e) // Connetti
        {
            if (ClientsConnection.client_Connesso == false)
            {
                await ClientsConnection.TestClient.InitializeClient();
                pnl_Subtitle.Visible = true;
                pnl_Subtitle.Enabled = true;
                lbl_Connessione_Server.Text = "Connesso";
                await ClientsConnection.TestClient.Send_Server($"auth|{Variabili.wallet}");
                lbl_Stato_Pagamento_Timer.Text = $"Status Pagamento:";
            }
        }

        private async void button2_Click(object sender, EventArgs e) // Disconnetti
        {
            if (ClientsConnection.client_Connesso == true)
            {
                await ClientsConnection.TestClient.Disconnetti();
                pnl_Subtitle.Visible = true;
                pnl_Subtitle.Enabled = true;
                lbl_Connessione_Server.Text = "Disconnesso";
            }
        }

        private void btn_Sqlite_Click(object sender, EventArgs e) // Refresh
        {
            Console.WriteLine($"[Payment] > Comandi ricevuti: {Variabili.queue_Payment_Command.Count}");
            int x = 0;
            int comandi = Variabili.queue_Payment_Command.Count;
            Console.WriteLine($"[Payment] > Comandi ricevuti: {Variabili.queue_Payment_Command.Count}");

            if (Variabili.queue_Payment_Command.Count > 0) {
                while (x < comandi)
                {
                    if (Variabili.queue_Payment_Command.Count == 0) return;

                    string messaggio = Variabili.queue_Payment_Command.Dequeue();
                    Console.WriteLine($"[Payment] > Argomento: {messaggio}");
                    string[] args = messaggio.Split('|');
                    Console.WriteLine($"[Payment] > Argomento Split: {args[0]}");
                    Console.WriteLine($"[Payment] > Argomento Split: {args[1]}");

                    if (args[0] == "plotSwap") txt_USDT_Anteprima.Text = args[1];
                    if (args[0] == "timerUSDT") lbl_Stato_Pagamento_Timer.Text = $"Age for make USDT payment: {args[1]} Minutes";
                    if (args[0] == "ID") lbl_ID.Text = args[1];
                    if (args[0] == "TxnSuccesso")
                    {
                        lbl_Avviso_Campi_Incompleti.Text = args[1];
                        lbl_Avviso_Campi_Incompleti.ForeColor = Color.YellowGreen;
                        lbl_Avviso_Campi_Incompleti.Visible = true;

                    }
                    if (args[0] == "TxnPartial")
                    {
                        lbl_Avviso_Campi_Incompleti.Text = args[1];
                        lbl_Avviso_Campi_Incompleti.ForeColor = Color.LightGoldenrodYellow;
                        lbl_Avviso_Campi_Incompleti.Visible = true;
                    }
                    x++;
                }
            } else
                Console.WriteLine($"Codice saltato, Comandi attuali: [{Variabili.queue_Payment_Command.Count}]");

            Console.WriteLine("Fine loop");
        }
    }
}
