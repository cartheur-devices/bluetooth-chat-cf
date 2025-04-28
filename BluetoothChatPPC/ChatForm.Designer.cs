namespace BluetoothChatPPC
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSend = new System.Windows.Forms.MenuItem();
            this.mnuMenu = new System.Windows.Forms.MenuItem();
            this.mnuSearch = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.btnSend = new System.Windows.Forms.Button();
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtMessagesArchive = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuSend);
            this.mainMenu1.MenuItems.Add(this.mnuMenu);
            // 
            // mnuSend
            // 
            this.mnuSend.Text = "Send";
            this.mnuSend.Click += new System.EventHandler(this.mnuSend_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.MenuItems.Add(this.mnuSearch);
            this.mnuMenu.MenuItems.Add(this.mnuExit);
            this.mnuMenu.Text = "Menu";
            // 
            // mnuSearch
            // 
            this.mnuSearch.Text = "Search Again";
            this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(184, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(48, 24);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cboDevices
            // 
            this.cboDevices.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cboDevices.Location = new System.Drawing.Point(8, 42);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(224, 22);
            this.cboDevices.TabIndex = 5;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMessage.Location = new System.Drawing.Point(8, 10);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(176, 21);
            this.txtMessage.TabIndex = 6;
            // 
            // txtMessagesArchive
            // 
            this.txtMessagesArchive.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMessagesArchive.Location = new System.Drawing.Point(8, 74);
            this.txtMessagesArchive.Multiline = true;
            this.txtMessagesArchive.Name = "txtMessagesArchive";
            this.txtMessagesArchive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessagesArchive.Size = new System.Drawing.Size(224, 115);
            this.txtMessagesArchive.TabIndex = 7;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cboDevices);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtMessagesArchive);
            this.Menu = this.mainMenu1;
            this.Name = "ChatForm";
            this.Text = "Bluetooth Chat";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuSend;
        private System.Windows.Forms.MenuItem mnuMenu;
        private System.Windows.Forms.MenuItem mnuSearch;
        private System.Windows.Forms.MenuItem mnuExit;
        internal System.Windows.Forms.Button btnSend;
        internal System.Windows.Forms.ComboBox cboDevices;
        internal System.Windows.Forms.TextBox txtMessage;
        internal System.Windows.Forms.TextBox txtMessagesArchive;
    }
}

