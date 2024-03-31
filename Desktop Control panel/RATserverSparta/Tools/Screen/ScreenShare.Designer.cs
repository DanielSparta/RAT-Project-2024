namespace RATserverSparta.Tools.Screen
{
    partial class ScreenShare
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
            this.KeyControl = new System.Windows.Forms.CheckBox();
            this.MouseControl = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // KeyControl
            // 
            this.KeyControl.AutoSize = true;
            this.KeyControl.Location = new System.Drawing.Point(111, 12);
            this.KeyControl.Name = "KeyControl";
            this.KeyControl.Size = new System.Drawing.Size(107, 17);
            this.KeyControl.TabIndex = 5;
            this.KeyControl.Text = "Keyboard Control";
            this.KeyControl.UseVisualStyleBackColor = true;
            // 
            // MouseControl
            // 
            this.MouseControl.AutoSize = true;
            this.MouseControl.Location = new System.Drawing.Point(12, 12);
            this.MouseControl.Name = "MouseControl";
            this.MouseControl.Size = new System.Drawing.Size(91, 17);
            this.MouseControl.TabIndex = 4;
            this.MouseControl.Text = "MouseControl";
            this.MouseControl.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 305);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "data";
            // 
            // ScreenShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyControl);
            this.Controls.Add(this.MouseControl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScreenShare";
            this.Text = "ScreenShare";
            this.Load += new System.EventHandler(this.ScreenShare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox KeyControl;
        private System.Windows.Forms.CheckBox MouseControl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}