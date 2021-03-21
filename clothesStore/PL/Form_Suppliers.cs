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
    public partial class Form_Suppliers : Form
    {
        Suppliers s = new Suppliers();
        DataTable dt2 = new DataTable();
        public Form_Suppliers()
        {
            InitializeComponent();
            dataGridView1.DataSource = s.SelectSuppliers();
            dataGridView1.Columns[0].Visible = false;
            btn_new.Hide();
            btn_save.Show();
            btn_delete.Hide();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            txt_name.Focus();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txt_name.Text == "")
                {
                    MessageBox.Show("يرجي التاكد من اسم المورد");
                }
                else
                {
                    s.addSuppliers(txt_name.Text, txt_address.Text, txt_phone.Text);
                    dt2.Clear();
                    dt2 = s.Select_LastIdSupplier();
                    s.Add_SupplierTotalMoney(Convert.ToInt32(dt2.Rows[0][0]));
                    MessageBox.Show("تم اضافه المورد بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clear();
                    dataGridView1.DataSource = s.SelectSuppliers();
                    txt_name.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
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
        //        if (MessageBox.Show("هل تريد حذف المورد", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //        {
                
        //            s.DeleteSuppliers(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        //            MessageBox.Show("تم مسح المورد بنجاح", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.None);
        //            dataGridView1.DataSource = s.SelectSuppliers();

        //            clear();
        //            btn_save.Show();
        //            btn_new.Hide();
        //            btn_update.Enabled = false;
        //            btn_delete.Enabled = false;
           

        //            Form2.getmain.comboBox1.DataSource = s.CompoBox();
        //            Form2.getmain.comboBox1.DisplayMember = "Name";
        //            Form2.getmain.comboBox1.ValueMember = "Sup_id";

        //        }

        //        else
        //        {
        //            MessageBox.Show("تم الغاء عمليه الحذف", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.None);
        //            clear();
        //            btn_save.Show();
        //            btn_new.Hide();
        //            btn_update.Enabled = false;
        //            btn_delete.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Suppliers s = new Suppliers();
              
                if (txt_name.Text == "")
                {
                    MessageBox.Show("يرجي التاكد من اسم المورد");
                }
                else if (MessageBox.Show("هل تريد تعديل بيانات المورد", "عمليه التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    s.UpdateSuppliers(txt_name.Text, txt_address.Text, txt_phone.Text, int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("تم تعديل بيانات العميل بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    dataGridView1.DataSource = s.SelectSuppliers();
                    clear();
                    btn_save.Show();
                    btn_new.Hide();
                    btn_update.Enabled = false;
                    btn_delete.Enabled = false;
                    txt_name.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = s.SearchSuppliers(txt_search.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            btn_new.Hide();
            btn_save.Show();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            clear(); 
            txt_name.Focus();


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_address.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                btn_save.Hide();
                btn_new.Show();
                btn_update.Enabled = true;
                txt_name.Focus();
            }
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
