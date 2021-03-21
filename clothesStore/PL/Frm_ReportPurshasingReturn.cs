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
    public partial class Frm_ReportPurshasingReturn : Form
    {
        Suppliers s = new Suppliers();
        Store Store = new Store();
        public Frm_ReportPurshasingReturn()
        {
            InitializeComponent();
            gridControl1.DataSource = s.Report_ReturnPurshasing();
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
        }
       

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt = s.Search_ReportReturnPurshasing(DateFrom.Value, DateTo.Value);
             
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
