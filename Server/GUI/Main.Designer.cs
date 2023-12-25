namespace WindowsFormsApp8
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ClientsList = new System.Windows.Forms.ListView();
            this.Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Country = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pubip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Current = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.system = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Privileges = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OpenDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.serverCreationStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerTalkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.disconnectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.clientChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blindShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs = new System.Windows.Forms.TabControl();
            this.Welcome = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientList = new System.Windows.Forms.TabPage();
            this.Clients = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Logs = new System.Windows.Forms.TabPage();
            this.logView = new System.Windows.Forms.ListView();
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Settings = new System.Windows.Forms.TabPage();
            this.HostValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lineup = new System.Windows.Forms.CheckBox();
            this.top = new System.Windows.Forms.CheckBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.StripMenu.SuspendLayout();
            this.tabs.SuspendLayout();
            this.Welcome.SuspendLayout();
            this.ClientList.SuspendLayout();
            this.Logs.SuspendLayout();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientsList
            // 
            this.ClientsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Client,
            this.Country,
            this.pubip,
            this.Current,
            this.idle,
            this.system,
            this.Privileges,
            this.OpenDate});
            this.ClientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsList.HideSelection = false;
            this.ClientsList.Location = new System.Drawing.Point(3, 3);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(879, 337);
            this.ClientsList.TabIndex = 0;
            this.ClientsList.UseCompatibleStateImageBehavior = false;
            this.ClientsList.View = System.Windows.Forms.View.Details;
            // 
            // Client
            // 
            this.Client.Text = "Client";
            this.Client.Width = 120;
            // 
            // Country
            // 
            this.Country.Text = "Country";
            this.Country.Width = 80;
            // 
            // pubip
            // 
            this.pubip.Text = "Public IP";
            this.pubip.Width = 80;
            // 
            // Current
            // 
            this.Current.Text = "CurrentWindow";
            this.Current.Width = 120;
            // 
            // idle
            // 
            this.idle.Text = "Idle time";
            this.idle.Width = 100;
            // 
            // system
            // 
            this.system.Text = "Operating system";
            this.system.Width = 130;
            // 
            // Privileges
            // 
            this.Privileges.Text = "Privileges";
            this.Privileges.Width = 104;
            // 
            // OpenDate
            // 
            this.OpenDate.Text = "Opening Date";
            this.OpenDate.Width = 130;
            // 
            // StripMenu
            // 
            this.StripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverCreationStripMenuItem,
            this.buildProgramToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolsToolStripMenuItem,
            this.screenShareToolStripMenuItem,
            this.cameraViewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.clientChatToolStripMenuItem,
            this.blindShellToolStripMenuItem,
            this.keyloggerToolStripMenuItem});
            this.StripMenu.Name = "StripMenu";
            this.StripMenu.Size = new System.Drawing.Size(151, 192);
            // 
            // serverCreationStripMenuItem
            // 
            this.serverCreationStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.serverCreationStripMenuItem.Name = "serverCreationStripMenuItem";
            this.serverCreationStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.serverCreationStripMenuItem.Text = "Server Create";
            // 
            // buildProgramToolStripMenuItem
            // 
            this.buildProgramToolStripMenuItem.Name = "buildProgramToolStripMenuItem";
            this.buildProgramToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.buildProgramToolStripMenuItem.Text = "Build program";
            this.buildProgramToolStripMenuItem.Click += new System.EventHandler(this.buildProgramToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computerTalkToolStripMenuItem,
            this.toolStripSeparator1,
            this.disconnectToolStripMenuItem1,
            this.deleteAppToolStripMenuItem,
            this.shutdownToolStripMenuItem});
            this.toolsToolStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // computerTalkToolStripMenuItem
            // 
            this.computerTalkToolStripMenuItem.Name = "computerTalkToolStripMenuItem";
            this.computerTalkToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.computerTalkToolStripMenuItem.Text = "Computer talk";
            this.computerTalkToolStripMenuItem.Click += new System.EventHandler(this.computerTalkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // disconnectToolStripMenuItem1
            // 
            this.disconnectToolStripMenuItem1.Name = "disconnectToolStripMenuItem1";
            this.disconnectToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.disconnectToolStripMenuItem1.Text = "Disconnect (app close)";
            this.disconnectToolStripMenuItem1.Click += new System.EventHandler(this.disconnectToolStripMenuItem1_Click);
            // 
            // deleteAppToolStripMenuItem
            // 
            this.deleteAppToolStripMenuItem.Name = "deleteAppToolStripMenuItem";
            this.deleteAppToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deleteAppToolStripMenuItem.Text = "Delete app";
            this.deleteAppToolStripMenuItem.Click += new System.EventHandler(this.deleteAppToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // screenShareToolStripMenuItem
            // 
            this.screenShareToolStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.screenShareToolStripMenuItem.Name = "screenShareToolStripMenuItem";
            this.screenShareToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.screenShareToolStripMenuItem.Text = "Screen Share";
            this.screenShareToolStripMenuItem.Click += new System.EventHandler(this.screenShareToolStripMenuItem_Click);
            // 
            // cameraViewToolStripMenuItem
            // 
            this.cameraViewToolStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.cameraViewToolStripMenuItem.Name = "cameraViewToolStripMenuItem";
            this.cameraViewToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cameraViewToolStripMenuItem.Text = "Camera view";
            this.cameraViewToolStripMenuItem.Click += new System.EventHandler(this.cameraViewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(147, 6);
            // 
            // clientChatToolStripMenuItem
            // 
            this.clientChatToolStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.clientChatToolStripMenuItem.Name = "clientChatToolStripMenuItem";
            this.clientChatToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.clientChatToolStripMenuItem.Text = "Client chat";
            this.clientChatToolStripMenuItem.Click += new System.EventHandler(this.clientChatToolStripMenuItem_Click);
            // 
            // blindShellToolStripMenuItem
            // 
            this.blindShellToolStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.blindShellToolStripMenuItem.Name = "blindShellToolStripMenuItem";
            this.blindShellToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.blindShellToolStripMenuItem.Text = "Blind shell";
            this.blindShellToolStripMenuItem.Click += new System.EventHandler(this.blindShellToolStripMenuItem_Click);
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.Image = global::WindowsFormsApp8.Properties.Resources.LIGHT;
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.Welcome);
            this.tabs.Controls.Add(this.ClientList);
            this.tabs.Controls.Add(this.Logs);
            this.tabs.Controls.Add(this.Settings);
            this.tabs.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs.Location = new System.Drawing.Point(2, -1);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(893, 370);
            this.tabs.TabIndex = 5;
            // 
            // Welcome
            // 
            this.Welcome.BackColor = System.Drawing.Color.White;
            this.Welcome.Controls.Add(this.label2);
            this.Welcome.Controls.Add(this.label1);
            this.Welcome.Location = new System.Drawing.Point(4, 23);
            this.Welcome.Name = "Welcome";
            this.Welcome.Padding = new System.Windows.Forms.Padding(3);
            this.Welcome.Size = new System.Drawing.Size(885, 343);
            this.Welcome.TabIndex = 3;
            this.Welcome.Text = "Welcome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(539, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enjoy your stay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(187, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 159);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome";
            // 
            // ClientList
            // 
            this.ClientList.Controls.Add(this.Clients);
            this.ClientList.Controls.Add(this.label3);
            this.ClientList.Controls.Add(this.ClientsList);
            this.ClientList.Location = new System.Drawing.Point(4, 23);
            this.ClientList.Name = "ClientList";
            this.ClientList.Padding = new System.Windows.Forms.Padding(3);
            this.ClientList.Size = new System.Drawing.Size(885, 343);
            this.ClientList.TabIndex = 0;
            this.ClientList.Text = "Clients";
            this.ClientList.UseVisualStyleBackColor = true;
            // 
            // Clients
            // 
            this.Clients.AutoSize = true;
            this.Clients.Location = new System.Drawing.Point(117, 318);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(13, 14);
            this.Clients.TabIndex = 7;
            this.Clients.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Connected clients:";
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.logView);
            this.Logs.Location = new System.Drawing.Point(4, 23);
            this.Logs.Name = "Logs";
            this.Logs.Padding = new System.Windows.Forms.Padding(3);
            this.Logs.Size = new System.Drawing.Size(885, 343);
            this.Logs.TabIndex = 1;
            this.Logs.Text = "Logs";
            this.Logs.UseVisualStyleBackColor = true;
            // 
            // logView
            // 
            this.logView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.type,
            this.value,
            this.date});
            this.logView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logView.HideSelection = false;
            this.logView.Location = new System.Drawing.Point(3, 3);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(879, 337);
            this.logView.TabIndex = 0;
            this.logView.UseCompatibleStateImageBehavior = false;
            this.logView.View = System.Windows.Forms.View.Details;
            // 
            // type
            // 
            this.type.Text = "type";
            this.type.Width = 130;
            // 
            // value
            // 
            this.value.Text = "value";
            this.value.Width = 120;
            // 
            // date
            // 
            this.date.Text = "date";
            this.date.Width = 135;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.HostValue);
            this.Settings.Controls.Add(this.label4);
            this.Settings.Controls.Add(this.pictureBox3);
            this.Settings.Controls.Add(this.pictureBox2);
            this.Settings.Controls.Add(this.pictureBox4);
            this.Settings.Controls.Add(this.lineup);
            this.Settings.Controls.Add(this.top);
            this.Settings.Controls.Add(this.listView2);
            this.Settings.Location = new System.Drawing.Point(4, 23);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(885, 343);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // HostValue
            // 
            this.HostValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HostValue.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostValue.Location = new System.Drawing.Point(155, 13);
            this.HostValue.Multiline = true;
            this.HostValue.Name = "HostValue";
            this.HostValue.Size = new System.Drawing.Size(196, 31);
            this.HostValue.TabIndex = 13;
            this.HostValue.Text = "192.168.1.18";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Server IpAddress:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApp8.Properties.Resources.chomik_hampster;
            this.pictureBox3.Location = new System.Drawing.Point(730, 224);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(155, 109);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp8.Properties.Resources.chomik_hampster;
            this.pictureBox2.Location = new System.Drawing.Point(730, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 112);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsFormsApp8.Properties.Resources.chomik_hampster;
            this.pictureBox4.Location = new System.Drawing.Point(730, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(155, 115);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // lineup
            // 
            this.lineup.AutoSize = true;
            this.lineup.Location = new System.Drawing.Point(14, 52);
            this.lineup.Name = "lineup";
            this.lineup.Size = new System.Drawing.Size(96, 18);
            this.lineup.TabIndex = 7;
            this.lineup.Text = "Lineup mouse";
            this.lineup.UseVisualStyleBackColor = true;
            this.lineup.CheckedChanged += new System.EventHandler(this.lineup_CheckedChanged);
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Location = new System.Drawing.Point(14, 81);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(73, 18);
            this.top.TabIndex = 8;
            this.top.Text = "Top Most";
            this.top.UseVisualStyleBackColor = true;
            this.top.CheckedChanged += new System.EventHandler(this.top_CheckedChanged_2);
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(879, 337);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 365);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "SpartaRAT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StripMenu.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.Welcome.ResumeLayout(false);
            this.Welcome.PerformLayout();
            this.ClientList.ResumeLayout(false);
            this.ClientList.PerformLayout();
            this.Logs.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView ClientsList;
        private System.Windows.Forms.ContextMenuStrip StripMenu;
        private System.Windows.Forms.ToolStripMenuItem serverCreationStripMenuItem;
        private System.Windows.Forms.ColumnHeader Client;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clientChatToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Country;
        private System.Windows.Forms.ColumnHeader pubip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem screenShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerTalkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader Current;
        private System.Windows.Forms.ColumnHeader idle;
        private System.Windows.Forms.ToolStripMenuItem blindShellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyloggerToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader system;
        private System.Windows.Forms.ToolStripMenuItem cameraViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage ClientList;
        private System.Windows.Forms.TabPage Logs;
        private System.Windows.Forms.Label Clients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView logView;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.CheckBox lineup;
        private System.Windows.Forms.CheckBox top;
        private System.Windows.Forms.TabPage Welcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ColumnHeader Privileges;
        private System.Windows.Forms.ToolStripMenuItem buildProgramToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HostValue;
        private System.Windows.Forms.ColumnHeader OpenDate;
        private System.Windows.Forms.ToolStripMenuItem deleteAppToolStripMenuItem;
    }
}

