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
    public partial class Frm_ReportAllCustomer : Form
    {
        Customer C = new Customer();
        public Frm_ReportAllCustomer()
        {
            InitializeComponent();
            gridControl1.DataSource = C.Report_AllCustomer();
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    gridControl1.ShowRibbonPrintPreview();
                }
                else
                {
                    MessageBox.Show("لا يوجد داتا للطباعة");
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
