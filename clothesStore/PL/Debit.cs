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
    public partial class Debit : Form
    {
        Customer c = new Customer ();
        public Debit()
        {
            InitializeComponent();
            gridControl1.DataSource = c.SelectDepit();
            calc();
        }
        void calc()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount ; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(row[2].ToString());              
            }
            txt_reb7h.Text = Math.Round(total, 2).ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Debit_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }
    }
}
