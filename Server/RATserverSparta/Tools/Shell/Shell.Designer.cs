namespace RATserverSparta.Tools.Shell
{
    partial class Shell
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
            this.label1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.Label();
            this.text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Remote blind shell";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(104, 69);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(35, 13);
            this.status.TabIndex = 9;
            this.status.Text = "status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.ForeColor = System.Drawing.Color.Crimson;
            this.error.Location = new System.Drawing.Point(9, 97);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(148, 13);
            this.error.TabIndex = 7;
            this.error.Text = "There errors will not be shown";
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 38);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(324, 20);
            this.text.TabIndex = 6;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 125);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.error);
            this.Controls.Add(this.text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Shell";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.TextBox text;
    }
}