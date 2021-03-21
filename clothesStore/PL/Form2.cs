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
    public partial class Form2 : Form
    {
        private static Form2 farm;

        static void STATUESCllosed(object sender, FormClosedEventArgs e)
        {
            farm = null;
        }
        public static Form2 getmain
        {
            get
            {
                if (farm == null)
                {
                    farm = new Form2();
                    farm.FormClosed += new FormClosedEventHandler(STATUESCllosed);
                }
                return farm;
            }
        }
        DataTable dt = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt6 = new DataTable();
        Suppliers s = new Suppliers();
        Store Store = new Store();
        Stock st = new Stock();
        Proudect p = new Proudect();
        public Form2()
        {
            InitializeComponent();

            if (farm==null)
            {
                farm = this;
            }
            //txt_barcode.Hide();
            //Btn_PrintPreview.Hide();
            ComboSupplier();
            ComboStock();
            dataTablee();
            txt_sales.Text = Program.salesman;
        }
      
        void ComboSupplier()
        {
            comboBox1.DataSource = s.CompoBoxSuppliers();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Sup_id";
            comboBox1.SelectedIndex = -1;
        }
        void ComboStock()
        {
            cmb_Stock.DataSource = st.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
            if (dt4.Rows.Count > 0)
            {
                dt4 = st.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));

            }
        }
        public void dataTablee()
        {
            dt.Columns.Add("رقم الصنف");//0
            dt.Columns.Add("اسم الصنف");//1
            dt.Columns.Add("النوع");//2
            dt.Columns.Add("سعرالشراء");//3
            dt.Columns.Add("الكميه"); //4
            dt.Columns.Add(" الاجمالي ");//5
            dt.Columns.Add("الخصم");//6
            dt.Columns.Add("الاجمالي بعد الخصم");//7
            dt.Columns.Add(" رقم الباركود");//8
            dt.Columns.Add("سعر البيع");//9
            dataGridView1.DataSource = dt;
        }

        void data()
        {
            dataGridView1.DataSource = null;
            dt.Clear();
            txt_note.Clear();
            txt_invo.Text = "0.00";
            txt_pay.Text = "0.00";
            txt_mark.Text = "0";
            txt_num.Clear();
            comboBox1.SelectedIndex = -1;
            lblItemsCount.Text = dataGridView1.Rows.Count.ToString();

        }

        public void pay()

        {
            if (txt_invo.Text != string.Empty && txt_pay.Text != string.Empty)
            {
                decimal totainv = Convert.ToDecimal(txt_invo.Text) - Convert.ToDecimal(txt_pay.Text) ;
                txt_mark.Text = totainv.ToString();
            }
        }
      
      public  void calcalutordirect()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal mins = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value) * Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                dataGridView1.Rows[i].Cells[5].Value = Math.Round(mins,2).ToString();

            }
        }
     
      public  void totaldirect()
      {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal amount = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                decimal discount = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal total = amount - discount;
                dataGridView1.Rows[i].Cells[7].Value = Math.Round(total,2).ToString();
            }
      }
        public void totalinvoicesup()
        {           
                decimal total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                }
                txt_invo.Text = Math.Round(total, 2).ToString();         
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {              
                FormListSuppliers ls = new FormListSuppliers();
                ls.ShowDialog();            
                if (ls.dataGridView1.Rows.Count > 0 && ls.dataGridView1.SelectedRows.Count>0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == ls.dataGridView1.CurrentRow.Cells[0].Value.ToString())
                        {
                            Console.Beep();
                            MessageBox.Show("هذا الصنف مسجل من قبل ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                
                    DataRow r = dt.NewRow();
                    r[0] = ls.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    r[1] = ls.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    r[2] = ls.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    r[3] = ls.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    r[4] = 1;
                    r[6] = 0;
                    r[8] = ls.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    r[9] = ls.dataGridView1.CurrentRow.Cells[6].Value.ToString();
 
                    dt.Rows.Add(r);
                    Console.Beep();
                    dataGridView1.DataSource = dt;
                    calcalutordirect();
                    totaldirect();
                    totalinvoicesup();
                    pay();
                    lblItemsCount.Text = dataGridView1.Rows.Count.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 )
                {
                    if (cmb_Stock.Text == ""){MessageBox.Show("لا بد من تحديد خزنة");return;}
                    if (comboBox1.Text == ""){MessageBox.Show("لا بد من تحديد إسم المورد");return;}

                    dt4.Clear();
                    dt4 = st.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));

                    if (dt4.Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(txt_pay.Text) > Convert.ToDecimal(dt4.Rows[0][0]))
                        {
                            MessageBox.Show("رصيد الخزنة الحالى غير كافى لشراء هذه الفاتورة");
                            return;

                        }
                    }
                    btn_save.Enabled = false;

                    if (Convert.ToDecimal(txt_pay.Text)>0)
                    {
                        st.Add_StockPull(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_pay.Text), dateTimePicker1.Value, 
                            txt_sales.Text, " رصيد مسحوب من الخزنة لفاتورة مشتريات" , "فاتورة مشتريات"+" "+ comboBox1.Text);
                    }

                    s.ADDSuppliersINFORMARION( Convert.ToInt32(comboBox1.SelectedValue), 
                        dateTimePicker1.Value,txt_note.Text, txt_sales.Text,Convert.ToDecimal(txt_invo.Text),
                        Convert.ToDecimal(txt_pay.Text), Convert.ToDecimal(txt_mark.Text), Convert.ToInt32(cmb_Stock.SelectedValue));
                    txt_num.Text = s.LastSuppliersDetalis().Rows[0][0].ToString();

                   for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                   {
               
                        s.addSuppliersDetails(Convert.ToInt32(txt_num.Text),
                       Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value)
                      ,Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value),Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value),
                       Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value),Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value), 
                       dataGridView1.Rows[i].Cells[1].Value.ToString());

                        //dt6.Clear();
                        //dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), Convert.ToString(dataGridView1.Rows[i].Cells[4].Value));
                        //decimal x = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value) / Convert.ToDecimal(dt6.Rows[0][1]);
                        dt4.Clear();
                        dt4 = Store.Validate_ProductStore(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), 
                            Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value));
                    if (dt4.Rows.Count == 0)
                    {

                        Store.Add_StoreProduct(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                         Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value));

                    }
                        //else if (dt4.Rows.Count>0)
                        
                            p.Update_ProductQuantityIncrease(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                                                              Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value));
                            //}
                   }
                    dt6.Clear();
                    dt6 = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
                    decimal mno = Convert.ToDecimal(dt6.Rows[0][1]) + Convert.ToDecimal(txt_mark.Text);
                    s.Update_SupplierTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                    s.Add_SuppliersStatementAccount(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txt_invo.Text),
                        Convert.ToDecimal(txt_pay.Text), "فاتورة مشتريات رقم " + " " + txt_num.Text, dateTimePicker1.Value, mno);
                    MessageBox.Show("تم اضافه الفاتوره بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    data();
                    btn_save.Enabled = true;

                }
                else
                {
                    MessageBox.Show("من فضلك قم بااختيار صنف واحد علي الاقل ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void txt_mark_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void
            txt_pay_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void txt_invo_KeyUp_1(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void txt_pay_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txt_mark_KeyUp_1(object sender, KeyEventArgs e)
        {
            pay();
        }

        private void txt_invo_KeyUp(object sender, KeyEventArgs e)
        {
            pay();
        }
        private void txt_pay_KeyUp_1(object sender, KeyEventArgs e)
        {            
            pay(); 
        }
        private void dataGridView1_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Suppliers sm = new Form_Suppliers();
            sm.ShowDialog();
            comboBox1.DataSource = s.CompoBoxSuppliers();
        }
        private void Txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txt_barcode.Text != string.Empty && e.KeyChar == 13)
                {
                    Proudect p = new Proudect();
                    DataTable dt10 = new DataTable();
                    dt10.Clear();
                    dt10 = p.search_barcode(Convert.ToInt64(txt_barcode.Text));
                    if (dt10.Rows.Count > 0)
                    {

                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == dt10.Rows[0][0].ToString())
                            {
                                Console.Beep();
                                MessageBox.Show("هذا الصنف مسجل من قبل ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                return;

                            }

                        }


                        dataGridView1.DataSource = dt;
                        DataRow r2 = dt.NewRow();
                        r2[0] = dt10.Rows[0][0].ToString();
                        r2[1] = dt10.Rows[0][1].ToString();
                        r2[2] = dt10.Rows[0][2].ToString();
                        r2[3] = dt10.Rows[0][7].ToString();
                        r2[4] = 1;
                        r2[6] = 0;
                        r2[8] = dt10.Rows[0][5].ToString();
                        r2[9] = dt10.Rows[0][3].ToString();


                        dt.Rows.Add(r2);
                        Console.Beep();
                        dataGridView1.DataSource = dt;
                        calcalutordirect();
                        totaldirect();
                        totalinvoicesup();
                        pay();
                        lblItemsCount.Text = dataGridView1.Rows.Count.ToString();

                        btn_save.Enabled = true;

                        txt_pay.Enabled = true;
                        txt_barcode.Clear();
                    }
                    else
                    {
                        MessageBox.Show("هذا الرقم غير موجود في قائمة الاصناف ");
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

        private void Btn_PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {


                if (dataGridView1.Rows.Count > 0)
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        DataSet1 ds = new DataSet1();
                        //ds.Clear();
                        //Rpt.CrystalReport2 cr = new Rpt.CrystalReport2();
                        //ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[10].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[10].Value.ToString(), dataGridView1.Rows[i].Cells[11].Value.ToString());
                        //cr.SetDataSource(ds);
                        //Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
                        //frm.crystalReportViewer1.ReportSource = cr;
                        //frm.crystalReportViewer1.Refresh();
                        //System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                        //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                        //cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value), true, 0, 0);
                        //frm.ShowDialog();
                        if (Properties.Settings.Default.BarcodeSize == "مقاس كبير ")
                        {

                            Rpt.Rpt_Large_Barcode cr = new Rpt.Rpt_Large_Barcode();
                            ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[8].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString());
                            cr.SetDataSource(ds);
                            Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
                            frm.crystalReportViewer1.ReportSource = cr;
                            frm.crystalReportViewer1.Refresh();
                            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                            cr.PrintOptions.PrinterName = Properties.Settings.Default.PrintBarcode;
                            //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                            cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value), true, 0, 0);
                        }
                        else if (Properties.Settings.Default.BarcodeSize == "مقاس وسط ")
                        {

                            Rpt.Rpt_MidBarcode cr = new Rpt.Rpt_MidBarcode();
                            ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[8].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString());
                            cr.SetDataSource(ds);
                            Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
                            frm.crystalReportViewer1.ReportSource = cr;
                            frm.crystalReportViewer1.Refresh();
                            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                            cr.PrintOptions.PrinterName = Properties.Settings.Default.PrintBarcode;
                            //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                            cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value), true, 0, 0);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لابد من اختيار صنف واحد على الاقل");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Txt_pay_MouseClick(object sender, MouseEventArgs e)
        {
            txt_pay.SelectAll();
        }
        void Update_QtyUnit()
        {
            Frm_EditQuantitySupplier Frm = new Frm_EditQuantitySupplier();

            if (dataGridView1.Rows.Count > 0 && dataGridView1.SelectedRows.Count > 0)
            {
                Frm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Frm.ShowDialog();
            }
            if (Frm.Txt_Quantity.Text != "0" && Frm.Txt_Quantity.Text != "" &&
                Frm.txt_prise.Text != "" && Frm.txt_prise.Text != "0" && Frm.Txt_DisCount.Text != "" )
            {

                dataGridView1.CurrentRow.Cells[4].Value = Frm.Txt_Quantity.Text;
                dataGridView1.CurrentRow.Cells[6].Value = Frm.Txt_DisCount.Text;
                dataGridView1.CurrentRow.Cells[3].Value = Frm.txt_prise.Text;
                //DataTable dt3 = new DataTable();
                //dt3.Clear();
                //dt3 = p.SelectQuantityMinmun(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                //if (dt3.Rows.Count > 0)
                //{
                //    MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                calcalutordirect();
                totaldirect();
                totalinvoicesup();
                pay();
                Frm.Txt_Quantity.Clear();
                Frm.Txt_DisCount.Clear();
                Frm.txt_prise.Clear();
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        private void Txt_pay_MouseLeave(object sender, EventArgs e)
        {
            if (txt_pay.Text=="")
            {
                txt_pay.Text = "0";
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            dt4.Clear();
            if (comboBox1.Text != "")
            {
                dt4 = s.VildateSuppliers(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt4.Rows.Count == 0)
                {
                    MessageBox.Show("اسم المورد الذى قمت باادخالة غير مسجل ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    comboBox1.SelectAll();
                    comboBox1.Focus();
                    return;
                }
            }
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            data();
            btn_save.Enabled = true;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        Update_QtyUnit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                totalinvoicesup();
                pay();
                lblItemsCount.Text = dataGridView1.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

