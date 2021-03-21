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
    public partial class Frm_SearchCustomerOrder : Form
    {
        Order o = new Order();
        Customer Cm = new Customer();
        DataTable dt2 = new DataTable();
        public Frm_SearchCustomerOrder()
        {
            InitializeComponent();
            ComboCustomer();
        }
        void ComboCustomer()
        {
            Cmb_Customer.DataSource = o.SelectCustName();
            Cmb_Customer.DisplayMember = "Name";
            Cmb_Customer.ValueMember = "ID_Cust";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            this.Close();
        }

        private void Cmb_Customer_Leave(object sender, EventArgs e)
        {
            dt2.Clear();
            if (Cmb_Customer.Text != "")
            {
                dt2 = Cm.VildateCustomer(Convert.ToInt32(Cmb_Customer.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم العميل الذى قمت باادخالة غير متسجل ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Cmb_Customer.SelectAll();
                    Cmb_Customer.Focus();
                    return;
                }
            }
        }

        private void Cmb_Customer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Customer.Text != "")
                {
                    dataGridView1.DataSource = Cm.Select_OrderForCustomer(Convert.ToInt32(Cmb_Customer.SelectedValue));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
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
                    dataGridView1.DataSource = Cm.Select_OrderForCustomer(Convert.ToInt32(Cmb_Customer.SelectedValue));
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
