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
    public partial class Form_ReportInsertStock : Form
    {

        Stock s = new Stock();
        DataTable dt = new DataTable();
        public Form_ReportInsertStock()
        {
            InitializeComponent();
            Stock();
            gridControl1.DataSource = s.Insert_Stock(Convert.ToInt32(cmb_Stock.SelectedValue));
            calc();
            DateFrom.Text = DateTime.Now.ToShortDateString();
            DateTo.Text = DateTime.Now.ToShortDateString();
        }
        void Stock()
        {
            cmb_Stock.DataSource = s.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
        }
    private void Btn_search_Click(object sender, EventArgs e)
        {
           
        }
        void calc()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow r = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(r[1].ToString());

            }
            textBox1.Text = Math.Round(total, 2).ToString();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox1.Text = "0";
            }
        }

        private void Form_ReportInsertStock_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dt = s.Search_Insert_Stock(Convert.ToInt32(cmb_Stock.SelectedValue), DateFrom.Value, DateTo.Value);
                gridControl1.DataSource = dt;
                calc();
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            //gridControl1.ShowRibbonPrintPreview();
            gridControl1.ShowPrintPreview();
        }
    }
}
