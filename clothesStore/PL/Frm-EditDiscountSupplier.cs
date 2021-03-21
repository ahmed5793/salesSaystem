using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothesStore.PL
{
    public partial class Frm_EditDiscountSupplier : Form
    {
        public Frm_EditDiscountSupplier()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != string.Empty && textBox1.Text != "0")
                {
                    Form2.getmain.dataGridView1.CurrentRow.Cells[5].Value = textBox1.Text;
                    Form2.getmain.calcalutordirect();
                    Form2.getmain.totaldirect();
                    Form2.getmain.totalinvoicesup();
                    Form2.getmain.pay();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("يرجى تحديد مبلغ الخمم");
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox1.Text != "0")
            {
                Form2.getmain.dataGridView1.CurrentRow.Cells[5].Value = textBox1.Text;
                Form2.getmain.calcalutordirect();
                Form2.getmain.totaldirect();
                Form2.getmain.totalinvoicesup();
                Form2.getmain.pay();
                this.Close();
            }
            else
            {
                MessageBox.Show("يرجى تحديد مبلغ الخمم");
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&& e.KeyChar!=8&&e.KeyChar!= Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
            else if(e.KeyChar=='.'&& textBox1.Text.ToString().IndexOf('.')>-1)
            {
                e.Handled = true;
            }
        }
    }
}
