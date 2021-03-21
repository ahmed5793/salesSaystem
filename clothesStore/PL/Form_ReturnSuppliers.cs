using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clothesStore.PL;
using clothesStore.Bl;
using System.Net;
using System.Globalization;

namespace clothesStore.PL
{
    public partial class Form_ReturnSuppliers : Form
    {
        Suppliers s = new Suppliers();
        Stock st = new Stock();
        DataTable dt2 = new DataTable();
        DataTable dt = new DataTable();
        Proudect p = new Proudect();
        DataTable dt10 = new DataTable();
        Store Store = new Store();
        DataTable dt87 = new DataTable();
        DataTable dt6 = new DataTable();
        public Form_ReturnSuppliers()
        {
            InitializeComponent();
            Select_IdSupplierInnvoice();
            SelectDataTable();
            txt_sales.Text = Program.salesman;

        }
        void Select_IdSupplierInnvoice()
        {
            comboBox1.DataSource = s.ReturncompoSupplier();
            comboBox1.DisplayMember = "ID";
            comboBox1.ValueMember = "ID";
        }
      
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
        //void Select_ComboUnit()
        //{
        //    cmb_Unit.DataSource = p.Select_UnitProduct(Convert.ToInt32(Txt_IdProduct.Text));
        //    cmb_Unit.DisplayMember = "Unit_Name";
        //    cmb_Unit.ValueMember = "Id_Unit";
        //}
        public void CalctotalinvoOrder()
        {
            decimal total = 0;
            for (int i = 0; i < DGV_Return.Rows.Count; i++)
            {
                total += Convert.ToDecimal(DGV_Return.Rows[i].Cells[4].Value);
            }
            Txt_TotalReturn.Text = Math.Round(total, 2).ToString();
        }
        void SelectDataTable()
        {
            dt10.Columns.Add("رقم الصنف");
            dt10.Columns.Add("إسم الصنف");
            dt10.Columns.Add("الكمية المرتجعه");
            dt10.Columns.Add("سعر الشراء");
            dt10.Columns.Add("إلاجمالى");
            DGV_Return.DataSource = dt10;
        }

        private void Form_ReturnSuppliers_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try {

                dt.Clear();
                dt = s.Validate_IdSupplierinnoice(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt.Rows.Count == 0)
                {
                    Console.Beep();
                    MessageBox.Show("لا توجد فاتورة بهذا الرقم");
                    return;
                }
                clear();
                dt = s.SelectSuppliersRteurn(Convert.ToInt32(comboBox1.SelectedValue));
                dt2 = s.SelectProudectRteurn(Convert.ToInt32(comboBox1.SelectedValue));
                foreach (DataRow dr in dt.Rows)
                {
                    txt_num.Text = dr["ID"].ToString();
                    txt_Name.Text = dr["Name"].ToString();
                    Txt_NumSupplier.Text = dr["sup_id"].ToString();
                    txt_sales.Text = Program.salesman;

                }
                dataGridView1.DataSource = dt2;
                dataGridView1.Columns[0].Visible = false;
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
                if (dataGridView1.Rows.Count>0)
                {
                    Txt_IdProduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txt_names.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txt_prise.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txt_quantity.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txt_amount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    dt87.Clear();
                    dt87 = Store.Select_ProductQuntity(Convert.ToInt32(Txt_IdProduct.Text));
                    txt_QuantityInStore.Text = dt87.Rows[0][0].ToString();
                }
            }
            catch
            {
                return;
            }
        }
        void calcalutor()
        {
            if (txt_prise.Text != string.Empty && txt_quantity.Text != string.Empty)
            {

                decimal mins = Convert.ToDecimal(txt_prise.Text) * Convert.ToInt32(txt_quantity.Text);
                txt_amount.Text = mins.ToString();
            }
        }

        void clear()
        {
            txt_amount.Clear();
            txt_Name.Clear();
            txt_names.Clear();
            txt_num.Clear();
            txt_prise.Clear();
            txt_quantity.Clear();
            txt_sales.Clear();
            txt_QuantityInStore.Clear();
            dataGridView1.Columns.Clear();
            dt10.Clear();
            Txt_NumSupplier.Clear();
            Txt_TotalReturn.Text = "0";
            Txt_IdProduct.Clear();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            //dt.Clear();
            //dt = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(Txt_IdProduct.Text), (Txt_Unitname.Text));
            //dt6.Clear();
            //dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(Txt_IdProduct.Text), cmb_Unit.Text);
            if (Convert.ToDecimal(txt_QuantityReturn.Text) ==0 && (txt_QuantityReturn.Text)=="")
            {
                MessageBox.Show("لا بد من تحديد الكمية المرتجعة");
                txt_QuantityReturn.Focus();
                return;
            }

            if (Convert.ToDecimal(txt_QuantityReturn.Text) > Convert.ToDecimal(txt_quantity.Text))
            {
                MessageBox.Show("الكمية المرتجعة أكبر من الكمية المشتراه");
                txt_QuantityReturn.Focus();
                return;
            }
            if (Convert.ToDecimal(txt_QuantityReturn.Text)  > Convert.ToDecimal(txt_QuantityInStore.Text))
            {
                MessageBox.Show("الكمية المرتجعة أكبر من الكمية فى المخزن");
                txt_QuantityReturn.Focus();
                return;
            }
            for (int i = 0; i < DGV_Return.Rows.Count; i++)
            {
                if (DGV_Return.Rows[i].Cells[0].Value.ToString() == (Txt_IdProduct.Text))
                {
                    MessageBox.Show("تم إرتجاع هذا الصنف فى نفس الفاتورة من قبل لا بد من مسح الصنف من الاصناف المرتجعةاولا وارتجاعة مره اخرى");
                    return;
                }
            }
            if (Txt_IdProduct.Text != string.Empty && Convert.ToDecimal(txt_QuantityReturn.Text)>0)
            {
                decimal z = Convert.ToDecimal(txt_prise.Text);
                DataRow r = dt10.NewRow();
                r[0] = Txt_IdProduct.Text;
                r[1] = txt_names.Text;
                r[2] = (txt_QuantityReturn.Text) + ".00";
                r[3] = z;
                r[4] = (Convert.ToDecimal(txt_QuantityReturn.Text) * z);

                dt10.Rows.Add(r);
                DGV_Return.DataSource = dt10;
                CalctotalinvoOrder();
                txt_amount.Clear();
                txt_prise.Clear();
                txt_quantity.Clear();
                txt_QuantityInStore.Clear();
                txt_QuantityReturn.Clear();
                Txt_IdProduct.Clear();
                txt_names.Clear();
            }     
            else
            {
             MessageBox.Show("من فضلك قم بتحديد الصنف المراد إرجاعه");
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {          
                  
                if (DGV_Return.Rows.Count > 0)
                {
                    if (txt_num.Text == "") { MessageBox.Show("لا بد من اختيار فاتورة"); return; }
                    if (Txt_NumSupplier.Text == "") { MessageBox.Show("لا بد من وجود رقم المورد"); return; }
                    if (txt_sales.Text == "") { txt_sales.Text = Program.salesman; }

                  //  if (Convert.ToDecimal(Txt_TotalReturn.Text) > 0)
                  //{
                  //st.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(Txt_Pay.Text), dateTimePicker1.Value,
                  //                   txt_sales.Text, " رصيد مضاف الى الخزنة ", "مرتجع فاتورة مستريات رقم "+" " + txt_num.Text);
                  //}
                 

                    for (int i = 0; i < DGV_Return.Rows.Count ; i++)
                    {
              
                        s.AddReturn(Convert.ToInt32(txt_num.Text), Convert.ToInt32(Txt_NumSupplier.Text),
                        Convert.ToInt32(DGV_Return.Rows[i].Cells[0].Value), Convert.ToDecimal(DGV_Return.Rows[i].Cells[2].Value),
                        dateTimePicker1.Value,Convert.ToDecimal(DGV_Return.Rows[i].Cells[3].Value), 
                        Convert.ToDecimal(DGV_Return.Rows[i].Cells[4].Value), txt_sales.Text );

                        //dt6.Clear();
                        //dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(DGV_Return.Rows[i].Cells[0].Value), Convert.ToString(DGV_Return.Rows[i].Cells[3].Value));
                        //decimal x = Convert.ToDecimal(DGV_Return.Rows[i].Cells[4].Value) / Convert.ToDecimal(dt6.Rows[0][1]);

                        p.Update_ProductQuantityDecrease(Convert.ToInt32(DGV_Return.Rows[i].Cells[0].Value),
                             Convert.ToDecimal(DGV_Return.Rows[i].Cells[2].Value));
                    }

                    DataTable dt71 = new DataTable();
                    dt71.Clear();
                    dt71 = s.select_SupplierBalance(Convert.ToInt32(Txt_NumSupplier.Text));
                    decimal mno = Convert.ToDecimal(dt71.Rows[0][1]) - (Convert.ToDecimal(Txt_TotalReturn.Text) );
                    s.Add_SuppliersStatementAccount(Convert.ToInt32(Txt_NumSupplier.Text),0, 
                                                  Convert.ToDecimal(Txt_TotalReturn.Text), "مرتجع مشتريات للفاتورة رقم "+" "+ txt_num.Text, dateTimePicker1.Value, mno);
                    s.Update_SupplierTotalMoney(Convert.ToInt32(Txt_NumSupplier.Text), mno);
                    MessageBox.Show("تم حفظ الفاتورة بنجاح ", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    btn_save.Enabled = false;                    
                    clear();
                    btn_save.Enabled = true;
                }
                else
                {
                    MessageBox.Show("لا بد من إختيار فاتورة");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void txt_return_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Txt_Pay_Leave_1(object sender, EventArgs e)
        {
            
        }

        private void Txt_Pay_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void txt_QuantityReturn_Layout(object sender, LayoutEventArgs e)
        {
            if (txt_QuantityReturn.Text == "")
            {
                txt_QuantityReturn.Text = "0";
            }
        }

        private void DGV_Return_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalctotalinvoOrder();
        }

        private void Btn_OldReturn_Click(object sender, EventArgs e)
        {
            Frm_ShowOldReturnSupplier frm_show = new Frm_ShowOldReturnSupplier();
            DataTable data5 = new DataTable();
            try
            {
                if (txt_num.Text == "") { MessageBox.Show("لا بد من اختيار فاتورة"); return; }
                data5.Clear();
                data5 = s.Select_OldReturnSupplier(Convert.ToInt32(txt_num.Text));
                if (data5.Rows.Count > 0)
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
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_SearchSupplierOrder frm = new Frm_SearchSupplierOrder();

            try
            {
                frm.ShowDialog();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                
                    if (frm.dataGridView1.SelectedRows.Count > 0 && frm.dataGridView1.Rows.Count > 0)
                    {
                        clear();

                        dt1.Clear();
                        dt2.Clear();
                         clear();
                        dt1 = s.SelectSuppliersRteurn(Convert.ToInt32(frm.dataGridView1.CurrentRow.Cells[0].Value));
                        dt2 = s.SelectProudectRteurn(Convert.ToInt32(frm.dataGridView1.CurrentRow.Cells[0].Value));
                    foreach (DataRow dr in dt1.Rows)
                    {
                        txt_num.Text = dr["ID"].ToString();
                        txt_Name.Text = dr["Name"].ToString();
                        Txt_NumSupplier.Text = dr["sup_id"].ToString();
                    }
                    dataGridView1.DataSource = dt2;
                    dataGridView1.Columns[0].Visible = false;
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.StackTrace);
                }
              
            
          
        }

        private void txt_prise_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_QuantityReturn_Leave(object sender, EventArgs e)
        {
            if (txt_QuantityReturn.Text=="")
            {
                txt_QuantityReturn.Text = "0";
            }
        }
    }
}
            



