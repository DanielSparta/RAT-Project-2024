using System.Runtime.CompilerServices;

namespace WindowsFormsApp8
{
    partial class ConnectionAlert
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
            this.TopMost = true;
            this.TopMost = false;
            this.TopMost = true;
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.connection = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Connection";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.time.Location = new System.Drawing.Point(326, 8);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(26, 18);
            this.time.TabIndex = 1;
            this.time.Text = "10";
            // 
            // connection
            // 
            this.connection.AutoSize = true;
            this.connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.connection.Location = new System.Drawing.Point(13, 53);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(66, 24);
            this.connection.TabIndex = 2;
            this.connection.Text = "label3";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            // 
            // ConnectionAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(364, 104);
            this.Controls.Add(this.connection);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectionAlert";
            this.Text = "ConnectionAlert";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConnectionAlert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label connection;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}