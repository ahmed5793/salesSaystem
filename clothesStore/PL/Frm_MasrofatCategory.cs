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
    public partial class Frm_MasrofatCategory : Form
    {
        Masrofat M = new Masrofat();
        public Frm_MasrofatCategory()
        {
            InitializeComponent();
            dataGridView1.DataSource = M.Select_MasrofatCategory();
            btn_update.Enabled = false;
        }

        private void Frm_MasrofatCategory_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_amount.Text=="")
                {
                    MessageBox.Show("لا بد من كتابة نوع المصروف");
                    return;
                }
                M.Add_MAsrofCategory(txt_amount.Text);
                MessageBox.Show("تم حفظ المصروف بنجاح");
                txt_amount.Clear();
                dataGridView1.DataSource = M.Select_MasrofatCategory();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message) ;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count>0)
                {
                    txt_amount.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    btn_update.Enabled = true;
                    btn_save.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد التعديل", " عميل التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (txt_amount.Text!="")
                    {
                        M.Update_MAsrofCategory(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), txt_amount.Text);
                        MessageBox.Show("تم التعديل بنجاح");
                    }
                    else
                    {
                        MessageBox.Show("لا بد من كتابة نوع المصروف");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("تم إلغاء التعديل");

                }
                txt_amount.Clear();
                dataGridView1.DataSource = M.Select_MasrofatCategory();
                btn_update.Enabled = false;
                btn_save.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
