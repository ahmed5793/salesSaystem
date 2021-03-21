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
    public partial class PaySuppliers : Form
    {
        Suppliers s = new Suppliers();
        DataTable dt = new DataTable();
        public PaySuppliers()
        {
            InitializeComponent();
            comboBox1.DataSource = s.ComboBox_PaySuppliers();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Sup_id";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "آختر إسم";
            Txt_SalesMan.Text = Program.salesman;
            txt_prise.Enabled = false;
         
        }

        Stock st = new Stock();
        DataTable dt4 = new DataTable();
        private void PaySuppliers_Load(object sender, EventArgs e)
        {
            cmb_Stock.DataSource = st.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
          

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            DataTable dt5 = new DataTable();
            try
            {
                dt5.Clear();
                dt5 = s.VildateID_Supplirs(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt5.Rows.Count== 0 )
                {
                    MessageBox.Show("إسم المورد غير موجود فى قائمة الموردين");
                    comboBox1.Focus();
                    return;
                }
                 if (comboBox1.Text!= "")
                 {
                    dataGridView1.DataSource = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RdbAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {           
        }
        private void RdbAllPay_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbAllPay.Checked==true)
            {
                txt_prise.Enabled = false;
                txt_prise.Text = "0";
            }
            else
            {
                txt_prise.Enabled = true;
                txt_prise.Text = "0";
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count >= 1)
                {
                    if (cmb_Stock.Text == "")
                    {
                        MessageBox.Show("لا بد من تحديد خزنة");
                        return;
                    }
                    dt4 = st.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));
                   
                    if (RdbAllPay.Checked == true)
                    {

                        if (MessageBox.Show("هل تريد دفع المبلغ بالكامل", "عمليه الدفع", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {                           
                            if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value) > Convert.ToDecimal(dt4.Rows[0][0]))
                            {
                                MessageBox.Show("رصيد الخزنة الحالى غير كافى لشراء هذه الفاتورة");
                                return;
                            }
                          
                            if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value) >0 && comboBox1.Text!="")
                            {
                                st.Add_StockPull(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value), dateTimePicker1.Value, Txt_SalesMan.Text, " رصيد مسحوب من الخزنة ", " مدفوعات مورد" + " " + comboBox1.Text);

                                s.AddPaySuppliers(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value)
                                   , dateTimePicker1.Value, Txt_SalesMan.Text);
                                s.Add_SuppliersStatementAccount(Convert.ToInt32(comboBox1.SelectedValue),0, Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value),"مدفوعات مورد",dateTimePicker1.Value,0);
                                s.Update_SupplierTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), 0);
                                MessageBox.Show("تم دفع المبلغ بنجاح");
                                dataGridView1.DataSource = s.SelectOneSuppliersMony(Convert.ToInt32(comboBox1.SelectedValue));
                                txt_prise.Text = "0";
                                //comboBox1.DataSource = s.CompoBox();
                            }    
                        }
                        else
                        {
                            MessageBox.Show("تم إلغاء العملية بنجاح");
                            return;
                        }
                    }
                    else if (rdbPartPay.Checked == true )
                    {
                        if (MessageBox.Show("هل تريد دفع المبلغ المحدد", "عمليه الدفع", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                        {
                            dt4.Clear();
                            dt4 = st.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));
                            if (Convert.ToDecimal(txt_prise.Text) > Convert.ToDecimal(dt4.Rows[0][0]))
                            {
                                MessageBox.Show("رصيد الخزنة الحالى غير كافى لشراء هذه الفاتورة");
                                return;
                            }
                            if (txt_prise.Text == "0" && txt_prise.Text == "")
                            {
                                MessageBox.Show("لا بد ان يكون المبلغ اكبر من الصفر ");
                                return;
                            }
                            if (Convert.ToDecimal(txt_prise.Text)> Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value))
                            {
                                MessageBox.Show("المبلغ المراد دفعة للمورد اكبر من المبلغ المطلوب فى الرصيد");
                                return;
                            }
                           s.AddPaySuppliers(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txt_prise.Text)
                            , dateTimePicker1.Value, Txt_SalesMan.Text);
                            MessageBox.Show("تم دفع المبلغ بنجاح");
                            st.Add_StockPull(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_prise.Text), dateTimePicker1.Value, Txt_SalesMan.Text, " رصيد مسحوب من الخزنة", " مدفوعات مورد"+" "+comboBox1.Text);
                            decimal x = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value) - Convert.ToDecimal(txt_prise.Text);

                            s.Add_SuppliersStatementAccount(Convert.ToInt32(comboBox1.SelectedValue), 0, Convert.ToDecimal(txt_prise.Text), "مدفوعات مورد", dateTimePicker1.Value, x);
                            s.Update_SupplierTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), x);
                            dataGridView1.DataSource = s.SelectOneSuppliersMony(Convert.ToInt32(comboBox1.SelectedValue));
                            txt_prise.Text = "0";
                            MessageBox.Show("تم دفع المبلغ بنجاح");


                        }
                        else
                        {
                            MessageBox.Show("تم إلغاء العملية بنجاح");
                            return;

                        }
                    }                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txt_prise_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Txt_prise_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Txt_prise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='.'&& txt_prise.Text.ToString().IndexOf('.')>-1)
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar!=8 && e.KeyChar!=Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))

            {
                e.Handled = true;

            }
        }

        private void RdbOneSuppliers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmb_Stock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdbPartPay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPartPay.Checked==true)
            {
                txt_prise.Enabled = true;
            }
        }

        private void txt_prise_TextChanged(object sender, EventArgs e)
        {
            if (txt_prise.Text==".")
            {
                txt_prise.Text = "";
            }
        }
    }
}
