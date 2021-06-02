
namespace WindowsFormsApp1
{
    partial class GradeForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwLectureGradestd = new System.Windows.Forms.ListView();
            this.lvwLectureGrade = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.cmbMenu.SelectedIndexChanged += new System.EventHandler(this.cmbMenu_SelectedIndexChanged);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lvwLectureGradestd);
            this.panel3.Controls.Add(this.lvwLectureGrade);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 497);
            this.panel3.TabIndex = 15;
            // 
            // lvwLectureGradestd
            // 
            this.lvwLectureGradestd.FullRowSelect = true;
            this.lvwLectureGradestd.HideSelection = false;
            this.lvwLectureGradestd.Location = new System.Drawing.Point(19, 40);
            this.lvwLectureGradestd.Name = "lvwLectureGradestd";
            this.lvwLectureGradestd.Size = new System.Drawing.Size(936, 446);
            this.lvwLectureGradestd.TabIndex = 14;
            this.lvwLectureGradestd.UseCompatibleStateImageBehavior = false;
            // 
            // lvwLectureGrade
            // 
            this.lvwLectureGrade.FullRowSelect = true;
            this.lvwLectureGrade.HideSelection = false;
            this.lvwLectureGrade.Location = new System.Drawing.Point(19, 40);
            this.lvwLectureGrade.Name = "lvwLectureGrade";
            this.lvwLectureGrade.Size = new System.Drawing.Size(936, 446);
            this.lvwLectureGrade.TabIndex = 0;
            this.lvwLectureGrade.UseCompatibleStateImageBehavior = false;
            this.lvwLectureGrade.DoubleClick += new System.EventHandler(this.lvwLectureGrade_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "성적 내역";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cmbSubject);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 40);
            this.panel2.TabIndex = 14;
            // 
            // cmbSubject
            // 
            this.cmbSubject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSubject.BackColor = System.Drawing.Color.White;
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbSubject.ForeColor = System.Drawing.Color.Brown;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(63, 8);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(150, 24);
            this.cmbSubject.TabIndex = 13;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
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
            // GradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GradeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GradeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvwLectureGrade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwLectureGradestd;
    }
}