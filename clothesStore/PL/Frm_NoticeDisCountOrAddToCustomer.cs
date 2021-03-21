using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using clothesStore.Bl;
namespace clothesStore.PL
{
    public partial class Frm_NoticeDisCountOrAddToCustomer : DevExpress.XtraEditors.XtraForm
    {
        Customer Cm = new Customer();
        Order o = new Order();
        DataTable dt51 = new DataTable();
        DataTable dt2 = new DataTable();
        void ComboCustomer()
        {
            comboBox1.DataSource = o.SelectCustName();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Cust";
            comboBox1.SelectedIndex = -1;
        }
        public Frm_NoticeDisCountOrAddToCustomer()
        {
            InitializeComponent();
            ComboCustomer();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt51.Clear();
            dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
            txt_LastBalance.Text = dt51.Rows[0][1].ToString();

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            dt2.Clear();
            if (comboBox1.Text != "")
            {
                dt2 = Cm.VildateCustomer(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم العميل الذى قمت باادخالة غير متسجل ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    comboBox1.SelectAll();
                    comboBox1.Focus();
                    return;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_Amount.Text==""|| txt_Amount.Text=="0"){MessageBox.Show("لا بد من تحديد المبلغ");return;}
                if (cmb_Notice.Text==""){MessageBox.Show("لا بد من تحديد نوع إلاشعار");return;}
                if (comboBox1.Text==""){MessageBox.Show("لا بد من تحديد إسم العميل");return;}

                dt51.Clear();
                dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
                if (cmb_Notice.Text== "لة")
                {
                    decimal mno = Convert.ToDecimal(dt51.Rows[0][1]) - Convert.ToDecimal(txt_Amount.Text);

                    Cm.Update_CustomerTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                    Cm.Add_CustomerStatmentAccount(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txt_Amount.Text),
                      0, "رصيد افتتاحي للعميل ", dateTimePicker1.Value, mno, Program.salesman);
                }
                if (cmb_Notice.Text== "علية")
                {

                    decimal mno = Convert.ToDecimal(dt51.Rows[0][1]) + Convert.ToDecimal(txt_Amount.Text);
                    Cm.Update_CustomerTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                    Cm.Add_CustomerStatmentAccount(Convert.ToInt32(comboBox1.SelectedValue), 0,
                      Convert.ToDecimal(txt_Amount.Text), "رصيد افتتاحي للعميل", dateTimePicker1.Value, mno ,Program.salesman);
                }
                MessageBox.Show("تم حفظ العملية بنجاح");
                txt_Amount.Text = "0";
                txt_note.Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='.'&& txt_Amount.Text.ToString().IndexOf('.')>-1)
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar)&& e.KeyChar!=8 && e.KeyChar!= Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}