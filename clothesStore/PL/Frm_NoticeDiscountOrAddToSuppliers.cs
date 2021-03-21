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
    public partial class Frm_NoticeDiscountOrAddToSuppliers : DevExpress.XtraEditors.XtraForm
    {
        Suppliers s = new Suppliers();
        DataTable dt6 = new DataTable();
        DataTable dt4 = new DataTable();
        void ComboSupplier()
        {
            comboBox1.DataSource = s.CompoBoxSuppliers();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Sup_id";
            comboBox1.SelectedIndex = -1;
        }
        public Frm_NoticeDiscountOrAddToSuppliers()
        {
            InitializeComponent();
            ComboSupplier();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt6.Clear();
            dt6 = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
            txt_LastBalance.Text = dt6.Rows[0][1].ToString();

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

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='.'&& txt_Amount.Text.ToString().IndexOf('.')>-1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar)&& e.KeyChar!=8 && e.KeyChar!= Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txt_Amount_Leave(object sender, EventArgs e)
        {
            if (txt_Amount.Text=="")
            {
                txt_Amount.Text = "0";
            }
        }

        private void txt_Amount_Click(object sender, EventArgs e)
        {
            if (txt_Amount.Text == "0")
            {
                txt_Amount.Text = "";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Amount.Text == "" || txt_Amount.Text == "0") { MessageBox.Show("لا بد من تحديد المبلغ"); return; }
                if (cmb_Notice.Text == "") { MessageBox.Show("لا بد من تحديد نوع إلاشعار"); return; }
                if (comboBox1.Text == "") { MessageBox.Show("لا بد من تحديد إسم العميل"); return; }

                dt6.Clear();
                dt6 = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
                if (cmb_Notice.Text == "لة")
                {
                    decimal mno = Convert.ToDecimal(dt6.Rows[0][1]) + Convert.ToDecimal(txt_Amount.Text);
                    s.Update_SupplierTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                    s.Add_SuppliersStatementAccount(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDecimal(txt_Amount.Text),
                      0 , "إشعار إضافة رصيد لحساب المورد عن طريق الموظف   " + " " + Program.salesman, dateTimePicker1.Value, mno);
                }
                if (cmb_Notice.Text == "علية")
                {

                    decimal mno = Convert.ToDecimal(dt6.Rows[0][1]) - Convert.ToDecimal(txt_Amount.Text);
                    s.Update_SupplierTotalMoney(Convert.ToInt32(comboBox1.SelectedValue), mno);
                    s.Add_SuppliersStatementAccount(Convert.ToInt32(comboBox1.SelectedValue),0, Convert.ToDecimal(txt_Amount.Text),
                            "إشعار إضافه رصيد على المورد عن طريق الموظف  " + " " + Program.salesman, dateTimePicker1.Value, mno);
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
    }
}