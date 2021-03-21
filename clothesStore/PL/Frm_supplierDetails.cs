using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using clothesStore.Bl;


namespace clothesStore.PL
{    
    public partial class Frm_supplierDetails : Form
    {
        public Frm_supplierDetails()
        {
            InitializeComponent();
            //Btn_PrintPreview.Hide();
        }
        DataTable dt = new DataTable();
        private void Frm_supplierDetails_Load(object sender, EventArgs e)
        {

        }

        private void Btn_PrintPreview_Click(object sender, EventArgs e)
        {

            //try
            //{


            //    if (dataGridView1.Rows.Count > 0)
            //    {

            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {

            //            DataSet1 ds = new DataSet1();
            //            ds.Clear();
            //            Rpt.CrystalReport2 cr = new Rpt.CrystalReport2();
            //            ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[10].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[10].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString());
            //            cr.SetDataSource(ds);
            //            Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
            //            frm.crystalReportViewer1.ReportSource = cr;
            //            frm.crystalReportViewer1.Refresh();
            //            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
            //            cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
            //            cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value), true, 0, 0);
            //            //frm.ShowDialog();
            //            cr.Close();
            //            frm.Dispose();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("لابد من اختيار صنف واحد على الاقل");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Btn_PrintPreview_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        DataSet1 ds = new DataSet1();
                        //ds.Clear();
                        //Rpt.CrystalReport2 cr = new Rpt.CrystalReport2();
                        //ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[10].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[10].Value.ToString(), dataGridView1.Rows[i].Cells[11].Value.ToString());
                        //cr.SetDataSource(ds);
                        //Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
                        //frm.crystalReportViewer1.ReportSource = cr;
                        //frm.crystalReportViewer1.Refresh();
                        //System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                        //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                        //cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value), true, 0, 0);
                        //frm.ShowDialog();
                        if (Properties.Settings.Default.BarcodeSize == "مقاس كبير ")
                        {

                            Rpt.Rpt_Large_Barcode cr = new Rpt.Rpt_Large_Barcode();
                            ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[8].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[7].Value.ToString());
                            cr.SetDataSource(ds);
                            Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
                            frm.crystalReportViewer1.ReportSource = cr;
                            frm.crystalReportViewer1.Refresh();
                            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                            cr.PrintOptions.PrinterName = Properties.Settings.Default.PrintBarcode;
                            //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                            cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value), true, 0, 0);
                        }
                        else if (Properties.Settings.Default.BarcodeSize == "مقاس وسط ")
                        {

                            Rpt.Rpt_MidBarcode cr = new Rpt.Rpt_MidBarcode();
                            ds.Tables[0].Rows.Add(dataGridView1.Rows[i].Cells[1].Value.ToString(), "*" + dataGridView1.Rows[i].Cells[8].Value.ToString().Trim() + "*", dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[7].Value.ToString());
                            cr.SetDataSource(ds);
                            Rpt.FrmSingleReport frm = new Rpt.FrmSingleReport();
                            frm.crystalReportViewer1.ReportSource = cr;
                            frm.crystalReportViewer1.Refresh();
                            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                            cr.PrintOptions.PrinterName = Properties.Settings.Default.PrintBarcode;
                            //cr.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                            cr.PrintToPrinter(Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value), true, 0, 0);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لابد من اختيار صنف واحد على الاقل");
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
