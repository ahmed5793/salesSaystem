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
    public partial class Form_StockTransfair : Form
    {
        Stock s = new Stock();
        DataTable dt = new DataTable();
        public Form_StockTransfair()
        {
            InitializeComponent();

            cmb_StockFrom.DataSource = s.Compo_Stock();
            cmb_StockFrom.DisplayMember = "Treasury_name";
            cmb_StockFrom.ValueMember = "id_Treasury";
            Cmb_StrockTo.DataSource = s.Compo_Stock();
            Cmb_StrockTo.DisplayMember = "Treasury_name";
            Cmb_StrockTo.ValueMember = "id_Treasury";

            dt = s.Select_moneyStock(Convert.ToInt32(cmb_StockFrom.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                txt_CurrentBalance1.Text = dt.Rows[0][0].ToString();
            }
            dt = s.Select_moneyStock(Convert.ToInt32(Cmb_StrockTo.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0][0].ToString();
            }
        }
        void clear()
        {
            txt_addbalance.Clear();
            txt_CurrentBalance1.Text = "0";
            textBox1.Text = "0";
            txt_name.Clear();

            txt_reason.Clear();
        }

        private void Cmb_StockFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
         
                dt = s.Select_moneyStock(Convert.ToInt32(cmb_StockFrom.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                txt_CurrentBalance1.Text = dt.Rows[0][0].ToString();
            }
        }

        private void Cmb_StrockTo_SelectedIndexChanged(object sender, EventArgs e)
        {

            dt = s.Select_moneyStock(Convert.ToInt32(Cmb_StrockTo.SelectedValue));
            if (dt.Rows.Count > 0)
            {

                textBox1.Text = dt.Rows[0][0].ToString();
            }
        }

        private void Txt_addbalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && txt_addbalance.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try

            {
                if (cmb_StockFrom.SelectedValue ==  Cmb_StrockTo.SelectedValue )
                {
                    MessageBox.Show("لا يمكن تحويل رصيد لنفس الخزنة");
                    return;
                }
                if (cmb_StockFrom.Text== "" || Cmb_StrockTo.Text == "")
                {
                    MessageBox.Show("لا بد من وجود خزنة للتحويل");
                    return;
                }
                if (txt_addbalance.Text == "")
                {
                    MessageBox.Show("لا بد من ان يكون التحويل اكبر من الصفر");
                    txt_addbalance.Focus();
                    return;
                }
                else if (txt_name.Text == "")
                {
                    MessageBox.Show("يرجى تحديد إسم ");
                    txt_name.Focus();
                    return;
                }
                else if (Convert.ToDecimal(txt_addbalance.Text) > Convert.ToDecimal(txt_CurrentBalance1.Text))
                {
                    MessageBox.Show("   المبلغ المراد تحويلة اكبر من الرصيد الحالى");
                    txt_addbalance.Focus();
                    return;

                }
                else if (MessageBox.Show("هل تريد حفظ التحويل", "عملية التحويل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    s.Add_StockTransfair(Convert.ToDecimal(txt_addbalance.Text), Date_insert.Value, cmb_StockFrom.SelectedValue.ToString(), Cmb_StrockTo.SelectedValue.ToString(), txt_name.Text, txt_reason.Text);
                    s.add_insertStock(Convert.ToInt32(Cmb_StrockTo.SelectedValue), Convert.ToDecimal(txt_addbalance.Text), Date_insert.Value, txt_name.Text, "رصيد محول من خزنة "+ " "+ cmb_StockFrom.Text, txt_reason.Text);
                    s.Add_StockPull(Convert.ToInt32(cmb_StockFrom.SelectedValue), Convert.ToDecimal(txt_addbalance.Text), Date_insert.Value, txt_name.Text, "تم تحويل رصيد الي خزنة " + " " + Cmb_StrockTo.Text, txt_reason.Text);

                    MessageBox.Show("تم إضافة الرصيد للخزنة المحددة");

                    clear();
                }
                else
                {
                    MessageBox.Show("تم إلغاء التحويل");
                    clear();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form_StockTransfair_Load(object sender, EventArgs e)
        {

        }
    }
}
