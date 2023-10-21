using System.Data.SQLite;
using System;
using System.Diagnostics;
using System.IO;

namespace TCPServer
{
    public class Database
    {
        private static Database? _instance;
        private static SQLiteConnection? _con;
        private Database()
        {
            Console.WriteLine("[DB|INFO] > Setting up Database");
            var cs = "Data Source=:memory:";
            if (Env.DB_PATH != null) cs = "URI=file:" + Env.DB_PATH; // Env.DB_PATH
            Console.WriteLine($"[DB|LOG] > SQLite Instance: {cs}");

            _con = new SQLiteConnection(cs);
            _con.Open();

            using var cmd = new SQLiteCommand("SELECT SQLITE_VERSION()", _con);
            var version = cmd.ExecuteScalar()?.ToString();
            Console.WriteLine($"[DB|LOG] > SQLite version: {version}");
        }
        public static Database? Instance()
        {
            return _instance ??= new Database();
        }
        public static void User_Add_DB()
        {
            var users_Pending = Users_Pending();
            foreach (var user in users_Pending)
                Aggiunta_Utenti(user);
        }

        public static void Test()
        {
            var command = Task.Run(() => Payment.Payment_Users());

            // Crea un nuovo processo PowerShell per avviare una nuova finestra
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-NoExit -NoProfile -Command \"{command}\"",
                UseShellExecute = true
            };

            Process newPowerShellProcess = new Process { StartInfo = psi };
            newPowerShellProcess.Start();

            // Attendere il completamento del processo
            newPowerShellProcess.WaitForExit();
        }
        public static void Aggiunta_Utenti(string[] user)
        {
            // Caricare di dati dal database "User_Pending"
            int ID = Convert.ToInt32(user[0]);
            var wallet = user[1];
            var plot = user[2];
            var invito_Referal = user[3];
            var fee = user[4];

            //var wallet = "xch10gww22w6nf58nar6ca22e8xu7ms6nldmxr94j9ye9dz2f238fdcqze530c";     //Client
            var deposito = Convert.ToInt32(plot);            //Client
            double bonus = 0.18;
            var tantum = 0.0000;
            var referal_Code = "Codie_Refeal";
            var referal_Invite = invito_Referal;        //Client
            var Fee = "0.000000000001";
            var rendimento = 0;                 // 0|1
            var datatime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            const int costante_Base_Prezzo = 200;     //Costante calcolo daily payment
            const double costante_Base = 0.10;        //Costante calcolo daily payment

            //Papiro
            if ((bonus * 100) > 18)
            {
                Console.WriteLine($"[Errore|User_Add] >> Il bonus applicato è troppo alto: {bonus}%");
                return;
            }
            double daily_Reward = costante_Base * deposito / costante_Base_Prezzo;       //Quantità pagata giornalmente
            double credito = deposito + deposito * bonus;    //Calcola il credito + il bonus
            double credito_Rimasto = credito;

            //Applicare il bonus referal se il codice referal corrisponde con quello fornito
            var usersReferal = Apply_User_Referal_Bonus();
            foreach (var users in usersReferal)
                Apply_Referal_Bonus(users, referal_Invite, deposito);

            //Effettuare controllo sul wallet, se è già presente aggiungere il deposito, il credito, ed il credito rimanente
            var user_Check_Wallet = Check_User_Wallet();
            foreach (var users in user_Check_Wallet)
                if (users.Contains(wallet) == true)
                {
                    Console.WriteLine($"[Errore|Databse] > Wallet [{wallet}] già presente nel database");
                    Console.WriteLine("Conseguenze.... ↓↓↓↓↓↓↓↓ Da programmare... ↓↓↓↓↓↓↓↓");
                }

            //Generare un codice referal
            referal_Code = Payment.Generate_Random_Code(10);

            if (Utenti_Registrati() > 0 )
            {
                bool check_Random_Referal_Code = true;
                while (check_Random_Referal_Code == true)
                {
                    //Controllo che il codice refal non sia già presente
                    var user_Check_ReferalCode = Check_User_Referal_Code();
                    foreach (var users in user_Check_ReferalCode)
                        if (users.Contains(referal_Code) == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"[Errore|Databse] > Referal Code [{referal_Code}] già presente nel database");
                            referal_Code = Payment.Generate_Random_Code(10);
                            Console.WriteLine("Codice referal rigerato correttamente!");
                            Console.WriteLine("");
                        }
                        else
                            check_Random_Referal_Code = false;
                }
                Console.WriteLine($"Utenti Registrati: {Utenti_Registrati()}");
            }

            AddUser(wallet, deposito.ToString("0.0000"), credito.ToString("0.0000"), credito_Rimasto.ToString("0.0000"), daily_Reward.ToString("0.0000"), (bonus * 100).ToString(), tantum.ToString("0.0000"), referal_Code, referal_Invite, Fee, rendimento, datatime, ID);
        }

        public static async void AddUser(string wallet, string deposito, string credito, string credito_Rimasto, string daily_Reward, string bonus, string tantum,
                            string referal_Code, string referal_Invite, string fee, int rendimento, string datatime, int ID)
        {
            var utenti_Registrati = Utenti_Registrati();
            await Payment.Numero_Coins_Protocol(); // Numero di utenti che possono essere gestiti dal software
            if (Payment.numero_Max_Utenti < utenti_Registrati)
            {
                Console.WriteLine($"Numero massimo utenti: {Payment.numero_Max_Utenti} Utenti Registrati: {utenti_Registrati}");
                return;
            }
            var stm = $"INSERT INTO Users (Wallet, Deposito, Credito, Credito_Rimasto, Daily_Reward, Bonus, Tantum, Referal_Code, Referal_Invite, Fee, Rendimento_Bool, DataTime) VALUES " +
                      $"(\"{wallet}\", \"{deposito}\", \"{credito}\", \"{credito_Rimasto}\", \"{daily_Reward}\", \"{bonus}\", \"{tantum}\"," +
                      $"\"{referal_Code}\",\"{referal_Invite}\", \"{fee}\", \"{rendimento}\", \"{datatime}\");";

            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
            Console.WriteLine("");
            Console.WriteLine(" ** Utente Aggiunto ** ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Wallet:         {wallet}");
            Console.WriteLine($"Deposito:       {deposito} Euro");
            Console.WriteLine($"Pagamento:      {daily_Reward} Euro");
            Console.WriteLine($"Referal Invite: {referal_Invite}");
            Console.WriteLine($"Referal Code:   {referal_Code}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"L'utente {wallet} è stato aggiuto al database (righe aggiunte: {rowNumber}) ");
            Console.WriteLine($"------------------------");
            Console.WriteLine($"Utenti aggiunti nel DB: {rowNumber} ");

            if (rowNumber == 1)
                Delete_Pending_Users(ID); //Elimina l'utente una volta aggiunto nel database
        }
        public static void Add_New_Transaction(int user_ID, string Tx, string tx_Hash, string xch_Payed, string euro_Payed, string chia_Price,
                                    string reward, string status, string block_Number, string dataTime)
        {
            var stm = $"INSERT INTO \"Transaction\" (User_ID, Tx, Tx_Hash, Xch_Payed, Euro_Payed, Chia_Price, Reward, Status, Block_Number, Data_Time) VALUES " +
                      $"(\"{user_ID}\", \"{Tx}\", \"{tx_Hash}\", \"{xch_Payed}\", \"{euro_Payed}\", \"{chia_Price}\"," +
                      $"\"{reward}\",\"{status}\",\"{Convert.ToInt32(block_Number)}\", \"{dataTime}\");";

            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
            Variabili.payment_Log.Add($"Transazione aggiunta | User ID: {user_ID}");
        }
        public static async Task User_Transaction_Request(string guid, string Transaction_Memo, string timer, string wallet, string chain)
        {
            var datatime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            var stm = $"INSERT INTO Pending_Transactions_Request (Guid, Transaction_Memo, Data_Time, Timer, wallet, Chain) VALUES " +
                      $"(\"{guid}\", \"{Transaction_Memo}\", \"{datatime}\", \"{timer}\", \"{wallet}\", \"{chain}\");";

            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();

            Console.WriteLine("");
            Console.WriteLine(" ** Richiesta Transazione In Coda ** ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Guid:                   {guid}");
            Console.WriteLine($"Transaction_Memo:       {Transaction_Memo}");
            Console.WriteLine($"timer:                  {timer}");
            Console.WriteLine($"datatime:               {datatime}");
            Console.WriteLine("----------------------------------");
        }
        public static async Task Add_Client_Pending(string wallet, int plot, string USDT, string referal_Code, string fee, string clientGuid)
        {
            string EURO = plot.ToString();
            var datatime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            var stm = $"INSERT INTO Users_Pending (Wallet, Plot, USDT, EURO, Referal_Code, Fee, DataTime) VALUES " +
                      $"(\"{wallet}\", \"{plot}\", \"{USDT}\", \"{EURO}\", \"{referal_Code}\", \"{fee}\", \"{datatime}\");";

            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();

            Console.WriteLine("** Dati Client **");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Client ID:          {clientGuid}");
            Console.WriteLine($"Wallet:             {wallet}");
            Console.WriteLine($"Plot Number:        {plot}");
            Console.WriteLine($"Deposito (USDT):    {USDT}");
            Console.WriteLine($"Deposito (EURO):    {plot}"); // L'acquisto di un plot aggiunge 1€ al deposito dell'utente
            Console.WriteLine($"Referal Code:       {referal_Code}");
            Console.WriteLine($"Fee:                {fee}");
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("");
            Console.WriteLine(" ** Utente In Coda ** ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Wallet:         {wallet}");
            Console.WriteLine($"Deposito:       {EURO} Euro");
            Console.WriteLine($"Plot:           {plot} Plot");
            Console.WriteLine($"USDT:           {USDT} USDT");
            Console.WriteLine($"Referal Code:   {referal_Code}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"L'utente {wallet} è stato aggiuto al database User_Pending (righe aggiunte: {rowNumber}) ");
            Console.WriteLine($"Utenti aggiunti: {rowNumber} ");
        }
        public static List<string[]> Get_Users_To_Pay()
        {
            //Codice per leggere una query
            var users_To_Pay = new List<string[]>();

            const string stm2 = "SELECT id, Wallet, Deposito, Credito, Credito_Rimasto, Daily_Reward, Tantum, Fee, Rendimento_Bool FROM Users WHERE NOT Credito_Rimasto = 0";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt16(0);
                var wallet = rdr.GetString(1);
                var deposito = rdr.GetString(2);
                var credito = rdr.GetString(3);
                var creditoRimasto = rdr.GetString(4);
                var daily_Reward = rdr.GetString(5);
                var tantum = rdr.GetString(6);
                var fee = rdr.GetString(7);
                var rendimento_Bool = rdr.GetInt32(8).ToString();
                var user = new string[] { id.ToString(), wallet, deposito, credito, creditoRimasto, daily_Reward, tantum, fee, rendimento_Bool };
                users_To_Pay.Add(user);

                Payment.protocol_Pay_Euro += Convert.ToDouble(daily_Reward);
            }
            //return (id.ToString(), wallet, deposito, credito, credito_Rimasto, bonus, tantum, referal_Code, referal_Invite, Fee, Rendimento.ToString(), timestaamp);
            return users_To_Pay;
        }
        public static List<string[]> Get_Users_mempool()
        {
            var users_Tx = new List<string[]>();
            const string stm2 = $"SELECT Tx_ID, TX FROM \"Transaction\" WHERE Block_Number = \"0\"";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt16(0);
                var Tx = rdr.GetString(1);

                var user = new string[] { id.ToString(), Tx };
                users_Tx.Add(user);
                Variabili.mempool_Log.Add($"--> ID: {id} Tx: {Tx}");
                Mempool.totale_Transazioni_mempool++;
            }
            //return (id.ToString(), wallet, deposito, credito, credito_Rimasto, bonus, tantum, referal_Code, referal_Invite, Fee, Rendimento.ToString(), timestaamp);
            return users_Tx;
        }
        public static List<string[]> Users_Pending()
        {
            var users_Pending = new List<string[]>();

            const string stm2 = "SELECT ID, Wallet, Plot, Referal_Code, fee FROM Users_Pending";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt16(0);
                var wallet = rdr.GetString(1);
                var plot = rdr.GetInt32(2);
                var referal_Code = rdr.GetString(3);
                var fee = rdr.GetString(4);
                var user = new string[] { id.ToString(), wallet, plot.ToString(), referal_Code, fee };
                users_Pending.Add(user);
            }
            return users_Pending;
        }
        public static List<string[]> Apply_User_Referal_Bonus()
        {
            var users_For_Referal = new List<string[]>();

            const string stm2 = "SELECT id, Credito, Credito_Rimasto, Referal_Code FROM users";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt16(0);
                var credito = rdr.GetString(1);
                var creditoRimasto = rdr.GetString(2);
                var referal_Code = rdr.GetString(3);
                var user = new string[] { id.ToString(), credito, creditoRimasto, referal_Code };
                users_For_Referal.Add(user);
            }
            return users_For_Referal;
        }
        public static List<string[]> Check_User_Referal_Code()
        {
            var wallet_Check = new List<string[]>();

            const string stm2 = "SELECT id, Referal_Code FROM users";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read()){

                int id = rdr.GetInt16(0);
                var referal_Code = rdr.GetString(1);
                var user = new string[] { id.ToString(), referal_Code };
                wallet_Check.Add(user);

            }return wallet_Check;
        }
        public static List<string[]> Check_User_Wallet()
        {
            var wallet_Check = new List<string[]>();

            const string stm2 = "SELECT id, Wallet FROM users";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read()){

                int id = rdr.GetInt16(0);
                var wallet = rdr.GetString(1);
                var user = new string[] { id.ToString(), wallet };
                wallet_Check.Add(user);

            }return wallet_Check;
        }
        public static List<string[]> Check_Client_Memo()
        {
            var client_Memo_Check = new List<string[]>();

            const string stm2 = "SELECT ID, Guid, Transaction_Memo, Data_Time, Timer, Wallet, Chain FROM Pending_Transactions_Request";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read()){

                int id = rdr.GetInt32(0);
                var guID = rdr.GetString(1);
                var transaction_Memo = rdr.GetString(2);
                var datatime = rdr.GetString(3);
                var timer = rdr.GetInt32(4);
                var wallet = rdr.GetString(5);
                var chain = rdr.GetString(6);
                var user = new string[] { id.ToString(), guID, transaction_Memo, datatime.ToString(), timer.ToString(), wallet, chain };
                client_Memo_Check.Add(user);

            }return client_Memo_Check;
        }
        public static int Utenti_Registrati()
        {
            const string stm = $"SELECT COUNT(*) FROM users WHERE NOT Credito_Rimasto = 0";
            using var command = new SQLiteCommand(stm, _con);

            // Esecuzione del comando e lettura del conteggio
            int utenti_Registrati = Convert.ToInt32(command.ExecuteScalar());
            return utenti_Registrati;
        }
        public static int Utenti_Pending()
        {
            const string stm = $"SELECT COUNT(*) FROM Users_Pending";
            using var command = new SQLiteCommand(stm, _con);

            // Esecuzione del comando e lettura del conteggio
            int utenti_Pending = Convert.ToInt32(command.ExecuteScalar());
            return utenti_Pending;
        }
        public static int Client_Pending()
        {
            const string stm = $"SELECT COUNT(*) FROM Pending_Transactions_Request";

            using var command = new SQLiteCommand(stm, _con);
            // Esecuzione del comando e lettura del conteggio
            int utenti_Pending = Convert.ToInt32(command.ExecuteScalar());

            return utenti_Pending;
        }
        public static void Update_User_Balance(int ID, string new_Credito_Rimasto)
        {
            // Aggiorna il credito rimasto dell'utente
            var stm = $"UPDATE Users SET Credito_Rimasto = \"{new_Credito_Rimasto}\" WHERE id = {ID}";
            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
        }
        public static void Update_Transaction_Block(int id, string? blockNumber, string txnHash)
        {
            // Aggiorna la transazione utente
            // string stm = $"UPDATE \"Transaction\" SET Block_Number = \"{block_Number}\" WHERE Tx_ID = {ID};";
            var stm = $"UPDATE \"Transaction\" SET Tx_Hash = \"{txnHash}\", Status = \"Confirmed\", Block_Number = \"{blockNumber}\" WHERE Tx_ID = {id};";

            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
        }
        public static void Update_Client_Data(int ID, string timer)
        {
            // Aggiorna il credito rimasto dell'utente
            var stm = $"UPDATE Pending_Transactions_Request SET Timer = \"{timer}\" WHERE ID = {ID}";
            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
        }
        public static void Update_User_Pending(string wallet)
        {
            // Aggiorna il credito rimasto dell'utente
            var stm = $"UPDATE Users_Pending SET Payed_Bool = \"{1}\" WHERE Wallet = {wallet}";
            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
        }
        public static async Task User_Transaction_Request_Update(string guid)
        {
            var stm = $"DELETE FROM Pending_Transactions_Request WHERE Guid = {guid}";
            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
            Console.WriteLine("Timer: \"Time Out\"");
            Console.WriteLine($"Pending transaction Deleted \"Pending\": [guid: {guid}]");
            Console.WriteLine($"------------------------");
        }
        static void Apply_Referal_Bonus(string[] users, string referal_Code, double deposito)
        {
            //Aggiunge il deposito all'utente che è presente nel database se il codice referal corrisponde
            string ID = users[0];
            string credito = users[1];
            string credito_Rimasto = users[2];
            string referal_Invite = users[3];

            if (referal_Invite == referal_Code)
            {
                Console.WriteLine("");
                Console.WriteLine("Check Referal [Trovato]");
                Console.WriteLine("");
                Console.WriteLine(" * Load User DB Info *");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("User ID: " + ID);
                Console.WriteLine($"Credito Precedente: {credito} Euro");
                Console.WriteLine($"Credito Rimasto:    {credito_Rimasto} Euro");
                Console.WriteLine($"Refeal Utente DB:   {referal_Invite} REF");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("** Nuovo Credito **");
                Console.WriteLine("----------------------------------------------");

                double credito_Calcolato = deposito * Payment.bonus_Referal / 100;
                double new_Credito = Convert.ToDouble(credito) + credito_Calcolato;
                double new_Credito_Rimasto = Convert.ToDouble(credito_Rimasto) + credito_Calcolato;

                Console.WriteLine($"Credito Totale:     {new_Credito.ToString("0.0000")} Euro");
                Console.WriteLine($"Credito Rimanente:  {new_Credito_Rimasto.ToString("0.0000")} Euro");
                Console.WriteLine($"Bonus applicato:    {Payment.bonus_Referal} %");
                Console.WriteLine($"Credito Aggiunto:   {credito_Calcolato.ToString("0.0000")} Euro");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("");
                // Aggiorna il credito rimasto dell'utente
                var stm = $"UPDATE Users SET Credito = \"{new_Credito.ToString("0.0000")}\", Credito_Rimasto = \"{new_Credito_Rimasto.ToString("0.0000")}\" WHERE id = {ID}";
                using var cmd = new SQLiteCommand(stm, _con);
                var rowNumber = cmd.ExecuteNonQuery();
            }
            else
                Console.WriteLine($"Referal non corrisponde | Utente saltato | User ID: {ID}");
        }
        public static async Task<int> Numero_Plot()
        {
            int id = 0;
            int plot_Number = 0;
            int plot_Reserve = 0;

            const string stm2 = "SELECT ID, Plot_Farming, Plot_Reserve FROM Dati";
            using var cmd2 = new SQLiteCommand(stm2, _con);
            using var rdr = cmd2.ExecuteReader();
            while (rdr.Read())
            {
                id = rdr.GetInt16(0);
                plot_Number = Convert.ToInt32(rdr.GetInt32(1));
                plot_Reserve = Convert.ToInt32(rdr.GetInt32(2));

            }
            if (plot_Number == 0)
            {
                Variabili.payment_Log.Add("");
                Variabili.payment_Log.Add("** Plot **");
                Variabili.payment_Log.Add("-------------------------------------");
                Variabili.payment_Log.Add($"Totale:       {plot_Number}");
                Variabili.payment_Log.Add("-------------------------------------");
            }
            else
            {
                Variabili.payment_Log.Add("");
                Variabili.payment_Log.Add("** Plot **");
                Variabili.payment_Log.Add("-------------------------------------");
                Variabili.payment_Log.Add($"Totale:       {plot_Number}");
                Variabili.payment_Log.Add($"Riserva:      {plot_Reserve}");
                Variabili.payment_Log.Add($"Disponiili:   {plot_Number - plot_Reserve}");
                Variabili.payment_Log.Add("-------------------------------------");
                return plot_Number;
            }
            return plot_Number;
        }
        public static Task Check_Recived_USDT()
        {
            return Task.Run(async() => //Crea un task e gli assegna un blocco istruzioni da eseguire.
            {
                int timer_Sleep = 1; // Minuti
                int numero_Cicli = 0;
                bool loop_Recived_Usdt = true;

                Console.WriteLine("Timer: " + timer_Sleep * 60 + "s");
                Thread.Sleep(timer_Sleep * 60 * 1000);

                if (Variabili.loop_USDT_Checker == false) return; //Controllo
                while (loop_Recived_Usdt == true)
                {
                    int client_Attesa = Client_Pending(); // Funzione conteggio numeri utente
                    var data_Client = Check_Client_Memo();

                    if (client_Attesa == 0)
                    {
                        Console.WriteLine($"[Database|USDT_Loop] > Ciclo interrotto, utenti in attesa: {client_Attesa}");
                        loop_Recived_Usdt = false;
                        Variabili.loop_USDT_Checker = loop_Recived_Usdt;
                        return;
                    }

                    foreach (var user in data_Client)
                    {
                        int ID = Convert.ToInt32(user[0]);
                        string guID = user[1];
                        string transaction_Memo = user[2];
                        string datatime = user[3];
                        int tempo = Convert.ToInt32(user[4]);
                        string wallet = user[5];
                        string chain = user[6];

                        double importo = 0.8;

                        //Controllo se c'è una transazione con la memo corrispondente
                        await DepositCoins.Check_USDT_Deposit("Test", importo, "Memo", wallet);

                        //Se l'importo è inferiore va deciso se attendere l'importo mancante oppure invalidare l'acquisto


                        Console.WriteLine("Tempo: " + tempo);
                        if (tempo == 0)
                            await Delete_TimeOut_User(transaction_Memo, wallet);

                        if (numero_Cicli > 0)
                        {
                            tempo = tempo - timer_Sleep;
                            //Update dati client aggiornati - "Tempo"
                            Update_Client_Data(ID, tempo.ToString());
                        }
                    }
                    //Calcolo del tempo impegato per eseguire tutto il foreach

                    numero_Cicli++;
                    Variabili.loop_USDT_Checker = loop_Recived_Usdt;
                    Console.WriteLine("Timer: " + timer_Sleep * 60 * 1000);
                    Thread.Sleep(timer_Sleep * 60 * 1000);
                }
            });
        }
        public static async Task Delete_TimeOut_User(string memo, string wallet)
        {
            string stm = $"DELETE FROM Pending_Transactions_Request WHERE Transaction_Memo = \"{memo}\" and Wallet = \"{wallet}\"";
            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
            Console.WriteLine($"");
            Console.WriteLine($"** Delete TimeOut User **");
            Console.WriteLine($"------------------------");
            Console.WriteLine($"Utente Eliminato \"Pending_Transactions_Request\" ");
            Console.WriteLine($"Pending request:   {rowNumber}");
            Console.WriteLine($"Wallet: {wallet}");
            Console.WriteLine($"Memo:   {memo}");
            Console.WriteLine($"------------------------");
            Console.WriteLine($"");
        }
        static void Delete_Pending_Users(int ID)
        {
            var stm = $"DELETE FROM Users_Pending WHERE ID = {ID}";
            using var cmd = new SQLiteCommand(stm, _con);
            var rowNumber = cmd.ExecuteNonQuery();
            Console.WriteLine($"Utente Eliminato \"Pending\": [ID {ID}]");
            Console.WriteLine($"------------------------");
        }
    }
}
