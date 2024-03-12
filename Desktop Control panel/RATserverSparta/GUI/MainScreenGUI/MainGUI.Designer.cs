namespace RATserverSparta
{
    partial class MainGUI
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
            this.components = new System.ComponentModel.Container();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Welcome = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientList = new System.Windows.Forms.TabPage();
            this.Clients = new System.Windows.Forms.Label();
            this.ClientsConnected = new System.Windows.Forms.Label();
            this.ClientsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Current = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.system = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabs = new System.Windows.Forms.TabControl();
            this.StripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.serverCreationStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.disconnectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.screenLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listenBacklog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Welcome.SuspendLayout();
            this.ClientList.SuspendLayout();
            this.Logs.SuspendLayout();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabs.SuspendLayout();
            this.StripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem1.Text = "Client chat";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem3.Text = "Keylogger";
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
            this.ClientList.Controls.Add(this.ClientsConnected);
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
            // ClientsConnected
            // 
            this.ClientsConnected.AutoSize = true;
            this.ClientsConnected.Location = new System.Drawing.Point(8, 318);
            this.ClientsConnected.Name = "ClientsConnected";
            this.ClientsConnected.Size = new System.Drawing.Size(101, 14);
            this.ClientsConnected.TabIndex = 6;
            this.ClientsConnected.Text = "Connected clients:";
            // 
            // ClientsList
            // 
            this.ClientsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.Current,
            this.idle,
            this.system,
            this.columnHeader4,
            this.columnHeader5});
            this.ClientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientsList.HideSelection = false;
            this.ClientsList.Location = new System.Drawing.Point(3, 3);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.Size = new System.Drawing.Size(879, 337);
            this.ClientsList.TabIndex = 0;
            this.ClientsList.UseCompatibleStateImageBehavior = false;
            this.ClientsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Client";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Country";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Public IP";
            this.columnHeader3.Width = 80;
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
            // columnHeader4
            // 
            this.columnHeader4.Text = "Privileges";
            this.columnHeader4.Width = 104;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Opening Date";
            this.columnHeader5.Width = 130;
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
            this.Settings.Controls.Add(this.listenBacklog);
            this.Settings.Controls.Add(this.label3);
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
            this.HostValue.Text = "0.0.0.0";
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
            this.pictureBox3.Location = new System.Drawing.Point(730, 224);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(155, 109);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(730, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 112);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
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
            this.lineup.Location = new System.Drawing.Point(14, 100);
            this.lineup.Name = "lineup";
            this.lineup.Size = new System.Drawing.Size(96, 18);
            this.lineup.TabIndex = 7;
            this.lineup.Text = "Lineup mouse";
            this.lineup.UseVisualStyleBackColor = true;
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Location = new System.Drawing.Point(14, 129);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(73, 18);
            this.top.TabIndex = 8;
            this.top.Text = "Top Most";
            this.top.UseVisualStyleBackColor = true;
            this.top.CheckedChanged += new System.EventHandler(this.top_CheckedChanged);
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
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem4.Text = "Blind shell";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.Welcome);
            this.tabs.Controls.Add(this.ClientList);
            this.tabs.Controls.Add(this.Logs);
            this.tabs.Controls.Add(this.Settings);
            this.tabs.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs.Location = new System.Drawing.Point(0, 1);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(893, 370);
            this.tabs.TabIndex = 6;
            // 
            // StripMenu
            // 
            this.StripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverCreationStripMenuItem,
            this.buildProgramToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem5,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.screenLockToolStripMenuItem});
            this.StripMenu.Name = "StripMenu";
            this.StripMenu.Size = new System.Drawing.Size(151, 214);
            // 
            // serverCreationStripMenuItem
            // 
            this.serverCreationStripMenuItem.Name = "serverCreationStripMenuItem";
            this.serverCreationStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.serverCreationStripMenuItem.Text = "Server Create";
            this.serverCreationStripMenuItem.Click += new System.EventHandler(this.serverCreationStripMenuItem_Click);
            // 
            // buildProgramToolStripMenuItem
            // 
            this.buildProgramToolStripMenuItem.Name = "buildProgramToolStripMenuItem";
            this.buildProgramToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.buildProgramToolStripMenuItem.Text = "Build program";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripSeparator3,
            this.disconnectToolStripMenuItem1,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem5.Text = "Tools";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem6.Text = "Computer talk";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            // 
            // disconnectToolStripMenuItem1
            // 
            this.disconnectToolStripMenuItem1.Name = "disconnectToolStripMenuItem1";
            this.disconnectToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.disconnectToolStripMenuItem1.Text = "Disconnect (app close)";
            this.disconnectToolStripMenuItem1.Click += new System.EventHandler(this.disconnectToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem7.Text = "Delete app";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem8.Text = "Shutdown";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem9.Text = "Screen Share";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem10.Text = "Camera view";
            // 
            // screenLockToolStripMenuItem
            // 
            this.screenLockToolStripMenuItem.Name = "screenLockToolStripMenuItem";
            this.screenLockToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.screenLockToolStripMenuItem.Text = "Screen lock";
            this.screenLockToolStripMenuItem.Click += new System.EventHandler(this.screenLockToolStripMenuItem_Click);
            // 
            // listenBacklog
            // 
            this.listenBacklog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listenBacklog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.listenBacklog.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenBacklog.Location = new System.Drawing.Point(155, 50);
            this.listenBacklog.Multiline = true;
            this.listenBacklog.Name = "listenBacklog";
            this.listenBacklog.Size = new System.Drawing.Size(196, 31);
            this.listenBacklog.TabIndex = 15;
            this.listenBacklog.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Listen Backlog:";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 371);
            this.Controls.Add(this.tabs);
            this.Name = "MainGUI";
            this.Text = "SpartaRAT";
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
            this.tabs.ResumeLayout(false);
            this.StripMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.TabPage Welcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage ClientList;
        private System.Windows.Forms.Label Clients;
        public System.Windows.Forms.Label ClientsConnected;
        public System.Windows.Forms.ListView ClientsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader Current;
        private System.Windows.Forms.ColumnHeader idle;
        private System.Windows.Forms.ColumnHeader system;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabPage Logs;
        public System.Windows.Forms.ListView logView;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.TextBox HostValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox lineup;
        private System.Windows.Forms.CheckBox top;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.ContextMenuStrip StripMenu;
        private System.Windows.Forms.ToolStripMenuItem serverCreationStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem screenLockToolStripMenuItem;
        public System.Windows.Forms.TextBox listenBacklog;
        private System.Windows.Forms.Label label3;
    }
}

