using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Client : Form
    {
        private TcpClient client;
        private bool isCommunicating;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.Text = "Client: ";
            lbl_versione.Text = "0.01.00";
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
                logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Received: " + message + Environment.NewLine); });

                Console.WriteLine(message);

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
    }
}
