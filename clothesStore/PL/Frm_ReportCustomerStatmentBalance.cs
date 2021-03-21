using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using clothesStore.Bl;
namespace clothesStore.PL
{
    public partial class Frm_ReportCustomerStatmentBalance : DevExpress.XtraEditors.XtraForm
    {
        Order o = new Order();
        Customer Cm = new Customer();
        DataTable dt2 = new DataTable();
        DataTable dt51 = new DataTable();

        public Frm_ReportCustomerStatmentBalance()
        {
            InitializeComponent();
            ComboCustomer();
            gridControl1.DataSource = Cm.SelectReport_CustomerAccountStatement(Convert.ToInt32(comboBox1.SelectedValue));
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker2.Text = DateTime.Now.ToShortDateString();
        }
        void ComboCustomer()
        {
            comboBox1.DataSource = o.SelectCustName();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Cust";
            comboBox1.SelectedIndex = -1;
        }

        private void Frm_ReportCustomerStatmentBalance_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            dt2.Clear();
            if (comboBox1.Text != "")
            {
                dt2 = Cm.VildateCustomer(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم العميل الذى قمت باادخالة غير متسجل ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    comboBox1.SelectAll();
                    comboBox1.Focus();
                    return;
                }
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
               
                gridControl1.DataSource = Cm.Report_CustomerAccountStatement(Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value , dateTimePicker2.Value);

                dt51.Clear();
                dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
                textEdit1.Text = dt51.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
               
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0)
            {
                gridControl1.ShowRibbonPrintPreview();
            }
            else
            {
                MessageBox.Show("لا يوجد داتا للطباعة");
            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            gridControl1.DataSource = Cm.SelectReport_CustomerAccountStatement(Convert.ToInt32(comboBox1.SelectedValue));

            dt51.Clear();
            dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
            textEdit1.Text = dt51.Rows[0][1].ToString();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            gridControl1.DataSource = Cm.SelectReport_CustomerAccountStatement(Convert.ToInt32(comboBox1.SelectedValue));

            dt51.Clear();
            dt51 = Cm.Select_CustomerBalance(Convert.ToInt32(comboBox1.SelectedValue));
            textEdit1.Text = dt51.Rows[0][1].ToString();
        }
    }
}