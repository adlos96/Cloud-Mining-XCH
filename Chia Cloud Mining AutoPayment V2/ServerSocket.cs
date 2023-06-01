using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class ServerSocket : Form
    {
        private TcpListener listener;
        private TcpClient client;
        private bool isRunning;
        private bool isCommunicating;

        public ServerSocket()
        {
            InitializeComponent();
        }

        private void btn_Server_Start_Click(object sender, EventArgs e)
        {

            if (listener != null)
                return;

            IPAddress ipAddress;
            if (!IPAddress.TryParse(ipAddressTextBox.Text, out ipAddress))
            {
                logTextBox.AppendText("Invalid IP address" + Environment.NewLine);
                return;
            }

            int port;
            if (!int.TryParse(portTextBox.Text, out port))
            {
                logTextBox.AppendText("Invalid port number" + Environment.NewLine);
                return;
            }

            listener = new TcpListener(ipAddress, port);
            listener.Start();

            isRunning = true;

            Thread thread = new Thread(new ThreadStart(WaitForClients));
            thread.Start();

            logTextBox.AppendText("Server started" + Environment.NewLine);
        }

        private void btn_Server_Stop_Click(object sender, EventArgs e)
        {
            if (listener == null)
                return;
            try
            {
                isRunning = false;
                listener.Stop();

                // Chiude la connessione del client se presente
                if (client != null && client.Connected)
                    client.Close();

                listener = null;
                logTextBox.AppendText("Server stopped" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                logTextBox.AppendText("Error stopping server: " + ex.Message + Environment.NewLine);
            }
        }

        private void WaitForClients()
        {
            while (isRunning)
            {
                try { client = listener.AcceptTcpClient(); }
                catch { break; }

                Thread thread = new Thread(new ThreadStart(HandleClientCommunication));
                thread.Start();
            }
        }

        private void HandleClientCommunication()
        {
            isCommunicating = true;
            logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Client connected" + Environment.NewLine); });

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesReceived;

            while (isCommunicating)
            {
                bytesReceived = 0;

                try { bytesReceived = stream.Read(buffer, 0, buffer.Length); }
                catch
                {
                    isCommunicating = false;
                    logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Client disconnected" + Environment.NewLine); });
                    break;
                }

                if (bytesReceived == 0)
                {
                    isCommunicating = false;
                    logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Client disconnected" + Environment.NewLine); });
                    break;
                }

                string message = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                logTextBox.Invoke((MethodInvoker)delegate { logTextBox.AppendText("Received: " + message + Environment.NewLine); });
            }

            client?.Close();
        }





        private void ServerSocket_Load(object sender, EventArgs e)
        {

        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            string message = Variabili.messaggio_server;
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            try
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
                logTextBox.AppendText("Sent: " + message + Environment.NewLine);
            }
            catch { logTextBox.AppendText("Error sending message" + Environment.NewLine); }
        }
    }
}
