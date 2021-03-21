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
    public partial class Frm_Customer : Form
    {
        Customer cm = new Customer();
        Order o = new Order();
        DataTable dt = new DataTable();
        public Frm_Customer()
        {
           


            InitializeComponent();
        
            dataGridView1.DataSource = cm.SelectCustomer();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            btn_new.Hide();
            btn_save.Show();
            btn_delete.Hide();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {    
                 if(txt_name.Text=="")
                {
                    MessageBox.Show("يرجي التاكد من اسم العميل");
                    return;
                }
                else
                {                 
                    cm.addCustomer(txt_name.Text, txt_address.Text, txt_phone.Text);
                    dt.Clear();
                    dt = cm.Select_IdCustomer();
                    Txt_Id.Text = dt.Rows[0][0].ToString();
                    cm.Add_CustomerBalanceAccount(Convert.ToInt32(Txt_Id.Text));
                    MessageBox.Show("تم اضافه العميل بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clear();
                    dataGridView1.DataSource = cm.SelectCustomer();

                    Txt_Id.Text = cm.Select_IdCustomer().ToString();
                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Frm_Customer_Load(object sender, EventArgs e)
        {
        }
        void clear()
        {
            txt_phone.Text = "";
            txt_name.Text = "";
            txt_address.Text = "";
        }

        //private void btn_delete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("هل تريد حذف العميل", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //        {
        //            Customer cm = new Customer();
        //            cm.DeleteCustomer(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        //            MessageBox.Show("تم مسح العميل بنجاح", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.None);
        //            dataGridView1.DataSource = cm.SelectCustomer();
        //            clear();
        //            btn_new.Hide();
        //            btn_save.Show();
        //            btn_update.Enabled = false;
        //            btn_delete.Enabled = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("تم الغاء عمليه الحذف", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.None);
        //            clear();
        //            btn_new.Hide();
        //            btn_save.Show();
        //            btn_update.Enabled = false;
        //            btn_delete.Enabled = false;
        //        }

        //        Order o = new Order();

        //    OrderSales.getmain.comboBox1.DataSource = o.SelectCompoCustomer();

        //        OrderSales.getmain.comboBox1.DisplayMember = "Name";
        //        OrderSales.getmain.comboBox1.ValueMember = "ID_Cust";

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                Txt_Id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_address.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                btn_save.Hide();
                btn_new.Show();
                btn_delete.Enabled = true;
                btn_update.Enabled = true;

            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource=  cm.SearchCustomer(txt_search.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            btn_save.Show();
            btn_new.Hide();
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
            Txt_Id.Text = cm.Select_IdCustomer().ToString();
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {

             
                 if (txt_name.Text == "")
                {
                    MessageBox.Show("يرجي التاكد من اسم العميل");
                }



                else if (MessageBox.Show("هل تريد تعديل بيانات العميل", "عمليه التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    cm.UpdateCustomer(txt_name.Text, txt_address.Text, txt_phone.Text, int.Parse(Txt_Id.Text));
                    MessageBox.Show("تم تعديل بيانات العميل بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    MessageBox.Show("لم يتم تعديل بيانات العميل ", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                }

                dataGridView1.DataSource = cm.SelectCustomer();
                clear();
                btn_new.Hide();
                btn_save.Show();
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
                Txt_Id.Text = cm.Select_IdCustomer().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
