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
    public partial class FrmSalesReb7 : Form
    {
        Order o = new Order();
        Store Store = new Store();
        public FrmSalesReb7()
        {
            InitializeComponent();
            gridControl1.DataSource = o.SelectSalesReb7();
       
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
            calctotalselling();
            CalcTotalPurshacing();
            TotalReb7();
        }
    
        void calctotalselling()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(row[5].ToString());
            }
            txt_TotalSelling.Text = Math.Round(total,2).ToString();
        }
        void CalcTotalPurshacing()
        {
            decimal totalPUr = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow r = gridView1.GetDataRow(i);
                totalPUr += Convert.ToDecimal(r[6].ToString());
            }
            txt_TotalPurshacing.Text = Math.Round(totalPUr, 2).ToString();
        }

        void TotalReb7()
        {
            if (txt_TotalPurshacing.Text!=string.Empty && txt_TotalSelling.Text!=string.Empty)
            {
                decimal Reb7 = Convert.ToDecimal(txt_TotalSelling.Text) - Convert.ToDecimal(txt_TotalPurshacing.Text);
                txt_reb7h.Text = Reb7.ToString();
            }
        }


        private void FrmSalesReb7_Load(object sender, EventArgs e)
        {

        }

        private void Txt_reb7h_KeyUp(object sender, KeyEventArgs e)
        {
            TotalReb7();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        DataTable dt = new DataTable();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                    dt.Clear();
                    dt = o.SearchSalesReb7(DateFrom.Value, DateTo.Value);
                    gridControl1.DataSource = dt;
                    calctotalselling();
                    CalcTotalPurshacing();
                    TotalReb7();
                
                //if (Rdb_oneStore.Checked==true )
                //{
                //    dt.Clear();
                //    dt = o.SearchSalesReb7ForOneStore(Convert.ToInt32(Cmb_Store.SelectedValue),DateFrom.Value, DateTo.Value);
                //    gridControl1.DataSource = dt;
                //    calctotalselling();
                //    CalcTotalPurshacing();
                //    TotalReb7();
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Rdb_AllMasrofat_CheckedChanged(object sender, EventArgs e)
        {
            //if (Rdb_AllStore.Checked==true)
            //{
            //    Cmb_Store.Enabled = false;
            //    gridControl1.DataSource = o.SelectSalesReb7();
            //}
            //else
            //{
            //    Cmb_Store.Enabled = true;
            //    gridControl1.DataSource = o.SelectSalesReb7foroneStore(Convert.ToInt32(Cmb_Store.SelectedValue));

            //}
            //calctotalselling();
            //CalcTotalPurshacing();
            //TotalReb7();
        }

        private void Rdb_oneStore_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (Rdb_oneStore.Checked==true)
            //{
            //    gridControl1.DataSource = o.SelectSalesReb7foroneStore(Convert.ToInt32(Cmb_Store.SelectedValue));
            //    calctotalselling();
            //    CalcTotalPurshacing();
            //    TotalReb7();
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DateTo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
