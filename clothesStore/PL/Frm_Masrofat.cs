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
using System.Globalization;

namespace clothesStore.PL
{
    public partial class Frm_Masrofat : Form
    {
        Masrofat m = new Masrofat();
        Stock st = new Stock();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();

        public Frm_Masrofat()
        {
            InitializeComponent();

            cmb_Stock.DataSource = st.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";

            Cmb_MasrofatCategory.DataSource = m.Select_MasrofatCategory();
            Cmb_MasrofatCategory.DisplayMember = "Mastof_Name";
            Cmb_MasrofatCategory.ValueMember = "Id_MAsrof";

            dataGridView1.DataSource = m.Select_masrofat();
            btn_new.Hide();
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
            btn_update.Hide();
       

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            try {
                if (Cmb_MasrofatCategory.Text == "")
                {
                    MessageBox.Show("تاكد من  نوع المصروف");
                    return;
                }
                 if (txt_amount.Text == "" || txt_amount.Text == "0")
                {
                    MessageBox.Show("لابد ابن يكون مبلغ المصروف اكبر من الصفر");

                    return;
                }

                if (cmb_Stock.Text == "")
                {
                    MessageBox.Show("لا بد من تحديد خزنة");
                    return;

                }
                dt4 = st.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));

              
                

                    if (Convert.ToDecimal(txt_amount.Text) > Convert.ToDecimal(dt4.Rows[0][0]))
                    {
                        MessageBox.Show("رصيد الخزنة الحالى غير كافى لسحب هذا المبلغ");
                        return;
                    }
                
                else
                {
                    m.Add_masrof(Convert.ToInt32(Cmb_MasrofatCategory.SelectedValue), Convert.ToDecimal(txt_amount.Text),
                        dateTimePicker1.Value, txt_notes.Text ,Convert.ToInt32(cmb_Stock.SelectedValue) , Program.salesman);

                    st.Add_StockPull(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_amount.Text), dateTimePicker1.Value
                        ,Program.salesman, "رصيد مسحوب من الخزنة", "مصروف"+" "+ Cmb_MasrofatCategory.Text );
                    Console.Beep();
                    MessageBox.Show("تم تسجيل المصروف بنجاح");
                    dataGridView1.DataSource = m.Select_masrofat();
                    txt_amount.Clear();
                    txt_notes.Clear();


                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        if (Cmb_MasrofatCategory.Text == "")
        //        {
        //            MessageBox.Show("تاكد من كتابة نوع المصروف");
        //        }
        //        else if (txt_amount.Text == "")
        //        {
        //            MessageBox.Show("تاكد من كتابة مبلغ المصروف");

        //        }
        //        dt4 = st.Select_moneyStock(Convert.ToInt32(cmb_Stock.SelectedValue));

        //        if (Convert.ToDecimal(txt_amount.Text) > Convert.ToDecimal(dt4.Rows[0][0]))
        //        {
        //            MessageBox.Show("رصيد الخزنة الحالى غير كافى لسحب هذا المبلغ");
        //            return;
        //        }

        //        if (MessageBox.Show("هل تريد التعديل", " عميل التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)

        //            {
        //            dt5.Clear();
        //            dt5 = m.Select_MoneyMasrof(Convert.ToInt32(Txt_Count.Text));
                    
        //            st.add_insertStock(Convert.ToInt32(dt5.Rows[0][2]),Convert.ToDecimal(dt5.Rows[0][1]),dateTimePicker1.Value, 
        //                Program.salesman, "رصيد مضاف للخزنة","تعديل فى المصروفات");

        //            st.Add_StockPull(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_amount.Text), dateTimePicker1.Value
        //                , Program.salesman, "رصيد مسحوب من الخزنة", " تعديل مصروف "+" "+ Cmb_MasrofatCategory.Text);

        //            m.Update_masrof(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),  Convert.ToDecimal(txt_amount.Text),
        //                dateTimePicker1.Value, txt_notes.Text, Convert.ToInt32(cmb_Stock.SelectedValue), Program.salesman,Convert.ToInt32(Txt_Count.Text));                  
        //            MessageBox.Show("تم تعديل المصروف بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                      
        //        }
        //        else
        //        {
        //          MessageBox.Show("تم إلغاء التعديل");
        //        }
        //        dataGridView1.DataSource = m.Select_masrofat();
        //        txt_amount.Clear();
        //        txt_notes.Clear();
        //        Txt_Count.Clear();
        //        btn_new.Hide();
        //        btn_save.Show();
        //        btn_delete.Enabled = false;
        //        btn_update.Enabled = false;              
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //        MessageBox.Show(ex.StackTrace);
        //    }

        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف هذا المصروف ","حذف المصروف",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    //dt5.Clear();
                    //dt5 = m.Select_moneyStock(Convert.ToInt32(Txt_Count.Text));

                    st.add_insertStock(Convert.ToInt32(cmb_Stock.SelectedValue), Convert.ToDecimal(txt_amount.Text), dateTimePicker1.Value,
                     Program.salesman, "رصيد مضاف للخزنة", "مسح  مصروف"+""+ Cmb_MasrofatCategory.Text);

                    m.Delete_masrof(Convert.ToInt32(Txt_Count.Text));

                    MessageBox.Show("تم مسح المصروف بنجاح");                                
                }
                else
                {
                    MessageBox.Show("تم إلغاء المسح");
                }
                dataGridView1.DataSource = m.Select_masrofat();
                txt_amount.Clear();
                txt_notes.Clear();
                Txt_Count.Clear();
                btn_new.Hide();
                btn_save.Show();
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
                Cmb_MasrofatCategory.Enabled = true;
                cmb_Stock.Enabled = true;
                txt_amount.Enabled = true;

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cmb_MasrofatCategory.Enabled = false;
                cmb_Stock.Enabled = false;
                txt_amount.Enabled = false;
                Cmb_MasrofatCategory.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_amount.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_notes.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                cmb_Stock.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                Txt_Count.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
               
                btn_new.Show();
                btn_save.Hide();
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                cmb_Stock.Enabled = true;
                Cmb_MasrofatCategory.Enabled = true;            
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            txt_amount.Clear();
            txt_notes.Clear();
            Txt_Count.Clear();
            btn_new.Hide();
            btn_save.Show();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
           
        }

        private void Txt_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_amount.Text=="")
            {
                txt_amount.Text = "0";
            }
        }

        private void Txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='.' && txt_amount.Text.ToString().IndexOf('.')>-1 )
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar!= 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void Txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = m.Searech_masrofat(txt_search.Text);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void Frm_Masrofat_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_MasrofatCategory frm = new Frm_MasrofatCategory();
          
                frm.ShowDialog();
                Cmb_MasrofatCategory.DataSource = m.Select_MasrofatCategory();
         
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
