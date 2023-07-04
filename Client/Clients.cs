using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Clients : Form
    {
        private TcpClient client;
        private bool isCommunicating;

        public Clients()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.Text = "Client: ";
            lbl_versione.Text = "0.01.00";
            lbl_data.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbl_Numero_Plot_Minimo.Text = trackBar_Plot.Minimum.ToString();
            lbl_Numero_Plot_Max.Text = trackBar_Plot.Maximum.ToString();
            Connetti_GB.Visible = false;
            lbl_plot_manuali.Visible = false;
            txt_plot_Manuale.Visible = false;
            btn_Conferma.Visible = false;
            Connetti_GB.Visible = false;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                return;
            }

            string ipAddress = ipAddressTextBox.Text;
            int port;
            if (!int.TryParse(portTextBox.Text, out port))
            {
                logTextBox.AppendText("Invalid port number" + Environment.NewLine);
                return;
            }

            try
            {
                client = new TcpClient(ipAddress, port);
                isCommunicating = true;

                Thread thread = new Thread(new ThreadStart(ReceiveMessages));
                thread.Start();

                logTextBox.AppendText("Connected to server" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                logTextBox.AppendText("Error connecting to server: " + ex.Message + Environment.NewLine);
            }
        }

        private void ReceiveMessages()
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesReceived;

            while (isCommunicating)
            {
                bytesReceived = 0;
                try
                {
                    bytesReceived = stream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    isCommunicating = false;
                    logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Connection closed by server" + Environment.NewLine); });
                    break;
                }

                if (bytesReceived == 0)
                {
                    isCommunicating = false;
                    logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Connection closed by server" + Environment.NewLine); });
                    break;
                }

                string message = Encoding.ASCII.GetString(buffer, 0, bytesReceived);




                Console.WriteLine(message);
                Variabili_Client.messaggio = message;
                Console.WriteLine(Variabili_Client.messaggio);




                logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Received: " + message + Environment.NewLine); });
                
            }

            client?.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                logTextBox.AppendText("Not connected to server" + Environment.NewLine);
                return;
            }

            string message = messageTextBox.Text;
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            try
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
                logTextBox.AppendText("Sent: " + message + Environment.NewLine);
            }
            catch
            {
                logTextBox.AppendText("Error sending message" + Environment.NewLine);
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                return;
            }

            try
            {
                isCommunicating = false;
                client.Close();
                client = null;
                logTextBox.AppendText("Disconnected from server" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                logTextBox.AppendText("Error disconnecting from server: " + ex.Message + Environment.NewLine);
            }
        }
        private void btn_Test_Click(object sender, EventArgs e)
        {
            int id = 0;
            Variabili_Client.prova(id);
            lbl_nome_utente.Text = Variabili_Client.prova(id);
            lbl_credito.Text = Variabili_Client.prova(id + 1);
            lbl_balance.Text = Variabili_Client.prova(id + 2);
        }


        private void lbl_Work_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void lbl_refresh_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                logTextBox.AppendText("Not connected to server" + Environment.NewLine);
                //return;
            }

            string indirizzo_xch_cliente = txt_AddresXCH.Text;
            byte[] buffer = Encoding.ASCII.GetBytes(indirizzo_xch_cliente);

            try
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
                logTextBox.AppendText("Sent: " + indirizzo_xch_cliente + Environment.NewLine);
            }
            catch
            {
                logTextBox.AppendText("Error sending message" + Environment.NewLine);
            }

            label4.Visible = false;
            txt_AddresXCH.Visible = false;
            btn_Invio_Address.Visible = false;
            gbox_Plot.Visible = true;
            Connetti_GB.Visible = true;
        }

        private void trackBar_Plot_Scroll(object sender, EventArgs e)
        {
            lbl_Numero_Plot.Text = trackBar_Plot.Value.ToString();
            int Numero_Plot = Convert.ToInt32(lbl_Numero_Plot.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Variabili_Client.ControllaStringaNumerico(txt_plot_Manuale.Text) == false)
                MessageBox.Show("Puoi inserire SOLO numeri!");
            else
            {
                lbl_Numero_Plot.Text = txt_plot_Manuale.Text;
                lbl_plot_manuali.Text = txt_plot_Manuale.Text;
                trackBar_Plot.Value = Convert.ToInt32(lbl_Numero_Plot.Text);
            }
            
        }

        private void Manuale_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Manuale_checkbox.Checked == false)
            {
                lbl_plot_manuali.Visible = false;
                txt_plot_Manuale.Visible = false;
                btn_Conferma.Visible = false;
            }
            if (Manuale_checkbox.Checked == true)
            {
                lbl_plot_manuali.Visible = true;
                txt_plot_Manuale.Visible = true;
                btn_Conferma.Visible = true;
            }
        }

        private void connettiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connetti_GB.Visible = true;
        }
    }
}
