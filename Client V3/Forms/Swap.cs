using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Client_V3.Forms
{
    public partial class Swap : Form
    {
        double importo_Deposito = 0;
        double importo_Prelievo = 0;

        public Swap()
        {
            InitializeComponent();
        }

        private void Swap_Load(object sender, EventArgs e)
        {
            Coin_Selection_From.Items.Add("XCH");
            Coin_Selection_From.Items.Add("XDLS");
            Coin_Selection_From.Items.Add("XUSDT");
            Coin_Selection_From.Items.Add("axlUSDC");
            Coin_Selection_From.Items.Add("USDT");

            Coin_Selection_To.Items.Add("XCH");
            Coin_Selection_To.Items.Add("XDLS");
            Coin_Selection_To.Items.Add("XUSDT");
            Coin_Selection_To.Items.Add("axlUSDC");
            Coin_Selection_To.Items.Add("USDT");

            Chain_Selection_From.Items.Add("Chia Network");
            Chain_Selection_From.Items.Add("Poligon");
            Chain_Selection_From.Items.Add("Cronos");
            Chain_Selection_From.Items.Add("Terra");

            Chain_Selection_To.Items.Add("Chia Network");
            Chain_Selection_To.Items.Add("Poligon");
            Chain_Selection_To.Items.Add("Cronos");
            Chain_Selection_To.Items.Add("Terra");

            txt_Slippage.Text = "0.50";
            txt_Protocol_Fee.Text = "0.75";
            txt_Tansaction_Fee.Text = "0";
            txt_Bridge_Fee.Text = "0";
        }

        private void Coin_Selection_From_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selezione = Coin_Selection_From.Text;
            switch (selezione) {
                case "XDLS":
                    Chain_Selection_From.Items.Clear();
                    Chain_Selection_From.Items.Add("Chia Network");
                    Chain_Selection_From.Text = "Chia Network";

                    Coin_Selection_To.Items.Clear();
                    Coin_Selection_To.Items.Add("USDT");
                    Coin_Selection_To.Items.Add("XUSDT");
                    Coin_Selection_To.Items.Add("axlUSDC");
                    Coin_Selection_To.Text = "XUSDT";

                    Chain_Selection_To.Items.Clear();
                    Chain_Selection_To.Items.Add("Chia Network");
                    Chain_Selection_To.Items.Add("Terra");
                    Chain_Selection_To.Text = "Chia Network";
                    lbl_Importo_From.Text = "XDLS";
                    lbl_Price_From.Text = "Prezzo: " + Variabili.price_XUSDT + " XDLS";

                    txt_Wallet_Deposit.Text = "Internal";
                    txt_Wallet_Deposit.ReadOnly = true;

                    lbl_Disponibile.Visible = true;
                    txt_Coin_Disponibili.Visible = true;

                    Btn_Swap.Text = "Update Data";
                    break;

                case "XUSDT":
                    Chain_Selection_From.Items.Clear();
                    Chain_Selection_From.Items.Add("Chia Network");
                    Chain_Selection_From.Text = "Chia Network";

                    Coin_Selection_To.Items.Clear();
                    Coin_Selection_To.Items.Add("USDT");
                    Coin_Selection_To.Items.Add("XDLS");
                    Coin_Selection_To.Items.Add("axlUSDC");
                    Coin_Selection_To.Text = "XDLS";
                    lbl_Importo_From.Text = "XUSDT";
                    lbl_Price_From.Text = "Prezzo: " + Variabili.price_XUSDT + " XUSDT";

                    txt_Wallet_Deposit.Text = "Internal";
                    txt_Wallet_Deposit.ReadOnly = true;

                    lbl_Disponibile.Visible = true;
                    txt_Coin_Disponibili.Visible = true;

                    Btn_Swap.Text = "Update Data";

                    break;

                case "XCH":
                    Chain_Selection_From.Items.Clear();
                    Chain_Selection_From.Items.Add("Chia Network");
                    Chain_Selection_From.Text = "Chia Network";

                    Coin_Selection_To.Items.Clear();
                    Coin_Selection_To.Items.Add("XDLS");
                    Coin_Selection_To.Items.Add("XUSDT");
                    Coin_Selection_To.Text = "XDLS";
                    lbl_Importo_From.Text = "XCH";
                    lbl_Price_From.Text = "Prezzo: " + Variabili.price_CHIA + " XCH";

                    txt_Wallet_Deposit.Text = "Wallet Invio";
                    txt_Wallet_Deposit.ReadOnly = false;

                    lbl_Disponibile.Visible = true;
                    txt_Coin_Disponibili.Visible = true;

                    Btn_Swap.Text = "Update Data";
                    break;

                case "USDT":
                    Chain_Selection_From.Items.Clear();
                    Chain_Selection_From.Items.Add("Polygon");
                    Chain_Selection_From.Text = "Polygon";

                    Coin_Selection_To.Items.Clear();
                    Coin_Selection_To.Items.Add("XDLS");
                    Coin_Selection_To.Items.Add("XUSDT");
                    Coin_Selection_To.Items.Add("axlUSDC");
                    Coin_Selection_To.Text = "XUSDT";
                    lbl_Importo_From.Text = "USDT";
                    lbl_Price_From.Text = "Prezzo: " + Variabili.price_USDT + " USDT";

                    txt_Wallet_Deposit.Text = "Wallet Invio";
                    txt_Wallet_Deposit.ReadOnly = false;

                    lbl_Disponibile.Visible = true;
                    txt_Coin_Disponibili.Visible = true;

                    Btn_Swap.Text = "Update Data";
                    break;

                case "axlUSDC":
                    Chain_Selection_From.Items.Clear();
                    Chain_Selection_From.Items.Add("Terra");
                    Chain_Selection_From.Text = "Terra";

                    Coin_Selection_To.Items.Clear();
                    Coin_Selection_To.Items.Add("XDLS");
                    Coin_Selection_To.Items.Add("XUSDT");
                    Coin_Selection_To.Items.Add("USDT");
                    Coin_Selection_To.Text = "XUSDT";
                    lbl_Importo_From.Text = "axlUSDC";
                    lbl_Price_From.Text = "Prezzo: " + Variabili.price_axlUSDC + " axlUSDC";

                    txt_Wallet_Deposit.Text = "Wallet Invio";
                    txt_Wallet_Deposit.ReadOnly = false;

                    lbl_Disponibile.Visible = true;
                    txt_Coin_Disponibili.Visible = true;

                    Btn_Swap.Text = "Update Data";
                    break;
            }
        }

        private void Coin_Selection_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selezione = Coin_Selection_To.Text;
            switch (selezione) {
                case "XUSDT":
                    Chain_Selection_To.Items.Clear();
                    Chain_Selection_To.Items.Add("Chia Network");
                    Chain_Selection_To.Text = "Chia Network";

                    txt_Wallet_Withdrawal.Text = "Internal";
                    txt_Wallet_Withdrawal.ReadOnly = true;

                    txt_Tansaction_Fee.Text = "0.15";
                    txt_Bridge_Fee.Text = "0";
                    txtlbl_Bridge_Fee.Text = "XUSDT";
                    txtlbl_Transaction_Fee.Text = "XUSDT";
                    lbl_Importo_To.Text = "XUSDT";
                    txt_Coin_Disponibili.Text = Variabili.XUSDT_Swap;
                    lbl_Price_To.Text = "Prezzo: " + Variabili.price_XUSDT + " XUSDT";

                    if (Chain_Selection_From.Text != Chain_Selection_To.Text)
                        txt_Bridge_Fee.Text = "1.50";
                    break;
                case "XDLS":
                    Chain_Selection_To.Items.Clear();
                    Chain_Selection_To.Items.Add("Chia Network");
                    Chain_Selection_To.Text = "Chia Network";

                    txt_Wallet_Withdrawal.Text = "Internal";
                    txt_Wallet_Withdrawal.ReadOnly = true;

                    txt_Tansaction_Fee.Text = "0.13";
                    txt_Bridge_Fee.Text = "0";
                    txtlbl_Bridge_Fee.Text = "XDLS";
                    txtlbl_Transaction_Fee.Text = "XDLS";
                    lbl_Importo_To.Text = "XDLS";
                    txt_Coin_Disponibili.Text = Variabili.XDLS_Swap;
                    lbl_Price_To.Text = "Prezzo: " + Variabili.price_XDLS + " XDLS";

                    if (Chain_Selection_From.Text != Chain_Selection_To.Text)
                        txt_Bridge_Fee.Text = "1.50";
                    break;
                case "XCH":
                    Chain_Selection_To.Items.Clear();
                    Chain_Selection_To.Items.Add("Chia Network");
                    Chain_Selection_To.Text = "Chia Network";

                    txt_Wallet_Withdrawal.Text = "Wallet Ricezione";
                    txt_Wallet_Withdrawal.ReadOnly = false;

                    txt_Tansaction_Fee.Text = "0.0024";
                    txt_Bridge_Fee.Text = "0";
                    txtlbl_Bridge_Fee.Text = "XCH";
                    txtlbl_Transaction_Fee.Text = "XCH";
                    lbl_Importo_To.Text = "XCH";
                    txt_Coin_Disponibili.Text = Variabili.CHIA_Swap;
                    lbl_Price_To.Text = "Prezzo: " + Variabili.price_CHIA + " XCH";
                    break;
                case "axlUSDC":
                    Chain_Selection_To.Items.Clear();
                    Chain_Selection_To.Items.Add("Terra");
                    Chain_Selection_To.Text = "Terra";

                    txt_Wallet_Withdrawal.Text = "Wallet Ricezione";
                    txt_Wallet_Withdrawal.ReadOnly = false;

                    txt_Tansaction_Fee.Text = "0.12";
                    txt_Bridge_Fee.Text = "1.50";
                    txtlbl_Bridge_Fee.Text= "axlUSDC";
                    txtlbl_Transaction_Fee.Text = "axlUSDC";
                    lbl_Importo_To.Text = "axlUSDC";
                    txt_Coin_Disponibili.Text = Variabili.axlUSDC_Swap;
                    lbl_Price_To.Text = "Prezzo: " + Variabili.price_axlUSDC + " axlUSDC";

                    if (Chain_Selection_From.Text != Chain_Selection_To.Text)
                        txt_Bridge_Fee.Text = "1.50";

                    break;
                case "USDT":
                    Chain_Selection_To.Items.Clear();
                    Chain_Selection_To.Items.Add("Poligon");
                    Chain_Selection_To.Text = "Poligon";

                    txt_Wallet_Withdrawal.Text = "Wallet Ricezione";
                    txt_Wallet_Withdrawal.ReadOnly = false;

                    txt_Tansaction_Fee.Text = "0.15";
                    txt_Bridge_Fee.Text = "1.50";
                    txtlbl_Bridge_Fee.Text = "USDT";
                    txtlbl_Transaction_Fee.Text = "USDT";
                    lbl_Importo_To.Text = "USDT";
                    txt_Coin_Disponibili.Text = Variabili.USDT_Swap;
                    lbl_Price_To.Text = "Prezzo: " + Variabili.price_USDT + " USDT";

                    break;
            }
        }

        private void checkB_Show_Client_Balance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkB_Show_Client_Balance.Checked == true) Panel_Credito_Utente.Visible = true;
            else Panel_Credito_Utente.Visible = false;
        }

        private async void Btn_Swap_Click(object sender, EventArgs e)
        {
            if (Btn_Swap.Text == "Update Data")
            {
                Btn_Swap.Enabled = false;

                //Codice Richiesta parametri per lo swap ed aggiornamento gui client con i dati aggiornati...

                try
                {
                    if (double.TryParse(txt_Coin_Deposit.Text, out double depositAmount) && depositAmount > 0)
                    {
                        importo_Deposito = depositAmount;
                        Btn_Swap.Text = "Swap";
                        await ClientsConnection.TestClient.Send_Server(
                            //"update_swap|Coin_From|Coin_to|Network_From|Network_To|Amount|Slippage|Protocol_Fee|Transaction_Fee|Bridge_Fee|");
                            "update_swap|Coin_From|Coin_to|Network_From|Network_To|Amount||");
                    }
                    else
                        MessageBox.Show("L'importo deve essere maggiore di zero."); // Gestisci il caso in cui il valore convertito è non positivo (<= 0)
                }
                catch (FormatException)
                { MessageBox.Show("Inserisci un valore numerico valido."); } // Gestisci il caso in cui il testo non può essere convertito in un numero
                catch (OverflowException)
                { MessageBox.Show("Il valore inserito è troppo grande."); } // Gestisci il caso in cui il testo rappresenta un numero troppo grande per essere convertito
                catch (Exception ex)
                { MessageBox.Show($"Si è verificato un errore: {ex.Message}"); } // Gestisci altre eccezioni non previste

                //End code

                await Sleep(5000);
                Btn_Swap.Enabled = true;
            }
            if (Btn_Swap.Text == "Swap")
            {
                Btn_Swap.Enabled = false;

                //Codice Controllo parametri Swap (Prezzi, Disponibilità, etc... etc...)

                //End Code
                Sleep(5000);
                Btn_Swap.Enabled = true;
            }
        }

        public Task Sleep(int millisecondi)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(millisecondi);
            });
        }
    }
}
