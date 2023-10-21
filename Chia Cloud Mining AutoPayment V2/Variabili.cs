namespace TCPServer {

    // TODO Tecnicamente questo file "Funzionu.cs possiamo anche eliminarlo"

    internal class Variabili {

        public static bool loop_USDT_Checker = false;
        public static bool loop_Payment_Checker = false;
        public static bool loop_Mempool_Checker = false;

        public static List<string> payment_Log = new List<string>();
        public static List<string> mempool_Log = new List<string>();
        public static List<string> server_Log = new List<string>();
    }
}
