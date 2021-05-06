
namespace WindowsFormsApp1
{
    partial class SignUpForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPasswod = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordCheck = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelError = new System.Windows.Forms.Panel();
            this.btnError = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.panelAlready = new System.Windows.Forms.Panel();
            this.btnAlready = new System.Windows.Forms.Button();
            this.lblAlready = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.panelError.SuspendLayout();
            this.panelAlready.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.BackColor = System.Drawing.SystemColors.Info;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(89, 465);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(210, 24);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "뒤로";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picMain
            // 
            this.picMain.Image = global::WindowsFormsApp1.Properties.Resources.university;
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(400, 200);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.TabIndex = 10;
            this.picMain.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Location = new System.Drawing.Point(17, 291);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(30, 16);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "이름";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNum.Location = new System.Drawing.Point(17, 344);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(30, 16);
            this.lblNum.TabIndex = 12;
            this.lblNum.Text = "학번";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(231, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Password";
            // 
            // lblPasswod
            // 
            this.lblPasswod.AutoSize = true;
            this.lblPasswod.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswod.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPasswod.Location = new System.Drawing.Point(231, 344);
            this.lblPasswod.Name = "lblPasswod";
            this.lblPasswod.Size = new System.Drawing.Size(104, 16);
            this.lblPasswod.TabIndex = 14;
            this.lblPasswod.Text = "PasswordCheck";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Location = new System.Drawing.Point(20, 310);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 14);
            this.txtName.TabIndex = 15;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Location = new System.Drawing.Point(234, 310);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(140, 14);
            this.txtPassword.TabIndex = 16;
            // 
            // txtPasswordCheck
            // 
            this.txtPasswordCheck.BackColor = System.Drawing.SystemColors.Window;
            this.txtPasswordCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasswordCheck.Location = new System.Drawing.Point(234, 363);
            this.txtPasswordCheck.Name = "txtPasswordCheck";
            this.txtPasswordCheck.Size = new System.Drawing.Size(140, 14);
            this.txtPasswordCheck.TabIndex = 17;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.Window;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Location = new System.Drawing.Point(20, 363);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(140, 14);
            this.txtId.TabIndex = 18;
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSignUp.Location = new System.Drawing.Point(140, 238);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(110, 29);
            this.lblSignUp.TabIndex = 19;
            this.lblSignUp.Text = "Sign Up";
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDone.Location = new System.Drawing.Point(89, 435);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(210, 24);
            this.btnDone.TabIndex = 20;
            this.btnDone.Text = " 완료";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtMajor
            // 
            this.txtMajor.BackColor = System.Drawing.SystemColors.Window;
            this.txtMajor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMajor.Location = new System.Drawing.Point(20, 415);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(140, 14);
            this.txtMajor.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(17, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "학과";
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.btnError);
            this.panelError.Controls.Add(this.lblError);
            this.panelError.Location = new System.Drawing.Point(103, 126);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(200, 81);
            this.panelError.TabIndex = 25;
            // 
            // btnError
            // 
            this.btnError.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnError.FlatAppearance.BorderSize = 0;
            this.btnError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnError.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnError.ForeColor = System.Drawing.SystemColors.Control;
            this.btnError.Location = new System.Drawing.Point(44, 42);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(107, 36);
            this.btnError.TabIndex = 1;
            this.btnError.Text = "확인";
            this.btnError.UseVisualStyleBackColor = false;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblError.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblError.Location = new System.Drawing.Point(23, 10);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(158, 22);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "정확히 입력해주세요.";
            // 
            // panelAlready
            // 
            this.panelAlready.Controls.Add(this.btnAlready);
            this.panelAlready.Controls.Add(this.lblAlready);
            this.panelAlready.Location = new System.Drawing.Point(103, 149);
            this.panelAlready.Name = "panelAlready";
            this.panelAlready.Size = new System.Drawing.Size(196, 104);
            this.panelAlready.TabIndex = 26;
            // 
            // btnAlready
            // 
            this.btnAlready.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAlready.FlatAppearance.BorderSize = 0;
            this.btnAlready.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlready.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAlready.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAlready.Location = new System.Drawing.Point(47, 64);
            this.btnAlready.Name = "btnAlready";
            this.btnAlready.Size = new System.Drawing.Size(89, 33);
            this.btnAlready.TabIndex = 1;
            this.btnAlready.Text = "확인";
            this.btnAlready.UseVisualStyleBackColor = false;
            this.btnAlready.Click += new System.EventHandler(this.btnAlready_Click);
            // 
            // lblAlready
            // 
            this.lblAlready.AutoSize = true;
            this.lblAlready.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAlready.Location = new System.Drawing.Point(14, 18);
            this.lblAlready.Name = "lblAlready";
            this.lblAlready.Size = new System.Drawing.Size(173, 22);
            this.lblAlready.TabIndex = 0;
            this.lblAlready.Text = "이미 가입되어있습니다.";
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.panelAlready);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblSignUp);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtPasswordCheck);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPasswod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUpForm";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.panelAlready.ResumeLayout(false);
            this.panelAlready.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPasswod;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPasswordCheck;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblSignUp;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelAlready;
        private System.Windows.Forms.Button btnAlready;
        private System.Windows.Forms.Label lblAlready;
    }
}