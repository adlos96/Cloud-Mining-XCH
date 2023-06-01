using System;
using System.Windows.Forms;
using System.Xml;

namespace Chia_Cloud_Mining_AutoPayment_V2
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }
        private void Database_Load(object sender, EventArgs e)
        {
            double _investimento = 0;
            double _credito = 0;
            lbl_Numero_Utenti.Text = "Utenti: " + Variabili.conta_numero_elementi().ToString(); //Conta il numero di Clienti

            string[] elementi_passati = new string[Variabili.conta_numero_elementi()];
            elementi_passati = Variabili.carica_contenuto_elementi();
            for (int x = 0; x < elementi_passati.Length; x++)
            {
                //Assegna ad una "stringa" nodo il valore del file .xml
                XmlDocument DocumentoXml = new XmlDataDocument();
                DocumentoXml.Load(elementi_passati[x]);
                string idContatto = System.IO.Path.GetFileNameWithoutExtension(elementi_passati[x]);
                XmlNode nodeUtente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Utente");
                XmlNode nodeInvestimento = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Investimento");
                XmlNode nodeCredito = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito");
                XmlNode nodeCredito_Rimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Credito_Rimanente");
                XmlNode nodeDaily_Reward = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Daily_Reward");
                XmlNode nodeEmail = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Email");
                XmlNode nodeIndirizzo_Xch = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Indirizzo_Xch");
                XmlNode nodeBonus = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Bonus");
                XmlNode nodeTantum = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Tantum");
                XmlNode nodeFee = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/Fee");
                XmlNode nodeBoolAPY = DocumentoXml.DocumentElement.SelectSingleNode("/Cliente/BoolAPY");

                //Calcola il valore delle variabili credito ed investimento
                double lettura_Investimento = 0;
                double lettura_Credito = 0;
                lettura_Investimento = Convert.ToDouble(nodeInvestimento.InnerText);
                lettura_Credito = Convert.ToDouble(nodeCredito.InnerText);
                _investimento = _investimento + lettura_Investimento;
                _credito = _credito + lettura_Credito;
                //Carica i seguenti elementi nella griglia ... Db
                string[] nuovariga = {idContatto, nodeUtente.InnerText, nodeInvestimento.InnerText, nodeCredito.InnerText, nodeCredito_Rimanente.InnerText,
                    nodeDaily_Reward.InnerText, nodeEmail.InnerText, nodeIndirizzo_Xch.InnerText, nodeBonus.InnerText, nodeTantum.InnerText, nodeFee.InnerText,
                    nodeBoolAPY.InnerText};
                Database_db.Rows.Add(nuovariga);

                lbl_Totale_EURO_Investiti.Text = "Capitale: " + _investimento;
                lbl_Credito_Residuo.Text = "Credito Residuo: " + _credito;
            }
        }
        private void lbl_Numero_Utenti_Click(object sender, EventArgs e)
        {

        }
    }
}
