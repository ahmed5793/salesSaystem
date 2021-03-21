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
    public partial class Frm_ReportPaySuppliers : Form
    {
        Suppliers s = new Suppliers();
        public Frm_ReportPaySuppliers()
        {
            InitializeComponent();
            dataGridViewList.DataSource = s.Report_PaySupplier();
            calc();
        }

        void calc()
        {
            Decimal total = 0;
            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dataGridViewList.Rows[i].Cells[2].Value);
            }
            txt_TotalPurshacing.Text = Math.Round(total, 2).ToString();
        }

        private void Frm_ReportPaySuppliers_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = s.Search_PaySupplier(textBox1.Text);
            dataGridViewList.DataSource = dt;
            calc();
        }
    }
}
