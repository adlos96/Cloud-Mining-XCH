namespace Multi_XCHPY
{
    partial class Main_Form
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Wallet_Receive = new System.Windows.Forms.TextBox();
            this.txt_Wallet_Send = new System.Windows.Forms.TextBox();
            this.Comb_Loop_Number = new System.Windows.Forms.ComboBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Fee_XCH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Send_XCH = new System.Windows.Forms.TextBox();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.text_N_transazioni = new System.Windows.Forms.TextBox();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Wallet_Receive);
            this.groupBox1.Controls.Add(this.txt_Wallet_Send);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(110, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wallet Ricezione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wallet Invio";
            // 
            // txt_Wallet_Receive
            // 
            this.txt_Wallet_Receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Wallet_Receive.Location = new System.Drawing.Point(6, 77);
            this.txt_Wallet_Receive.Name = "txt_Wallet_Receive";
            this.txt_Wallet_Receive.Size = new System.Drawing.Size(85, 20);
            this.txt_Wallet_Receive.TabIndex = 1;
            // 
            // txt_Wallet_Send
            // 
            this.txt_Wallet_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Wallet_Send.Location = new System.Drawing.Point(6, 38);
            this.txt_Wallet_Send.Name = "txt_Wallet_Send";
            this.txt_Wallet_Send.Size = new System.Drawing.Size(85, 20);
            this.txt_Wallet_Send.TabIndex = 0;
            this.txt_Wallet_Send.Text = "2978252248";
            // 
            // Comb_Loop_Number
            // 
            this.Comb_Loop_Number.FormattingEnabled = true;
            this.Comb_Loop_Number.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Comb_Loop_Number.Location = new System.Drawing.Point(9, 133);
            this.Comb_Loop_Number.Name = "Comb_Loop_Number";
            this.Comb_Loop_Number.Size = new System.Drawing.Size(63, 23);
            this.Comb_Loop_Number.TabIndex = 1;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.btn_Start.Location = new System.Drawing.Point(171, 127);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(54, 33);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Numero transazioni";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_Refresh);
            this.groupBox2.Controls.Add(this.text_N_transazioni);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_Fee_XCH);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_Send_XCH);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_Start);
            this.groupBox2.Controls.Add(this.Comb_Loop_Number);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 166);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extreme";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fee";
            // 
            // txt_Fee_XCH
            // 
            this.txt_Fee_XCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fee_XCH.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Fee_XCH.Location = new System.Drawing.Point(12, 86);
            this.txt_Fee_XCH.Name = "txt_Fee_XCH";
            this.txt_Fee_XCH.Size = new System.Drawing.Size(85, 20);
            this.txt_Fee_XCH.TabIndex = 6;
            this.txt_Fee_XCH.Text = "0.000000000001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "XCH da Inviare";
            // 
            // txt_Send_XCH
            // 
            this.txt_Send_XCH.Location = new System.Drawing.Point(12, 46);
            this.txt_Send_XCH.Name = "txt_Send_XCH";
            this.txt_Send_XCH.Size = new System.Drawing.Size(85, 21);
            this.txt_Send_XCH.TabIndex = 4;
            this.txt_Send_XCH.Text = "0.00001";
            // 
            // txt_Log
            // 
            this.txt_Log.Location = new System.Drawing.Point(15, 208);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.Size = new System.Drawing.Size(227, 136);
            this.txt_Log.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(18, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pannello informazioni";
            // 
            // text_N_transazioni
            // 
            this.text_N_transazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.text_N_transazioni.Location = new System.Drawing.Point(78, 134);
            this.text_N_transazioni.Name = "text_N_transazioni";
            this.text_N_transazioni.Size = new System.Drawing.Size(32, 20);
            this.text_N_transazioni.TabIndex = 8;
            this.text_N_transazioni.Text = "10";
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Refresh.Location = new System.Drawing.Point(115, 126);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(54, 33);
            this.Btn_Refresh.TabIndex = 9;
            this.Btn_Refresh.Text = "Refresh";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 356);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.groupBox2);
            this.Name = "Main_Form";
            this.Text = "Programma";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Wallet_Receive;
        private System.Windows.Forms.TextBox txt_Wallet_Send;
        private System.Windows.Forms.ComboBox Comb_Loop_Number;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Fee_XCH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Send_XCH;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_N_transazioni;
        private System.Windows.Forms.Button Btn_Refresh;
    }
}

