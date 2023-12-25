namespace WindowsFormsApp8
{
    partial class Chat
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
            this.talk = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 224);
            this.text.Multiline = true;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(228, 34);
            this.text.TabIndex = 0;
            // 
            // talk
            // 
            this.talk.Location = new System.Drawing.Point(12, 18);
            this.talk.Multiline = true;
            this.talk.Name = "talk";
            this.talk.Size = new System.Drawing.Size(333, 200);
            this.talk.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "tip: you can also use ESC to close.";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 263);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.talk);
            this.Controls.Add(this.text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.TextBox talk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}