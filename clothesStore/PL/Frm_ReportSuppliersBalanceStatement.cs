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
    public partial class Frm_ReportSuppliersBalanceStatement : DevExpress.XtraEditors.XtraForm
    {
        Suppliers s = new Suppliers();
        DataTable dt4 = new DataTable();
        void ComboSupplier()
        {
            comboBox1.DataSource = s.CompoBoxSuppliers();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Sup_id";
            comboBox1.SelectedIndex = -1;
        }
        public Frm_ReportSuppliersBalanceStatement()
        {
            InitializeComponent();
            ComboSupplier();
            gridControl1.DataSource = s.SelectReport_SupplierAccountStatement(Convert.ToInt32(comboBox1.SelectedValue));
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker2.Text = DateTime.Now.ToShortDateString();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            dt4.Clear();
            if (comboBox1.Text != "")
            {
                dt4 = s.VildateSuppliers(Convert.ToInt32(comboBox1.SelectedValue));
                if (dt4.Rows.Count == 0)
                {
                    MessageBox.Show("اسم المورد الذى قمت باادخالة غير مسجل ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                gridControl1.DataSource = s.Report_SupplierAccountStatement(Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value,dateTimePicker2.Value);

                dt4.Clear();
                dt4 = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
                textEdit1.Text = dt4.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {

            gridControl1.ShowRibbonPrintPreview();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = s.SelectReport_SupplierAccountStatement(Convert.ToInt32(comboBox1.SelectedValue));
                dt4.Clear();
                dt4 = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
                textEdit1.Text = dt4.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                gridControl1.DataSource = s.SelectReport_SupplierAccountStatement(Convert.ToInt32(comboBox1.SelectedValue));
                dt4.Clear();
                dt4 = s.select_SupplierBalance(Convert.ToInt32(comboBox1.SelectedValue));
                textEdit1.Text = dt4.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message) ;
                MessageBox.Show(ex.StackTrace) ;
            }
        }
    }
}