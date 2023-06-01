namespace Chia_Cloud_Mining_AutoPayment_V2
{
    partial class ServerSocket
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
            this.btn_Server_Start = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.btn_Server_Stop = new System.Windows.Forms.Button();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.btn_Test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Server_Start
            // 
            this.btn_Server_Start.BackColor = System.Drawing.Color.Silver;
            this.btn_Server_Start.Location = new System.Drawing.Point(277, 12);
            this.btn_Server_Start.Name = "btn_Server_Start";
            this.btn_Server_Start.Size = new System.Drawing.Size(122, 44);
            this.btn_Server_Start.TabIndex = 0;
            this.btn_Server_Start.Text = "Server Start";
            this.btn_Server_Start.UseVisualStyleBackColor = false;
            this.btn_Server_Start.Click += new System.EventHandler(this.btn_Server_Start_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 62);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(254, 175);
            this.logTextBox.TabIndex = 1;
            // 
            // btn_Server_Stop
            // 
            this.btn_Server_Stop.BackColor = System.Drawing.Color.Silver;
            this.btn_Server_Stop.Location = new System.Drawing.Point(277, 62);
            this.btn_Server_Stop.Name = "btn_Server_Stop";
            this.btn_Server_Stop.Size = new System.Drawing.Size(122, 44);
            this.btn_Server_Stop.TabIndex = 2;
            this.btn_Server_Stop.Text = "Server Stop";
            this.btn_Server_Stop.UseVisualStyleBackColor = false;
            this.btn_Server_Stop.Click += new System.EventHandler(this.btn_Server_Stop_Click);
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Location = new System.Drawing.Point(12, 12);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(151, 20);
            this.ipAddressTextBox.TabIndex = 3;
            this.ipAddressTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(169, 12);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(97, 20);
            this.portTextBox.TabIndex = 4;
            this.portTextBox.Text = "48500";
            // 
            // btn_Test
            // 
            this.btn_Test.BackColor = System.Drawing.Color.Silver;
            this.btn_Test.Location = new System.Drawing.Point(277, 134);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(122, 44);
            this.btn_Test.TabIndex = 5;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = false;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // ServerSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(411, 249);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipAddressTextBox);
            this.Controls.Add(this.btn_Server_Stop);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.btn_Server_Start);
            this.Name = "ServerSocket";
            this.Text = "ServerSocket";
            this.Load += new System.EventHandler(this.ServerSocket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Server_Start;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button btn_Server_Stop;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button btn_Test;
    }
}