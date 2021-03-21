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
    public partial class FrmAllPurshacing : Form
    {
        Suppliers s = new Suppliers();
        public FrmAllPurshacing()
        {
            InitializeComponent();
            //dataGridViewList.DataSource = s.suppliermanagement();
            calcTotal();
        }
        void calcTotal()
        {
            decimal total = 0;
            for (int i = 0; i < dataGridViewList.Rows.Count ; i++)
            {
                total += Convert.ToDecimal(dataGridViewList.Rows[i].Cells[3].Value);
            }
            textBox1.Text = Math.Round(total, 2).ToString();
        }

        private void FrmAllPurshacing_Load(object sender, EventArgs e)
        {

        }

        private void DataGridViewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt = s.SearchsuppliermanagementSystem(DateFrom.Value, DateTo.Value);
            dataGridViewList.DataSource = dt;
            calcTotal();
        }
    }
}
