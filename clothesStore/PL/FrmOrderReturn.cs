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
    public partial class FrmOrderReturn : Form
    {
        Customer Cm = new Customer();
        Stock s = new Stock();
        Order o = new Order();
        Store Store = new Store(); 
        Proudect p = new Proudect();
        DataTable dt = new DataTable();
        DataTable dt10 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt6 = new DataTable();
        public void CalctotalinvoOrder()
        {
            decimal total = 0;
            for (int i = 0; i < Dgv_Return.Rows.Count; i++)
            {
                total += Convert.ToDecimal(Dgv_Return.Rows[i].Cells[4].Value);
            }
            Txt_TotalReturn.Text = Math.Round(total, 2).ToString();
        }
        void clear()
        {
            txt_amount.Clear();
            txt_Name.Clear();
            txt_NumCust.Clear();
            txt_nameProduct.Clear();
            txt_num.Clear();
            txt_prise.Clear();
            txt_quantity.Clear();
            txt_sales.Clear();
            Txt_IdProduct.Clear();
            txt_totalQuantity.Clear();
            Txt_TotalReturn.Text = "0";
            dt10.Clear();
        }
        void SelectDataTable()
        {
            dt10.Columns.Add("رقم الصنف");//0
            dt10.Columns.Add("إسم الصنف");//1
            dt10.Columns.Add("الكمية المرتجعه");//2
            dt10.Columns.Add("سعر البيع");//3
            dt10.Columns.Add("إلاجمالى");//4
            Dgv_Return.DataSource = dt10;
        }
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
       
        void Select_IdOrder()
        {
            comboBox1.DataSource = o.SelectIdOrder();
            comboBox1.DisplayMember = "ID_Order";
            comboBox1.ValueMember = "ID_Order";
        }
        public FrmOrderReturn()
        {
            InitializeComponent();
            Select_IdOrder();
            SelectDataTable();
            txt_sales.Text = Program.salesman;
            Txt_IdProduct.Hide();
        }

        private void FrmOrderReturn_Load(object sender, EventArgs e)
        {     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                clear();
                dt2.Clear();
                if (comboBox1.Text != "")
                {
                    dt2 = o.VildateID_Order(Convert.ToInt32(comboBox1.SelectedValue));
                    if (dt2.Rows.Count == 0)
                    {
                        MessageBox.Show(" رقم الفاتورة غير موجود ف الفواتير ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        comboBox1.SelectAll();
                        comboBox1.Focus();
                        return;

                    }
                }        
                dt1.Clear();
                dt1 = o.SelectOrderReturn(Convert.ToInt32(comboBox1.SelectedValue));
                dt2.Clear();
                dt2 = o.SelectProdRuturnOrder(Convert.ToInt32(comboBox1.SelectedValue));
                foreach (DataRow dr in dt1.Rows)
                {
                    txt_num.Text = dr["ID_Order"].ToString();
                    txt_Name.Text = dr["Name"].ToString();
                    txt_NumCust.Text = dr["ID_Cust"].ToString();
                    txt_sales.Text = Program.salesman ;
                }
                    dataGridView1.DataSource = dt2;
                    dataGridView1.Columns[0].Visible = false;
                //Cmb_Store.Text = dt2.Rows[0][10].ToString();
             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            
            }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    decimal y = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value) / Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
                    Txt_IdProduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txt_nameProduct.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txt_prise.Text = y.ToString();
                    txt_quantity.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txt_amount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    dt.Clear();
                    dt = Store.Select_ProductQuntity(Convert.ToInt32(Txt_IdProduct.Text));
                    txt_totalQuantity.Text = dt.Rows[0][0].ToString();

                }
            }
            catch
            {
                return;
            }
        }

        private void txt_prise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && txt_prise.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txt_prise_Validated(object sender, EventArgs e)
        {
            if (txt_prise.Text == "")
            {
                MessageBox.Show("برجاء ادخال سعر الصنف");
                txt_prise.Focus();
            }
        }

        private void txt_pay_TextChanged(object sender, EventArgs e)
        {
            //if (txt_pay.Text == "")
            //{
            //    txt_pay.Text = "0";
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
           
        }

        private void txt_return_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }


        private void txt_return_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsDigit(e.KeyChar)&&e.KeyChar!= 8 )
            {
                e.Handled = true;
            }
        }
        private void Txt_pay_Leave(object sender, EventArgs e)
        {
           
        }

        private void Btn_AddToReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(txt_QuantityReturn.Text) == 0 && (txt_QuantityReturn.Text) == "")
                    {
                        MessageBox.Show("لا بد من تحديد الكمية المرتجعة");
                    }

                    if (Convert.ToDecimal(txt_QuantityReturn.Text) > Convert.ToDecimal(txt_quantity.Text))
                    {
                        MessageBox.Show("الكمية المرتجعة أكبر من الكمية المباعة");
                        txt_QuantityReturn.Focus();
                        return;
                    }
                    DataTable data5 = new DataTable();
                    data5.Clear();
                    data5 = o.SelectQuantityOFProductFromOrderReturn(Convert.ToInt32(txt_num.Text), Convert.ToInt32(Txt_IdProduct.Text));
                    if (data5.Rows.Count > 0)
                    {

                        if (Convert.ToDecimal(data5.Rows[0][4]) + Convert.ToDecimal(txt_QuantityReturn.Text)
                              > Convert.ToDecimal(txt_quantity.Text))
                        {
                            MessageBox.Show(" تم إرتجاع هذا الصنف من قبل لا بد من التاكد من مرتجع الفاتورة السابق والتاكد من الكمية المرتجعه تخطت الكمية المباعة ");
                            return;

                        }

                    }
                    //if (Convert.ToInt32(txt_QuantityReturn.Text) > Convert.ToInt32(txt_totalQuantity.Text))
                    //{
                    //    MessageBox.Show("الكمية المرتجعة أكبر من الكمية الموجودة فى المخزن");
                    //    txt_QuantityReturn.Focus();
                    //    return;
                    //}
                    for (int i = 0; i < Dgv_Return.Rows.Count; i++)
                    {
                        if (Dgv_Return.Rows[i].Cells[0].Value.ToString()==(Txt_IdProduct.Text))
                        {
                            MessageBox.Show("تم إرتجاع هذا الصنف فى نفس الفاتورة من قبل لا بد من مسح الصنف من قائمة الاصناف المرتجعةاولا ثم إرتجاعة مره اخرى");
                            return;
                        }
                    }
                    if (Txt_IdProduct.Text != "" && Convert.ToDecimal(txt_QuantityReturn.Text) > 0)
                    {
                        DataRow r = dt10.NewRow();
                        r[0] = Txt_IdProduct.Text;
                        r[1] = txt_nameProduct.Text;
                        r[2] = (txt_QuantityReturn.Text) + ".00";
                        r[3] = txt_prise.Text;
                        r[4] = (Convert.ToDecimal(txt_QuantityReturn.Text) * Convert.ToDecimal(txt_prise.Text));
                
                        dt10.Rows.Add(r);
                        Dgv_Return.DataSource = dt10;
                        CalctotalinvoOrder();

                        txt_amount.Clear();
                        txt_nameProduct.Clear();
                        txt_prise.Clear();
                        txt_quantity.Clear();
                        Txt_IdProduct.Clear();
                        txt_QuantityReturn.Text = "0";
                        txt_totalQuantity.Clear();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك قم بتحديد الكميه المرتجعه");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_num.Text==""){MessageBox.Show("لا بد من اختيار فاتورة");return;}
                if (txt_NumCust.Text==""){MessageBox.Show("لا بد من وجود رقم العميل");return;}
                if (txt_sales.Text==""){ txt_sales.Text = Program.salesman; }
                
                if (dataGridView1.Rows.Count > 0 && Dgv_Return.Rows.Count>0 )
                {
                    
                   

                    for (int i = 0; i < Dgv_Return.Rows.Count ; i++)
                    {
                        o.AddOrderReturn(Convert.ToInt32(txt_num.Text), Convert.ToInt32(txt_NumCust.Text),
                            Convert.ToInt32(Dgv_Return.Rows[i].Cells[0].Value),Convert.ToDecimal(Dgv_Return.Rows[i].Cells[2].Value),
                            dateTimePicker1.Value , Convert.ToDecimal(Dgv_Return.Rows[i].Cells[3].Value),
                            Convert.ToDecimal(Dgv_Return.Rows[i].Cells[4].Value)
                            ,txt_sales.Text ) ;

                        p.Update_ProductQuantityIncrease(Convert.ToInt32(Dgv_Return.Rows[i].Cells[0].Value),
                             Convert.ToDecimal(Dgv_Return.Rows[i].Cells[2].Value));
                    }
                    DataTable dt51 = new DataTable();
                    dt51.Clear();
                    dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(txt_NumCust.Text));
                    decimal mno = Convert.ToDecimal(dt51.Rows[0][1]) + (0 - Convert.ToDecimal(Txt_TotalReturn.Text));
                    Cm.Update_CustomerTotalMoney(Convert.ToInt32(txt_NumCust.Text), mno);
                    Cm.Add_CustomerStatmentAccount(Convert.ToInt32(txt_NumCust.Text), Convert.ToDecimal(Txt_TotalReturn.Text),
                        0, "مرتجع مبيعات للفاتورة رقم " + " " + txt_num.Text, dateTimePicker1.Value, mno,Program.salesman);
                    MessageBox.Show("تم حفظ المرتجع بنجاح", "عمليه مرتجع مبيعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    comboBox1.DataSource = o.SelectIdOrder();
                    clear();
                    dataGridView1.Columns.Clear();
                }
                else
                {
                    MessageBox.Show("لا بد من إختيار فاتورة");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Frm_SearchCustomerOrder frm = new Frm_SearchCustomerOrder();

            try
            {
                frm.ShowDialog();     
                if (frm.dataGridView1.SelectedRows.Count > 0 && frm.dataGridView1.Rows.Count > 0)
                {
                    clear();

                    dt1.Clear();
                    dt2.Clear();
                    dt1 = o.SelectOrderReturn(Convert.ToInt32(frm.dataGridView1.CurrentRow.Cells[0].Value));
                    dt2 = o.SelectProdRuturnOrder(Convert.ToInt32(frm.dataGridView1.CurrentRow.Cells[0].Value));
                    foreach (DataRow dr in dt1.Rows)
                    {
                        txt_num.Text = dr["ID_Order"].ToString();
                        txt_Name.Text = dr["Name"].ToString();
                        txt_NumCust.Text = dr["ID_Cust"].ToString();
                        txt_sales.Text = Program.salesman;
                    }
                    dataGridView1.DataSource = dt2;
                    dataGridView1.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_OldReturn_Click(object sender, EventArgs e)
        {
            Frm_ShowOldReturnOrder frm_show = new Frm_ShowOldReturnOrder();
            DataTable data5 = new DataTable();
            try
            {

                if (txt_num.Text == "") { MessageBox.Show("لا بد من اختيار فاتورة"); return; }
                if (txt_NumCust.Text == "") { MessageBox.Show("لا بد من وجود رقم العميل"); return; }
                data5.Clear();
                data5 = o.Select_OldReturnOrder(Convert.ToInt32(txt_num.Text));
                if (data5.Rows.Count > 0 )
                {
                    frm_show.dataGridView1.DataSource = data5;
                    frm_show.ShowDialog();
                }
                else
                {
                    MessageBox.Show("لا يوجد مرتجع سابق لهذه الفاتورة");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_QuantityReturn_Leave(object sender, EventArgs e)
        {
            if (txt_QuantityReturn.Text == "")
            {
                txt_QuantityReturn.Text = "0";
            }
        }

        private void txt_QuantityReturn_Click(object sender, EventArgs e)
        {
            if (txt_QuantityReturn.Text == "0")
            {
                txt_QuantityReturn.Text = "";
            }

        }

        private void Dgv_Return_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalctotalinvoOrder();
        }

        private void Txt_TotalReturn_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_TotalReturn_Click(object sender, EventArgs e)
        {
           
        }

        private void Txt_Pay_Click(object sender, EventArgs e)
        {
           
        }
    }




} 
  
