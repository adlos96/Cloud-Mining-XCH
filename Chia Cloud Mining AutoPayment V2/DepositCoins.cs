using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TCPServer
{
    internal class DepositCoins
    {
        class TokenTransactionsResponse
        {
            public string Status { get; set; }
            public TokenTransaction[] Result { get; set; }
        }
        class TokenTransaction
        {
            public string Hash { get; set; }
            public string Input { get; set; }
            public string Value { get; set; }
            public string To { get; set; }
        }

        public static async Task Check_USDT_Deposit(string chain_selection, double importo, string memo, string wallet)
        {
            // Vero Wallet: 0xCF10CaA8e699B8089e408a6980d47672fFA99b3b
            // Test Wallet: 0x533639a1645462F0AdF954097CcD66388B2D6EbB

            string walletAddress = "0xCF10CaA8e699B8089e408a6980d47672fFA99b3b"; // Da cambiare se necessario (Indirizzo di ricezione)

            string usdt_Contract_Address_Polygon = "0xc2132D05D31c914a87C6611C10748AEb04B58e8F"; // Contratto USDT
            string usdt_Contract_Address_Cronos = "0x66e428c3f67a68878562e79A0234c1F83c208770"; // Ether scan
            string usdt_Contract_Address_Ether = "0xdAC17F958D2ee523a2206206994597C13D831ec7"; // Ether scan
            string cronosContractAddress = "0xa0b73e1ff0b80914ab6fe0444e65848c4c34450b"; // Contratto CRO
            string maticContractAddress = "0x0000000000000000000000000000000000001010"; // Contratto MATIC
            string api_Key_Cronos = "BN9QJ6H54YDSIHPNGDJFJE4XKN8DXC1UHP"; // Cronos Scan
            string api_Key_Polygon = "ICXMQ27DW241YGFER63KT882VZBEDHQR43"; // Polygon Scan
            string api_Key_Ether = "E55I3W7UUURKWJ9AQ8YVKHCVJZJ8YDK5R4"; // Ether Scan

            if (chain_selection == "Polygon")
            {
                decimal usdt_Balance_Polygon = await GetTokenBalance_USDT_Polygon(walletAddress, usdt_Contract_Address_Polygon, api_Key_Polygon);
                decimal matic_Balance_Polygon = await GetTokenBalance_MATIC_Polygon(walletAddress, maticContractAddress, api_Key_Polygon);
                Console.WriteLine($"[Poligon] Saldo USDT:   {usdt_Balance_Polygon.ToString("0.00")}");
                Console.WriteLine($"[Poligon] Saldo MATIC:  {matic_Balance_Polygon.ToString("0.00")}");
            }
            if (chain_selection == "Cronos")
            {
                decimal usdt_Balance_Cronos = await GetTokenBalance_USDT_Cronos(walletAddress, usdt_Contract_Address_Cronos, api_Key_Cronos);
                decimal cro_Balance_Cronos = await GetTokenBalance_CRO_Cronos(walletAddress, cronosContractAddress, api_Key_Cronos);
                Console.WriteLine($"[Cronos ] Saldo USDT:   {usdt_Balance_Cronos.ToString("0.00")}");
                Console.WriteLine($"[Cronos ] Saldo CRO:    {cro_Balance_Cronos.ToString("0.00")}");
            }
            if (chain_selection == "Ethereum")
            {
                decimal usdt_Balance_Ether = await GetTokenBalance_USDT_Ether(walletAddress, usdt_Contract_Address_Ether, api_Key_Ether);
                decimal eth_Balance_Ether = await GetTokenBalance_Ether(walletAddress, api_Key_Ether);
                Console.WriteLine($"[Ether  ] Saldo USDT:   {usdt_Balance_Ether.ToString("0.00")}");
                Console.WriteLine($"[Ether  ] Saldo ETH:    {eth_Balance_Ether.ToString("0.00")}");
            }

            if (chain_selection == "Test")
            {
                //Vorrei rimuovere "importo, memo, wallet ↓↓↓  ↑↑↑ in cima alla funzione"
                await Get_Transactions_USDT_Polygon(walletAddress, api_Key_Polygon, usdt_Contract_Address_Polygon, importo, memo, wallet);
            }
        }
        static async Task<decimal> GetTokenBalance_USDT_Polygon(string walletAddress, string tokenContractAddress, string api_Key_Polygon)
        {
            string apiUrl = $"https://api.polygonscan.com/api?module=account&action=tokenbalance&contractaddress={tokenContractAddress}&address={walletAddress}&tag=latest&apikey={api_Key_Polygon}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseData = JObject.Parse(responseContent);
                    if (responseData["status"].ToString() == "1")
                    {
                        string tokenBalance = responseData["result"].ToString();
                        decimal balance = decimal.Parse(tokenBalance) / (decimal)Math.Pow(10, 6); // 18 decimal places for USDT
                        return balance;
                    }
                }
            }
            return 0;
        }
        static async Task Get_Transactions_USDT_Polygon(string walletAddress, string api_Key_Polygon, string tokenContractAddress, double importo, string memo, string wallet)
        {
            using (HttpClient client = new HttpClient())
            {
                // QUI carichiamo i dati dell'utente? da quale database? mmm....

                string url = $"https://api.polygonscan.com/api?module=account&action=tokentx&address={walletAddress}&contractaddress={tokenContractAddress}&startblock=0&endblock=99999999&sort=asc&apikey={api_Key_Polygon}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode){
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Deserializza la risposta JSON per ottenere la lista delle transazioni dei token ERC-20.
                    var result = JsonConvert.DeserializeObject<TokenTransactionsResponse>(responseData);
                    Console.WriteLine("QUII??");
                    Console.WriteLine(result);
                    if (result.Status == "1" && result.Result.Length > 0){

                        // Ci sono transazioni dei token ERC-20 per l'indirizzo specificato.
                        foreach (var tx in result.Result){

                            double USDT_letti = Convert.ToInt32(tx.Value) / Math.Pow(10, 6);
                            string transaction_Memo = tx.Input;

                            if (transaction_Memo.Contains(memo) == true){

                                Console.WriteLine("La transazione corrisponde: " + transaction_Memo);
                                if (USDT_letti == importo){

                                    Console.WriteLine("L'importo ricevuto corrisponde: " + USDT_letti + " USDT");
                                    Database.Update_User_Pending(wallet);

                                    //Elimina l'utente dal client pending
                                    Database.Delete_TimeOut_User(transaction_Memo, wallet);
                                }
                                else if (USDT_letti < importo){
                                    Console.WriteLine("l'importo ricevuto è inferiore all'importo: " + importo + " USDT");
                                    double USDT_rimanenti = importo - USDT_letti;
                                    //eseguire una fuzione a seconda del caso....
                                }
                            }

                            // Ora puoi accedere ai dati desiderati, come memo e importo, dalla transazione del token.
                            Console.WriteLine("");
                            Console.WriteLine("** Transazione Polygon (USDT) **");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine($"Memo: {transaction_Memo}");
                            Console.WriteLine($"Importo: {USDT_letti}");
                            Console.WriteLine($"Tipo di transazione: {(tx.To.ToLower() == walletAddress.ToLower() ? "Entrata" : "Uscita")}");
                            Console.WriteLine($"Hash della transazione: {tx.Hash}");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("");
                        }
                    }else
                        Console.WriteLine("Nessuna transazione dei token ERC-20 trovata per l'indirizzo specificato.");
                }else
                    Console.WriteLine("Errore durante la richiesta API");
            }
        }
        static async Task<decimal> GetTokenBalance_MATIC_Polygon(string walletAddress, string maticContractAddress, string api_Key_Polygon)
        {
            string apiUrl = $"https://api.polygonscan.com/api?module=account&action=tokenbalance&contractaddress={maticContractAddress}&address={walletAddress}&tag=latest&apikey={api_Key_Polygon}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseData = JObject.Parse(responseContent);
                    if (responseData["status"].ToString() == "1")
                    {
                        string tokenBalance = responseData["result"].ToString();
                        decimal balance = decimal.Parse(tokenBalance) / (decimal)Math.Pow(10, 18); // 18 decimal places for USDT
                        return balance;
                    }
                }
            }

            return 0;
        }
        static async Task<decimal> GetTokenBalance_USDT_Cronos(string walletAddress, string tokenContractAddress, string api_Key_Cronos)
        {
            string apiUrl = $"https://api.cronoscan.com/api?module=account&action=tokenbalance&contractaddress={tokenContractAddress}&address={walletAddress}&tag=latest&apikey={api_Key_Cronos}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseData = JObject.Parse(responseContent);
                    if (responseData["status"].ToString() == "1")
                    {
                        string tokenBalance = responseData["result"].ToString();
                        decimal balance = decimal.Parse(tokenBalance) / (decimal)Math.Pow(10, 6); // 18 decimal places for USDT
                        return balance;
                    }
                }
            }
            return 0;
        }
        static async Task<decimal> GetTokenBalance_CRO_Cronos(string walletAddress, string tokenContractAddress, string api_Key_Cronos)
        {
            string apiUrl = $"https://api.cronoscan.com/api?module=account&action=balance&contractaddress={tokenContractAddress}&address={walletAddress}&apikey={api_Key_Cronos}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseData = JObject.Parse(responseContent);
                    if (responseData["status"].ToString() == "1")
                    {
                        string tokenBalance = responseData["result"].ToString();
                        decimal balance = decimal.Parse(tokenBalance) / (decimal)Math.Pow(10, 18); // 8 decimal places for CRO
                        return balance;
                    }
                }
            }
            return 0;
        }
        static async Task<decimal> GetTokenBalance_USDT_Ether(string walletAddress, string tokenContractAddress, string api_Key_Ether)
        {
            string apiUrl = $"https://api.etherscan.io/api?module=account&action=tokenbalance&contractaddress={tokenContractAddress}&address={walletAddress}&tag=latest&apikey={api_Key_Ether}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseData = JObject.Parse(responseContent);
                    if (responseData["status"].ToString() == "1")
                    {
                        string tokenBalance = responseData["result"].ToString();
                        decimal balance = decimal.Parse(tokenBalance) / (decimal)Math.Pow(10, 6); // 18 decimal places for USDT
                        return balance;
                    }
                }
            }

            return 0;
        }
        static async Task<decimal> GetTokenBalance_Ether(string walletAddress, string api_Key_Ether)
        {
            string apiUrl = $"https://api.etherscan.io/api?module=account&action=balance&address={walletAddress}&tag=latest&apikey={api_Key_Ether}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    JObject responseData = JObject.Parse(responseContent);
                    if (responseData["status"].ToString() == "1")
                    {
                        string tokenBalance = responseData["result"].ToString();
                        decimal balance = decimal.Parse(tokenBalance) / (decimal)Math.Pow(10, 18); // 18 decimal places for USDT
                        return balance;
                    }
                }
            }

            return 0;
        }
    }
}
