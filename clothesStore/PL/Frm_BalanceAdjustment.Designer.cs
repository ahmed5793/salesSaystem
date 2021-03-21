namespace clothesStore.PL
{
    partial class Frm_BalanceAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BalanceAdjustment));
            this.label8 = new System.Windows.Forms.Label();
            this.Cmb_product = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sales = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.Txt_AllQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Qty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rdb_Decrease = new System.Windows.Forms.RadioButton();
            this.Rdb_increase = new System.Windows.Forms.RadioButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(66, 115);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(56, 18);
            this.label8.TabIndex = 67;
            this.label8.Text = "إسم المتج";
            // 
            // Cmb_product
            // 
            this.Cmb_product.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Cmb_product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_product.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_product.FormattingEnabled = true;
            this.Cmb_product.Location = new System.Drawing.Point(241, 109);
            this.Cmb_product.Name = "Cmb_product";
            this.Cmb_product.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_product.Size = new System.Drawing.Size(246, 26);
            this.Cmb_product.TabIndex = 66;
            this.Cmb_product.SelectionChangeCommitted += new System.EventHandler(this.Cmb_product_SelectionChangeCommitted);
            this.Cmb_product.Leave += new System.EventHandler(this.Cmb_product_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(241, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 26);
            this.dateTimePicker1.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(66, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 68;
            this.label2.Text = "التاريخ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_sales
            // 
            this.txt_sales.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_sales.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sales.Location = new System.Drawing.Point(241, 56);
            this.txt_sales.Name = "txt_sales";
            this.txt_sales.ReadOnly = true;
            this.txt_sales.Size = new System.Drawing.Size(246, 25);
            this.txt_sales.TabIndex = 73;
            this.txt_sales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(66, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 72;
            this.label4.Text = "اسم المستخدم";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(66, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 71;
            this.label3.Text = "ملاحظات";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_note
            // 
            this.txt_note.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_note.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_note.Location = new System.Drawing.Point(241, 335);
            this.txt_note.Multiline = true;
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(246, 71);
            this.txt_note.TabIndex = 70;
            this.txt_note.TextChanged += new System.EventHandler(this.txt_note_TextChanged);
            // 
            // Txt_AllQuantity
            // 
            this.Txt_AllQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Txt_AllQuantity.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_AllQuantity.Location = new System.Drawing.Point(241, 160);
            this.Txt_AllQuantity.Name = "Txt_AllQuantity";
            this.Txt_AllQuantity.ReadOnly = true;
            this.Txt_AllQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_AllQuantity.Size = new System.Drawing.Size(143, 25);
            this.Txt_AllQuantity.TabIndex = 77;
            this.Txt_AllQuantity.Text = "0";
            this.Txt_AllQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(65, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 76;
            this.label1.Text = "الكمية الموجودة حاليا ";
            // 
            // Txt_Qty
            // 
            this.Txt_Qty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Txt_Qty.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Qty.Location = new System.Drawing.Point(241, 284);
            this.Txt_Qty.MaximumSize = new System.Drawing.Size(143, 25);
            this.Txt_Qty.MinimumSize = new System.Drawing.Size(143, 25);
            this.Txt_Qty.Name = "Txt_Qty";
            this.Txt_Qty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Qty.Size = new System.Drawing.Size(143, 25);
            this.Txt_Qty.TabIndex = 79;
            this.Txt_Qty.Text = "0";
            this.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Qty.Click += new System.EventHandler(this.Txt_Qty_Click);
            this.Txt_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Qty_KeyPress);
            this.Txt_Qty.Leave += new System.EventHandler(this.Txt_Qty_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(65, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 19);
            this.label5.TabIndex = 78;
            this.label5.Text = "الكمية المضافة أو المسحوبة   ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.Rdb_Decrease);
            this.groupBox1.Controls.Add(this.Rdb_increase);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(69, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 61);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الحالة";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Rdb_Decrease
            // 
            this.Rdb_Decrease.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rdb_Decrease.AutoSize = true;
            this.Rdb_Decrease.BackColor = System.Drawing.Color.White;
            this.Rdb_Decrease.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Decrease.ForeColor = System.Drawing.Color.Black;
            this.Rdb_Decrease.Location = new System.Drawing.Point(75, 24);
            this.Rdb_Decrease.Name = "Rdb_Decrease";
            this.Rdb_Decrease.Size = new System.Drawing.Size(111, 23);
            this.Rdb_Decrease.TabIndex = 1;
            this.Rdb_Decrease.TabStop = true;
            this.Rdb_Decrease.Text = "سحب من الكمية";
            this.Rdb_Decrease.UseVisualStyleBackColor = false;
            // 
            // Rdb_increase
            // 
            this.Rdb_increase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rdb_increase.AutoSize = true;
            this.Rdb_increase.BackColor = System.Drawing.Color.White;
            this.Rdb_increase.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_increase.ForeColor = System.Drawing.Color.Black;
            this.Rdb_increase.Location = new System.Drawing.Point(246, 24);
            this.Rdb_increase.Name = "Rdb_increase";
            this.Rdb_increase.Size = new System.Drawing.Size(106, 23);
            this.Rdb_increase.TabIndex = 0;
            this.Rdb_increase.TabStop = true;
            this.Rdb_increase.Text = "زيادة فى الكمية";
            this.Rdb_increase.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.btn_save.Location = new System.Drawing.Point(170, 463);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(209, 36);
            this.btn_save.TabIndex = 86;
            this.btn_save.Text = "حفظ التسوية";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Frm_BalanceAdjustment
            // 
            this.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(549, 513);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Txt_Qty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_AllQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sales);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Cmb_product);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_BalanceAdjustment";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسوية رصيد صنف";
            this.Load += new System.EventHandler(this.Frm_BalanceAdjustment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox Cmb_product;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_sales;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.TextBox Txt_AllQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Rdb_Decrease;
        private System.Windows.Forms.RadioButton Rdb_increase;
        public DevExpress.XtraEditors.SimpleButton btn_save;
    }
}