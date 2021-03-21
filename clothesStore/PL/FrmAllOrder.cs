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
    public partial class FrmAllOrder : Form
    {
        Order o = new Order();
        public FrmAllOrder()
        {
            InitializeComponent();
            //dataGridViewList.DataSource = o.SelectOrderManagment();
            calcTotal();
        }

        void calcTotal()
        {
            decimal total = 0;
            for (int i = 0; i < dataGridViewList.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dataGridViewList.Rows[i].Cells[3].Value);
            }
            textBox1.Text = Math.Round(total, 2).ToString();
        }

        private void DataGridViewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmAllOrder_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt = o.SearchOrderManagmentSystem(DateFrom.Value, DateTo.Value);
            dataGridViewList.DataSource = dt;
            calcTotal();
        }
    }
}
