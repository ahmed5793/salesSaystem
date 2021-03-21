namespace clothesStore.PL
{
    partial class Form_BackUp
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_backUp = new System.Windows.Forms.Button();
            this.btn_file = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(167, 66);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(517, 40);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "رجاء قم بتحديد مسار حفظ النسحه الاحتياطيه";
            // 
            // btn_backUp
            // 
            this.btn_backUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_backUp.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backUp.Location = new System.Drawing.Point(238, 122);
            this.btn_backUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_backUp.Name = "btn_backUp";
            this.btn_backUp.Size = new System.Drawing.Size(280, 66);
            this.btn_backUp.TabIndex = 2;
            this.btn_backUp.Text = "انشاء النسخه الاحتياطيه";
            this.btn_backUp.UseVisualStyleBackColor = true;
            this.btn_backUp.Click += new System.EventHandler(this.btn_backUp_Click);
            // 
            // btn_file
            // 
            this.btn_file.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_file.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_file.Location = new System.Drawing.Point(5, 66);
            this.btn_file.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(154, 40);
            this.btn_file.TabIndex = 3;
            this.btn_file.Text = "تحديد الملف";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // Form_BackUp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(692, 201);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.btn_backUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(708, 239);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(708, 239);
            this.Name = "Form_BackUp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انشاء نسخه احتياطيه";
            this.Load += new System.EventHandler(this.Form_BackUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_backUp;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}