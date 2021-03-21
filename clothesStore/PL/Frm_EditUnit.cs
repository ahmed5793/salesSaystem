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
    public partial class Frm_EditUnit : Form
    {
        Frm_Sales Frm_S = new Frm_Sales();
        Proudect p = new Proudect();
        DataTable dt2 = new DataTable();
        Store S = new Store();
        public Frm_EditUnit()
        {
            InitializeComponent();
            textBox1.Hide();
        }
        private void cmb_Stock_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //dt.Clear();
            //dt = p.Select_PriceUnitProduct(Convert.ToInt32(textBox1.Text), Convert.ToInt32(cmb_Unit.SelectedValue));
            //dt2.Clear();
            //dt2 = S.Select_ProductQuntity(Convert.ToInt32(textBox1.Text), Convert.ToInt32(Frm_S.Cmb_Store.SelectedValue));

            dt2.Clear();
            dt2 = p.selectListProudect(Convert.ToInt32(textBox1.Text));

            try
            {

                if (txt_prise.Text=="" || txt_prise.Text=="0"){MessageBox.Show("لا بد من تحديد السعر");return;}
                if (Txt_Quantity.Text==""){MessageBox.Show("لا بد من تحديد الكمية");return;}
                if (Txt_Quantity.Text=="0"){MessageBox.Show("لا بد ان تكون الكمية الكبر من الصفر ");return;}
                if (Txt_DisCount.Text==""){ Txt_DisCount.Text = "0"; }
                if (txt_prise.Text!="" && Txt_Quantity.Text!="" && Txt_DisCount.Text!="")
                {
                    if (Convert.ToDecimal(Txt_Quantity.Text) > (Convert.ToDecimal(dt2.Rows[0][4])))
                    {
                        MessageBox.Show("الكمية المدخلة اكبر من الكميةالحالية الموجوده ");
                        Txt_Quantity.Focus();
                        return;
                    }
                    DataTable dt3 = new DataTable();
                    dt3.Clear();
                    dt3 = p.SelectQuantityMinmun(Convert.ToInt32(textBox1.Text));
                    if (dt3.Rows.Count > 0)
                    {
                        MessageBox.Show("عزيزيى المستخدم يرجي العلم بان هذا الصنف وصل للحد الادني", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_EditUnit_Load(object sender, EventArgs e)
        {
            //if (Frm_S.DgvSale.Rows.Count > 0 && Frm_S.DgvSale.SelectedRows.Count > 0)
            //{
            //    cmb_Unit.DataSource = p.Select_UnitProduct(Convert.ToInt32(Frm_S.DgvSale.CurrentRow.Cells[0].Value));
            //    cmb_Unit.DisplayMember = "Unit_Name";
            //    cmb_Unit.ValueMember = "Id_Unit";
            //    cmb_Unit.Text = Frm_S.DgvSale.CurrentRow.Cells[3].Value.ToString();
            //    Txt_Quantity.Text = Frm_S.DgvSale.CurrentRow.Cells[5].Value.ToString();
            //    Txt_DisCount.Text = Frm_S.DgvSale.CurrentRow.Cells[7].Value.ToString();
            //}
        }
        DataTable dt = new DataTable();
        private void cmb_Unit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    dt.Clear();
            //    dt = p.Select_PriceUnitProduct(Convert.ToInt32(textBox1.Text), Convert.ToInt32(cmb_Unit.SelectedValue));
            //    if (cmb_Unit.Text != "")
            //    {
            //        txt_prise.Text = dt.Rows[0][0].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
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
            if (txt_prise.Text=="")
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
