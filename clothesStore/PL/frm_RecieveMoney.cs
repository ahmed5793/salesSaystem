using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using clothesStore.Bl;
namespace clothesStore.PL
{
    public partial class frm_RecieveMoney : DevExpress.XtraEditors.XtraForm
    {
        Stock s = new Stock();
        
        public frm_RecieveMoney()
        {
            InitializeComponent();
            ComboStock();
          
        }
        void Clac_total()
        {
            decimal totalmoney = Convert.ToDecimal(textBox1.Text) - Convert.ToDecimal(textBox2.Text);
            textBox3.Text = totalmoney.ToString();
        }
        void calcPull()
        {
            decimal total = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow r = gridView1.GetDataRow(i);
                total += Convert.ToDecimal(r[1].ToString());

            }
            textBox2.Text = Math.Round(total, 2).ToString();
        }
        void calcinsert()
        {
            decimal total = 0;
            for (int i = 0; i < gridViewInsert.RowCount; i++)
            {
                DataRow r = gridViewInsert.GetDataRow(i);
                total += Convert.ToDecimal(r[1].ToString());

            }
            textBox1.Text = Math.Round(total, 2).ToString();
        }
        void insertStock()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = s.Search_Insert_Stock(Convert.ToInt32(cmb_Stock.SelectedValue), FromDate.Value, ToDate.Value);
            gridControlInsert.DataSource = dt;
            calcinsert();
        }
        void PullStock()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt = s.Search_PullStock(Convert.ToInt32(cmb_Stock.SelectedValue), FromDate.Value, ToDate.Value);
            gridControl1.DataSource = dt;
            calcPull();
        }
        void ComboStock()
        {
            cmb_Stock.DataSource = s.Compo_Stock();
            cmb_Stock.DisplayMember = "Treasury_name";
            cmb_Stock.ValueMember = "id_Treasury";
        }

        private void frm_RecieveMoney_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            PullStock();
            insertStock();
            Clac_total();
        }
    }
}