namespace clothesStore.PL
{
    partial class Frm_NoticeDiscountOrAddToSuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NoticeDiscountOrAddToSuppliers));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_LastBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_Notice = new System.Windows.Forms.ComboBox();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(260, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 26);
            this.dateTimePicker1.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(419, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 87;
            this.label2.Text = "التاريخ";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Amount.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Amount.Location = new System.Drawing.Point(249, 170);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.Size = new System.Drawing.Size(138, 25);
            this.txt_Amount.TabIndex = 83;
            this.txt_Amount.Text = "0";
            this.txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Amount.Click += new System.EventHandler(this.txt_Amount_Click);
            this.txt_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Amount_KeyPress);
            this.txt_Amount.Leave += new System.EventHandler(this.txt_Amount_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(419, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 18);
            this.label4.TabIndex = 82;
            this.label4.Text = "المبلغ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(419, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 85;
            this.label5.Text = "الحساب السابق";
            // 
            // txt_LastBalance
            // 
            this.txt_LastBalance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_LastBalance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LastBalance.Location = new System.Drawing.Point(249, 128);
            this.txt_LastBalance.Multiline = true;
            this.txt_LastBalance.Name = "txt_LastBalance";
            this.txt_LastBalance.ReadOnly = true;
            this.txt_LastBalance.Size = new System.Drawing.Size(149, 27);
            this.txt_LastBalance.TabIndex = 84;
            this.txt_LastBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(616, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 81;
            this.label3.Text = "ملاحظات";
            // 
            // txt_note
            // 
            this.txt_note.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_note.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_note.Location = new System.Drawing.Point(12, 219);
            this.txt_note.Multiline = true;
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(598, 69);
            this.txt_note.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(422, 7);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(66, 18);
            this.label7.TabIndex = 79;
            this.label7.Text = "نوع الإشعار";
            // 
            // cmb_Notice
            // 
            this.cmb_Notice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmb_Notice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Notice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Notice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Notice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Notice.FormattingEnabled = true;
            this.cmb_Notice.Items.AddRange(new object[] {
            "لة",
            "علية"});
            this.cmb_Notice.Location = new System.Drawing.Point(249, 3);
            this.cmb_Notice.Name = "cmb_Notice";
            this.cmb_Notice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_Notice.Size = new System.Drawing.Size(168, 26);
            this.cmb_Notice.TabIndex = 78;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_save.Appearance.BackColor = System.Drawing.Color.Black;
            this.btn_save.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.btn_save.Appearance.BorderColor = System.Drawing.Color.White;
            this.btn_save.Appearance.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_save.Appearance.Options.UseBackColor = true;
            this.btn_save.Appearance.Options.UseBorderColor = true;
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.Appearance.Options.UseForeColor = true;
            this.btn_save.Appearance.Options.UseTextOptions = true;
            this.btn_save.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btn_save.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.AppearanceDisabled.Options.UseFont = true;
            this.btn_save.AppearanceHovered.BackColor = System.Drawing.Color.Silver;
            this.btn_save.AppearanceHovered.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.AppearanceHovered.Options.UseBackColor = true;
            this.btn_save.AppearanceHovered.Options.UseFont = true;
            this.btn_save.AppearanceHovered.Options.UseTextOptions = true;
            this.btn_save.AppearanceHovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btn_save.AppearancePressed.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.AppearancePressed.Options.UseFont = true;
            this.btn_save.AppearancePressed.Options.UseTextOptions = true;
            this.btn_save.AppearancePressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.Location = new System.Drawing.Point(288, 319);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(140, 36);
            this.btn_save.TabIndex = 86;
            this.btn_save.Text = "حفظ الفاتورة";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(173, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(244, 32);
            this.comboBox1.TabIndex = 89;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(423, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 90;
            this.label1.Text = "اسم المورد";
            // 
            // Frm_NoticeDiscountOrAddToSuppliers
            // 
            this.Appearance.BackColor = System.Drawing.Color.RosyBrown;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 367);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_Amount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_LastBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_Notice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_NoticeDiscountOrAddToSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إشعار خصم أو إضافة رصيد لمورد";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.SimpleButton btn_save;
        public System.Windows.Forms.TextBox txt_Amount;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_LastBalance;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_note;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cmb_Notice;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}