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
    public partial class Frm_ReportOrderReturn : Form
    {
        Order o = new Order();
        DataTable dt = new DataTable();
        Store Store = new Store();
        public Frm_ReportOrderReturn()
        {
            InitializeComponent();
            gridControl1.DataSource = o.Report_OrderReturn();
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
        }
       
        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = o.Search_ReportOrderReturn(DateFrom.Value, DateTo.Value);
                    gridControl1.DataSource = dt;
              
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

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
