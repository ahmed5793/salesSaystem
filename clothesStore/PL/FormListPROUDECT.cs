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
    public partial class FormListPROUDECT : Form
    {
        Proudect p = new Proudect();
      
        DataTable dt = new DataTable();

        public FormListPROUDECT()
        {
            InitializeComponent();

         

        }

        private void dataGridViewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       public void exit(object sender , EventArgs e)
        {
            this.Close();
        }

        private void FormListPROUDECT_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = p.selectListProudect(Convert.ToInt32(OrderSales.getmain.Cmb_Store.SelectedValue));
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
           
           
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
            dt = p.search(textBox1.Text, Convert.ToInt32(OrderSales.getmain.Cmb_Store.SelectedValue));
            dataGridView1.DataSource = dt;
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_selectProduct_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_selectProduct_MouseClick(object sender, MouseEventArgs e)
        {
            
            dataGridView1.DataSource = null;
            this.Close();
          
        }
    }
}