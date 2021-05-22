namespace WindowsFormsApp1
{
    partial class ArticleViewDisplay
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
            this.articleTB = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.btn굵게 = new System.Windows.Forms.Button();
            this.btn기울임 = new System.Windows.Forms.Button();
            this.btn밑줄 = new System.Windows.Forms.Button();
            this.cmbFont = new System.Windows.Forms.ComboBox();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // articleTB
            // 
            this.articleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.articleTB.Location = new System.Drawing.Point(12, 95);
            this.articleTB.Multiline = true;
            this.articleTB.Name = "articleTB";
            this.articleTB.ReadOnly = true;
            this.articleTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.articleTB.Size = new System.Drawing.Size(676, 447);
            this.articleTB.TabIndex = 16;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(628, 548);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 40);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(78, 548);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(60, 40);
            this.btnModify.TabIndex = 18;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(12, 548);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // titleTB
            // 
            this.titleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTB.Location = new System.Drawing.Point(12, 23);
            this.titleTB.MaxLength = 20;
            this.titleTB.Name = "titleTB";
            this.titleTB.ReadOnly = true;
            this.titleTB.Size = new System.Drawing.Size(676, 35);
            this.titleTB.TabIndex = 20;
            // 
            // btn굵게
            // 
            this.btn굵게.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn굵게.Location = new System.Drawing.Point(203, 64);
            this.btn굵게.Name = "btn굵게";
            this.btn굵게.Size = new System.Drawing.Size(26, 25);
            this.btn굵게.TabIndex = 21;
            this.btn굵게.Text = "가";
            this.btn굵게.UseVisualStyleBackColor = true;
            this.btn굵게.Click += new System.EventHandler(this.btn굵게_Click);
            // 
            // btn기울임
            // 
            this.btn기울임.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn기울임.Location = new System.Drawing.Point(235, 64);
            this.btn기울임.Name = "btn기울임";
            this.btn기울임.Size = new System.Drawing.Size(26, 25);
            this.btn기울임.TabIndex = 22;
            this.btn기울임.Text = "가";
            this.btn기울임.UseVisualStyleBackColor = true;
            this.btn기울임.Click += new System.EventHandler(this.btn기울임_Click);
            // 
            // btn밑줄
            // 
            this.btn밑줄.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn밑줄.Location = new System.Drawing.Point(267, 64);
            this.btn밑줄.Name = "btn밑줄";
            this.btn밑줄.Size = new System.Drawing.Size(26, 25);
            this.btn밑줄.TabIndex = 23;
            this.btn밑줄.Text = "가";
            this.btn밑줄.UseVisualStyleBackColor = true;
            this.btn밑줄.Click += new System.EventHandler(this.btn밑줄_Click);
            // 
            // cmbFont
            // 
            this.cmbFont.FormattingEnabled = true;
            this.cmbFont.Location = new System.Drawing.Point(12, 67);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new System.Drawing.Size(89, 20);
            this.cmbFont.TabIndex = 24;
            this.cmbFont.SelectedIndexChanged += new System.EventHandler(this.cmbFont_SelectedIndexChanged);
            // 
            // cmbSize
            // 
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(107, 67);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(89, 20);
            this.cmbSize.TabIndex = 25;
            this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(562, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 40);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ArticleViewDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.cmbFont);
            this.Controls.Add(this.btn밑줄);
            this.Controls.Add(this.btn기울임);
            this.Controls.Add(this.btn굵게);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.articleTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArticleViewDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticleViewDisplay";
            this.Load += new System.EventHandler(this.ArticleViewDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox articleTB;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.Button btn굵게;
        private System.Windows.Forms.Button btn기울임;
        private System.Windows.Forms.Button btn밑줄;
        private System.Windows.Forms.ComboBox cmbFont;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Button btnSave;
    }
}