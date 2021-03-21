using clothesStore.Bl;
using System;
using System.Data;
using System.Windows.Forms;
using clothesStore.Rpt;
namespace clothesStore.PL
{
    public partial class Frm_Sales : DevExpress.XtraEditors.XtraForm
    {
        Frm_Customer c = new Frm_Customer();
        Customer Cm = new Customer();
        Order o = new Order();
        Stock s = new Stock();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt51 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt5 = new DataTable();

        Store Store = new Store();
        unit U = new unit();
        Proudect p = new Proudect();
        public Frm_Sales()
        {
            InitializeComponent();
            ComboCustomer();
            ComboStock();
            ComboProduct();
            SelectdataTable();
            //rezizse();
            txt_sales.Text = Program.salesman;
        }
        void ComboCustomer()
        {
            comboBox1.DataSource = o.SelectCustName();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Cust";
            comboBox1.SelectedIndex = -1;
        }
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
        void ComboStock()
        {
            cmb_Stock.DataSource = s.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
        }
        void ComboProduct()
        {
            Cmb_product.DataSource = p.Select_ProductFormStoreForSale();
            Cmb_product.DisplayMember = "Name_Prod";
            Cmb_product.ValueMember = "ID_Prod";
            Cmb_product.SelectedIndex = -1;
        }
        public void calcalutordirect()
        {
            for (int i = 0; i < DgvSale.Rows.Count; i++)
            {
                decimal mins = Convert.ToDecimal(DgvSale.Rows[i].Cells[3].Value) * Convert.ToInt32(DgvSale.Rows[i].Cells[4].Value);
                DgvSale.Rows[i].Cells[5].Value = mins.ToString();
            }
        }
        public void totaldirect()
        {
            for (int i = 0; i < DgvSale.Rows.Count; i++)
            {
                decimal amount = Convert.ToDecimal(DgvSale.Rows[i].Cells[5].Value);
                decimal discount = Convert.ToDecimal(DgvSale.Rows[i].Cells[6].Value);
                decimal total = amount - discount;
                DgvSale.Rows[i].Cells[7].Value = total.ToString();
            }
        }
        public void pay()
        {
            if (txt_invo.Text != string.Empty && txt_pay.Text != string.Empty)
            {
                decimal totainv = Convert.ToDecimal(txt_invo.Text) - Convert.ToDecimal(txt_pay.Text);
                txt_mark.Text = Math.Round(totainv, 1).ToString();
            }
        }
        public void calctotalinvoOrder()
        {
            decimal total = 0;
            for (int i = 0; i < DgvSale.Rows.Count; i++)
            {
                total += Convert.ToDecimal(DgvSale.Rows[i].Cells[7].Value);
            }
            txt_invo.Text = Math.Round(total, 1).ToString();
        }
        void SelectdataTable()
        {
            dt.Columns.Add("رقم الصنف");//0
            dt.Columns.Add("اسم الصنف");//1
            dt.Columns.Add("النوع");//2
            dt.Columns.Add("سعر");//3
            dt.Columns.Add("الكميه المباعه"); //4
            dt.Columns.Add(" الاجمالي ");//5
            dt.Columns.Add("  الخصم");//6
            dt.Columns.Add(" الاجمالي بعد الخصم");//7
            DgvSale.DataSource = dt;
        }
        void rezizse()
        {
            DgvSale.RowHeadersWidth = 20;
            DgvSale.Columns[0].Width = 60;
            DgvSale.Columns[1].Width = 195;
            DgvSale.Columns[2].Width = 158;
            DgvSale.Columns[3].Width = 108;
            DgvSale.Columns[4].Width = 106;
            DgvSale.Columns[5].Width = 100;
            DgvSale.Columns[6].Width = 97;
            DgvSale.Columns[7].Width = 95;
            DgvSale.Columns[8].Width = 90;
        }
        void data()
        {
            //dataGridView1.DataSource = null;
            dt.Clear();
            txt_note.Clear();
            txt_pay.Text = "0";
            txt_mark.Text = "0";
            txt_invo.Text = "0";
            txt_num.Clear();
            //txt_barcode.Enabled = true;
            btn_save.Enabled = false;
            Btn_Print.Enabled = false;
            Btn_AddCustomer.Enabled = true;
            //Btn_selectProduct.Enabled = true;
            btn_new.Enabled = true;
            Cmb_product.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            lblItemsCount.Text = DgvSale.Rows.Count.ToString();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dt51.Clear();
                dt51 = p.selectListProudect( Convert.ToInt32(Cmb_product.SelectedValue));
                if (Cmb_product.Text != "" && dt51.Rows.Count > 0)
                {

                    for (int i = 0; i < DgvSale.Rows.Count; i++)
                    {
                        if (DgvSale.Rows[i].Cells[0].Value.ToString() == dt51.Rows[0][0].ToString())
                        {
                            //dt6.Clear();
                            //dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value), Convert.ToString(DgvSale.Rows[i].Cells[3].Value));
                            
                            decimal y = Convert.ToDecimal(DgvSale.Rows[i].Cells[4].Value) ;

                            if (y >= Convert.ToDecimal(dt51.Rows[0][4]))
                            {
                                MessageBox.Show(" الكميه المدخله لهذا الصنف غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {

                                decimal x = 1;
                                Console.Beep();
                                DgvSale.Rows[i].Cells[4].Value = Convert.ToDecimal(DgvSale.Rows[i].Cells[4].Value) + x;
                               
                                calcalutordirect();
                                totaldirect();
                                calctotalinvoOrder();
                                pay();
                                dt5.Clear();
                                dt5 = p.SelectQuantityMinmun(Convert.ToInt32(dt51.Rows[0][0]));
                                if (dt5.Rows.Count > 0)
                                {
                                    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                Cmb_product.SelectedIndex = -1;

                                return;
                            }
                        }

                    }
                    //if (dt51.Rows.Count>0)
                    //{
                    DataRow r = dt.NewRow();
                    r[0] = dt51.Rows[0][0];
                    r[1] = dt51.Rows[0][1];
                    r[2] = dt51.Rows[0][2];
                    r[3] = dt51.Rows[0][3];
                    r[4] = 1.00;
                    r[6] = 0;
                    dt.Rows.Add(r);
                    Console.Beep();
                    DgvSale.DataSource = dt;
                    calcalutordirect();
                    totaldirect();
                    calctotalinvoOrder();
                    pay();
                    dt5.Clear();
                    dt5 = p.SelectQuantityMinmun(Convert.ToInt32(dt51.Rows[0][0]));
                    if (dt5.Rows.Count > 0)
                    {
                        MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    lblItemsCount.Text = DgvSale.Rows.Count.ToString();
                    txt_barcode.Focus();
                }
                else
                {
                    MessageBox.Show("هذا الصنف غير مسجل فى قائمة الاصناف");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Frm_Sales_Load(object sender, EventArgs e)
        {
            //label6.Hide();
            //txt_barcode.Hide();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "")
                {
                    dt2.Clear();
                    dt2 = Cm.VildateCustomer(Convert.ToInt32(comboBox1.SelectedValue));
                    if (dt2.Rows.Count == 0)
                    {
                        MessageBox.Show("اسم العميل الذى قمت بإدخالة غير مسجل من قبل  ", "تنبيه", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        comboBox1.SelectAll();
                        comboBox1.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
         
        }

        //private void simpleButton1_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        dt51.Clear();
        //        dt51 = p.selectListProudect(Convert.ToInt32(Cmb_Store.SelectedValue), Convert.ToInt32(Cmb_product.SelectedValue));
        //        if (Cmb_product.Text != "")
        //        {
        //            for (int i = 0; i < DgvSale.Rows.Count; i++)
        //            {
        //                if (DgvSale.Rows[i].Cells[0].Value == dt51.Rows[0][0])
        //                {
        //                    if (Convert.ToInt32(DgvSale.Rows[i].Cells[5].Value) >= Convert.ToInt32(dt51.Rows[0][5]))
        //                    {
        //                        MessageBox.Show(" الكميه المدخله لهذا الصنف غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                        return;
        //                    }
        //                    else
        //                    {

        //                        int x = 1;
        //                        Console.Beep();
        //                        DgvSale.Rows[i].Cells[5].Value = Convert.ToInt32(DgvSale.Rows[i].Cells[5].Value) + x;
        //                        calcalutordirect();
        //                        totaldirect();
        //                        calctotalinvoOrder();
        //                        pay();
        //                        return;
        //                    }
        //                }

        //                DataRow r = dt.NewRow();
        //                r[0] = dt51.Rows[0][0];
        //                r[1] = dt51.Rows[0][1];
        //                r[2] = dt51.Rows[0][2];
        //                r[3] = dt51.Rows[0][3];
        //                r[4] = dt51.Rows[0][4];
        //                r[5] = 1;
        //                r[7] = 0;
        //                dt.Rows.Add(r);
        //                Console.Beep();
        //                DgvSale.DataSource = dt;
        //                calcalutordirect();
        //                totaldirect();
        //                calctotalinvoOrder();
        //                pay();
        //                DataTable dt5 = new DataTable();
        //                dt5.Clear();
        //                dt5 = p.SelectQuantityMinmun(Convert.ToInt32(dt51.Rows[0][5]), Convert.ToInt32(Cmb_Store.SelectedValue));
        //                if (dt5.Rows.Count > 0)
        //                {
        //                    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void Cmb_product_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_product.Text != "")
                {
                    dt2.Clear();
                    dt2 = p.Validate_ProductFormStoreForSale(Convert.ToInt32(Cmb_product.SelectedValue));
                    if (dt2.Rows.Count == 0)
                    {
                        MessageBox.Show("اسم الصنف الذى قمت باادخالة غير موجود فى قائمة الاصناف ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        Cmb_product.SelectAll();
                        Cmb_product.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                if (DgvSale.Rows.Count <= 0) { MessageBox.Show("لا بد من اختيار صنف واحد على الاقل "); return; }
                if (comboBox1.Text == "") { MessageBox.Show("لابد من اختيار إسم العميل "); return; }
                if (cmb_Stock.Text == "") { MessageBox.Show("لابد من اختيار الخزنة "); return; }
                if (Convert.ToDecimal(txt_pay.Text) > Convert.ToDecimal(txt_invo.Text))
                {
                    MessageBox.Show("لابد أن يكون المدفوع اقل من اجمالى الفاتورة ");
                    txt_pay.Focus();
                    return;
                }
                if (DgvSale.Rows.Count > 0 && comboBox1.Text != string.Empty && cmb_Stock.Text != string.Empty )
                {
                    o.AddOrder(dateTimePicker1.Value, Convert.ToInt32(comboBox1.SelectedValue), txt_note.Text, txt_sales.Text,
                    Convert.ToDecimal(txt_invo.Text), Convert.ToDecimal(txt_pay.Text), Convert.ToDecimal(txt_mark.Text),
                     Convert.ToInt32(cmb_Stock.SelectedValue));

                    txt_num.Text = o.LastId().Rows[0][0].ToString();

                    for (int i = 0; i < DgvSale.Rows.Count; i++)
                    {

                        o.AddOrderDetails(Convert.ToInt32(txt_num.Text),Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),
                        (DgvSale.Rows[i].Cells[1].Value.ToString()),Convert.ToDecimal(DgvSale.Rows[i].Cells[4].Value), 
                        Convert.ToDecimal(DgvSale.Rows[i].Cells[3].Value),Convert.ToDecimal(DgvSale.Rows[i].Cells[6].Value),
                        Convert.ToDecimal(DgvSale.Rows[i].Cells[5].Value),Convert.ToDecimal(DgvSale.Rows[i].Cells[7].Value));

                        //dt6.Clear();
                        //dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value), Convert.ToString(DgvSale.Rows[i].Cells[3].Value));

                        //decimal x = Convert.ToDecimal(DgvSale.Rows[i].Cells[5].Value) / Convert.ToDecimal(dt6.Rows[0][1]);

                        p.Update_ProductQuantityDecrease(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value)
                            , Convert.ToDecimal(DgvSale.Rows[i].Cells[4].Value));

                        //if (DgvSale.Rows[i].Cells[3].Value.ToString() == dt7.Rows[0][0].ToString())
                        //{
                        //    p.Update_ProductQuantitySmallUnit(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value), x);
                        //    p.Update_StoreProductQuantitySmallUnit(Convert.ToInt32(DgvSale.Rows[i].Cells[0].Value),
                        //    Convert.ToInt32(Cmb_Store.SelectedValue), x);
                        //}
                        //p.Update_TotalProduct();
                    }
                    if (Convert.ToDecimal(txt_pay.Text) > 0 && Convert.ToDecimal(txt_pay.Text) <= Convert.ToDecimal(txt_invo.Text))
                    {
                        s.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_pay.Text), dateTimePicker1.Value, txt_sales.Text, "فاتورة مبيعات", " فاتورة مبيعات إلى" + " " + comboBox1.Text);
                    }
                    else if (Convert.ToDecimal(txt_pay.Text) > Convert.ToDecimal(txt_invo.Text))
                    {
                        s.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_invo.Text), dateTimePicker1.Value, txt_sales.Text, "فاتورة مبيعات", " فاتورة مبيعات إلى" + " " + comboBox1.Text);
                    }

                    dt51.Clear();
                    dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));

                    decimal mno = Convert.ToDecimal(dt51.Rows[0][1]) + Convert.ToDecimal(txt_mark.Text);
                    Cm.Update_CustomerTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                    Cm.Add_CustomerStatmentAccount(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txt_pay.Text),
                        Convert.ToDecimal(txt_invo.Text), "فاتورة مبيعات رقم " + " " + txt_num.Text, dateTimePicker1.Value,mno,txt_sales.Text);
                    MessageBox.Show("تم اضافه الفاتوره بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    btn_save.Enabled = false;
                    Btn_Print.Enabled = true;
                }
                else
                {
                    MessageBox.Show("من فضلك قم بااختيار صنف واحد علي الاقل &&او التاكد من اسم العميل &&او إضافة خزنة ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void txt_pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && txt_pay.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar((System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
            }
        }

        private void txt_invo_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void txt_pay_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void txt_mark_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void DgvSale_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calctotalinvoOrder();
            pay();
            lblItemsCount.Text = DgvSale.Rows.Count.ToString();

        }

        private void txt_pay_TextChanged(object sender, EventArgs e)
        {
            if (txt_pay.Text==".")
            {
                txt_pay.Text = "0";
            }

            if (txt_pay.Text == "")
            {
                decimal x = 0;
                decimal totainv = Convert.ToDecimal(txt_invo.Text) - x;
                txt_mark.Text = totainv.ToString();
            }
            else
            {
                decimal totainv = Convert.ToDecimal(txt_invo.Text) - Convert.ToDecimal(txt_pay.Text);
                txt_mark.Text = totainv.ToString();
            }
            
        }
        void Update_QtyUnit()
        {
            Frm_EditUnit Frm = new Frm_EditUnit();

            if (DgvSale.Rows.Count > 0 && DgvSale.SelectedRows.Count > 0)
            {
            //    Frm.cmb_Unit.DataSource = p.Select_UnitProduct(Convert.ToInt32(DgvSale.CurrentRow.Cells[0].Value));
            //    Frm.cmb_Unit.DisplayMember = "Unit_Name";
            //    Frm.cmb_Unit.ValueMember = "Id_Unit";
                Frm.textBox1.Text = DgvSale.CurrentRow.Cells[0].Value.ToString();

                Frm.ShowDialog();

            }
            if (Frm.Txt_Quantity.Text != "0" && Frm.txt_prise.Text != "" && Frm.txt_prise.Text != "0"
                && Frm.Txt_DisCount.Text != "")
            {

                //DgvSale.CurrentRow.Cells[3].Value = Frm.cmb_Unit.Text;
                DgvSale.CurrentRow.Cells[4].Value = Frm.Txt_Quantity.Text;
                DgvSale.CurrentRow.Cells[6].Value = Frm.Txt_DisCount.Text;
                DgvSale.CurrentRow.Cells[3].Value = Frm.txt_prise.Text;
                DataTable dt3 = new DataTable();
                dt3.Clear();
                dt3 = p.SelectQuantityMinmun(Convert.ToInt32(DgvSale.CurrentRow.Cells[0].Value));
                if (dt3.Rows.Count > 0)
                {
                    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                calcalutordirect();
                totaldirect();
                calctotalinvoOrder();
                pay();
                Frm.Txt_Quantity.Clear();
                Frm.Txt_DisCount.Clear();
                Frm.txt_prise.Clear();
            }
        }
        private void Frm_Sales_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F11)
            {
                Update_QtyUnit();
            }

        }

        private void DgvSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Update_QtyUnit();
            }
        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboProduct();
            dt.Clear();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            data();
            btn_save.Enabled = true;
            Btn_Print.Enabled = false;
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Stock_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt.Clear();
            calcalutordirect();
            totaldirect();
            calctotalinvoOrder();
            pay();
            ComboProduct();
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt51 = new DataTable();
              

                    Rpt_PrintOrder r = new Rpt_PrintOrder();
                    FrmSingleReport sr = new FrmSingleReport();
                    sr.crystalReportViewer1.RefreshReport();
                    //r.SetDatabaseLogon("", "", ".", "FEEDStore");
                    //r.SetParameterValue("@ID", int.Parse(dataGridViewList.CurrentRow.Cells[0].Value.ToString()));
                    //sr.crystalReportViewer1.ReportSource = r;
                    //sr.Show();
                    dt51.Clear();
                    dt51 = o.RportOrder(Convert.ToInt32(txt_num.Text));
                    clothesStore.DAL.DataOrderReport ds = new DAL.DataOrderReport();
                    Rpt.Frm_RptDocumetViewer frm = new Frm_RptDocumetViewer();
                    Rpt_PrintOrder rpts = new Rpt_PrintOrder();
                    frm.documentViewer1.Refresh();
                    ds.Tables["PrintOrder"].Clear();

                    for (int i = 0; i < dt51.Rows.Count; i++)
                    {
                        ds.Tables["PrintOrder"].Rows.Add(dt51.Rows[i][0], dt51.Rows[i][1], dt51.Rows[i][2],
                        dt51.Rows[i][3], dt51.Rows[i][4], dt51.Rows[i][5]
                          , dt51.Rows[i][6], dt51.Rows[i][7], dt51.Rows[i][8],
                         dt51.Rows[i][9], dt51.Rows[i][10], dt51.Rows[i][11], dt51.Rows[i][12]
                         , dt51.Rows[i][13]);
                    }
                    SettingPrint st = new SettingPrint();
                    DataTable tbl = new DataTable();
                    tbl.Clear();
                    tbl = st.SelectSettingPrintOrder();
                    ds.Tables["PrintInformation"].Clear();
                    ds.Tables["PrintInformation"].Rows.Add(tbl.Rows[0][0], tbl.Rows[0][1], tbl.Rows[0][2],
                        tbl.Rows[0][3], tbl.Rows[0][4]);


                    //rpts.SetDatabaseLogon("", "", ".", "EasySystem");
                    rpts.SetDataSource(ds);
                    rpts.SetParameterValue("@ID", Convert.ToInt32(txt_num.Text));

                    frm.documentViewer1.DocumentSource = rpts;

                    System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                    rpts.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;
                    rpts.PrintToPrinter(1, true, 0, 0);




                
        

            data();
            btn_save.Enabled = true;
            Btn_Print.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_AddCustomer_Click(object sender, EventArgs e)
        {
            Frm_Customer cm = new Frm_Customer();
            cm.ShowDialog();
                        comboBox1.DataSource = o.SelectCustName();

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txt_barcode.Text != "" && e.KeyChar == 13)
                {


                    dt51.Clear();
                    dt51 = p.search_barcode(Convert.ToInt64(txt_barcode.Text));
                    if (dt51.Rows.Count > 0)
                    {

                        for (int i = 0; i < DgvSale.Rows.Count; i++)
                        {
                            if (DgvSale.Rows[i].Cells[0].Value.ToString() == dt51.Rows[0][0].ToString())
                            {
                                if (Convert.ToInt32(DgvSale.Rows[i].Cells[4].Value) >= Convert.ToInt32(dt51.Rows[0][4]))
                                {
                                    MessageBox.Show(" الكميه المدخله لهذا الصنف غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txt_barcode.Clear();
                                    return;
                                }
                                else
                                {
                                    int x = 1;
                                    Console.Beep();
                                    DgvSale.Rows[i].Cells[4].Value = Convert.ToInt32(DgvSale.Rows[i].Cells[4].Value) + x;
                                    txt_barcode.Clear();

                                    calcalutordirect();
                                    totaldirect();
                                    calctotalinvoOrder();
                                    pay();
                                    dt5.Clear();
                                    dt5 = p.SelectQuantityMinmun(Convert.ToInt32(dt51.Rows[0][0]));
                                    if (dt5.Rows.Count > 0)
                                    {
                                        MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    return;

                                }
                            }
                        }



                        DataRow r = dt.NewRow();
                        r[0] = dt51.Rows[0][0];
                        r[1] = dt51.Rows[0][1];
                        r[2] = dt51.Rows[0][2];
                        r[3] = dt51.Rows[0][3];
                        r[4] = 1.00;
                        r[6] = 0;
                        dt.Rows.Add(r);
                        Console.Beep();
                        DgvSale.DataSource = dt;
                        calcalutordirect();
                        totaldirect();
                        calctotalinvoOrder();
                        pay();
                        dt5.Clear();
                        dt5 = p.SelectQuantityMinmun(Convert.ToInt32(dt51.Rows[0][0]));
                        if (dt5.Rows.Count > 0)
                        {
                            MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        lblItemsCount.Text = DgvSale.Rows.Count.ToString();

                        btn_save.Enabled = true;
                        txt_pay.Enabled = true;


                        txt_barcode.Clear();
                        txt_barcode.Focus();
                    }

                    else
                    {
                        MessageBox.Show("هذا الصنف غير مسجل ");
                        txt_barcode.Clear();
                        return;
                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void txt_pay_Click(object sender, EventArgs e)
        {
            txt_pay.SelectAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_pay_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_pay.Text=="0")
            {
                txt_pay.Text = "";
            }
        }
    }
}