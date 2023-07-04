using System;
using System.Windows.Forms;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Impostazioni : Form
    {
        public Impostazioni()
        {
            InitializeComponent();
            this.Text = "Impostazioni " + Variabili.versione_software;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Salva percorso database
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_txt = text_Chia_Price_Path.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Pyton_exe = text_Python_Path.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Chia_Price_api = text_Chia_API_Path.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cmd = text_Cmd_Payment_Path.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Plot_Path = text_Percorso_Plot_Path.Text + @"\plot_number_adly.txt";

            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_database = text_percorso_database.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_api = text_percorso_database.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Cartella_cmd = text_percorso_database.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Wallet = text_wallet_invio.Text;
            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Mail_code = text_Mail_Code.Text;

            Chia_Cloud_Mining_AutoPayment_V2.Properties.Settings.Default.Salvato = true;
            Properties.Settings.Default.Save();
            Variabili.impostazioni_utente();
            this.Close();
        }

        private void Impostazioni_Load(object sender, EventArgs e)
        {
            text_percorso_database.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void text_wallet_invio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
