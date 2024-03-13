using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    partial class Payment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_Payment_USDT = new System.Windows.Forms.GroupBox();
            this.panel_Logo_Chain = new System.Windows.Forms.Panel();
            this.panel_Logo_Wallet = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_Chain_Selection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address_Recive_USDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_Subtitle = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_Connessione_Server = new System.Windows.Forms.Label();
            this.lbl_Stato_Pagamento_Timer = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Wallet_USDT_User = new System.Windows.Forms.TextBox();
            this.btn_Sqlite = new System.Windows.Forms.Button();
            this.lbl_Avviso_Campi_Incompleti = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel_Anteprima = new System.Windows.Forms.Panel();
            this.lbl_Referal_Code_Anteprima = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Plot_Anteprima = new System.Windows.Forms.TextBox();
            this.txt_USDT_Anteprima = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_Stato_Rete_Anteprima = new System.Windows.Forms.Label();
            this.lbl_Anteprima_Rete = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.goupbox_Acquisto_Plot = new System.Windows.Forms.GroupBox();
            this.checkB_Plot_Manuale = new System.Windows.Forms.CheckBox();
            this.panel_Plot_Manuali = new System.Windows.Forms.Panel();
            this.lbl_Testo_Manulale = new System.Windows.Forms.Label();
            this.txt_Plot_Manuali = new System.Windows.Forms.TextBox();
            this.lbl_Anteprima_Manuale = new System.Windows.Forms.Label();
            this.panel_Numero_Plot_TrackBar = new System.Windows.Forms.Panel();
            this.lbl_Plot_MIN = new System.Windows.Forms.Label();
            this.lbl_Plot_MAX = new System.Windows.Forms.Label();
            this.lbl_Plot_Current_Selection = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_Conferma_Plot = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox_Payment_USDT.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Subtitle.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_Anteprima.SuspendLayout();
            this.goupbox_Acquisto_Plot.SuspendLayout();
            this.panel_Plot_Manuali.SuspendLayout();
            this.panel_Numero_Plot_TrackBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox_Payment_USDT);
            this.groupBox1.Controls.Add(this.pnl_Subtitle);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.btn_Sqlite);
            this.groupBox1.Controls.Add(this.lbl_Avviso_Campi_Incompleti);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.goupbox_Acquisto_Plot);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 378);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Green;
            this.label18.Location = new System.Drawing.Point(652, 312);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 20);
            this.label18.TabIndex = 22;
            this.label18.Text = "USDT";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(447, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(210, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "Da quale indirizzo vuoi inviare";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.ForestGreen;
            this.button2.Location = new System.Drawing.Point(741, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 30);
            this.button2.TabIndex = 20;
            this.button2.Text = "Disconnetti";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(741, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 30);
            this.button1.TabIndex = 19;
            this.button1.Text = "Connetti";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_Payment_USDT
            // 
            this.groupBox_Payment_USDT.Controls.Add(this.panel_Logo_Chain);
            this.groupBox_Payment_USDT.Controls.Add(this.panel_Logo_Wallet);
            this.groupBox_Payment_USDT.Controls.Add(this.panel2);
            this.groupBox_Payment_USDT.Controls.Add(this.label4);
            this.groupBox_Payment_USDT.Controls.Add(this.label1);
            this.groupBox_Payment_USDT.Controls.Add(this.panel1);
            this.groupBox_Payment_USDT.Controls.Add(this.label7);
            this.groupBox_Payment_USDT.Controls.Add(this.label6);
            this.groupBox_Payment_USDT.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox_Payment_USDT.Location = new System.Drawing.Point(9, 10);
            this.groupBox_Payment_USDT.Name = "groupBox_Payment_USDT";
            this.groupBox_Payment_USDT.Size = new System.Drawing.Size(328, 164);
            this.groupBox_Payment_USDT.TabIndex = 2;
            this.groupBox_Payment_USDT.TabStop = false;
            this.groupBox_Payment_USDT.Text = "Payment Request";
            // 
            // panel_Logo_Chain
            // 
            this.panel_Logo_Chain.BackgroundImage = global::Client_V3.Properties.Resources.cronos_cro_logo;
            this.panel_Logo_Chain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_Logo_Chain.Location = new System.Drawing.Point(195, 119);
            this.panel_Logo_Chain.Name = "panel_Logo_Chain";
            this.panel_Logo_Chain.Size = new System.Drawing.Size(40, 35);
            this.panel_Logo_Chain.TabIndex = 15;
            // 
            // panel_Logo_Wallet
            // 
            this.panel_Logo_Wallet.BackgroundImage = global::Client_V3.Properties.Resources.Tether_ico_32;
            this.panel_Logo_Wallet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_Logo_Wallet.Location = new System.Drawing.Point(244, 46);
            this.panel_Logo_Wallet.Name = "panel_Logo_Wallet";
            this.panel_Logo_Wallet.Size = new System.Drawing.Size(41, 35);
            this.panel_Logo_Wallet.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel2.Controls.Add(this.comboBox_Chain_Selection);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(10, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 33);
            this.panel2.TabIndex = 6;
            // 
            // comboBox_Chain_Selection
            // 
            this.comboBox_Chain_Selection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.comboBox_Chain_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Chain_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Chain_Selection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox_Chain_Selection.ForeColor = System.Drawing.SystemColors.Control;
            this.comboBox_Chain_Selection.FormattingEnabled = true;
            this.comboBox_Chain_Selection.Location = new System.Drawing.Point(69, 5);
            this.comboBox_Chain_Selection.Name = "comboBox_Chain_Selection";
            this.comboBox_Chain_Selection.Size = new System.Drawing.Size(114, 23);
            this.comboBox_Chain_Selection.TabIndex = 3;
            this.comboBox_Chain_Selection.SelectedIndexChanged += new System.EventHandler(this.comboBox_Chain_Selection_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chain:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(109, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "a cui effetturare il pagamento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(66, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "USDT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Address_Recive_USDT);
            this.panel1.Location = new System.Drawing.Point(10, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 33);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Wallet:";
            // 
            // txt_Address_Recive_USDT
            // 
            this.txt_Address_Recive_USDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Address_Recive_USDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Address_Recive_USDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_Address_Recive_USDT.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_Address_Recive_USDT.Location = new System.Drawing.Point(59, 8);
            this.txt_Address_Recive_USDT.Name = "txt_Address_Recive_USDT";
            this.txt_Address_Recive_USDT.ReadOnly = true;
            this.txt_Address_Recive_USDT.Size = new System.Drawing.Size(174, 18);
            this.txt_Address_Recive_USDT.TabIndex = 6;
            this.txt_Address_Recive_USDT.Text = "0x123123123";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.Location = new System.Drawing.Point(5, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Seleziona la chain che vuoi utilizzare:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(5, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Indirizzo";
            // 
            // pnl_Subtitle
            // 
            this.pnl_Subtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Subtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(56)))));
            this.pnl_Subtitle.Controls.Add(this.label16);
            this.pnl_Subtitle.Controls.Add(this.lbl_Connessione_Server);
            this.pnl_Subtitle.Controls.Add(this.lbl_Stato_Pagamento_Timer);
            this.pnl_Subtitle.Location = new System.Drawing.Point(334, 17);
            this.pnl_Subtitle.Name = "pnl_Subtitle";
            this.pnl_Subtitle.Size = new System.Drawing.Size(504, 28);
            this.pnl_Subtitle.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.SeaGreen;
            this.label16.Location = new System.Drawing.Point(315, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 20);
            this.label16.TabIndex = 18;
            this.label16.Text = "Connessione:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Connessione_Server
            // 
            this.lbl_Connessione_Server.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Connessione_Server.AutoSize = true;
            this.lbl_Connessione_Server.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Connessione_Server.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_Connessione_Server.Location = new System.Drawing.Point(411, 4);
            this.lbl_Connessione_Server.Name = "lbl_Connessione_Server";
            this.lbl_Connessione_Server.Size = new System.Drawing.Size(96, 20);
            this.lbl_Connessione_Server.TabIndex = 17;
            this.lbl_Connessione_Server.Text = "Disconnesso";
            this.lbl_Connessione_Server.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Stato_Pagamento_Timer
            // 
            this.lbl_Stato_Pagamento_Timer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Stato_Pagamento_Timer.AutoSize = true;
            this.lbl_Stato_Pagamento_Timer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Stato_Pagamento_Timer.ForeColor = System.Drawing.Color.White;
            this.lbl_Stato_Pagamento_Timer.Location = new System.Drawing.Point(2, 4);
            this.lbl_Stato_Pagamento_Timer.Name = "lbl_Stato_Pagamento_Timer";
            this.lbl_Stato_Pagamento_Timer.Size = new System.Drawing.Size(206, 20);
            this.lbl_Stato_Pagamento_Timer.TabIndex = 16;
            this.lbl_Stato_Pagamento_Timer.Text = "Status Pagamento: Nessuno";
            this.lbl_Stato_Pagamento_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackgroundImage = global::Client_V3.Properties.Resources.Tether_ico_32;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(681, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(41, 35);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txt_Wallet_USDT_User);
            this.panel4.Location = new System.Drawing.Point(447, 334);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 33);
            this.panel4.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Wallet:";
            // 
            // txt_Wallet_USDT_User
            // 
            this.txt_Wallet_USDT_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Wallet_USDT_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Wallet_USDT_User.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_Wallet_USDT_User.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_Wallet_USDT_User.Location = new System.Drawing.Point(59, 8);
            this.txt_Wallet_USDT_User.Name = "txt_Wallet_USDT_User";
            this.txt_Wallet_USDT_User.Size = new System.Drawing.Size(174, 18);
            this.txt_Wallet_USDT_User.TabIndex = 6;
            this.txt_Wallet_USDT_User.Text = "0x123123123";
            // 
            // btn_Sqlite
            // 
            this.btn_Sqlite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sqlite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Sqlite.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Sqlite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Sqlite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sqlite.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Sqlite.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Sqlite.Location = new System.Drawing.Point(741, 118);
            this.btn_Sqlite.Name = "btn_Sqlite";
            this.btn_Sqlite.Size = new System.Drawing.Size(92, 30);
            this.btn_Sqlite.TabIndex = 14;
            this.btn_Sqlite.Text = "Refresh";
            this.btn_Sqlite.UseVisualStyleBackColor = false;
            this.btn_Sqlite.Click += new System.EventHandler(this.btn_Sqlite_Click);
            // 
            // lbl_Avviso_Campi_Incompleti
            // 
            this.lbl_Avviso_Campi_Incompleti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Avviso_Campi_Incompleti.AutoSize = true;
            this.lbl_Avviso_Campi_Incompleti.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Avviso_Campi_Incompleti.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_Avviso_Campi_Incompleti.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Avviso_Campi_Incompleti.Location = new System.Drawing.Point(456, 57);
            this.lbl_Avviso_Campi_Incompleti.Name = "lbl_Avviso_Campi_Incompleti";
            this.lbl_Avviso_Campi_Incompleti.Size = new System.Drawing.Size(232, 20);
            this.lbl_Avviso_Campi_Incompleti.TabIndex = 13;
            this.lbl_Avviso_Campi_Incompleti.Text = "SELEZIONA PRIMA UNA CHAIN";
            this.lbl_Avviso_Campi_Incompleti.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.panel_Anteprima);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(470, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 172);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anteprima";
            // 
            // panel_Anteprima
            // 
            this.panel_Anteprima.Controls.Add(this.lbl_Referal_Code_Anteprima);
            this.panel_Anteprima.Controls.Add(this.label14);
            this.panel_Anteprima.Controls.Add(this.label9);
            this.panel_Anteprima.Controls.Add(this.txt_Plot_Anteprima);
            this.panel_Anteprima.Controls.Add(this.txt_USDT_Anteprima);
            this.panel_Anteprima.Controls.Add(this.textBox4);
            this.panel_Anteprima.Controls.Add(this.btn_Pay);
            this.panel_Anteprima.Controls.Add(this.label17);
            this.panel_Anteprima.Controls.Add(this.label15);
            this.panel_Anteprima.Controls.Add(this.label10);
            this.panel_Anteprima.Controls.Add(this.lbl_Stato_Rete_Anteprima);
            this.panel_Anteprima.Controls.Add(this.lbl_Anteprima_Rete);
            this.panel_Anteprima.Controls.Add(this.label12);
            this.panel_Anteprima.Location = new System.Drawing.Point(3, 11);
            this.panel_Anteprima.Name = "panel_Anteprima";
            this.panel_Anteprima.Size = new System.Drawing.Size(200, 156);
            this.panel_Anteprima.TabIndex = 14;
            // 
            // lbl_Referal_Code_Anteprima
            // 
            this.lbl_Referal_Code_Anteprima.AutoSize = true;
            this.lbl_Referal_Code_Anteprima.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Referal_Code_Anteprima.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Referal_Code_Anteprima.Location = new System.Drawing.Point(65, 129);
            this.lbl_Referal_Code_Anteprima.Name = "lbl_Referal_Code_Anteprima";
            this.lbl_Referal_Code_Anteprima.Size = new System.Drawing.Size(53, 20);
            this.lbl_Referal_Code_Anteprima.TabIndex = 21;
            this.lbl_Referal_Code_Anteprima.Text = "Active";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.DarkOrange;
            this.label14.Location = new System.Drawing.Point(5, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 20);
            this.label14.TabIndex = 8;
            this.label14.Text = "PLOT -> USDT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.DarkOrange;
            this.label9.Location = new System.Drawing.Point(3, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Referal:";
            // 
            // txt_Plot_Anteprima
            // 
            this.txt_Plot_Anteprima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.txt_Plot_Anteprima.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Plot_Anteprima.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txt_Plot_Anteprima.ForeColor = System.Drawing.SystemColors.Info;
            this.txt_Plot_Anteprima.Location = new System.Drawing.Point(3, 25);
            this.txt_Plot_Anteprima.Name = "txt_Plot_Anteprima";
            this.txt_Plot_Anteprima.ReadOnly = true;
            this.txt_Plot_Anteprima.Size = new System.Drawing.Size(44, 18);
            this.txt_Plot_Anteprima.TabIndex = 9;
            this.txt_Plot_Anteprima.Text = "74";
            this.txt_Plot_Anteprima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_USDT_Anteprima
            // 
            this.txt_USDT_Anteprima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.txt_USDT_Anteprima.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_USDT_Anteprima.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txt_USDT_Anteprima.ForeColor = System.Drawing.Color.OrangeRed;
            this.txt_USDT_Anteprima.Location = new System.Drawing.Point(3, 46);
            this.txt_USDT_Anteprima.Name = "txt_USDT_Anteprima";
            this.txt_USDT_Anteprima.ReadOnly = true;
            this.txt_USDT_Anteprima.Size = new System.Drawing.Size(44, 18);
            this.txt_USDT_Anteprima.TabIndex = 14;
            this.txt_USDT_Anteprima.Text = "74";
            this.txt_USDT_Anteprima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.textBox4.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox4.Location = new System.Drawing.Point(70, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(36, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "PLOT";
            // 
            // btn_Pay
            // 
            this.btn_Pay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Pay.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Pay.FlatAppearance.BorderSize = 0;
            this.btn_Pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Pay.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_Pay.Location = new System.Drawing.Point(143, 3);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(55, 146);
            this.btn_Pay.TabIndex = 19;
            this.btn_Pay.Text = "Pay";
            this.btn_Pay.UseVisualStyleBackColor = false;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Location = new System.Drawing.Point(65, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 20);
            this.label17.TabIndex = 13;
            this.label17.Text = "USDT";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(3, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 17);
            this.label15.TabIndex = 18;
            this.label15.Text = "Rete selezionata:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DarkOrange;
            this.label10.Location = new System.Drawing.Point(3, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Rete:";
            // 
            // lbl_Stato_Rete_Anteprima
            // 
            this.lbl_Stato_Rete_Anteprima.AutoSize = true;
            this.lbl_Stato_Rete_Anteprima.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Stato_Rete_Anteprima.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_Stato_Rete_Anteprima.Location = new System.Drawing.Point(65, 109);
            this.lbl_Stato_Rete_Anteprima.Name = "lbl_Stato_Rete_Anteprima";
            this.lbl_Stato_Rete_Anteprima.Size = new System.Drawing.Size(53, 20);
            this.lbl_Stato_Rete_Anteprima.TabIndex = 17;
            this.lbl_Stato_Rete_Anteprima.Text = "Active";
            // 
            // lbl_Anteprima_Rete
            // 
            this.lbl_Anteprima_Rete.AutoSize = true;
            this.lbl_Anteprima_Rete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Anteprima_Rete.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbl_Anteprima_Rete.Location = new System.Drawing.Point(64, 89);
            this.lbl_Anteprima_Rete.Name = "lbl_Anteprima_Rete";
            this.lbl_Anteprima_Rete.Size = new System.Drawing.Size(66, 20);
            this.lbl_Anteprima_Rete.TabIndex = 15;
            this.lbl_Anteprima_Rete.Text = "Polygon";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.DarkOrange;
            this.label12.Location = new System.Drawing.Point(3, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "Stato:";
            // 
            // goupbox_Acquisto_Plot
            // 
            this.goupbox_Acquisto_Plot.Controls.Add(this.checkB_Plot_Manuale);
            this.goupbox_Acquisto_Plot.Controls.Add(this.panel_Plot_Manuali);
            this.goupbox_Acquisto_Plot.Controls.Add(this.panel_Numero_Plot_TrackBar);
            this.goupbox_Acquisto_Plot.Controls.Add(this.btn_Conferma_Plot);
            this.goupbox_Acquisto_Plot.ForeColor = System.Drawing.SystemColors.Control;
            this.goupbox_Acquisto_Plot.Location = new System.Drawing.Point(9, 182);
            this.goupbox_Acquisto_Plot.Name = "goupbox_Acquisto_Plot";
            this.goupbox_Acquisto_Plot.Size = new System.Drawing.Size(329, 187);
            this.goupbox_Acquisto_Plot.TabIndex = 3;
            this.goupbox_Acquisto_Plot.TabStop = false;
            this.goupbox_Acquisto_Plot.Text = "Acquisto Plot";
            // 
            // checkB_Plot_Manuale
            // 
            this.checkB_Plot_Manuale.AutoSize = true;
            this.checkB_Plot_Manuale.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.checkB_Plot_Manuale.Location = new System.Drawing.Point(39, 113);
            this.checkB_Plot_Manuale.Name = "checkB_Plot_Manuale";
            this.checkB_Plot_Manuale.Size = new System.Drawing.Size(124, 17);
            this.checkB_Plot_Manuale.TabIndex = 15;
            this.checkB_Plot_Manuale.Text = "Inserimento Manuale";
            this.checkB_Plot_Manuale.UseVisualStyleBackColor = true;
            this.checkB_Plot_Manuale.CheckedChanged += new System.EventHandler(this.checkB_Plot_Manuale_CheckedChanged);
            // 
            // panel_Plot_Manuali
            // 
            this.panel_Plot_Manuali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel_Plot_Manuali.Controls.Add(this.lbl_Testo_Manulale);
            this.panel_Plot_Manuali.Controls.Add(this.txt_Plot_Manuali);
            this.panel_Plot_Manuali.Controls.Add(this.lbl_Anteprima_Manuale);
            this.panel_Plot_Manuali.Location = new System.Drawing.Point(35, 132);
            this.panel_Plot_Manuali.Name = "panel_Plot_Manuali";
            this.panel_Plot_Manuali.Size = new System.Drawing.Size(144, 50);
            this.panel_Plot_Manuali.TabIndex = 14;
            // 
            // lbl_Testo_Manulale
            // 
            this.lbl_Testo_Manulale.AutoSize = true;
            this.lbl_Testo_Manulale.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbl_Testo_Manulale.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Testo_Manulale.Location = new System.Drawing.Point(9, 27);
            this.lbl_Testo_Manulale.Name = "lbl_Testo_Manulale";
            this.lbl_Testo_Manulale.Size = new System.Drawing.Size(99, 17);
            this.lbl_Testo_Manulale.TabIndex = 15;
            this.lbl_Testo_Manulale.Text = "Plot Selezionati:";
            // 
            // txt_Plot_Manuali
            // 
            this.txt_Plot_Manuali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Plot_Manuali.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Plot_Manuali.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Plot_Manuali.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Plot_Manuali.Location = new System.Drawing.Point(19, 8);
            this.txt_Plot_Manuali.Name = "txt_Plot_Manuali";
            this.txt_Plot_Manuali.Size = new System.Drawing.Size(109, 20);
            this.txt_Plot_Manuali.TabIndex = 14;
            this.txt_Plot_Manuali.Text = "0";
            this.txt_Plot_Manuali.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Plot_Manuali.Visible = false;
            // 
            // lbl_Anteprima_Manuale
            // 
            this.lbl_Anteprima_Manuale.AutoSize = true;
            this.lbl_Anteprima_Manuale.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Anteprima_Manuale.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_Anteprima_Manuale.Location = new System.Drawing.Point(105, 28);
            this.lbl_Anteprima_Manuale.Name = "lbl_Anteprima_Manuale";
            this.lbl_Anteprima_Manuale.Size = new System.Drawing.Size(15, 17);
            this.lbl_Anteprima_Manuale.TabIndex = 16;
            this.lbl_Anteprima_Manuale.Text = "0";
            // 
            // panel_Numero_Plot_TrackBar
            // 
            this.panel_Numero_Plot_TrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel_Numero_Plot_TrackBar.Controls.Add(this.lbl_Plot_MIN);
            this.panel_Numero_Plot_TrackBar.Controls.Add(this.lbl_Plot_MAX);
            this.panel_Numero_Plot_TrackBar.Controls.Add(this.lbl_Plot_Current_Selection);
            this.panel_Numero_Plot_TrackBar.Controls.Add(this.trackBar2);
            this.panel_Numero_Plot_TrackBar.Controls.Add(this.label21);
            this.panel_Numero_Plot_TrackBar.Location = new System.Drawing.Point(5, 19);
            this.panel_Numero_Plot_TrackBar.Name = "panel_Numero_Plot_TrackBar";
            this.panel_Numero_Plot_TrackBar.Size = new System.Drawing.Size(282, 88);
            this.panel_Numero_Plot_TrackBar.TabIndex = 13;
            // 
            // lbl_Plot_MIN
            // 
            this.lbl_Plot_MIN.AutoSize = true;
            this.lbl_Plot_MIN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Plot_MIN.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_Plot_MIN.Location = new System.Drawing.Point(9, 62);
            this.lbl_Plot_MIN.Name = "lbl_Plot_MIN";
            this.lbl_Plot_MIN.Size = new System.Drawing.Size(15, 17);
            this.lbl_Plot_MIN.TabIndex = 15;
            this.lbl_Plot_MIN.Text = "1";
            // 
            // lbl_Plot_MAX
            // 
            this.lbl_Plot_MAX.AutoSize = true;
            this.lbl_Plot_MAX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Plot_MAX.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_Plot_MAX.Location = new System.Drawing.Point(243, 62);
            this.lbl_Plot_MAX.Name = "lbl_Plot_MAX";
            this.lbl_Plot_MAX.Size = new System.Drawing.Size(15, 17);
            this.lbl_Plot_MAX.TabIndex = 14;
            this.lbl_Plot_MAX.Text = "0";
            // 
            // lbl_Plot_Current_Selection
            // 
            this.lbl_Plot_Current_Selection.AutoSize = true;
            this.lbl_Plot_Current_Selection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Plot_Current_Selection.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_Plot_Current_Selection.Location = new System.Drawing.Point(243, 13);
            this.lbl_Plot_Current_Selection.Name = "lbl_Plot_Current_Selection";
            this.lbl_Plot_Current_Selection.Size = new System.Drawing.Size(15, 17);
            this.lbl_Plot_Current_Selection.TabIndex = 13;
            this.lbl_Plot_Current_Selection.Text = "0";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(2, 30);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(264, 45);
            this.trackBar2.TabIndex = 12;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.DarkOrange;
            this.label21.Location = new System.Drawing.Point(9, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 17);
            this.label21.TabIndex = 11;
            this.label21.Text = "Numero Plot";
            // 
            // btn_Conferma_Plot
            // 
            this.btn_Conferma_Plot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Conferma_Plot.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Conferma_Plot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Conferma_Plot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Conferma_Plot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Conferma_Plot.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Conferma_Plot.Location = new System.Drawing.Point(205, 132);
            this.btn_Conferma_Plot.Name = "btn_Conferma_Plot";
            this.btn_Conferma_Plot.Size = new System.Drawing.Size(82, 36);
            this.btn_Conferma_Plot.TabIndex = 4;
            this.btn_Conferma_Plot.Text = "Conferma";
            this.btn_Conferma_Plot.UseVisualStyleBackColor = false;
            this.btn_Conferma_Plot.Click += new System.EventHandler(this.btn_Conferma_Plot_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(7)))), ((int)(((byte)(33)))));
            this.panel5.Controls.Add(this.lbl_ID);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 393);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(860, 28);
            this.panel5.TabIndex = 1;
            // 
            // lbl_ID
            // 
            this.lbl_ID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID.ForeColor = System.Drawing.Color.White;
            this.lbl_ID.Location = new System.Drawing.Point(691, 4);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(140, 20);
            this.lbl_ID.TabIndex = 19;
            this.lbl_ID.Text = "6EDjOrju xDH7eIGB";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(229, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "I Pagamenti sono momentaneamente sospesi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(860, 421);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.groupBox1);
            this.Name = "Payment";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_Payment_USDT.ResumeLayout(false);
            this.groupBox_Payment_USDT.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Subtitle.ResumeLayout(false);
            this.pnl_Subtitle.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel_Anteprima.ResumeLayout(false);
            this.panel_Anteprima.PerformLayout();
            this.goupbox_Acquisto_Plot.ResumeLayout(false);
            this.goupbox_Acquisto_Plot.PerformLayout();
            this.panel_Plot_Manuali.ResumeLayout(false);
            this.panel_Plot_Manuali.PerformLayout();
            this.panel_Numero_Plot_TrackBar.ResumeLayout(false);
            this.panel_Numero_Plot_TrackBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox_Payment_USDT;
        private GroupBox goupbox_Acquisto_Plot;
        private Label label7;
        private Label label6;
        private ComboBox comboBox_Chain_Selection;
        private Label label5;
        private Label label3;
        private TextBox txt_Address_Recive_USDT;
        private Panel panel1;
        private Label label4;
        private Label label1;
        private Panel panel2;
        private GroupBox groupBox2;
        private Panel panel_Numero_Plot_TrackBar;
        private Panel panel_Plot_Manuali;
        private Label lbl_Plot_MIN;
        private Label lbl_Plot_MAX;
        private Label lbl_Plot_Current_Selection;
        private TrackBar trackBar2;
        private Label label21;
        private Label lbl_Avviso_Campi_Incompleti;
        private Panel panel5;
        private Label label2;
        private Panel panel_Anteprima;
        private Label lbl_Referal_Code_Anteprima;
        private Label label14;
        private Label label9;
        private TextBox txt_Plot_Anteprima;
        private TextBox txt_USDT_Anteprima;
        private TextBox textBox4;
        private Button btn_Pay;
        private Label label17;
        private Label label15;
        private Label label10;
        private Label lbl_Stato_Rete_Anteprima;
        private Label lbl_Anteprima_Rete;
        private Label label12;
        private Panel panel_Logo_Wallet;
        private Panel panel_Logo_Chain;
        private Button btn_Conferma_Plot;
        private CheckBox checkB_Plot_Manuale;
        private Label lbl_Testo_Manulale;
        private Label lbl_Anteprima_Manuale;
        private TextBox txt_Plot_Manuali;
        private Button btn_Sqlite;
        private Panel panel3;
        private Panel panel4;
        private Label label8;
        private TextBox txt_Wallet_USDT_User;
        private Panel pnl_Subtitle;
        private Label lbl_Stato_Pagamento_Timer;
        private Label label16;
        private Label lbl_Connessione_Server;
        private Label lbl_ID;
        private Button button2;
        private Button button1;
        private Label label18;
        private Label label13;
    }
}