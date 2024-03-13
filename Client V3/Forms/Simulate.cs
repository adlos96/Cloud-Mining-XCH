using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_V3.Forms
{
    public partial class Simulate : Form
    {
        public Simulate()
        {
            InitializeComponent();
        }
        private async void btn_Conferma_Click(object sender, EventArgs e)
        {
            btn_Conferma.Enabled = false;
            btn_Aggiorna.Enabled = false;
            if (ClientsConnection.client_Connesso == false)
            {
                await ClientsConnection.TestClient.InitializeClient();
                await ClientsConnection.TestClient.Send_Server($"auth|{Variabili.wallet}");
            }
            int numero_Plot = 0;
            int deposit_Bonus = 0;
            double rendita_Giornaliera = 0.0;

            if (checkB_Plot_Manuale.Checked == false) numero_Plot = Convert.ToInt32(lbl_Plot_Current_Selection.Text);
            else numero_Plot = Convert.ToInt32(txt_Plot_Manuale.Text);

            if (radioButton_A.Checked == true) rendita_Giornaliera = 0.00;
            if (radioButton_B.Checked == true) rendita_Giornaliera = 0.87;
            if (radioButton_C.Checked == true) rendita_Giornaliera = 1.65;
            if (radioButton_D.Checked == true) rendita_Giornaliera = 2.20;
            if (radioButton_E.Checked == true) rendita_Giornaliera = 2.75;

            txt_Plot_Anteprima.Text = numero_Plot.ToString();
            txt_EUR_Anteprima.Text = (numero_Plot * 1.05).ToString("0.00");
            txt_USDT_Anteprima.Text = "0";

            //Invio dati per simulazione
            await ClientsConnection.TestClient.ClientSend($"simulazione|2000|{numero_Plot}|{rendita_Giornaliera}");

            await Wait();
            btn_Conferma.Enabled = true;
            btn_Aggiorna.Enabled = true;

        }
        private void Simulate_Load_1(object sender, EventArgs e)
        {
            radioButton_A.Text = Variabili.Rendita_Base_A.ToString() + "%";
            radioButton_B.Text = Variabili.Rendita_Base_B.ToString() + "%";
            radioButton_C.Text = Variabili.Rendita_Base_C.ToString() + "%";
            radioButton_D.Text = Variabili.Rendita_Base_D.ToString() + "%";
            radioButton_E.Text = Variabili.Rendita_Base_E.ToString() + "%";

            trkBar_NumeroPlot.Maximum = 100;
            trkBar_NumeroPlot.Minimum = 1;

            lbl_Plot_MAX.Text = trkBar_NumeroPlot.Maximum.ToString();
            lbl_Plot_MIN.Text = trkBar_NumeroPlot.Minimum.ToString();
            lbl_Plot_Current_Selection.Text = trkBar_NumeroPlot.Value.ToString();

            lbl_Plot_Manuale_Selezionato.Visible = false;
            txt_Plot_Manuale.Visible = false;
            label8.Visible = false;
        }
        private void checkB_Plot_Manuale_CheckedChanged(object sender, EventArgs e) {
            if (checkB_Plot_Manuale.Checked == true) {

                lbl_Plot_Manuale_Selezionato.Visible = true;
                txt_Plot_Manuale.Visible =  true;
                label8.Visible = true;

                trkBar_NumeroPlot.Visible = false;
                lbl_Plot_MAX.Visible = false;
                lbl_Plot_MIN.Visible = false;
                lbl_Plot_Current_Selection.Visible = false;
                label21.Visible = false;
            } else {

                lbl_Plot_Manuale_Selezionato.Visible = false;
                txt_Plot_Manuale.Visible = false;
                label8.Visible = false;

                trkBar_NumeroPlot.Visible = true;
                lbl_Plot_MAX.Visible = true;
                lbl_Plot_MIN.Visible = true;
                lbl_Plot_Current_Selection.Visible = true;
                label21.Visible = true;
            }
        }
        private void trkBar_NumeroPlot_Scroll(object sender, EventArgs e)
        {
            lbl_Plot_MIN.Text = trkBar_NumeroPlot.Minimum.ToString();
            lbl_Plot_MAX.Text = trkBar_NumeroPlot.Maximum.ToString();
            lbl_Plot_Current_Selection.Text = trkBar_NumeroPlot.Value.ToString();
        }

        private void btn_Aggiorna_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (Variabili.queue_Simulate_Command.Count != 0)
            {
                while (x <= Variabili.queue_Simulate_Command.Count)
                {
                    string messaggio = Variabili.queue_Simulate_Command.Dequeue();
                    string[] args = messaggio.Split('|');

                    if (args[0] == "simulazione")
                    {
                        string prezzo_Chia_Euro = args[1];
                        string prezzo_Chia_USDT = args[2];
                        string xch_Pay = args[3];
                        string daily_Payment = args[4];
                        string rendita = args[5];
                        string credito = args[6];
                        string bonus_Deposito = args[7];
                        string totale = args[8];
                        string giorni = args[9];
                        string plot_Price = args[10];

                        txt_USDT_Anteprima.Text = plot_Price;
                        Txt_Giorni_Noleggio.Text = giorni;
                        txt_Prezzo_Chia_Euro.Text = prezzo_Chia_Euro;
                        Txt_Chia_Reward_1.Text = xch_Pay.ToString();
                        Txt_Chia_Reward_7.Text = (Convert.ToDouble(xch_Pay) * 7).ToString();
                        Txt_Chia_Reward_2000.Text = (Convert.ToDouble(xch_Pay) * Convert.ToDouble(giorni)).ToString();
                        Txt_Daily_Reward.Text = daily_Payment;
                        txt_Rendita.Text = rendita;
                        Txt_Deposito_Bonus.Text = credito;
                        Txt_Bonus.Text = bonus_Deposito;
                        Txt_Totale.Text = totale;
                    }
                    x++;
                }
            }
            else
                Console.WriteLine($"Codice saltato, Comandi attuali: [{Variabili.queue_Simulate_Command.Count}]");

            Console.WriteLine("Fine loop");
        }
        public static Task Wait() {
            return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {
                Thread.Sleep(1250);
            });
        }
    }
}
