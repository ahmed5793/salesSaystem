using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clothesStore.Bl;
using System.Globalization;

namespace clothesStore.PL
{
    public partial class OrderSales : Form
    {
        Frm_Customer c = new Frm_Customer();
        Customer Cust = new Customer();
        Order o = new Order();
        Stock s = new Stock();
        DataTable dt = new DataTable();
        DataTable dt51 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt7 = new DataTable();
        Store Store = new Store();
        unit U = new unit();

        private static OrderSales farm;

        static void STATUESCllosed(object sender, FormClosedEventArgs e)
        {
            farm = null;
        }
        public static OrderSales getmain
        {
            get
            {
                if (farm == null)
                {
                    farm = new OrderSales();
                    farm.FormClosed += new FormClosedEventHandler(STATUESCllosed);
                }
                return farm;
            }
        }
        public OrderSales()
        {
            InitializeComponent();
            if (farm == null)
            {
                farm = this;
            }

            comboBox1.DataSource = o.SelectCustName();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Cust";
            
            cmb_Stock.DataSource = s.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";

            Cmb_Store.DataSource = Store.Select_ComboStore();
            Cmb_Store.DisplayMember = "Store_Name";
            Cmb_Store.ValueMember = "Store_Id";

            txt_sales.Text = Program.salesman;
            SelectdataTable();
            txt_barcode.Hide();
            Btn_Print.Enabled = false;
        }

        public void calcalutordirect()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal mins = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                dataGridView1.Rows[i].Cells[6].Value = mins.ToString();
            }
        }
        public void totaldirect()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal amount = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal discount = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                decimal total = amount - discount;
                dataGridView1.Rows[i].Cells[8].Value = total.ToString();
            }
        }
        public void pay()
        {
            if (txt_invo.Text != string.Empty && txt_pay.Text != string.Empty)
            {
                decimal totainv = Convert.ToDecimal(txt_invo.Text) - Convert.ToDecimal(txt_pay.Text);
                txt_mark.Text = Math.Round(totainv , 1).ToString();
            }
        }
        public void calctotalinvoOrder()
        {
            decimal total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
            }
            txt_invo.Text = Math.Round(total, 2).ToString();
        }
        void SelectdataTable()
        {
            dt.Columns.Add("رقم الصنف");//0
            dt.Columns.Add("اسم الصنف");//1
            dt.Columns.Add("النوع");//2
            dt.Columns.Add("الوحدة");//3
            dt.Columns.Add("سعر");//4
            dt.Columns.Add("الكميه المباعه"); //5
            dt.Columns.Add(" الاجمالي ");//6
            dt.Columns.Add("  الخصم");//7
            dt.Columns.Add(" الاجمالي بعد الخصم");//8
            dataGridView1.DataSource = dt;
        }
        //void rezizse()
        //{
        //    dataGridView1.RowHeadersWidth = 20;
        //    dataGridView1.Columns[0].Width = 60;
        //    dataGridView1.Columns[1].Width = 195;

        //    dataGridView1.Columns[2].Width = 158;

        //    dataGridView1.Columns[3].Width = 108;
        //    dataGridView1.Columns[4].Width = 106;
        //    dataGridView1.Columns[5].Width = 100;
        //    dataGridView1.Columns[6].Width = 97;
        //    dataGridView1.Columns[7].Width = 95;
        //    dataGridView1.Columns[8].Width = 90;
        //    dataGridView1.Columns[9].Width = 110;
        //}
        private void OrderSales_Load(object sender, EventArgs e)
        {        
        }
        FormListPROUDECT f = new FormListPROUDECT();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                f.ShowDialog();
                if (f.dataGridView1.Rows.Count > 0 && f.dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == f.dataGridView1.CurrentRow.Cells[0].Value.ToString())
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) >= Convert.ToInt32(f.dataGridView1.CurrentRow.Cells[5].Value))
                            {
                                MessageBox.Show(" الكميه المدخله لهذا الصنف غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                int x = 1;
                                Console.Beep();
                                dataGridView1.Rows[i].Cells[5].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) + x;
                                calcalutordirect();
                                totaldirect();
                                calctotalinvoOrder();
                                pay();
                                return;
                            }
                        }
                    }
                    if (f.dataGridView1.Rows.Count > 0)
                    {
                        DataRow r = dt.NewRow();
                        r[0] = f.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        r[1] = f.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        r[2] = f.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        r[3] = f.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        r[4] = f.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        r[5] = 1;
                        r[7] = 0;
                        dt.Rows.Add(r);
                        Console.Beep();
                        dataGridView1.DataSource = dt;
                        calcalutordirect();
                        totaldirect();
                        calctotalinvoOrder();
                        pay();
                        //DataTable dt5 = new DataTable();
                        //dt5.Clear();
                        //dt5 = p.SelectQuantityMinmun(Convert.ToInt32(f.dataGridView1.CurrentRow.Cells[0].Value));
                        //if (dt5.Rows.Count > 0)
                        //{
                        //    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);                          
                        //}
                    }         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
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
            txt_barcode.Enabled = true;
            btn_save.Enabled = false;
            Btn_Print.Enabled = false;
            Btn_AddCustomer.Enabled = true;
            Btn_selectProduct.Enabled = true;
            btn_new.Enabled = true;
        }
        private void txt_quantity_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txt_pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && txt_pay.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar((CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
            {
                e.Handled = true;
            }
        }
        private void txt_mark_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }
        private void txt_invo_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }
        private void txt_pay_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }
        private void txt_mark_TextChanged(object sender, EventArgs e)
        {
            pay();
        }
        private void txt_pay_TextChanged(object sender, EventArgs e)
        {
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



        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calctotalinvoOrder();
            pay();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_pay.Text == "")
                //{
                //    txt_pay.Text = "0";
                //    pay();
                //}
                //else
                //{
                //    pay();
                //}
                if (dataGridView1.Rows.Count > 0 && comboBox1.Text != string.Empty && cmb_Stock.Text != string.Empty&&
                     Cmb_Store.Text!=string.Empty)
                {
                    o.AddOrder(dateTimePicker1.Value, Convert.ToInt32(comboBox1.SelectedValue), txt_note.Text, txt_sales.Text,
                    Convert.ToDecimal(txt_invo.Text), Convert.ToDecimal(txt_pay.Text), Convert.ToDecimal(txt_mark.Text), 
                     Convert.ToInt32(cmb_Stock.SelectedValue));

                    txt_num.Text = o.LastId().Rows[0][0].ToString();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        //o.AddOrderDetails(Convert.ToInt32(txt_num.Text),Convert.ToInt32(Cmb_Store.SelectedValue),
                        //Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                        //(dataGridView1.Rows[i].Cells[1].Value.ToString()), dataGridView1.Rows[i].Cells[3].Value.ToString(), 
                        //Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value),
                        //Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value), Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value),
                        //Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value));

                        dt6.Clear();
                        dt6 = p.Select_UnitProduct(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));

                        dt7.Clear();
                        //dt7 = p.Select_SmallUnitProduct(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                         if (dataGridView1.Rows[i].Cells[3].Value.ToString() == dt7.Rows[0][0].ToString())
                        {
                           DataTable dt8 = new DataTable();
                        //    dt8.Clear();
                        //    dt8 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));

                            decimal x = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value) / Convert.ToDecimal(dt8.Rows[0][0]);

                            //p.Update_ProductQuantitySmallUnit(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),x);

                            //p.Update_StoreProductQuantitySmallUnit(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                            //Convert.ToInt32(Cmb_Store.SelectedValue), x);
                        }
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString()==dt6.Rows[0][0].ToString())
                        {
                            //p.Update_ProductQuantityLargeUnit(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                                //Convert.ToInt32(Cmb_Store.SelectedValue),Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value));                             
                        }

                 
                        p.Update_TotalProduct();
                    }
                    dt51.Clear();
                    dt51 = Cust.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
                    if (Convert.ToDecimal(txt_pay.Text)>0)
                    {
                        s.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_pay.Text), dateTimePicker1.Value, comboBox1.Text, "فاتورة مبيعات", " فاتورة مبيعات إلى" + " " + comboBox1.Text);
                    }
                    cm.Add_CustomerStatmentAccount(Convert.ToInt32(comboBox1.SelectedValue),Convert.ToDecimal(txt_mark.Text),
                        Convert.ToDecimal(txt_pay.Text),  txt_num.Text +" "+"فاتورة مبيعات رقم ", dateTimePicker1.Value, Convert.ToDecimal(dt.Rows[0][0]),txt_sales.Text);
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
            }
        }

        private void txt_sales_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.ShowDialog();
            comboBox1.DataSource = o.SelectCustName();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dataGridView1.Rows.Count > 0 && comboBox1.Text != string.Empty)
            //    {
            //        Rpt.Rpt_PrintOrder ro = new Rpt.Rpt_PrintOrder();
            //        Rpt.FrmSingleReport s = new Rpt.FrmSingleReport();
            //        s.crystalReportViewer1.RefreshReport();
            //        ro.SetDatabaseLogon("", "", ".", "MesaStory");
            //        ro.SetParameterValue("@ID", (Convert.ToInt32(txt_num.Text)));
            //        s.crystalReportViewer1.ReportSource = ro;
            //        System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            //        ro.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
            //        ro.PrintToPrinter(1, true, 0, 0);
            //        // s.Show();
            //        data();
            //    }
            //    else
            //    {
            //        MessageBox.Show("");
            //    }

            //}
            //catch (Exception )
            //{
            //    MessageBox.Show("لايوجد طابعه للطباعه ");

            //}
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                data();
                txt_num.Clear();
                btn_save.Enabled = true;             
                Btn_AddCustomer.Enabled = true;
                Btn_selectProduct.Enabled = true;
                dataGridView1.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("هذة فاتورة فارغة ");
            }



        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_size_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ComboBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Txt_size_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
        Proudect p = new Proudect();

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataTable dt10 = new DataTable();
            if (txt_barcode.Text != string.Empty && e.KeyChar == 13)
            {

                dt10.Clear();

                //dt10 = p.search_barcode(txt_barcode.Text);
                if (dt10.Rows.Count > 0)
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == dt10.Rows[0][0].ToString())
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value) >= Convert.ToInt32(dt10.Rows[0][8]))
                            {
                                MessageBox.Show(" الكميه المدخله لهذا الصنف غير متاحه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt_barcode.Clear();
                                return;
                            }
                            else
                            {
                                int x = 1;
                                Console.Beep();
                                dataGridView1.Rows[i].Cells[6].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value) + x;
                                txt_barcode.Clear();
                                calcalutordirect();
                                totaldirect();
                                //txt_invo.Text = (from DataGridViewRow row in dataGridView1.Rows
                                //                 where (row.Cells[6].FormattedValue.ToString()) != string.Empty
                                //                 select Convert.ToDecimal(row.Cells[6].FormattedValue)).Sum().ToString();
                                calctotalinvoOrder();

                                pay();

                                return;

                            }
                        }
                    }

             

                    DataRow r2 = dt.NewRow();
                    r2[0] = dt10.Rows[0][0].ToString();
                    r2[1] = dt10.Rows[0][1].ToString();

                    r2[2] = dt10.Rows[0][2].ToString();
                    r2[3] = dt10.Rows[0][4].ToString();
                    r2[4] = dt10.Rows[0][3].ToString();
                    r2[5] = dt10.Rows[0][5].ToString();
                    r2[6] = 1;
                    r2[8] = 0;

                    dt.Rows.Add(r2);
                    Console.Beep();
                    dataGridView1.DataSource = dt;

                    calcalutordirect();
                    totaldirect();
                    //txt_invo.Text = (from DataGridViewRow row in dataGridView1.Rows
                    //                 where (row.Cells[6].FormattedValue.ToString()) != string.Empty
                    //                 select Convert.ToDecimal(row.Cells[6].FormattedValue)).Sum().ToString();
                    calctotalinvoOrder();
                    pay();


                    btn_save.Enabled = true;
                    txt_pay.Enabled = true;
                    txt_barcode.Focus();


                    txt_barcode.Clear();

                }

                else
                {
                    MessageBox.Show("هذا الصنف غير مسجل ");
                    txt_barcode.Clear();
                    return;
                }


            }


        }

        private void Txt_barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Frm_EditDiscount fed = new Frm_EditDiscount();
        Frm_EditPrice fp = new Frm_EditPrice();
        Frm_EditQuantity qs = new Frm_EditQuantity();
        Frm_EditUnit eu = new Frm_EditUnit();
        DataTable dt5 = new DataTable();
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        //    try
        //    {
        //        if (dataGridView1.Rows.Count > 0)
        //        {
        //            if (e.ColumnIndex == 3)
        //            {
        //                eu.ShowDialog();
        //                eu.cmb_Unit.DataSource = p.Select_UnitProduct(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        //                eu.cmb_Unit.DisplayMember = "Unit_Name";
        //                eu.cmb_Unit.ValueMember = "Id_Unit";

        //                if (eu.cmb_Unit.Text == "الوحدة الكبرى")
        //                {
        //                    dt5.Clear();
        //                    dt5 = p.Select_UnitProduct(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        //                    dataGridView1.CurrentRow.Cells[3].Value = dt5.Rows[0][0];
        //                    dataGridView1.CurrentRow.Cells[4].Value = dt5.Rows[0][1];
        //                    calcalutordirect();
        //                    totaldirect();
        //                    calctotalinvoOrder();
        //                    pay();
        //                }
        //                else if (eu.cmb_Unit.Text== "الوحدة الصغرى")
        //                {
        //                    dt5.Clear();
        //                    //dt5 = p.Select_SmallUnitProduct(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        //                    dataGridView1.CurrentRow.Cells[3].Value = dt5.Rows[0][0];
        //                    dataGridView1.CurrentRow.Cells[4].Value = dt5.Rows[0][1];
        //                    calcalutordirect();
        //                    totaldirect();
        //                    calctotalinvoOrder();
        //                    pay();
        //                }
        //            }
        //            if (e.ColumnIndex == 5)
        //            {                   
        //                qs.ShowDialog();
        //                DataTable dt2 = new DataTable();
        //                if (qs.Txt_Quantity.Text != "" && qs.Txt_Quantity.Text != "0")
        //                {
        //                    dt2.Clear();
        //                    dt2 = p.vaildateQuantity(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToInt32(qs.Txt_Quantity.Text));

        //                    if (dt2.Rows.Count > 0)
        //                    {
        //                        MessageBox.Show("الكميه المدخلة لهذا الصنف اكبر من الموجوده في المخزن");
        //                        return;
        //                    }
        //                    //DataTable dt3 = new DataTable();
        //                    //dt3.Clear();
        //                    //dt3 = p.SelectQuantityMinmun(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        //                    //if (dt3.Rows.Count > 0)
        //                    //{
        //                    //    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    //}
        //                    dataGridView1.CurrentRow.Cells[5].Value = qs.Txt_Quantity.Text;
        //                    calcalutordirect();
        //                    totaldirect();
        //                    calctotalinvoOrder();
        //                    pay();  
        //                    qs.Txt_Quantity.Clear();
        //                }                     
        //            }
        //            if (e.ColumnIndex == 4)
        //            {
        //                fp.ShowDialog();
        //                if (fp.txt_prise.Text != "" && fp.txt_prise.Text != "0")
        //                {
        //                    dataGridView1.CurrentRow.Cells[4].Value = fp.txt_prise.Text;
        //                    calcalutordirect();
        //                    totaldirect();
        //                    calctotalinvoOrder();
        //                    pay();
        //                    fp.txt_prise.Clear();
        //                }
        //            }
        //            if (e.ColumnIndex == 7)
        //            {
        //                fed.ShowDialog();
        //                if (fed.textBox1.Text != "")
        //                {
        //                    dataGridView1.CurrentRow.Cells[7].Value = fed.textBox1.Text;
        //                    calcalutordirect();
        //                    totaldirect();
        //                    calctotalinvoOrder();
        //                    pay();
        //                    fed.textBox1.Clear();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
               
        }

        private void Txt_pay_Leave(object sender, EventArgs e)
        {
            if (txt_pay.Text == "")
            {
                txt_pay.Text = "0";

            }
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void OrderSales_KeyDown(object sender, KeyEventArgs e)
        {
           
           
        }

        private void OrderSales_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
          
        }
        Customer cm = new Customer();
        DataTable dt2 = new DataTable();
        private void comboBox1_Leave(object sender, EventArgs e)
        {
            dt2.Clear();
            if (comboBox1.Text != "")
            {


                dt2 = cm.VildateCustomer(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم العميل الذى قمت باادخالة غير متسجل ","",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);

                    comboBox1.SelectAll();
                    comboBox1.Focus();
                    return;

                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
       
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && comboBox1.Text != string.Empty&& txt_num.Text!="")
                    //    {
                    //Rpt.Rpt_PrintOrder ro = new Rpt.Rpt_PrintOrder();
                    //Rpt.FrmSingleReport s1 = new Rpt.FrmSingleReport();
                    //s1.crystalReportViewer1.RefreshReport();
                    //ro.SetDatabaseLogon("", "", ".", "MesaStory");
                    //ro.SetParameterValue("@ID", (Convert.ToInt32(txt_num.Text)));
                    //s1.crystalReportViewer1.ReportSource = ro;
                    //System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                    //ro.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                    //ro.PrintToPrinter(1, true, 0, 0);
                    //ro.Close();
                    //s1.Dispose();
                    data();

                btn_save.Enabled = true;
                comboBox1.Enabled = true;
                txt_pay.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

