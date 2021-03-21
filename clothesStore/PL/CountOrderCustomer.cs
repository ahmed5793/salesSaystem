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
    public partial class CountOrderCustomer : Form
    {
        Order o = new Order();
        DataTable dt = new DataTable();
        public CountOrderCustomer()
        {
            InitializeComponent();
            dataGridView1.DataSource = o.CountCusromerOrder();

        }

        private void CountOrderCustomer_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            dt = o.SearchCountCusromerOrder(textBox1.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
