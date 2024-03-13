using System.Drawing;
using System.Windows.Forms;

namespace Client_V3.Forms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRimanente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColXCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChiaPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatoTransazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTransaction_hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumeroBlocco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_Totale_XCH = new System.Windows.Forms.Label();
            this.lbl_Rendimento_Totale = new System.Windows.Forms.Label();
            this.lbl_Utenti_Invitati = new System.Windows.Forms.Label();
            this.lbl_Numero_Transazioni = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SkyBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColDeposito,
            this.ColRimanente,
            this.ColXCH,
            this.ColChiaPrice,
            this.ColRendimento,
            this.ColStatoTransazione,
            this.ColTransaction_hash,
            this.ColNumeroBlocco,
            this.ColData});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(868, 367);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            this.ColId.Width = 60;
            // 
            // ColDeposito
            // 
            this.ColDeposito.HeaderText = "Deposito";
            this.ColDeposito.Name = "ColDeposito";
            this.ColDeposito.Width = 85;
            // 
            // ColRimanente
            // 
            this.ColRimanente.HeaderText = "Credito";
            this.ColRimanente.Name = "ColRimanente";
            this.ColRimanente.Width = 80;
            // 
            // ColXCH
            // 
            this.ColXCH.HeaderText = "XCH";
            this.ColXCH.Name = "ColXCH";
            // 
            // ColChiaPrice
            // 
            this.ColChiaPrice.HeaderText = "Chia Price";
            this.ColChiaPrice.Name = "ColChiaPrice";
            this.ColChiaPrice.Width = 85;
            // 
            // ColRendimento
            // 
            this.ColRendimento.HeaderText = "Rendimento";
            this.ColRendimento.Name = "ColRendimento";
            this.ColRendimento.Width = 85;
            // 
            // ColStatoTransazione
            // 
            this.ColStatoTransazione.HeaderText = "Transazione";
            this.ColStatoTransazione.Name = "ColStatoTransazione";
            this.ColStatoTransazione.Width = 80;
            // 
            // ColTransaction_hash
            // 
            this.ColTransaction_hash.HeaderText = "Transaction Hash";
            this.ColTransaction_hash.Name = "ColTransaction_hash";
            this.ColTransaction_hash.Width = 110;
            // 
            // ColNumeroBlocco
            // 
            this.ColNumeroBlocco.HeaderText = "Blocco";
            this.ColNumeroBlocco.Name = "ColNumeroBlocco";
            this.ColNumeroBlocco.Width = 70;
            // 
            // ColData
            // 
            this.ColData.HeaderText = "Data & Ora";
            this.ColData.Name = "ColData";
            this.ColData.Width = 110;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(7)))), ((int)(((byte)(33)))));
            this.panel5.Controls.Add(this.lbl_Totale_XCH);
            this.panel5.Controls.Add(this.lbl_Rendimento_Totale);
            this.panel5.Controls.Add(this.lbl_Utenti_Invitati);
            this.panel5.Controls.Add(this.lbl_Numero_Transazioni);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 339);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(868, 28);
            this.panel5.TabIndex = 2;
            // 
            // lbl_Totale_XCH
            // 
            this.lbl_Totale_XCH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Totale_XCH.AutoSize = true;
            this.lbl_Totale_XCH.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Totale_XCH.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_Totale_XCH.Location = new System.Drawing.Point(437, 5);
            this.lbl_Totale_XCH.Name = "lbl_Totale_XCH";
            this.lbl_Totale_XCH.Size = new System.Drawing.Size(188, 20);
            this.lbl_Totale_XCH.TabIndex = 20;
            this.lbl_Totale_XCH.Text = "Totale XCH: 1.123456789";
            this.lbl_Totale_XCH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Rendimento_Totale
            // 
            this.lbl_Rendimento_Totale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Rendimento_Totale.AutoSize = true;
            this.lbl_Rendimento_Totale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Rendimento_Totale.ForeColor = System.Drawing.Color.Coral;
            this.lbl_Rendimento_Totale.Location = new System.Drawing.Point(704, 5);
            this.lbl_Rendimento_Totale.Name = "lbl_Rendimento_Totale";
            this.lbl_Rendimento_Totale.Size = new System.Drawing.Size(152, 20);
            this.lbl_Rendimento_Totale.TabIndex = 19;
            this.lbl_Rendimento_Totale.Text = "Rendimento: 0.0001";
            this.lbl_Rendimento_Totale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Utenti_Invitati
            // 
            this.lbl_Utenti_Invitati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Utenti_Invitati.AutoSize = true;
            this.lbl_Utenti_Invitati.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Utenti_Invitati.ForeColor = System.Drawing.Color.Violet;
            this.lbl_Utenti_Invitati.Location = new System.Drawing.Point(218, 5);
            this.lbl_Utenti_Invitati.Name = "lbl_Utenti_Invitati";
            this.lbl_Utenti_Invitati.Size = new System.Drawing.Size(124, 20);
            this.lbl_Utenti_Invitati.TabIndex = 18;
            this.lbl_Utenti_Invitati.Text = "Utenti Invitati: 5";
            this.lbl_Utenti_Invitati.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Numero_Transazioni
            // 
            this.lbl_Numero_Transazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Numero_Transazioni.AutoSize = true;
            this.lbl_Numero_Transazioni.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Numero_Transazioni.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_Numero_Transazioni.Location = new System.Drawing.Point(12, 5);
            this.lbl_Numero_Transazioni.Name = "lbl_Numero_Transazioni";
            this.lbl_Numero_Transazioni.Size = new System.Drawing.Size(123, 20);
            this.lbl_Numero_Transazioni.TabIndex = 17;
            this.lbl_Numero_Transazioni.Text = "Transazioni: 100";
            this.lbl_Numero_Transazioni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(553, -24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "I Pagamenti sono momentaneamente sospesi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 32F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(217, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 71);
            this.label1.TabIndex = 22;
            this.label1.Text = "Work in progress";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(868, 367);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel5;
        private Label label2;
        private Label lbl_Totale_XCH;
        private Label lbl_Rendimento_Totale;
        private Label lbl_Utenti_Invitati;
        private Label lbl_Numero_Transazioni;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColDeposito;
        private DataGridViewTextBoxColumn ColRimanente;
        private DataGridViewTextBoxColumn ColXCH;
        private DataGridViewTextBoxColumn ColChiaPrice;
        private DataGridViewTextBoxColumn ColRendimento;
        private DataGridViewTextBoxColumn ColStatoTransazione;
        private DataGridViewTextBoxColumn ColTransaction_hash;
        private DataGridViewTextBoxColumn ColNumeroBlocco;
        private DataGridViewTextBoxColumn ColData;
        private Label label1;
    }
}