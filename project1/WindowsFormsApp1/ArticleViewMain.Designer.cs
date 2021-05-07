namespace WindowsFormsApp1
{
    partial class ArticleViewMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbMenu = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUniv = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblKwang = new System.Windows.Forms.Label();
            this.cmbLectureList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwArticles = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.cmbMenu);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.lblUniv);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblKwang);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 77);
            this.panel1.TabIndex = 12;
            // 
            // cmbMenu
            // 
            this.cmbMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbMenu.BackColor = System.Drawing.Color.White;
            this.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMenu.ForeColor = System.Drawing.Color.Brown;
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(288, 14);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(121, 24);
            this.cmbMenu.TabIndex = 12;
            this.cmbMenu.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(233, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "≡";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUser.ForeColor = System.Drawing.SystemColors.Window;
            this.txtUser.Location = new System.Drawing.Point(697, 10);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(207, 26);
            this.txtUser.TabIndex = 10;
            // 
            // lblUniv
            // 
            this.lblUniv.AutoSize = true;
            this.lblUniv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUniv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUniv.Location = new System.Drawing.Point(55, 41);
            this.lblUniv.Name = "lblUniv";
            this.lblUniv.Size = new System.Drawing.Size(117, 20);
            this.lblUniv.TabIndex = 1;
            this.lblUniv.Text = "UNIVERSITY";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.Info;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(927, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 21);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "나가기";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // lblKwang
            // 
            this.lblKwang.AutoSize = true;
            this.lblKwang.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKwang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblKwang.Location = new System.Drawing.Point(14, 10);
            this.lblKwang.Name = "lblKwang";
            this.lblKwang.Size = new System.Drawing.Size(212, 31);
            this.lblKwang.TabIndex = 0;
            this.lblKwang.Text = "KWANGWOON";
            // 
            // cmbLectureList
            // 
            this.cmbLectureList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbLectureList.BackColor = System.Drawing.Color.White;
            this.cmbLectureList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLectureList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbLectureList.ForeColor = System.Drawing.Color.Brown;
            this.cmbLectureList.FormattingEnabled = true;
            this.cmbLectureList.Location = new System.Drawing.Point(63, 8);
            this.cmbLectureList.Name = "cmbLectureList";
            this.cmbLectureList.Size = new System.Drawing.Size(121, 24);
            this.cmbLectureList.TabIndex = 13;
            this.cmbLectureList.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "과목명";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cmbLectureList);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 40);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lvwArticles);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 139);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 449);
            this.panel3.TabIndex = 15;
            // 
            // lvwArticles
            // 
            this.lvwArticles.HideSelection = false;
            this.lvwArticles.Location = new System.Drawing.Point(19, 48);
            this.lvwArticles.Name = "lvwArticles";
            this.lvwArticles.Size = new System.Drawing.Size(936, 389);
            this.lvwArticles.TabIndex = 0;
            this.lvwArticles.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "강의 자료실";
            // 
            // ArticleViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArticleViewMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticleViewMain";
            this.Load += new System.EventHandler(this.ArticleViewMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUniv;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblKwang;
        private System.Windows.Forms.ComboBox cmbLectureList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvwArticles;
        private System.Windows.Forms.Label label2;
    }
}