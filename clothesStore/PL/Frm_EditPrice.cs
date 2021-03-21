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
    public partial class Frm_EditPrice : Form
    {
       

     
        public Frm_EditPrice()
        {
           
            InitializeComponent();
       
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {

          
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txt_prise.Clear();
            this.Close();
        }

        private void Frm_EditPrice_Load(object sender, EventArgs e)
        {
          
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_prise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Close();


            }
        }

        private void Txt_prise_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
