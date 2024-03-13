using System;
using System.Windows.Forms;
using System.Xml;

namespace Client_V3.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            double _Rendimento = 0;
            double totale_Chia = 0;
            int lettura_Numero_Transazioni = 0;
            int lettura_Utenti_Invitati = 0;

            int trasazioni_Trovate = Variabili.conta_numero_elementi();
            string[] elementi_passati;
            elementi_passati = Variabili.carica_contenuto_elementi();
            if (trasazioni_Trovate > 0)
            {
                for (int x = 0; x < elementi_passati.Length; x++)
                {
                    Console.WriteLine("Cosa c'è qui: " + elementi_passati[x]);
                    //Assegna ad una "stringa" nodo il valore del file .xml
                    XmlDocument DocumentoXml = new XmlDataDocument();
                    DocumentoXml.Load(elementi_passati[x]);
                    XmlNode nodeID = DocumentoXml.DocumentElement.SelectSingleNode("ID");
                    XmlNode nodeDeposito = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Deposito");
                    XmlNode nodeCredito_Rimanente = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Rimanente");
                    XmlNode nodeImporto_Accreditato_Xch = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Importo_Accreditato_Xch");
                    XmlNode nodePrezzo_Chia = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Prezzo_Chia");
                    XmlNode nodeRendimento = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Rendimento");
                    XmlNode nodeStato_Transazione = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Stato_Transazione");
                    XmlNode nodeTransaction_hash = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Transaction_hash");
                    XmlNode nodeBlock_Number = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Block_Number");
                    XmlNode nodeData_Transazione = DocumentoXml.DocumentElement.SelectSingleNode("/Resoconto/Data_Transazione");

                    //Calcola il valore delle variabili credito ed investimento
                    double lettura_Transazione_Xch = 0;
                    double lettura_Rendimento = 0;

                    if (nodeImporto_Accreditato_Xch.InnerText != "None")
                    {
                        lettura_Transazione_Xch = Convert.ToDouble(nodeImporto_Accreditato_Xch.InnerText) * 10000;
                        lettura_Transazione_Xch.ToString("0.000000000000");
                        totale_Chia = totale_Chia + lettura_Transazione_Xch;
                        lettura_Rendimento = Convert.ToDouble(nodeRendimento.InnerText);
                        _Rendimento = _Rendimento + lettura_Rendimento;

                        lettura_Numero_Transazioni++;
                    }
                    else
                        lettura_Utenti_Invitati++;

                    //Carica i seguenti elementi nella griglia ... Db
                    string[] nuovariga = {nodeID.InnerText, nodeDeposito.InnerText, nodeCredito_Rimanente.InnerText, nodeImporto_Accreditato_Xch.InnerText, nodePrezzo_Chia.InnerText,
                    nodeRendimento.InnerText, nodeStato_Transazione.InnerText, nodeTransaction_hash.InnerText, nodeBlock_Number.InnerText, nodeData_Transazione.InnerText};
                    dataGridView1.Rows.Add(nuovariga);

                    lbl_Numero_Transazioni.Text = "Trasazioni: " + lettura_Numero_Transazioni;
                    lbl_Utenti_Invitati.Text = "Utenti Invitati: " + lettura_Utenti_Invitati;
                    lbl_Rendimento_Totale.Text = "Rendimento: " + _Rendimento.ToString("0.0000");
                    lbl_Totale_XCH.Text = "Totale XCH: " + (totale_Chia / 10000).ToString("0.000000000000");

                }
            }
            else
                Console.WriteLine("Nessuna transazione trovata");

        }
    }
}
