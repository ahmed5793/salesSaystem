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
    public partial class Frm_SearchSupplierOrder : Form
    {
        Suppliers s = new Suppliers();
        public Frm_SearchSupplierOrder()
        {
            InitializeComponent();
            Cmb_Customer.DataSource = s.CompoBox();
            Cmb_Customer.DisplayMember = "Name";
            Cmb_Customer.ValueMember = "Sup_id";
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            this.Close();
        }

        private void Cmb_Customer_Leave(object sender, EventArgs e)
        {
            DataTable dt5 = new DataTable();
            try
            {
                dt5.Clear();
                dt5 = s.VildateID_Supplirs(Convert.ToInt32(Cmb_Customer.SelectedValue));
                if (dt5.Rows.Count == 0 && Cmb_Customer.Text!="")
                {
                    MessageBox.Show("إسم المورد غير موجود فى قائمة الموردين");
                    Cmb_Customer.Focus();
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void Cmb_Customer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Customer.Text != "")
                {
                    dataGridView1.DataSource = s.Select_SupplierInformationForSupplier(Convert.ToInt32(Cmb_Customer.SelectedValue));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmb_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Cmb_Customer.Text != "")
                {
                    dataGridView1.DataSource = s.Select_SupplierInformationForSupplier(Convert.ToInt32(Cmb_Customer.SelectedValue));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
