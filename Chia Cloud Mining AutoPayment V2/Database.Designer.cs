namespace Chia_Cloud_Mining_AutoPayment_V2
{
    partial class Database
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
            this.Database_db = new System.Windows.Forms.DataGridView();
            this.barra_stato = new System.Windows.Forms.StatusStrip();
            this.lbl_Numero_Utenti = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Totale_EURO_Investiti = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Credito_Residuo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInvestimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCredito_Rimanente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDailyReward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIndirizzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTantum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBoolAPY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Database_db)).BeginInit();
            this.barra_stato.SuspendLayout();
            this.SuspendLayout();
            // 
            // Database_db
            // 
            this.Database_db.AllowUserToAddRows = false;
            this.Database_db.AllowUserToDeleteRows = false;
            this.Database_db.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.Database_db.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Database_db.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.Database_db.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Database_db.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColUser,
            this.ColInvestimento,
            this.ColCredito,
            this.ColCredito_Rimanente,
            this.ColDailyReward,
            this.ColEmail,
            this.ColIndirizzo,
            this.ColBonus,
            this.ColTantum,
            this.ColFee,
            this.colBoolAPY});
            this.Database_db.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Database_db.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Database_db.Location = new System.Drawing.Point(0, 24);
            this.Database_db.Name = "Database_db";
            this.Database_db.ReadOnly = true;
            this.Database_db.Size = new System.Drawing.Size(970, 367);
            this.Database_db.TabIndex = 0;
            // 
            // barra_stato
            // 
            this.barra_stato.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Numero_Utenti,
            this.lbl_Totale_EURO_Investiti,
            this.toolStripStatusLabel1,
            this.lbl_Credito_Residuo,
            this.toolStripStatusLabel2});
            this.barra_stato.Location = new System.Drawing.Point(0, 391);
            this.barra_stato.Name = "barra_stato";
            this.barra_stato.Size = new System.Drawing.Size(970, 22);
            this.barra_stato.TabIndex = 1;
            this.barra_stato.Text = "statusStrip1";
            // 
            // lbl_Numero_Utenti
            // 
            this.lbl_Numero_Utenti.Name = "lbl_Numero_Utenti";
            this.lbl_Numero_Utenti.Size = new System.Drawing.Size(51, 17);
            this.lbl_Numero_Utenti.Text = "Utenti: 0";
            this.lbl_Numero_Utenti.Click += new System.EventHandler(this.lbl_Numero_Utenti_Click);
            // 
            // lbl_Totale_EURO_Investiti
            // 
            this.lbl_Totale_EURO_Investiti.Name = "lbl_Totale_EURO_Investiti";
            this.lbl_Totale_EURO_Investiti.Size = new System.Drawing.Size(62, 17);
            this.lbl_Totale_EURO_Investiti.Text = "Capitale: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel1.Text = "€";
            // 
            // lbl_Credito_Residuo
            // 
            this.lbl_Credito_Residuo.Name = "lbl_Credito_Residuo";
            this.lbl_Credito_Residuo.Size = new System.Drawing.Size(103, 17);
            this.lbl_Credito_Residuo.Text = "Credito Residuo: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel2.Text = "€";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ColID
            // 
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Width = 40;
            // 
            // ColUser
            // 
            this.ColUser.HeaderText = "Utente";
            this.ColUser.Name = "ColUser";
            this.ColUser.ReadOnly = true;
            this.ColUser.Width = 80;
            // 
            // ColInvestimento
            // 
            this.ColInvestimento.HeaderText = "Investimento";
            this.ColInvestimento.Name = "ColInvestimento";
            this.ColInvestimento.ReadOnly = true;
            this.ColInvestimento.Width = 68;
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
            this.ColCredito_Rimanente.Width = 106;
            // 
            // ColDailyReward
            // 
            this.ColDailyReward.HeaderText = "Reward €";
            this.ColDailyReward.Name = "ColDailyReward";
            this.ColDailyReward.ReadOnly = true;
            this.ColDailyReward.Width = 76;
            // 
            // ColEmail
            // 
            this.ColEmail.HeaderText = "Email";
            this.ColEmail.Name = "ColEmail";
            this.ColEmail.ReadOnly = true;
            // 
            // ColIndirizzo
            // 
            this.ColIndirizzo.HeaderText = "Indirizzo XCH";
            this.ColIndirizzo.Name = "ColIndirizzo";
            this.ColIndirizzo.ReadOnly = true;
            // 
            // ColBonus
            // 
            this.ColBonus.HeaderText = "Bonus";
            this.ColBonus.Name = "ColBonus";
            this.ColBonus.ReadOnly = true;
            this.ColBonus.Width = 50;
            // 
            // ColTantum
            // 
            this.ColTantum.HeaderText = "Tantum";
            this.ColTantum.Name = "ColTantum";
            this.ColTantum.ReadOnly = true;
            this.ColTantum.Width = 46;
            // 
            // ColFee
            // 
            this.ColFee.HeaderText = "Fee";
            this.ColFee.Name = "ColFee";
            this.ColFee.ReadOnly = true;
            // 
            // colBoolAPY
            // 
            this.colBoolAPY.HeaderText = "APY";
            this.colBoolAPY.Name = "colBoolAPY";
            this.colBoolAPY.ReadOnly = true;
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 413);
            this.Controls.Add(this.Database_db);
            this.Controls.Add(this.barra_stato);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Database";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database";
            this.Load += new System.EventHandler(this.Database_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Database_db)).EndInit();
            this.barra_stato.ResumeLayout(false);
            this.barra_stato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Database_db;
        private System.Windows.Forms.StatusStrip barra_stato;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Numero_Utenti;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Totale_EURO_Investiti;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Credito_Residuo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInvestimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCredito_Rimanente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDailyReward;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIndirizzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTantum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoolAPY;
    }
}