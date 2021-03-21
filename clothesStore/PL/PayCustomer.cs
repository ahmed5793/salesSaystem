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

namespace clothesStore.PL
{
    public partial class PayCustomer : Form
    {
        Order o = new Order();
        DataTable dt = new DataTable();
        Stock s = new Stock();
        Customer Cm = new Customer();
        public PayCustomer()
        {
            InitializeComponent();
            comboBox1.DataSource = o.SelectCompoCustomer();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Cust";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "آختر إسم";
            Txt_SalesMan.Text = Program.salesman;
            txt_prise.Enabled = false;
        }
        private void PayCustomer_Load(object sender, EventArgs e)
        {
            cmb_Stock.DataSource = s.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
        }
        Customer c = new Customer();
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
                if (comboBox1.Text!="" && Convert.ToDecimal(dt.Rows[0][1])> 0)
                {

                    dataGridView1.DataSource = dt;


                }
                else
                {
                    MessageBox.Show("لا يوجد رصيد على هذا العميل");
                    return;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        MessageBox.Show("لا بد من إختيار خزنة");
                        return;
                    }
                    DataTable dt51 = new DataTable();
                    dt51.Clear();
                    dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
                    if (RdbAllPay.Checked == true)
                    {

                        if (MessageBox.Show("هل تريد دفع المبلغ بالكامل", "عمليه الدفع", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                        {                           
                            o.InsertPayCustomer(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value), dateTimePicker1.Value,
                                Convert.ToInt32(comboBox1.SelectedValue), Txt_SalesMan.Text);
                            s.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value), dateTimePicker1.Value, Txt_SalesMan.Text, "  رصيد مضاف الى الخزنة من مدفوعات عميل",  "مدفوعات  عميل من" +" "+ comboBox1.Text);

                            decimal mno = Convert.ToDecimal(dt51.Rows[0][1]) - Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                            Cm.Update_CustomerTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                            Cm.Add_CustomerStatmentAccount(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value),
                                0, "مدفوعات عميل " + " " + comboBox1.Text, dateTimePicker1.Value, mno, Program.salesman);
                            MessageBox.Show("تم دفع المبلغ بنجاح");

                            
                        }
                        else
                        {
                            MessageBox.Show("تم إلغاء العملية بنجاح");
                            return;
                        }
                    }
                    else if (rdbPartPay.Checked == true)
                    {
                        if (MessageBox.Show("هل تريد دفع جزء من المبلغ المتبقي", "عمليه الدفع", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)

                        {
                            if (Convert.ToDecimal(txt_prise.Text) > 0)
                            {
                                o.InsertPayCustomer(Convert.ToDecimal(txt_prise.Text), dateTimePicker1.Value, Convert.ToInt32(comboBox1.SelectedValue), Txt_SalesMan.Text);
                                s.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_prise.Text), dateTimePicker1.Value, Txt_SalesMan.Text, "  رصيد مضاف الى الخزنة من مدفوعات عميل", "مدفوعات  عميل من" + " " + comboBox1.Text);
                                decimal mno = Convert.ToDecimal(dt51.Rows[0][1]) - Convert.ToDecimal(txt_prise.Text);
                                Cm.Update_CustomerTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                                Cm.Add_CustomerStatmentAccount(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txt_prise.Text),
                                    0, "مدفوعات عميل " + " " + comboBox1.Text, dateTimePicker1.Value, mno, Program.salesman);
                                MessageBox.Show("تم دفع المبلغ بنجاح");
                                txt_prise.Text = "0";

                            }
                            else
                            {
                                MessageBox.Show("لا بد ان يكون المبلغ اكبر من الصفر");
                                return;
                            }


                        }
                        else
                        {
                            MessageBox.Show("تم إلغاء العملية بنجاح");
                            return;

                        }
                    }
                    comboBox1.DataSource = o.SelectCompoCustomer();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID_Cust";
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "آختر إسم";
                    dt.Clear();
                    dt = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
                    dataGridView1.DataSource = dt;
                }
             
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
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
            }
        }

        private void RdbAllCustomer_CheckedChanged(object sender, EventArgs e)
        {
           
        }

       

        private void txt_prise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && txt_prise.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization. CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {

                e.Handled = true;


            }
        }

        private void Txt_rent_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_prise_TextChanged(object sender, EventArgs e)
        {
            if (txt_prise.Text=="")
            {
                txt_prise.Text = "0";
            }
        }

        private void Txt_prise_MouseClick(object sender, MouseEventArgs e)
        {
            txt_prise.SelectAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Clear();
            if (comboBox1.Text != "")
            {
                dt2 = Cm.VildateCustomer(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم العميل الذى قمت باادخالة غير موجود فى قائمة العملاء ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    comboBox1.SelectAll();
                    comboBox1.Focus();
                    return;
                }
            }
        }
    }
        }
    

