
namespace WindowsFormsApp1
{
    partial class UploadForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWeek = new System.Windows.Forms.TextBox();
            this.txtChap = new System.Windows.Forms.TextBox();
            this.txtDist = new System.Windows.Forms.TextBox();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(48, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "주차";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(49, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "학습단원";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(48, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "구분";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(49, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "학습목차";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(48, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "인정시간";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(49, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "URL";
            // 
            // txtWeek
            // 
            this.txtWeek.Location = new System.Drawing.Point(186, 49);
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.Size = new System.Drawing.Size(206, 21);
            this.txtWeek.TabIndex = 2;
            // 
            // txtChap
            // 
            this.txtChap.Location = new System.Drawing.Point(186, 83);
            this.txtChap.Name = "txtChap";
            this.txtChap.Size = new System.Drawing.Size(206, 21);
            this.txtChap.TabIndex = 2;
            // 
            // txtDist
            // 
            this.txtDist.Location = new System.Drawing.Point(186, 116);
            this.txtDist.Name = "txtDist";
            this.txtDist.Size = new System.Drawing.Size(206, 21);
            this.txtDist.TabIndex = 2;
            // 
            // txtCon
            // 
            this.txtCon.Location = new System.Drawing.Point(186, 146);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(206, 21);
            this.txtCon.TabIndex = 2;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(186, 179);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(206, 21);
            this.txtTime.TabIndex = 2;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(186, 214);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(206, 21);
            this.txtURL.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "업로드";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "끝내기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(604, 286);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtCon);
            this.Controls.Add(this.txtDist);
            this.Controls.Add(this.txtChap);
            this.Controls.Add(this.txtWeek);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UploadForm";
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWeek;
        private System.Windows.Forms.TextBox txtChap;
        private System.Windows.Forms.TextBox txtDist;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}