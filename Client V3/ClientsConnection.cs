using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonTcp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client_V3
{
    internal class ClientsConnection
    {
        public static string argomento_Invio = "";
        public static string argomento_Ricevuto = "";
        public static bool client_Connesso = false;

        internal class TestClient
        {
            private static string _ServerIp = "127.1"; // adly.xed.im 185.229.236.183
            //private static string _ServerIp = "185.229.236.183"; // adly.xed.im 185.229.236.183
            private static int _ServerPort = 8443;
            private static bool _Ssl = false;
            private static string _CertFile = "";
            private static string _CertPass = "password";
            private static bool _DebugMessages = true;
            private static bool _AcceptInvalidCerts = true;
            private static bool _MutualAuth = true;
            private static WatsonTcpClient _Client = null;
            private static string _PresharedKey = null;

            public static Task ComunicazioneServer()
            {
                return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    if (!_Client.Send(Encoding.UTF8.GetBytes(argomento_Invio))) Console.WriteLine("Failed");
                    Thread.Sleep(1500);
                });
            }
            public static Task ClientSend(string argomento)
            {
                return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    if (!_Client.Send(Encoding.UTF8.GetBytes(argomento))) Console.WriteLine("Failed");
                    Thread.Sleep(1500);
                });
            }
            public static Task InitializeClient() {
                return Task.Run(async () => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    bool runForever = true;
                    bool success;

                    Console.WriteLine("Client partito");
                    Console.WriteLine($"Use SSL: {_Ssl}");

                    if (_Ssl)
                    {
                        bool supplyCert = true;
                        Console.WriteLine($"Supply SSL certificate: {supplyCert}");

                        if (supplyCert)
                        {
                            _CertFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\TestClient\test.pfx";
                            _CertPass = "password";
                        }

                        _AcceptInvalidCerts = true;
                        _MutualAuth = true;
                        Console.WriteLine($"Accept invalid certs: {_AcceptInvalidCerts}");
                        Console.WriteLine($"Mutually authenticate: {_MutualAuth}");
                    }

                   await ConnectClient();
                });
            }
            public static Task ConnectClient()
            {
                return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    if (_Client != null) _Client.Dispose();
                    if (!_Ssl) _Client = new WatsonTcpClient(_ServerIp, _ServerPort);
                    
                    else
                    {
                        _Client = new WatsonTcpClient(_ServerIp, _ServerPort, _CertFile, _CertPass);
                        _Client.Settings.AcceptInvalidCertificates = _AcceptInvalidCerts;
                        _Client.Settings.MutuallyAuthenticate = _MutualAuth;
                    }
                    client_Connesso = true;
                    _Client.Events.AuthenticationFailure += AuthenticationFailure;
                    _Client.Events.AuthenticationSucceeded += AuthenticationSucceeded;
                    _Client.Events.ServerConnected += ServerConnected;
                    _Client.Events.ServerDisconnected += ServerDisconnected;
                    _Client.Events.MessageReceived += MessageReceived;
                    _Client.Events.ExceptionEncountered += ExceptionEncountered; //???

                    _Client.Callbacks.SyncRequestReceived = SyncRequestReceived;
                    _Client.Callbacks.AuthenticationRequested = AuthenticationRequested;

                    // _Client.Settings.IdleServerTimeoutMs = 5000;
                    _Client.Settings.DebugMessages = _DebugMessages;
                    _Client.Settings.Logger = Logger;
                    _Client.Settings.NoDelay = true;

                    _Client.Keepalive.EnableTcpKeepAlives = true;
                    _Client.Keepalive.TcpKeepAliveInterval = 1;
                    _Client.Keepalive.TcpKeepAliveTime = 1;
                    _Client.Keepalive.TcpKeepAliveRetryCount = 3;

                    _Client.Connect();
                });
            }
            private static void ExceptionEncountered(object sender, ExceptionEventArgs e)
            {
                Console.WriteLine("*** Exception ***");
                Console.WriteLine(e.ToString());
            }
            private static string AuthenticationRequested()
            {
                // return "0000000000000000";
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Server requests authentication");
                Console.WriteLine("Press ENTER and THEN enter your preshared key");
                if (String.IsNullOrEmpty(_PresharedKey)) _PresharedKey = _CertPass;
                return _PresharedKey;
            }
            public static Task Send_Server(string argomento)
            {
                return Task.Run(() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
                {
                    if (!_Client.Send(Encoding.UTF8.GetBytes(argomento))) Console.WriteLine("Failed");
                    Thread.Sleep(5);
                });
            }

            private static void AuthenticationSucceeded(object sender, EventArgs args)
            {
                Console.WriteLine("Authentication succeeded");
            }
            private static void AuthenticationFailure(object sender, EventArgs args)
            {
                Console.WriteLine("Authentication failed");
            }
            private static void MessageReceived(object sender, MessageReceivedEventArgs args)
            {
                Console.Write("Message from server: ");
                if (args.Data == null)
                {
                    Console.WriteLine("[null]");
                    return;
                }
                string messaggio_Ricevuto = Encoding.UTF8.GetString(args.Data); // Ottenimento Risposta dal server

                Console.WriteLine("Messaggio Ricevuto");
                Console.WriteLine("Ricevuto: " + messaggio_Ricevuto);

                var msgArgs = messaggio_Ricevuto.Split('|');
                
                if (msgArgs.Length < 0)
                { Console.WriteLine("[Errore|ServerConnection] >> needed 1 args"); return; }

                switch (msgArgs[0])
                {
                    case "simulazione": Variabili.queue_Simulate_Command.Enqueue(messaggio_Ricevuto); break;
                    case "plotSwap": Variabili.queue_Payment_Command.Enqueue(messaggio_Ricevuto); break;
                    case "home_fee":
                        Variabili.fee_A = msgArgs[1];
                        Variabili.fee_B = msgArgs[2];
                        Variabili.fee_C = msgArgs[3];
                        break;
                    case "balance_P_Update":
                        Variabili.CHIA              = msgArgs[1];
                        Variabili.ATOM              = msgArgs[2];
                        Variabili.CRO               = msgArgs[3];
                        Variabili.LUNA              = msgArgs[4];
                        Variabili.TIA               = msgArgs[5];
                        Variabili.USDT              = msgArgs[6];
                        Variabili.USDC              = msgArgs[7];
                        Variabili.axlUSDC           = msgArgs[8];
                        Variabili.XDLS              = msgArgs[9];
                        Variabili.XUSDT             = msgArgs[10];
                        Variabili.xch_Prelevabili   = Convert.ToDouble(msgArgs[11]).ToString("0.0000000000");
                        Variabili.xch_Pending       = Convert.ToDouble(msgArgs[12]).ToString("0.0000000000");
                        Variabili.chia_prelevati    = msgArgs[13];
                        break;
                    case "timerUSDT":
                        Variabili.status_Pagamento = msgArgs[1];
                        Variabili.importo_USDT = (msgArgs[1]).ToString();
                        break;
                    case "ID":
                        Variabili.id_Client = msgArgs[1];
                        break;
                    case "validate": // Imposta true o false a seconda di se corrisponde o meno
                        Variabili.seed_Phrase = Convert.ToBoolean(msgArgs[1]);
                        break;
                    case "rendita": // Imposta true o false a seconda di se corrisponde o meno
                        Variabili.Rendita_Base_A = Convert.ToDouble(msgArgs[1]);
                        Variabili.Rendita_Base_B = Convert.ToDouble(msgArgs[2]);
                        Variabili.Rendita_Base_C = Convert.ToDouble(msgArgs[3]);
                        Variabili.Rendita_Base_D = Convert.ToDouble(msgArgs[4]);
                        Variabili.Rendita_Base_E = Convert.ToDouble(msgArgs[5]);
                        break;
                    case "bonus": // Imposta true o false a seconda di se corrisponde o meno
                        Variabili.bonus_Deposito = Convert.ToDouble(msgArgs[1]);
                        Variabili.bonus_Innvito_Ref = Convert.ToDouble(msgArgs[2]);
                        Variabili.bonus_Invitato_Ref  = Convert.ToDouble(msgArgs[3]);
                        break;

                    default: Console.WriteLine($"[Errore] >> [{messaggio_Ricevuto}] Comando non riconosciuto"); break;
                }

                var comando = msgArgs[0];
                Console.WriteLine("");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Comando:        {comando}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("");

                switch (comando)
                {
                    case "plotSwap"     : Message_Recived_PlotSwap(msgArgs); break;      // Risposta prezzo per plot
                    case "statusPayment": Message_Recived_StatusPayment(msgArgs); break; // Risposta timer payment usdt
                }

            }
            private static void Message_Recived_PlotSwap(string[] msgArgs)
            {
                argomento_Ricevuto = msgArgs[1];  //Assegnazione a variabile (Vecchio metodo comunicazione)
            }
            private static void Message_Recived_StatusPayment(string[] msgArgs)
            {
                argomento_Ricevuto = msgArgs[1];  //Assegnazione a variabile (Vecchio metodo comunicazione)
            }

            private static SyncResponse SyncRequestReceived(SyncRequest req)
            {
                Console.Write("Message received from server: ");
                if (req.Data != null) Console.WriteLine(Encoding.UTF8.GetString(req.Data));
                else Console.WriteLine("[null]");

                // Uncomment to test timeout
                // Task.Delay(10000).Wait();
                return new SyncResponse(req, "Here is your response!");
            }
            private static void ServerConnected(object sender, ConnectionEventArgs args)
            {
                Console.WriteLine("Server connected"); // Controlla se c'è una connessione col server
                client_Connesso = true;
            }
            private static void ServerDisconnected(object sender, DisconnectionEventArgs args)
            {
                Console.WriteLine("Server disconnected: " + args.Reason.ToString());
                client_Connesso = false;
            }
            private static void Logger(Severity sev, string msg)
            {
                Console.WriteLine("[" + sev.ToString().PadRight(9) + "] " + msg);
            }
            public static async Task Disconnetti()
            {
                if (client_Connesso == true)
                {
                    _Client.Disconnect();
                    client_Connesso = false;
                }
            }

            public static async Task Connessione() {
                if (client_Connesso == false)
                {
                    await InitializeClient();
                    await Send_Server($"auth|{Variabili.wallet}");
                    client_Connesso = true;
                }
            }
        }
    }
}
