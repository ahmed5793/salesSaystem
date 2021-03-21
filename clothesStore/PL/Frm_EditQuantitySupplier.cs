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
    public partial class Frm_EditQuantitySupplier : Form
    {
        DataTable dt = new DataTable();
        public Frm_EditQuantitySupplier()
        {
            InitializeComponent();
            textBox1.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

      
            try
            {
                if (txt_prise.Text == "" || txt_prise.Text == "0") { MessageBox.Show("لا بد من تحديد السعر"); return; }
                if (Txt_Quantity.Text == "") { MessageBox.Show("لا بد من تحديد الكمية"); return; }
                if (Txt_Quantity.Text == "0") { MessageBox.Show("لا بد ان تكون الكمية الكبر من الصفر "); return; }
                if (Txt_DisCount.Text == "") { Txt_DisCount.Text = "0"; }
                else
                {
                   this.Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txt_prise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && txt_prise.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Txt_DisCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && Txt_DisCount.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Txt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && Txt_Quantity.Text.ToString().IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txt_prise_Leave(object sender, EventArgs e)
        {
            if (txt_prise.Text == "")
            {
                txt_prise.Text = "0";
            }
        }

        private void Txt_DisCount_Leave(object sender, EventArgs e)
        {

            if (Txt_DisCount.Text == "")
            {
                Txt_DisCount.Text = "0";
            }
        }

        private void Txt_Quantity_Leave(object sender, EventArgs e)
        {
            if (Txt_Quantity.Text == "")
            {
                Txt_Quantity.Text = "0";
            }
        }

        private void txt_prise_Click(object sender, EventArgs e)
        {
            txt_prise.SelectAll();
        }

        private void Txt_DisCount_Click(object sender, EventArgs e)
        {
            Txt_DisCount.SelectAll();

        }

        private void Txt_Quantity_Click(object sender, EventArgs e)
        {
            Txt_Quantity.SelectAll();
        }
    }
}
