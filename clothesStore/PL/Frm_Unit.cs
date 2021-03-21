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
    public partial class Frm_Unit : Form
    {
        unit U = new unit();
        public Frm_Unit()
        {
            InitializeComponent();
            dataGridViewPR.DataSource = U.Select_Unit();
            btn_update.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text == "")
                {
                    MessageBox.Show("لا بد من كتابة إسم التصنيف");
                    txt_name.Focus();
                    return;
                }
                else
                {
                    U.Add_Unit(txt_name.Text);
                    MessageBox.Show("تم الحفظ بنجاح");
                    txt_name.Clear();
                    dataGridViewPR.DataSource = U.Select_Unit();
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
                if (txt_name.Text == "")
                {
                    MessageBox.Show("لا بد من كتابة إسم التصنيف");
                    txt_name.Focus();
                    return;
                }
                if (MessageBox.Show("هل تريد تعديل التصنيف", "تعديل التصنيف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    U.Update_Unit(Convert.ToInt32(dataGridViewPR.CurrentRow.Cells[0].Value), txt_name.Text);
                    MessageBox.Show("تم التعديل بنجاح");
                    dataGridViewPR.DataSource = U.Select_Unit();

                }
                else
                {
                    MessageBox.Show("تم إلغاء التعديل");
                    dataGridViewPR.DataSource = U.Select_Unit();

                }
                txt_name.Clear();
                btn_add.Enabled = true;
                btn_update.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewPR_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPR.Rows.Count > 0)
                {
                    txt_name.Text = dataGridViewPR.CurrentRow.Cells[1].Value.ToString();
                    btn_add.Enabled = false;
                    btn_update.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
