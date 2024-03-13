using System.Drawing;
using System.Windows.Forms;

namespace Client_V3
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Menu_Laterale = new System.Windows.Forms.Panel();
            this.btn_Simulate = new FontAwesome.Sharp.IconButton();
            this.btn_Staking = new FontAwesome.Sharp.IconButton();
            this.btn_Dashboard = new FontAwesome.Sharp.IconButton();
            this.btn_Payment = new FontAwesome.Sharp.IconButton();
            this.Btn_Swap = new FontAwesome.Sharp.IconButton();
            this.btn_EULA = new FontAwesome.Sharp.IconButton();
            this.btn_Home = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Logo = new System.Windows.Forms.Label();
            this.panel_Superiore = new System.Windows.Forms.Panel();
            this.label_Form_Selected = new System.Windows.Forms.Label();
            this.icon_Current_Selection = new FontAwesome.Sharp.IconPictureBox();
            this.panel_Desktop = new System.Windows.Forms.Panel();
            this.goupB_Main_Form = new System.Windows.Forms.GroupBox();
            this.txt_Avviso = new System.Windows.Forms.TextBox();
            this.lbl_Avviso = new System.Windows.Forms.Label();
            this.Btn_Sync = new System.Windows.Forms.Button();
            this.Gbox_New_Password = new System.Windows.Forms.GroupBox();
            this.btn_New_Password_Request = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.Gbox_Reset_Password = new System.Windows.Forms.GroupBox();
            this.btn_Reset_Password = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Reset_Seed_Phrase = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Gbox_Seed_Phrase = new System.Windows.Forms.GroupBox();
            this.txt_Seed_Phrase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Conferma_Main = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Referal_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_Avviso_Main_Titolo = new System.Windows.Forms.Label();
            this.lbl_Avviso_Main = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioBtn_EULA_2 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioBtn_EULA_1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_User_Address = new System.Windows.Forms.TextBox();
            this.btn_Conferma_Password = new System.Windows.Forms.Button();
            this.txt_Password_Post = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbl_Avviso_Password = new System.Windows.Forms.Label();
            this.Gbox_New_Password_Request_Post = new System.Windows.Forms.GroupBox();
            this.Btn_Update_Password_Post = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Gbox_Reset_Password_Post = new System.Windows.Forms.GroupBox();
            this.btn_Reset_Password_Post = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_PopUp_Main_Conferma = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbl_PopUp_Main_XCH_Address = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Load_Wallet = new System.Windows.Forms.Button();
            this.comboBox_Load_Wallet = new System.Windows.Forms.ComboBox();
            this.btn_Add_Wallet = new System.Windows.Forms.Button();
            this.btn_Clear_Data_Post = new System.Windows.Forms.Button();
            this.panel_Menu_Laterale.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Superiore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Current_Selection)).BeginInit();
            this.panel_Desktop.SuspendLayout();
            this.goupB_Main_Form.SuspendLayout();
            this.Gbox_New_Password.SuspendLayout();
            this.Gbox_Reset_Password.SuspendLayout();
            this.Gbox_Seed_Phrase.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.Gbox_New_Password_Request_Post.SuspendLayout();
            this.Gbox_Reset_Password_Post.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Menu_Laterale
            // 
            this.panel_Menu_Laterale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.panel_Menu_Laterale.Controls.Add(this.btn_Simulate);
            this.panel_Menu_Laterale.Controls.Add(this.btn_Staking);
            this.panel_Menu_Laterale.Controls.Add(this.btn_Dashboard);
            this.panel_Menu_Laterale.Controls.Add(this.btn_Payment);
            this.panel_Menu_Laterale.Controls.Add(this.Btn_Swap);
            this.panel_Menu_Laterale.Controls.Add(this.btn_EULA);
            this.panel_Menu_Laterale.Controls.Add(this.btn_Home);
            this.panel_Menu_Laterale.Controls.Add(this.panel1);
            this.panel_Menu_Laterale.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu_Laterale.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu_Laterale.Name = "panel_Menu_Laterale";
            this.panel_Menu_Laterale.Size = new System.Drawing.Size(189, 521);
            this.panel_Menu_Laterale.TabIndex = 0;
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Simulate.FlatAppearance.BorderSize = 0;
            this.btn_Simulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Simulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Simulate.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_Simulate.IconChar = FontAwesome.Sharp.IconChar.Hotjar;
            this.btn_Simulate.IconColor = System.Drawing.Color.Gainsboro;
            this.btn_Simulate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Simulate.IconSize = 32;
            this.btn_Simulate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Simulate.Location = new System.Drawing.Point(0, 289);
            this.btn_Simulate.Name = "btn_Simulate";
            this.btn_Simulate.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_Simulate.Size = new System.Drawing.Size(189, 43);
            this.btn_Simulate.TabIndex = 5;
            this.btn_Simulate.Text = "Simulate";
            this.btn_Simulate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Simulate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Simulate.UseVisualStyleBackColor = true;
            this.btn_Simulate.Click += new System.EventHandler(this.btn_Simulate_Click);
            // 
            // btn_Staking
            // 
            this.btn_Staking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Staking.FlatAppearance.BorderSize = 0;
            this.btn_Staking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Staking.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Staking.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_Staking.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btn_Staking.IconColor = System.Drawing.Color.Gainsboro;
            this.btn_Staking.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Staking.IconSize = 32;
            this.btn_Staking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Staking.Location = new System.Drawing.Point(0, 246);
            this.btn_Staking.Name = "btn_Staking";
            this.btn_Staking.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_Staking.Size = new System.Drawing.Size(189, 43);
            this.btn_Staking.TabIndex = 7;
            this.btn_Staking.Text = "Staking";
            this.btn_Staking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Staking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Staking.UseVisualStyleBackColor = true;
            this.btn_Staking.Click += new System.EventHandler(this.btn_Staking_Click);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Dashboard.FlatAppearance.BorderSize = 0;
            this.btn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Dashboard.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_Dashboard.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btn_Dashboard.IconColor = System.Drawing.Color.Gainsboro;
            this.btn_Dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Dashboard.IconSize = 32;
            this.btn_Dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dashboard.Location = new System.Drawing.Point(0, 203);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_Dashboard.Size = new System.Drawing.Size(189, 43);
            this.btn_Dashboard.TabIndex = 4;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Dashboard.UseVisualStyleBackColor = true;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // btn_Payment
            // 
            this.btn_Payment.AccessibleDescription = "";
            this.btn_Payment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Payment.FlatAppearance.BorderSize = 0;
            this.btn_Payment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Payment.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_Payment.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.btn_Payment.IconColor = System.Drawing.Color.Gainsboro;
            this.btn_Payment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Payment.IconSize = 32;
            this.btn_Payment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Payment.Location = new System.Drawing.Point(0, 160);
            this.btn_Payment.Name = "btn_Payment";
            this.btn_Payment.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_Payment.Size = new System.Drawing.Size(189, 43);
            this.btn_Payment.TabIndex = 3;
            this.btn_Payment.Text = "Payment";
            this.btn_Payment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Payment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Payment.UseVisualStyleBackColor = true;
            this.btn_Payment.Click += new System.EventHandler(this.btn_Payment_Click);
            // 
            // Btn_Swap
            // 
            this.Btn_Swap.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Swap.FlatAppearance.BorderSize = 0;
            this.Btn_Swap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Swap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_Swap.ForeColor = System.Drawing.Color.DarkOrange;
            this.Btn_Swap.IconChar = FontAwesome.Sharp.IconChar.Mixer;
            this.Btn_Swap.IconColor = System.Drawing.Color.Gainsboro;
            this.Btn_Swap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Swap.IconSize = 32;
            this.Btn_Swap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Swap.Location = new System.Drawing.Point(0, 117);
            this.Btn_Swap.Name = "Btn_Swap";
            this.Btn_Swap.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Btn_Swap.Size = new System.Drawing.Size(189, 43);
            this.Btn_Swap.TabIndex = 8;
            this.Btn_Swap.Text = "Swap";
            this.Btn_Swap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Swap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Swap.UseVisualStyleBackColor = true;
            this.Btn_Swap.Click += new System.EventHandler(this.Btn_Swap_Click);
            // 
            // btn_EULA
            // 
            this.btn_EULA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_EULA.FlatAppearance.BorderSize = 0;
            this.btn_EULA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EULA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_EULA.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_EULA.IconChar = FontAwesome.Sharp.IconChar.HandsHelping;
            this.btn_EULA.IconColor = System.Drawing.Color.Gainsboro;
            this.btn_EULA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_EULA.IconSize = 32;
            this.btn_EULA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EULA.Location = new System.Drawing.Point(0, 478);
            this.btn_EULA.Name = "btn_EULA";
            this.btn_EULA.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_EULA.Size = new System.Drawing.Size(189, 43);
            this.btn_EULA.TabIndex = 6;
            this.btn_EULA.Text = "EULA";
            this.btn_EULA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EULA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_EULA.UseVisualStyleBackColor = true;
            this.btn_EULA.Click += new System.EventHandler(this.btn_EULA_Click);
            // 
            // btn_Home
            // 
            this.btn_Home.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Home.FlatAppearance.BorderSize = 0;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Home.ForeColor = System.Drawing.Color.DarkOrange;
            this.btn_Home.IconChar = FontAwesome.Sharp.IconChar.HouseChimneyUser;
            this.btn_Home.IconColor = System.Drawing.Color.Gainsboro;
            this.btn_Home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Home.IconSize = 32;
            this.btn_Home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.Location = new System.Drawing.Point(0, 74);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btn_Home.Size = new System.Drawing.Size(189, 43);
            this.btn_Home.TabIndex = 2;
            this.btn_Home.Text = "Home";
            this.btn_Home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.label_Logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 74);
            this.panel1.TabIndex = 0;
            // 
            // label_Logo
            // 
            this.label_Logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Logo.AutoSize = true;
            this.label_Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.label_Logo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label_Logo.ForeColor = System.Drawing.Color.DarkOrange;
            this.label_Logo.Location = new System.Drawing.Point(43, 25);
            this.label_Logo.Name = "label_Logo";
            this.label_Logo.Size = new System.Drawing.Size(111, 21);
            this.label_Logo.TabIndex = 1;
            this.label_Logo.Text = "Login Protocol";
            this.label_Logo.Click += new System.EventHandler(this.label_Logo_Click);
            // 
            // panel_Superiore
            // 
            this.panel_Superiore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.panel_Superiore.Controls.Add(this.label_Form_Selected);
            this.panel_Superiore.Controls.Add(this.icon_Current_Selection);
            this.panel_Superiore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Superiore.Location = new System.Drawing.Point(189, 0);
            this.panel_Superiore.Name = "panel_Superiore";
            this.panel_Superiore.Size = new System.Drawing.Size(864, 74);
            this.panel_Superiore.TabIndex = 1;
            // 
            // label_Form_Selected
            // 
            this.label_Form_Selected.AutoSize = true;
            this.label_Form_Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.label_Form_Selected.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label_Form_Selected.ForeColor = System.Drawing.Color.DarkOrange;
            this.label_Form_Selected.Location = new System.Drawing.Point(51, 21);
            this.label_Form_Selected.Name = "label_Form_Selected";
            this.label_Form_Selected.Size = new System.Drawing.Size(106, 25);
            this.label_Form_Selected.TabIndex = 2;
            this.label_Form_Selected.Text = "Login Menu";
            // 
            // icon_Current_Selection
            // 
            this.icon_Current_Selection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.icon_Current_Selection.ErrorImage = null;
            this.icon_Current_Selection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.icon_Current_Selection.IconChar = FontAwesome.Sharp.IconChar.A;
            this.icon_Current_Selection.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.icon_Current_Selection.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icon_Current_Selection.IconSize = 28;
            this.icon_Current_Selection.InitialImage = null;
            this.icon_Current_Selection.Location = new System.Drawing.Point(17, 21);
            this.icon_Current_Selection.Name = "icon_Current_Selection";
            this.icon_Current_Selection.Size = new System.Drawing.Size(31, 28);
            this.icon_Current_Selection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icon_Current_Selection.TabIndex = 2;
            this.icon_Current_Selection.TabStop = false;
            // 
            // panel_Desktop
            // 
            this.panel_Desktop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Desktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.panel_Desktop.Controls.Add(this.goupB_Main_Form);
            this.panel_Desktop.Controls.Add(this.btn_Conferma_Password);
            this.panel_Desktop.Controls.Add(this.txt_Password_Post);
            this.panel_Desktop.Controls.Add(this.panel8);
            this.panel_Desktop.Controls.Add(this.Gbox_New_Password_Request_Post);
            this.panel_Desktop.Controls.Add(this.Gbox_Reset_Password_Post);
            this.panel_Desktop.Controls.Add(this.panel6);
            this.panel_Desktop.Controls.Add(this.panel7);
            this.panel_Desktop.Controls.Add(this.groupBox1);
            this.panel_Desktop.Location = new System.Drawing.Point(189, 74);
            this.panel_Desktop.Name = "panel_Desktop";
            this.panel_Desktop.Size = new System.Drawing.Size(864, 447);
            this.panel_Desktop.TabIndex = 3;
            // 
            // goupB_Main_Form
            // 
            this.goupB_Main_Form.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goupB_Main_Form.Controls.Add(this.txt_Avviso);
            this.goupB_Main_Form.Controls.Add(this.lbl_Avviso);
            this.goupB_Main_Form.Controls.Add(this.Btn_Sync);
            this.goupB_Main_Form.Controls.Add(this.Gbox_New_Password);
            this.goupB_Main_Form.Controls.Add(this.txt_Password);
            this.goupB_Main_Form.Controls.Add(this.Gbox_Reset_Password);
            this.goupB_Main_Form.Controls.Add(this.Gbox_Seed_Phrase);
            this.goupB_Main_Form.Controls.Add(this.btn_Conferma_Main);
            this.goupB_Main_Form.Controls.Add(this.panel3);
            this.goupB_Main_Form.Controls.Add(this.groupBox2);
            this.goupB_Main_Form.Controls.Add(this.panel2);
            this.goupB_Main_Form.Controls.Add(this.txt_User_Address);
            this.goupB_Main_Form.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.goupB_Main_Form.Location = new System.Drawing.Point(6, 6);
            this.goupB_Main_Form.Name = "goupB_Main_Form";
            this.goupB_Main_Form.Size = new System.Drawing.Size(849, 443);
            this.goupB_Main_Form.TabIndex = 22;
            this.goupB_Main_Form.TabStop = false;
            // 
            // txt_Avviso
            // 
            this.txt_Avviso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Avviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Avviso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Avviso.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txt_Avviso.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Avviso.Location = new System.Drawing.Point(216, 274);
            this.txt_Avviso.Name = "txt_Avviso";
            this.txt_Avviso.ReadOnly = true;
            this.txt_Avviso.Size = new System.Drawing.Size(415, 32);
            this.txt_Avviso.TabIndex = 27;
            this.txt_Avviso.Text = "AAAA-BBBB-CCCC-DDDD";
            this.txt_Avviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Avviso.Visible = false;
            // 
            // lbl_Avviso
            // 
            this.lbl_Avviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Avviso.AutoSize = true;
            this.lbl_Avviso.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lbl_Avviso.ForeColor = System.Drawing.Color.Red;
            this.lbl_Avviso.Location = new System.Drawing.Point(192, 230);
            this.lbl_Avviso.Name = "lbl_Avviso";
            this.lbl_Avviso.Size = new System.Drawing.Size(478, 32);
            this.lbl_Avviso.TabIndex = 28;
            this.lbl_Avviso.Text = "Dont lost this code!!  SAVE IT \"Seed Phrase\"";
            this.lbl_Avviso.Visible = false;
            // 
            // Btn_Sync
            // 
            this.Btn_Sync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Sync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.Btn_Sync.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.Btn_Sync.FlatAppearance.BorderSize = 0;
            this.Btn_Sync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Btn_Sync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Sync.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Sync.ForeColor = System.Drawing.Color.Yellow;
            this.Btn_Sync.Location = new System.Drawing.Point(627, 315);
            this.Btn_Sync.Name = "Btn_Sync";
            this.Btn_Sync.Size = new System.Drawing.Size(119, 30);
            this.Btn_Sync.TabIndex = 23;
            this.Btn_Sync.Text = "Sync";
            this.Btn_Sync.UseVisualStyleBackColor = false;
            this.Btn_Sync.Visible = false;
            this.Btn_Sync.Click += new System.EventHandler(this.Btn_Sync_Click);
            // 
            // Gbox_New_Password
            // 
            this.Gbox_New_Password.Controls.Add(this.btn_New_Password_Request);
            this.Gbox_New_Password.Controls.Add(this.label10);
            this.Gbox_New_Password.Controls.Add(this.textBox1);
            this.Gbox_New_Password.Controls.Add(this.label11);
            this.Gbox_New_Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gbox_New_Password.Location = new System.Drawing.Point(131, 318);
            this.Gbox_New_Password.Name = "Gbox_New_Password";
            this.Gbox_New_Password.Size = new System.Drawing.Size(250, 121);
            this.Gbox_New_Password.TabIndex = 26;
            this.Gbox_New_Password.TabStop = false;
            this.Gbox_New_Password.Text = "New Password Request";
            this.Gbox_New_Password.Visible = false;
            // 
            // btn_New_Password_Request
            // 
            this.btn_New_Password_Request.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Password_Request.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_New_Password_Request.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_New_Password_Request.FlatAppearance.BorderSize = 0;
            this.btn_New_Password_Request.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_New_Password_Request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_New_Password_Request.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_New_Password_Request.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_New_Password_Request.Location = new System.Drawing.Point(10, 84);
            this.btn_New_Password_Request.Name = "btn_New_Password_Request";
            this.btn_New_Password_Request.Size = new System.Drawing.Size(229, 30);
            this.btn_New_Password_Request.TabIndex = 26;
            this.btn_New_Password_Request.Text = "Update Password";
            this.btn_New_Password_Request.UseVisualStyleBackColor = false;
            this.btn_New_Password_Request.Click += new System.EventHandler(this.btn_New_Password_Request_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label10.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label10.Location = new System.Drawing.Point(19, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Insert your new password here:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox1.Location = new System.Drawing.Point(6, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "Password";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(24, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "New Password: If not, ingore it";
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Password.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Password.Location = new System.Drawing.Point(5, 73);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(839, 20);
            this.txt_Password.TabIndex = 25;
            this.txt_Password.Text = "Inserisci Password (Opzionale)";
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Gbox_Reset_Password
            // 
            this.Gbox_Reset_Password.Controls.Add(this.btn_Reset_Password);
            this.Gbox_Reset_Password.Controls.Add(this.label9);
            this.Gbox_Reset_Password.Controls.Add(this.txt_Reset_Seed_Phrase);
            this.Gbox_Reset_Password.Controls.Add(this.label8);
            this.Gbox_Reset_Password.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gbox_Reset_Password.Location = new System.Drawing.Point(380, 318);
            this.Gbox_Reset_Password.Name = "Gbox_Reset_Password";
            this.Gbox_Reset_Password.Size = new System.Drawing.Size(241, 121);
            this.Gbox_Reset_Password.TabIndex = 24;
            this.Gbox_Reset_Password.TabStop = false;
            this.Gbox_Reset_Password.Text = "Reset Password";
            this.Gbox_Reset_Password.Visible = false;
            // 
            // btn_Reset_Password
            // 
            this.btn_Reset_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reset_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Reset_Password.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Reset_Password.FlatAppearance.BorderSize = 0;
            this.btn_Reset_Password.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Reset_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset_Password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Reset_Password.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Reset_Password.Location = new System.Drawing.Point(6, 85);
            this.btn_Reset_Password.Name = "btn_Reset_Password";
            this.btn_Reset_Password.Size = new System.Drawing.Size(229, 30);
            this.btn_Reset_Password.TabIndex = 25;
            this.btn_Reset_Password.Text = "Reset Password";
            this.btn_Reset_Password.UseVisualStyleBackColor = false;
            this.btn_Reset_Password.Click += new System.EventHandler(this.btn_Reset_Password_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label9.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label9.Location = new System.Drawing.Point(24, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Insert your seed phrase here:";
            // 
            // txt_Reset_Seed_Phrase
            // 
            this.txt_Reset_Seed_Phrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Reset_Seed_Phrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Reset_Seed_Phrase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Reset_Seed_Phrase.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Reset_Seed_Phrase.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Reset_Seed_Phrase.Location = new System.Drawing.Point(6, 60);
            this.txt_Reset_Seed_Phrase.Name = "txt_Reset_Seed_Phrase";
            this.txt_Reset_Seed_Phrase.Size = new System.Drawing.Size(229, 20);
            this.txt_Reset_Seed_Phrase.TabIndex = 24;
            this.txt_Reset_Seed_Phrase.Text = "AAAA-BBBB-CCCC-DDDD";
            this.txt_Reset_Seed_Phrase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(16, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Lost password? Need reset it?";
            // 
            // Gbox_Seed_Phrase
            // 
            this.Gbox_Seed_Phrase.Controls.Add(this.txt_Seed_Phrase);
            this.Gbox_Seed_Phrase.Controls.Add(this.label6);
            this.Gbox_Seed_Phrase.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gbox_Seed_Phrase.Location = new System.Drawing.Point(620, 373);
            this.Gbox_Seed_Phrase.Name = "Gbox_Seed_Phrase";
            this.Gbox_Seed_Phrase.Size = new System.Drawing.Size(224, 66);
            this.Gbox_Seed_Phrase.TabIndex = 23;
            this.Gbox_Seed_Phrase.TabStop = false;
            this.Gbox_Seed_Phrase.Text = "Seed Phrase";
            this.Gbox_Seed_Phrase.Visible = false;
            // 
            // txt_Seed_Phrase
            // 
            this.txt_Seed_Phrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Seed_Phrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Seed_Phrase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Seed_Phrase.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Seed_Phrase.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Seed_Phrase.Location = new System.Drawing.Point(6, 39);
            this.txt_Seed_Phrase.Name = "txt_Seed_Phrase";
            this.txt_Seed_Phrase.ReadOnly = true;
            this.txt_Seed_Phrase.Size = new System.Drawing.Size(212, 20);
            this.txt_Seed_Phrase.TabIndex = 24;
            this.txt_Seed_Phrase.Text = "SEED-xDIx-PROVA-xxxx";
            this.txt_Seed_Phrase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(38, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Dont lost this code!!";
            // 
            // btn_Conferma_Main
            // 
            this.btn_Conferma_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Conferma_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Conferma_Main.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Conferma_Main.FlatAppearance.BorderSize = 0;
            this.btn_Conferma_Main.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Conferma_Main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Conferma_Main.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Conferma_Main.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Conferma_Main.Location = new System.Drawing.Point(5, 193);
            this.btn_Conferma_Main.Name = "btn_Conferma_Main";
            this.btn_Conferma_Main.Size = new System.Drawing.Size(839, 30);
            this.btn_Conferma_Main.TabIndex = 19;
            this.btn_Conferma_Main.Text = "Conferma";
            this.btn_Conferma_Main.UseVisualStyleBackColor = false;
            this.btn_Conferma_Main.Click += new System.EventHandler(this.btn_Conferma_Main_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.txt_Referal_Code);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(5, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(839, 27);
            this.panel3.TabIndex = 22;
            // 
            // txt_Referal_Code
            // 
            this.txt_Referal_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_Referal_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Referal_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Referal_Code.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Referal_Code.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Referal_Code.Location = new System.Drawing.Point(374, 3);
            this.txt_Referal_Code.Name = "txt_Referal_Code";
            this.txt_Referal_Code.Size = new System.Drawing.Size(88, 20);
            this.txt_Referal_Code.TabIndex = 23;
            this.txt_Referal_Code.Text = "Ref_Code";
            this.txt_Referal_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(85, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inserisci un";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(161, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "referal code:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "(Opzionale)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.groupBox2.Controls.Add(this.lbl_Avviso_Main_Titolo);
            this.groupBox2.Controls.Add(this.lbl_Avviso_Main);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(5, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 61);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EULA";
            // 
            // lbl_Avviso_Main_Titolo
            // 
            this.lbl_Avviso_Main_Titolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Avviso_Main_Titolo.AutoSize = true;
            this.lbl_Avviso_Main_Titolo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Avviso_Main_Titolo.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_Avviso_Main_Titolo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Avviso_Main_Titolo.Location = new System.Drawing.Point(434, 13);
            this.lbl_Avviso_Main_Titolo.Name = "lbl_Avviso_Main_Titolo";
            this.lbl_Avviso_Main_Titolo.Size = new System.Drawing.Size(115, 20);
            this.lbl_Avviso_Main_Titolo.TabIndex = 24;
            this.lbl_Avviso_Main_Titolo.Text = "Per continuare:";
            this.lbl_Avviso_Main_Titolo.Visible = false;
            // 
            // lbl_Avviso_Main
            // 
            this.lbl_Avviso_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Avviso_Main.AutoSize = true;
            this.lbl_Avviso_Main.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Avviso_Main.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_Avviso_Main.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Avviso_Main.Location = new System.Drawing.Point(434, 34);
            this.lbl_Avviso_Main.Name = "lbl_Avviso_Main";
            this.lbl_Avviso_Main.Size = new System.Drawing.Size(293, 20);
            this.lbl_Avviso_Main.TabIndex = 23;
            this.lbl_Avviso_Main.Text = "Accetta EULA ed Insierisci indirizzo CHIA";
            this.lbl_Avviso_Main.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.Controls.Add(this.radioBtn_EULA_2);
            this.panel5.Location = new System.Drawing.Point(3, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 23);
            this.panel5.TabIndex = 23;
            // 
            // radioBtn_EULA_2
            // 
            this.radioBtn_EULA_2.AutoSize = true;
            this.radioBtn_EULA_2.ForeColor = System.Drawing.SystemColors.Control;
            this.radioBtn_EULA_2.Location = new System.Drawing.Point(3, 3);
            this.radioBtn_EULA_2.Name = "radioBtn_EULA_2";
            this.radioBtn_EULA_2.Size = new System.Drawing.Size(252, 17);
            this.radioBtn_EULA_2.TabIndex = 16;
            this.radioBtn_EULA_2.TabStop = true;
            this.radioBtn_EULA_2.Text = "Accetto i rischi legati alla fluttuazione dei mercati";
            this.radioBtn_EULA_2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.Controls.Add(this.radioBtn_EULA_1);
            this.panel4.Location = new System.Drawing.Point(3, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 22);
            this.panel4.TabIndex = 23;
            // 
            // radioBtn_EULA_1
            // 
            this.radioBtn_EULA_1.AutoSize = true;
            this.radioBtn_EULA_1.ForeColor = System.Drawing.SystemColors.Control;
            this.radioBtn_EULA_1.Location = new System.Drawing.Point(3, 3);
            this.radioBtn_EULA_1.Name = "radioBtn_EULA_1";
            this.radioBtn_EULA_1.Size = new System.Drawing.Size(196, 17);
            this.radioBtn_EULA_1.TabIndex = 15;
            this.radioBtn_EULA_1.TabStop = true;
            this.radioBtn_EULA_1.Text = "Accetto i rischi legati alla blockchain";
            this.radioBtn_EULA_1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 29);
            this.panel2.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.Location = new System.Drawing.Point(302, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Inserisci un";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(378, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "wallet chia";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(457, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "per accedere";
            // 
            // txt_User_Address
            // 
            this.txt_User_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_User_Address.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_User_Address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_User_Address.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_User_Address.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_User_Address.Location = new System.Drawing.Point(5, 47);
            this.txt_User_Address.Name = "txt_User_Address";
            this.txt_User_Address.Size = new System.Drawing.Size(839, 20);
            this.txt_User_Address.TabIndex = 18;
            this.txt_User_Address.Text = "Inserisci wallet XCH";
            this.txt_User_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Conferma_Password
            // 
            this.btn_Conferma_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Conferma_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Conferma_Password.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Conferma_Password.FlatAppearance.BorderSize = 0;
            this.btn_Conferma_Password.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Conferma_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Conferma_Password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Conferma_Password.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Conferma_Password.Location = new System.Drawing.Point(502, 48);
            this.btn_Conferma_Password.Name = "btn_Conferma_Password";
            this.btn_Conferma_Password.Size = new System.Drawing.Size(346, 30);
            this.btn_Conferma_Password.TabIndex = 30;
            this.btn_Conferma_Password.Text = "Conferma";
            this.btn_Conferma_Password.UseVisualStyleBackColor = false;
            this.btn_Conferma_Password.Visible = false;
            this.btn_Conferma_Password.Click += new System.EventHandler(this.btn_Conferma_Password_Click);
            // 
            // txt_Password_Post
            // 
            this.txt_Password_Post.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password_Post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.txt_Password_Post.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password_Post.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Password_Post.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Password_Post.Location = new System.Drawing.Point(9, 19);
            this.txt_Password_Post.Name = "txt_Password_Post";
            this.txt_Password_Post.Size = new System.Drawing.Size(839, 20);
            this.txt_Password_Post.TabIndex = 29;
            this.txt_Password_Post.Text = "Inserisci Password (Opzionale)";
            this.txt_Password_Post.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel8.Controls.Add(this.lbl_Avviso_Password);
            this.panel8.Location = new System.Drawing.Point(6, 302);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(643, 23);
            this.panel8.TabIndex = 29;
            // 
            // lbl_Avviso_Password
            // 
            this.lbl_Avviso_Password.AutoSize = true;
            this.lbl_Avviso_Password.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_Avviso_Password.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_Avviso_Password.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Avviso_Password.Location = new System.Drawing.Point(3, 3);
            this.lbl_Avviso_Password.Name = "lbl_Avviso_Password";
            this.lbl_Avviso_Password.Size = new System.Drawing.Size(293, 20);
            this.lbl_Avviso_Password.TabIndex = 24;
            this.lbl_Avviso_Password.Text = "Accetta EULA ed Insierisci indirizzo CHIA";
            this.lbl_Avviso_Password.Visible = false;
            // 
            // Gbox_New_Password_Request_Post
            // 
            this.Gbox_New_Password_Request_Post.Controls.Add(this.Btn_Update_Password_Post);
            this.Gbox_New_Password_Request_Post.Controls.Add(this.label12);
            this.Gbox_New_Password_Request_Post.Controls.Add(this.textBox2);
            this.Gbox_New_Password_Request_Post.Controls.Add(this.label13);
            this.Gbox_New_Password_Request_Post.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gbox_New_Password_Request_Post.Location = new System.Drawing.Point(246, 43);
            this.Gbox_New_Password_Request_Post.Name = "Gbox_New_Password_Request_Post";
            this.Gbox_New_Password_Request_Post.Size = new System.Drawing.Size(250, 121);
            this.Gbox_New_Password_Request_Post.TabIndex = 28;
            this.Gbox_New_Password_Request_Post.TabStop = false;
            this.Gbox_New_Password_Request_Post.Text = "New Password Request";
            this.Gbox_New_Password_Request_Post.Visible = false;
            // 
            // Btn_Update_Password_Post
            // 
            this.Btn_Update_Password_Post.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Update_Password_Post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.Btn_Update_Password_Post.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.Btn_Update_Password_Post.FlatAppearance.BorderSize = 0;
            this.Btn_Update_Password_Post.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.Btn_Update_Password_Post.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Update_Password_Post.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Btn_Update_Password_Post.ForeColor = System.Drawing.Color.ForestGreen;
            this.Btn_Update_Password_Post.Location = new System.Drawing.Point(10, 84);
            this.Btn_Update_Password_Post.Name = "Btn_Update_Password_Post";
            this.Btn_Update_Password_Post.Size = new System.Drawing.Size(229, 30);
            this.Btn_Update_Password_Post.TabIndex = 26;
            this.Btn_Update_Password_Post.Text = "Update Password";
            this.Btn_Update_Password_Post.UseVisualStyleBackColor = false;
            this.Btn_Update_Password_Post.Click += new System.EventHandler(this.Btn_Update_Password_Post_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label12.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label12.Location = new System.Drawing.Point(19, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(212, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Insert your new password here:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox2.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox2.Location = new System.Drawing.Point(6, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(238, 20);
            this.textBox2.TabIndex = 24;
            this.textBox2.Text = "AAAA-BBBB-CCCC-DDDD";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(24, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(209, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "New Password: If not, ingore it";
            // 
            // Gbox_Reset_Password_Post
            // 
            this.Gbox_Reset_Password_Post.Controls.Add(this.btn_Reset_Password_Post);
            this.Gbox_Reset_Password_Post.Controls.Add(this.label14);
            this.Gbox_Reset_Password_Post.Controls.Add(this.textBox3);
            this.Gbox_Reset_Password_Post.Controls.Add(this.label15);
            this.Gbox_Reset_Password_Post.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gbox_Reset_Password_Post.Location = new System.Drawing.Point(6, 43);
            this.Gbox_Reset_Password_Post.Name = "Gbox_Reset_Password_Post";
            this.Gbox_Reset_Password_Post.Size = new System.Drawing.Size(241, 121);
            this.Gbox_Reset_Password_Post.TabIndex = 27;
            this.Gbox_Reset_Password_Post.TabStop = false;
            this.Gbox_Reset_Password_Post.Text = "Reset Password";
            this.Gbox_Reset_Password_Post.Visible = false;
            // 
            // btn_Reset_Password_Post
            // 
            this.btn_Reset_Password_Post.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reset_Password_Post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Reset_Password_Post.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Reset_Password_Post.FlatAppearance.BorderSize = 0;
            this.btn_Reset_Password_Post.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Reset_Password_Post.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset_Password_Post.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Reset_Password_Post.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Reset_Password_Post.Location = new System.Drawing.Point(6, 85);
            this.btn_Reset_Password_Post.Name = "btn_Reset_Password_Post";
            this.btn_Reset_Password_Post.Size = new System.Drawing.Size(229, 30);
            this.btn_Reset_Password_Post.TabIndex = 25;
            this.btn_Reset_Password_Post.Text = "Reset Password";
            this.btn_Reset_Password_Post.UseVisualStyleBackColor = false;
            this.btn_Reset_Password_Post.Click += new System.EventHandler(this.btn_Reset_Password_Post_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label14.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label14.Location = new System.Drawing.Point(24, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Insert your seed phrase here:";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox3.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox3.Location = new System.Drawing.Point(6, 60);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(229, 20);
            this.textBox3.TabIndex = 24;
            this.textBox3.Text = "AAAA-BBBB-CCCC-DDDD";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(16, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(206, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Lost password? Need reset it?";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel6.Controls.Add(this.lbl_PopUp_Main_Conferma);
            this.panel6.Location = new System.Drawing.Point(6, 258);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(643, 23);
            this.panel6.TabIndex = 25;
            // 
            // lbl_PopUp_Main_Conferma
            // 
            this.lbl_PopUp_Main_Conferma.AutoSize = true;
            this.lbl_PopUp_Main_Conferma.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_PopUp_Main_Conferma.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_PopUp_Main_Conferma.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_PopUp_Main_Conferma.Location = new System.Drawing.Point(3, 3);
            this.lbl_PopUp_Main_Conferma.Name = "lbl_PopUp_Main_Conferma";
            this.lbl_PopUp_Main_Conferma.Size = new System.Drawing.Size(293, 20);
            this.lbl_PopUp_Main_Conferma.TabIndex = 24;
            this.lbl_PopUp_Main_Conferma.Text = "Accetta EULA ed Insierisci indirizzo CHIA";
            this.lbl_PopUp_Main_Conferma.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel7.Controls.Add(this.lbl_PopUp_Main_XCH_Address);
            this.panel7.Location = new System.Drawing.Point(6, 280);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(643, 23);
            this.panel7.TabIndex = 26;
            // 
            // lbl_PopUp_Main_XCH_Address
            // 
            this.lbl_PopUp_Main_XCH_Address.AutoSize = true;
            this.lbl_PopUp_Main_XCH_Address.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_PopUp_Main_XCH_Address.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_PopUp_Main_XCH_Address.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_PopUp_Main_XCH_Address.Location = new System.Drawing.Point(3, 3);
            this.lbl_PopUp_Main_XCH_Address.Name = "lbl_PopUp_Main_XCH_Address";
            this.lbl_PopUp_Main_XCH_Address.Size = new System.Drawing.Size(293, 20);
            this.lbl_PopUp_Main_XCH_Address.TabIndex = 24;
            this.lbl_PopUp_Main_XCH_Address.Text = "Accetta EULA ed Insierisci indirizzo CHIA";
            this.lbl_PopUp_Main_XCH_Address.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Clear_Data_Post);
            this.groupBox1.Controls.Add(this.btn_Add_Wallet);
            this.groupBox1.Controls.Add(this.comboBox_Load_Wallet);
            this.groupBox1.Controls.Add(this.btn_Load_Wallet);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(502, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 153);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Wallet";
            // 
            // btn_Load_Wallet
            // 
            this.btn_Load_Wallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Load_Wallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Load_Wallet.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Load_Wallet.FlatAppearance.BorderSize = 0;
            this.btn_Load_Wallet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Load_Wallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Load_Wallet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Load_Wallet.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Load_Wallet.Location = new System.Drawing.Point(6, 14);
            this.btn_Load_Wallet.Name = "btn_Load_Wallet";
            this.btn_Load_Wallet.Size = new System.Drawing.Size(299, 30);
            this.btn_Load_Wallet.TabIndex = 25;
            this.btn_Load_Wallet.Text = "Load Wallet";
            this.btn_Load_Wallet.UseVisualStyleBackColor = false;
            this.btn_Load_Wallet.Click += new System.EventHandler(this.btn_Load_Wallet_Click);
            // 
            // comboBox_Load_Wallet
            // 
            this.comboBox_Load_Wallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.comboBox_Load_Wallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Load_Wallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Load_Wallet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox_Load_Wallet.ForeColor = System.Drawing.SystemColors.Control;
            this.comboBox_Load_Wallet.FormattingEnabled = true;
            this.comboBox_Load_Wallet.Location = new System.Drawing.Point(6, 46);
            this.comboBox_Load_Wallet.Name = "comboBox_Load_Wallet";
            this.comboBox_Load_Wallet.Size = new System.Drawing.Size(299, 23);
            this.comboBox_Load_Wallet.TabIndex = 26;
            // 
            // btn_Add_Wallet
            // 
            this.btn_Add_Wallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add_Wallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Add_Wallet.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Add_Wallet.FlatAppearance.BorderSize = 0;
            this.btn_Add_Wallet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Add_Wallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Wallet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Add_Wallet.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Add_Wallet.Location = new System.Drawing.Point(6, 74);
            this.btn_Add_Wallet.Name = "btn_Add_Wallet";
            this.btn_Add_Wallet.Size = new System.Drawing.Size(149, 30);
            this.btn_Add_Wallet.TabIndex = 27;
            this.btn_Add_Wallet.Text = "Add Wallet";
            this.btn_Add_Wallet.UseVisualStyleBackColor = false;
            this.btn_Add_Wallet.Click += new System.EventHandler(this.btn_Add_Wallet_Click);
            // 
            // btn_Clear_Data_Post
            // 
            this.btn_Clear_Data_Post.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear_Data_Post.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(47)))));
            this.btn_Clear_Data_Post.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btn_Clear_Data_Post.FlatAppearance.BorderSize = 0;
            this.btn_Clear_Data_Post.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btn_Clear_Data_Post.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear_Data_Post.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Clear_Data_Post.ForeColor = System.Drawing.Color.Red;
            this.btn_Clear_Data_Post.Location = new System.Drawing.Point(161, 75);
            this.btn_Clear_Data_Post.Name = "btn_Clear_Data_Post";
            this.btn_Clear_Data_Post.Size = new System.Drawing.Size(144, 30);
            this.btn_Clear_Data_Post.TabIndex = 28;
            this.btn_Clear_Data_Post.Text = "Clear Data";
            this.btn_Clear_Data_Post.UseVisualStyleBackColor = false;
            this.btn_Clear_Data_Post.Click += new System.EventHandler(this.btn_Clear_Data_Post_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 521);
            this.Controls.Add(this.panel_Desktop);
            this.Controls.Add(this.panel_Superiore);
            this.Controls.Add(this.panel_Menu_Laterale);
            this.MinimumSize = new System.Drawing.Size(900, 425);
            this.Name = "FormMain";
            this.Text = "Deep Mining Protocol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel_Menu_Laterale.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Superiore.ResumeLayout(false);
            this.panel_Superiore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Current_Selection)).EndInit();
            this.panel_Desktop.ResumeLayout(false);
            this.panel_Desktop.PerformLayout();
            this.goupB_Main_Form.ResumeLayout(false);
            this.goupB_Main_Form.PerformLayout();
            this.Gbox_New_Password.ResumeLayout(false);
            this.Gbox_New_Password.PerformLayout();
            this.Gbox_Reset_Password.ResumeLayout(false);
            this.Gbox_Reset_Password.PerformLayout();
            this.Gbox_Seed_Phrase.ResumeLayout(false);
            this.Gbox_Seed_Phrase.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.Gbox_New_Password_Request_Post.ResumeLayout(false);
            this.Gbox_New_Password_Request_Post.PerformLayout();
            this.Gbox_Reset_Password_Post.ResumeLayout(false);
            this.Gbox_Reset_Password_Post.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_Menu_Laterale;
        private Panel panel1;
        private Label label_Logo;
        private FontAwesome.Sharp.IconButton btn_Simulate;
        private FontAwesome.Sharp.IconButton btn_Dashboard;
        private FontAwesome.Sharp.IconButton btn_Payment;
        private FontAwesome.Sharp.IconButton btn_Home;
        private FontAwesome.Sharp.IconButton btn_EULA;
        private Panel panel_Superiore;
        private FontAwesome.Sharp.IconPictureBox icon_Current_Selection;
        private Label label_Form_Selected;
        private Panel panel_Desktop;
        private GroupBox goupB_Main_Form;
        private GroupBox groupBox2;
        private RadioButton radioBtn_EULA_1;
        private Panel panel2;
        private Label label7;
        private Label label1;
        private Label label2;
        private Button btn_Conferma_Main;
        private TextBox txt_User_Address;
        private Panel panel3;
        private TextBox txt_Referal_Code;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel4;
        private Panel panel5;
        private RadioButton radioBtn_EULA_2;
        private Label lbl_Avviso_Main;
        private Label lbl_Avviso_Main_Titolo;
        private Label lbl_PopUp_Main_Conferma;
        private Panel panel6;
        private Panel panel7;
        private Label lbl_PopUp_Main_XCH_Address;
        private Button Btn_Sync;
        private FontAwesome.Sharp.IconButton btn_Staking;
        private FontAwesome.Sharp.IconButton Btn_Swap;
        private GroupBox Gbox_Reset_Password;
        private TextBox txt_Reset_Seed_Phrase;
        private Label label8;
        private GroupBox Gbox_Seed_Phrase;
        private TextBox txt_Seed_Phrase;
        private Label label6;
        private Button btn_Reset_Password;
        private Label label9;
        private GroupBox Gbox_New_Password;
        private Label label10;
        private TextBox textBox1;
        private Label label11;
        private TextBox txt_Password;
        private TextBox txt_Avviso;
        private Label lbl_Avviso;
        private Button btn_New_Password_Request;
        private GroupBox Gbox_New_Password_Request_Post;
        private Button Btn_Update_Password_Post;
        private Label label12;
        private TextBox textBox2;
        private Label label13;
        private GroupBox Gbox_Reset_Password_Post;
        private Button btn_Reset_Password_Post;
        private Label label14;
        private TextBox textBox3;
        private Label label15;
        private Panel panel8;
        private Label lbl_Avviso_Password;
        private TextBox txt_Password_Post;
        private Button btn_Conferma_Password;
        private GroupBox groupBox1;
        private Button btn_Load_Wallet;
        private ComboBox comboBox_Load_Wallet;
        private Button btn_Add_Wallet;
        private Button btn_Clear_Data_Post;
    }
}