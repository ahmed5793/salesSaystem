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
    public partial class Frm_ReportPayCustomer : Form
    {
        Customer c = new Customer();
        public Frm_ReportPayCustomer()
        {
            InitializeComponent();
            dataGridViewList.DataSource = c.Report_PayCustomer();
            calculate();
        }
        void calculate()
        {
            decimal total = 0;
            for (int i = 0; i < dataGridViewList.Rows.Count ; i++)
            {

                total += Convert.ToDecimal(dataGridViewList.Rows[i].Cells[2].Value);
            }
            txt_TotalPurshacing.Text = Math.Round(total, 2).ToString();
        }
        private void Frm_ReportPayCustomer_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = c.search_PayCustomer(textBox1.Text);
            dataGridViewList.DataSource = dt;
            calculate();
        }
    }
}
