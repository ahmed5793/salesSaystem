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
    public partial class Frm_ReportTransfairProduct : Form
    {
        Proudect p = new Proudect();
        DataTable dt = new DataTable();
        public Frm_ReportTransfairProduct()
        {
            InitializeComponent();
            gridControl1.DataSource = p.Report_ProductTransfair();
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = p.SearchReport_ProductTransfair(DateFrom.Value , DateTo.Value);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
