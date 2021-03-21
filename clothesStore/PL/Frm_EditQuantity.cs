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
    public partial class Frm_EditQuantity : Form
    {
        Frm_TransFairProduct Frm_S = new Frm_TransFairProduct();
        Proudect p = new Proudect();
        DataTable dt2 = new DataTable();
        DataTable dt = new DataTable();
        Store S = new Store();
        public Frm_EditQuantity()
        {
            InitializeComponent();
            textBox1.Hide();
            Txt_numStore.Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Txt_Quantity.Text="1";
            this.Close();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&& e.KeyChar!=8)
            {
                e.Handled = true;
            }
           
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt = p.Select_PriceUnitProduct(Convert.ToInt32(textBox1.Text), Convert.ToInt32(cmb_Unit.SelectedValue));
            dt2.Clear();
            //dt2 = S.Select_ProductQuntity(Convert.ToInt32(textBox1.Text), Convert.ToInt32(Txt_numStore.Text));
            try
            {
                if (Txt_Quantity.Text == "") { MessageBox.Show("لا بد من تحديد الكمية"); return; }
                if (Txt_Quantity.Text == "0") { MessageBox.Show("لا بد ان تكون الكمية الكبر من الصفر "); return; }
                //if (Txt_DisCount.Text==""){MessageBox.Show("لا بد ان تكون الكمية الكبر من الصفر ");return;}
                if ( Txt_Quantity.Text != "" )
                {
                    if (Convert.ToDecimal(Txt_Quantity.Text)/ Convert.ToDecimal(dt.Rows[0][2]) > (Convert.ToDecimal(dt2.Rows[0][0]) ))
                    {
                        MessageBox.Show("الكمية المدخلة اكبر من الكميةالموجود فى المخزن");
                        Txt_Quantity.Focus();
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("لا بد من إستكمال البيانات ");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
    
        private void Frm_EditQuantity_Load(object sender, EventArgs e)
        {
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
