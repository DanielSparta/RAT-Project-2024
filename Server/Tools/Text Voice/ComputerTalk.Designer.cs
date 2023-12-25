namespace WindowsFormsApp8
{
    partial class ComputerTalk
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
            this.text = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 12);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(236, 135);
            this.text.TabIndex = 0;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(92, 153);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 1;
            this.button.Text = "Send to talk";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // ComputerTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 182);
            this.Controls.Add(this.button);
            this.Controls.Add(this.text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ComputerTalk";
            this.Text = "ComputerTalk";
            this.Load += new System.EventHandler(this.ComputerTalk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Button button;
    }
}