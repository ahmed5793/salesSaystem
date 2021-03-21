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
using clothesStore.Rpt;

namespace clothesStore.PL
{
    public partial class Form_OrderManagment : Form
    {
        DataTable dt = new DataTable();
        Order o = new Order();
        Store Store = new Store();
        void calc()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(row[3].ToString());
            }
            textBox2.Text = Math.Round(total, 2).ToString();
        }
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
        public Form_OrderManagment()
        {
            InitializeComponent();
            //ComboStore();
            gridControl1.DataSource= o.SelectOrderManagment();
            calc();
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
        }

        private void Form_OrderManagment_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt51 = new DataTable();
                if (gridView1.RowCount>0)                {

                    Rpt_PrintOrder r = new Rpt_PrintOrder();
                    FrmSingleReport sr = new FrmSingleReport();
                    sr.crystalReportViewer1.RefreshReport();
                    //r.SetDatabaseLogon("", "", ".", "FEEDStore");
                    //r.SetParameterValue("@ID", int.Parse(dataGridViewList.CurrentRow.Cells[0].Value.ToString()));
                    //sr.crystalReportViewer1.ReportSource = r;
                    //sr.Show();
                    dt51.Clear();
                    dt51 = o.RportOrder(Convert.ToInt32(gridView1.GetFocusedRowCellValue("رقم الفاتوره")));
                    clothesStore.DAL.DataOrderReport ds = new DAL.DataOrderReport();
                    Rpt.Frm_RptDocumetViewer frm = new Frm_RptDocumetViewer();
                    Rpt_PrintOrder rpts = new Rpt_PrintOrder();
                    frm.documentViewer1.Refresh();
                    ds.Tables["PrintOrder"].Clear();

                    for (int i = 0; i < dt51.Rows.Count; i++)
                    {
                        ds.Tables["PrintOrder"].Rows.Add(dt51.Rows[i][0], dt51.Rows[i][1], dt51.Rows[i][2],
                        dt51.Rows[i][3], dt51.Rows[i][4], dt51.Rows[i][5]
                          , dt51.Rows[i][6], dt51.Rows[i][7], dt51.Rows[i][8],
                         dt51.Rows[i][9], dt51.Rows[i][10], dt51.Rows[i][11], dt51.Rows[i][12]
                         , dt51.Rows[i][13]);
                    }
                    SettingPrint st = new SettingPrint();
                    DataTable tbl = new DataTable();
                    tbl.Clear();
                    tbl = st.SelectSettingPrintOrder();
                    ds.Tables["PrintInformation"].Clear();
                    ds.Tables["PrintInformation"].Rows.Add(tbl.Rows[0][0], tbl.Rows[0][1], tbl.Rows[0][2],
                        tbl.Rows[0][3], tbl.Rows[0][4]);


                    //rpts.SetDatabaseLogon("", "", ".", "EasySystem");
                    rpts.SetDataSource(ds);
                    rpts.SetParameterValue("@ID", Convert.ToInt32(gridView1.GetFocusedRowCellValue("رقم الفاتوره")));

                    frm.documentViewer1.DocumentSource = rpts;

                    System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                    rpts.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;
                    rpts.PrintToPrinter(1, true, 0, 0);


               

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt = o.SearchOrderManagmentSystem(DateFrom.Value, DateTo.Value);
                    gridControl1.DataSource = dt;
                    calc();                  
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
               
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //gridControl1.DataSource = o.SelectOrderManagment(Convert.T);
            //calc();
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //textBox1.Text = gridView1.GetFocusedRowCellValue("رقم الفاتوره").ToString();

           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt51 = new DataTable();
                if (gridView1.RowCount > 0)
                {

                    Rpt_PrintOrder r = new Rpt_PrintOrder();
                    FrmSingleReport sr = new FrmSingleReport();
                    sr.crystalReportViewer1.RefreshReport();
                    //r.SetDatabaseLogon("", "", ".", "FEEDStore");
                    //r.SetParameterValue("@ID", int.Parse(dataGridViewList.CurrentRow.Cells[0].Value.ToString()));
                    //sr.crystalReportViewer1.ReportSource = r;
                    //sr.Show();
                    dt51.Clear();
                    dt51 = o.RportOrder(Convert.ToInt32(gridView1.GetFocusedRowCellValue("رقم الفاتوره")));
                    clothesStore.DAL.DataOrderReport ds = new DAL.DataOrderReport();
                    Rpt.Frm_RptDocumetViewer frm = new Frm_RptDocumetViewer();
                    Rpt_PrintOrder rpts = new Rpt_PrintOrder();
                    frm.documentViewer1.Refresh();
                    ds.Tables["PrintOrder"].Clear();

                    for (int i = 0; i < dt51.Rows.Count; i++)
                    {
                        ds.Tables["PrintOrder"].Rows.Add(dt51.Rows[i][0], dt51.Rows[i][1], dt51.Rows[i][2],
                        dt51.Rows[i][3], dt51.Rows[i][4], dt51.Rows[i][5]
                          , dt51.Rows[i][6], dt51.Rows[i][7], dt51.Rows[i][8],
                         dt51.Rows[i][9], dt51.Rows[i][10], dt51.Rows[i][11], dt51.Rows[i][12]
                         , dt51.Rows[i][13]);
                    }
                    SettingPrint st = new SettingPrint();
                    DataTable tbl = new DataTable();
                    tbl.Clear();
                    tbl = st.SelectSettingPrintOrder();
                    ds.Tables["PrintInformation"].Clear();
                    ds.Tables["PrintInformation"].Rows.Add(tbl.Rows[0][0], tbl.Rows[0][1], tbl.Rows[0][2],
                        tbl.Rows[0][3], tbl.Rows[0][4]);


                    //rpts.SetDatabaseLogon("", "", ".", "EasySystem");
                    rpts.SetDataSource(ds);
                    rpts.SetParameterValue("@ID", Convert.ToInt32(gridView1.GetFocusedRowCellValue("رقم الفاتوره")));

                    frm.documentViewer1.DocumentSource = rpts;

                    //System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                    //rpts.PrintOptions.PrinterName = Properties.Settings.Default.PrinterName;
                    //rpts.PrintToPrinter(1, true, 0, 0);


                    frm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
