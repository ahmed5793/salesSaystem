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
    public partial class Form_suppliermanagement : Form
    {
        private static Form_suppliermanagement farm;
        static void STATUESCllosed(object sender, FormClosedEventArgs e)
        {
            farm = null;
        }
        public static Form_suppliermanagement getmain
        {
            get
            {
                if (farm == null)
                {
                    farm = new Form_suppliermanagement();
                    farm.FormClosed += new FormClosedEventHandler(STATUESCllosed);
                }
                return farm;
            }
        }
        Suppliers s = new Suppliers();
        Store Store = new Store();
        public Form_suppliermanagement()
        {
            InitializeComponent();
            if (farm == null)
            {
                farm = this;
            }
            gridControl1.DataSource = s.suppliermanagement();
            calc();
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
        }
        

        void calc()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow r = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(r[3].ToString()) ;
            }
            textBox2.Text = Math.Round(total,2).ToString();
        }

        
        private void Btn_update_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount>0 )
            {
                Frm_supplierDetails fsu = new Frm_supplierDetails();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                dt3.Clear();
                dt3 = s.reportsupplier(Convert.ToInt32(gridView1.GetFocusedRowCellValue("رقم الفاتورة")));
                foreach (DataRow item in dt3.Rows)
                {
                    fsu.txt_num.Text = item[0].ToString();
                    fsu.txt_name.Text = item[1].ToString();
                    fsu.txt_date.Text = item[3].ToString();
                    fsu.txt_note.Text = item[4].ToString();
                    fsu.txt_sales.Text = item[5].ToString();
                    fsu.txt_invo.Text = item[6].ToString();
                    fsu.txt_pay.Text = item[7].ToString();
                    fsu.txt_mark.Text = item[8].ToString();
                }
                dt4.Clear();
                dt4 = s.reportsupplierprod(Convert.ToInt32(gridView1.GetFocusedRowCellValue("رقم الفاتورة")));
                fsu.dataGridView1.DataSource = dt4;
                fsu.ShowDialog();
            }
            else
            {
                MessageBox.Show("لا يوجد فواتير لعرضها");
            }
      


            //dt4 = s.reportsupplierprod(Convert.ToInt32(dataGridViewList.CurrentRow.Cells[0].Value));
            //Frm_supplierDetails.getmain.dataGridView1.DataSource = dt4;
            //dt3 = s.reportsupplier(Convert.ToInt32(dataGridViewList.CurrentRow.Cells[0].Value));

            //foreach (DataRow item in dt3.Rows)
            //{

            //    Frm_supplierDetails.getmain.txt_num.Text = item[0].ToString();
            //    Frm_supplierDetails.getmain.txt_name.Text = item[1].ToString();
            //    Frm_supplierDetails.getmain.txt_date.Text = item[3].ToString();
            //    Frm_supplierDetails.getmain.txt_note.Text = item[4].ToString();
            //    Frm_supplierDetails.getmain.txt_sales.Text = item[5].ToString();
            //    Frm_supplierDetails.getmain.txt_invo.Text = item[14].ToString();
            //    Frm_supplierDetails.getmain.txt_pay.Text = item[15].ToString();
            //    Frm_supplierDetails.getmain.txt_mark.Text = item[16].ToString();
            //}

           
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt = s.SearchsuppliermanagementSystem(DateFrom.Value, DateTo.Value);
                gridControl1.DataSource = dt;
                calc();          
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
