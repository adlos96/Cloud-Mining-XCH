using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Transazioni : Form
    {
        public Transazioni()
        {
            InitializeComponent();
            this.Text = "Transazioni " + Variabili.versione_software;
        }
        private void Transazioni_Load(object sender, EventArgs e)
        {
            double totale_Chia = 0.000000000000;
            double totale_Rendimento = 0.0000;
            lbl_Numero_Utenti.Text = "Transazioni: " + Variabili.conta_numero__transazioni().ToString(); //Conta il numero di Clienti

            string[] elementi_passati = new string[Variabili.conta_numero__transazioni()];
            elementi_passati = Variabili.carica_transazioni();
            for (int x = 0; x < elementi_passati.Length; x++)
            {   //Assegna ad una "stringa" nodo il valore del file .xml
                XmlDocument DocumentoXml = new XmlDataDocument();
                DocumentoXml.Load(elementi_passati[x]);
                XmlNode nodeID = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/ID");
                XmlNode nodeNome_Utente = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Nome_Utente");
                XmlNode nodeWallet = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Wallet");
                XmlNode nodeTransaction_id = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Transaction_id");
                XmlNode nodeTransaction_hash = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Transaction_hash");
                XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Credito");
                XmlNode nodeImporto_Accreditato_Xch = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Importo_Accreditato_Xch");
                XmlNode nodeImporto_Accreditato_euro = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Importo_Accreditato_euro");
                XmlNode nodeRimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Rimanente");
                XmlNode nodePrezzo_Chia = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Prezzo_Chia");
                XmlNode nodeRendimento = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Rendimento");//Rendimento
                XmlNode nodeStato_Transazione = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Stato_Transazione");
                XmlNode nodeBlock_Number = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Block_Number");
                XmlNode nodeData_Time = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Data_Transazione");
                // Fa la somma tra tutte le transazioni inviate e restituisce il totale di xch mandati
                double lettura_Transazione_Xch = 0;
                if (nodeImporto_Accreditato_Xch.InnerText != "None")
                {
                    lettura_Transazione_Xch = Convert.ToDouble(nodeImporto_Accreditato_Xch.InnerText) * 10000;
                    lettura_Transazione_Xch.ToString("0.000000000000");
                    totale_Chia = totale_Chia + lettura_Transazione_Xch;
                    double lettura_rendimento = Convert.ToDouble(nodeRendimento.InnerText);
                    totale_Rendimento = totale_Rendimento + lettura_rendimento;
                }

                //Carica i seguenti elementi nella griglia ... Db
                string[] nuovariga = {nodeID.InnerText, nodeNome_Utente.InnerText, nodeWallet.InnerText, nodeTransaction_id.InnerText, nodeTransaction_hash.InnerText , nodeCredito.InnerText,
                    nodeImporto_Accreditato_Xch.InnerText, nodeImporto_Accreditato_euro.InnerText, nodeRimanente.InnerText, nodePrezzo_Chia.InnerText,
                    nodeRendimento.InnerText, nodeStato_Transazione.InnerText, nodeBlock_Number.InnerText, nodeData_Time.InnerText};
                Database_db.Rows.Add(nuovariga);

                lbl_chia_inviati.Text = "Totale XCH: " + (totale_Chia / 10000).ToString("0.000000000000");
                lbl_utile_prodotto.Text = "Rendimento: " + (totale_Rendimento).ToString("0.0000") + "€";
                this.Database_db.Sort(this.Database_db.Columns["ColBlock_number"], ListSortDirection.Ascending);
            }
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Transazioni transazioni = new Transazioni();
            transazioni.Show();
        }
    }
}
