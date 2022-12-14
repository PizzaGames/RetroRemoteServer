namespace RetroRemoteServer
{
    partial class RetroRemoteForm
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
            this.btCapture = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btStartServer = new System.Windows.Forms.Button();
            this.lbAddress = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCapture
            // 
            this.btCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCapture.Enabled = false;
            this.btCapture.Location = new System.Drawing.Point(725, 397);
            this.btCapture.Name = "btCapture";
            this.btCapture.Size = new System.Drawing.Size(145, 23);
            this.btCapture.TabIndex = 0;
            this.btCapture.Text = "Capture Inputs...";
            this.btCapture.UseVisualStyleBackColor = true;
            this.btCapture.Click += new System.EventHandler(this.btCapture_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtConsole.Location = new System.Drawing.Point(12, 12);
            this.txtConsole.MaxLength = 99999999;
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(858, 379);
            this.txtConsole.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatus.Text = "Ready...";
            // 
            // btStartServer
            // 
            this.btStartServer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btStartServer.Location = new System.Drawing.Point(582, 397);
            this.btStartServer.Name = "btStartServer";
            this.btStartServer.Size = new System.Drawing.Size(137, 23);
            this.btStartServer.TabIndex = 6;
            this.btStartServer.Text = "Start Server...";
            this.btStartServer.UseVisualStyleBackColor = true;
            this.btStartServer.Click += new System.EventHandler(this.btStartServer_Click);
            // 
            // lbAddress
            // 
            this.lbAddress.Location = new System.Drawing.Point(12, 401);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(57, 15);
            this.lbAddress.TabIndex = 7;
            this.lbAddress.Text = "Address:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(75, 397);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(118, 23);
            this.txtIP.TabIndex = 8;
            this.txtIP.Text = "10.0.0.20";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(199, 400);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(32, 15);
            this.lbPort.TabIndex = 9;
            this.lbPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(237, 397);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(69, 23);
            this.txtPort.TabIndex = 10;
            this.txtPort.Text = "9999";
            // 
            // RetroRemoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 448);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.btStartServer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btCapture);
            this.Name = "RetroRemoteForm";
            this.Text = "RetroRemote Server";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btCapture;
        private TextBox txtConsole;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatus;
        private Button btStartServer;
        private Label lbAddress;
        private TextBox txtIP;
        private Label lbPort;
        private TextBox txtPort;
    }
}