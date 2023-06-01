namespace Chia_Cloud_Mining_AutoPayment_V2
{
    partial class Transazioni
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Database_db = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIndirizzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEuro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCredito_Rimanente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_prezzo_chia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProfitto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barra_stato = new System.Windows.Forms.StatusStrip();
            this.lbl_Numero_Utenti = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_chia_inviati = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_utile_prodotto = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Database_db)).BeginInit();
            this.barra_stato.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Database_db
            // 
            this.Database_db.AllowUserToAddRows = false;
            this.Database_db.AllowUserToDeleteRows = false;
            this.Database_db.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.Database_db.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Database_db.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.Database_db.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Database_db.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColUser,
            this.ColIndirizzo,
            this.colTransaction,
            this.ColEuro,
            this.colXch,
            this.ColCredito,
            this.ColCredito_Rimanente,
            this.Col_prezzo_chia,
            this.ColProfitto,
            this.ColData});
            this.Database_db.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Database_db.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Database_db.Location = new System.Drawing.Point(0, 24);
            this.Database_db.Name = "Database_db";
            this.Database_db.ReadOnly = true;
            this.Database_db.Size = new System.Drawing.Size(1060, 166);
            this.Database_db.TabIndex = 3;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "Transazione";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Width = 70;
            // 
            // ColUser
            // 
            this.ColUser.HeaderText = "Utente";
            this.ColUser.Name = "ColUser";
            this.ColUser.ReadOnly = true;
            this.ColUser.Width = 65;
            // 
            // ColIndirizzo
            // 
            this.ColIndirizzo.HeaderText = "Indirizzo XCH";
            this.ColIndirizzo.Name = "ColIndirizzo";
            this.ColIndirizzo.ReadOnly = true;
            // 
            // colTransaction
            // 
            this.colTransaction.HeaderText = "-tx";
            this.colTransaction.Name = "colTransaction";
            this.colTransaction.ReadOnly = true;
            this.colTransaction.Width = 130;
            // 
            // ColEuro
            // 
            this.ColEuro.HeaderText = "Euro";
            this.ColEuro.Name = "ColEuro";
            this.ColEuro.ReadOnly = true;
            this.ColEuro.Width = 45;
            // 
            // colXch
            // 
            this.colXch.HeaderText = "Xch";
            this.colXch.Name = "colXch";
            this.colXch.ReadOnly = true;
            this.colXch.Width = 95;
            // 
            // ColCredito
            // 
            this.ColCredito.HeaderText = "Credito";
            this.ColCredito.Name = "ColCredito";
            this.ColCredito.ReadOnly = true;
            this.ColCredito.Width = 68;
            // 
            // ColCredito_Rimanente
            // 
            this.ColCredito_Rimanente.HeaderText = "Credito Residuo";
            this.ColCredito_Rimanente.Name = "ColCredito_Rimanente";
            this.ColCredito_Rimanente.ReadOnly = true;
            this.ColCredito_Rimanente.Width = 70;
            // 
            // Col_prezzo_chia
            // 
            this.Col_prezzo_chia.HeaderText = "Chia €";
            this.Col_prezzo_chia.Name = "Col_prezzo_chia";
            this.Col_prezzo_chia.ReadOnly = true;
            this.Col_prezzo_chia.Width = 65;
            // 
            // ColProfitto
            // 
            this.ColProfitto.HeaderText = "Utile";
            this.ColProfitto.Name = "ColProfitto";
            this.ColProfitto.ReadOnly = true;
            this.ColProfitto.Width = 65;
            // 
            // ColData
            // 
            this.ColData.HeaderText = "Data & Ora";
            this.ColData.Name = "ColData";
            this.ColData.ReadOnly = true;
            // 
            // barra_stato
            // 
            this.barra_stato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Numero_Utenti,
            this.lbl_chia_inviati,
            this.lbl_utile_prodotto});
            this.barra_stato.Location = new System.Drawing.Point(0, 190);
            this.barra_stato.Name = "barra_stato";
            this.barra_stato.Size = new System.Drawing.Size(1060, 22);
            this.barra_stato.TabIndex = 4;
            this.barra_stato.Text = "statusStrip1";
            // 
            // lbl_Numero_Utenti
            // 
            this.lbl_Numero_Utenti.ForeColor = System.Drawing.Color.Black;
            this.lbl_Numero_Utenti.Name = "lbl_Numero_Utenti";
            this.lbl_Numero_Utenti.Size = new System.Drawing.Size(51, 17);
            this.lbl_Numero_Utenti.Text = "Utenti: 0";
            // 
            // lbl_chia_inviati
            // 
            this.lbl_chia_inviati.ForeColor = System.Drawing.Color.Black;
            this.lbl_chia_inviati.Name = "lbl_chia_inviati";
            this.lbl_chia_inviati.Size = new System.Drawing.Size(92, 17);
            this.lbl_chia_inviati.Text = "Totale XCH: 0.00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1060, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // lbl_utile_prodotto
            // 
            this.lbl_utile_prodotto.ForeColor = System.Drawing.Color.Black;
            this.lbl_utile_prodotto.Name = "lbl_utile_prodotto";
            this.lbl_utile_prodotto.Size = new System.Drawing.Size(90, 17);
            this.lbl_utile_prodotto.Text = "Rendimento: 0€";
            // 
            // Transazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 212);
            this.Controls.Add(this.Database_db);
            this.Controls.Add(this.barra_stato);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(775, 175);
            this.Name = "Transazioni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transazioni";
            this.Load += new System.EventHandler(this.Transazioni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Database_db)).EndInit();
            this.barra_stato.ResumeLayout(false);
            this.barra_stato.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Database_db;
        private System.Windows.Forms.StatusStrip barra_stato;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Numero_Utenti;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lbl_chia_inviati;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIndirizzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEuro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colXch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCredito_Rimanente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_prezzo_chia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProfitto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColData;
        private System.Windows.Forms.ToolStripStatusLabel lbl_utile_prodotto;
    }
}