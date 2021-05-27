
namespace WindowsFormsApp1
{
    partial class WritingPostForm
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
            this.txtWriting = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWriting
            // 
            this.txtWriting.Location = new System.Drawing.Point(62, 74);
            this.txtWriting.Multiline = true;
            this.txtWriting.Name = "txtWriting";
            this.txtWriting.Size = new System.Drawing.Size(402, 278);
            this.txtWriting.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "올리기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(552, 283);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 69);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "끝내기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WritingPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtWriting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WritingPostForm";
            this.Text = "WritingPostForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWriting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExit;
    }
}