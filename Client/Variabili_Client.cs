using System;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    internal class Variabili_Client
    {
        public static string messaggio = "casa | idioma";



        public static string prova(int id) // Questo permette di spezzare la stringa da "casa | idioma" --> casa    idioma  (in maniera distinta)
        {
            string inputString = messaggio;
            char[] delimiterChars = { '|' };
            string[] parts = inputString.Split(delimiterChars);

            string var1 = parts[0]; // var1 sarà "Nome utente"
            string var2 = parts[1]; // var2 sarà "Credito rimanente [€]"
            string var3 = parts[2]; // var3 sarà "Balance [XCH]"
            Console.WriteLine("messaggio_Test: " + messaggio);
            return parts[id];
        }

        public static bool ControllaStringaNumerico(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
