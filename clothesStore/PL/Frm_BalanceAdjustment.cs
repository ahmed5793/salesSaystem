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
    public partial class Frm_BalanceAdjustment : DevExpress.XtraEditors.XtraForm
    {
        Store Store = new Store();
        Proudect p = new Proudect();
        DataTable dt2 = new DataTable();
        DataTable dt = new DataTable();
        DataTable dt6 = new DataTable();
        //void ComboStore()
        //{
        //    Cmb_Store.DataSource = Store.Select_ComboStore();
        //    Cmb_Store.DisplayMember = "Store_Name";
        //    Cmb_Store.ValueMember = "Store_Id";
        //}
        void ComboProduct()
        {
            Cmb_product.DataSource = p.Select_ProductFormStoreForSale();
            Cmb_product.DisplayMember = "Name_Prod";
            Cmb_product.ValueMember = "ID_Prod";
        }
        //void Select_ProductUnit()
        //{
        //    Cmb_LargeUnit.DataSource = p.Select_UnitProduct(Convert.ToInt32(Cmb_product.SelectedValue));
        //    Cmb_LargeUnit.DisplayMember = "Unit_Name";
        //    Cmb_LargeUnit.ValueMember = "Id_Unit";
        //}
        void SelectProductQty()
        {
            dt.Clear();
            dt = Store.Select_ProductQuntity(Convert.ToInt32(Cmb_product.SelectedValue));
            Txt_AllQuantity.Text = dt.Rows[0][0].ToString();
        }
        public Frm_BalanceAdjustment()
        {
            InitializeComponent();
            ComboProduct();
            Cmb_product.SelectedIndex = -1;
            Rdb_increase.Checked = true;
            txt_sales.Text = Program.salesman;
        }
        private void Frm_BalanceAdjustment_Load(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cmb_Store_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboProduct();
            SelectProductQty();
        }

        private void Cmb_product_Leave(object sender, EventArgs e)
        {
            if (Cmb_product.Text != "")
            {
                dt2.Clear();
                dt2 = p.Validate_ProductFormStoreForSale(Convert.ToInt32(Cmb_product.SelectedValue));
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("اسم الصنف الذى قمت باادخالة غير موجود فى قائمة الاصناف ", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Cmb_product.SelectAll();
                    Cmb_product.Focus();
                    return;
                }
            }
        }

        private void Cmb_product_SelectionChangeCommitted(object sender, EventArgs e)
        {
  
            SelectProductQty();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Qty.Text=="" || Txt_Qty.Text=="0"){MessageBox.Show("لا بد من تحديد الكمية");return;}
                //dt6.Clear();
                //dt6 = p.Select_NumberSmallInLargeUnit(Convert.ToInt32(Cmb_product.SelectedValue), Cmb_LargeUnit.Text);
                //decimal y  = Convert.ToDecimal(Txt_Qty.Text )+ Convert.ToDecimal(0.00);
                //decimal x = y / Convert.ToDecimal(dt6.Rows[0][1]);
                if (Rdb_Decrease.Checked==true)
                {
                    if ((Convert.ToDecimal(Txt_Qty.Text))> Convert.ToDecimal(Txt_AllQuantity.Text))
                    {
                        MessageBox.Show("الكمية المراد سحبها من المخزن اكبر من الكمية الموجود حاليا فى المخزن");
                        return;                    
                    }
                    
                    p.Add_BalanceAdjustment(Convert.ToInt32(Cmb_product.SelectedValue), 
                       Convert.ToDecimal(Txt_Qty.Text), dateTimePicker1.Value,txt_note.Text, txt_sales.Text,Rdb_Decrease.Text);
                    p.Update_ProductQuantityDecrease(Convert.ToInt32(Cmb_product.SelectedValue), Convert.ToDecimal(Txt_Qty.Text));
                }
                if (Rdb_increase.Checked==true)
                {
                    p.Add_BalanceAdjustment(Convert.ToInt32(Cmb_product.SelectedValue), Convert.ToDecimal(Txt_Qty.Text), 
                        dateTimePicker1.Value, txt_note.Text, txt_sales.Text, Rdb_increase.Text);

                    p.Update_ProductQuantityIncrease(Convert.ToInt32(Cmb_product.SelectedValue),Convert.ToDecimal(Txt_Qty.Text));
                }
                MessageBox.Show("تم حفظ العملية بنجاح");
                SelectProductQty();
                Txt_Qty.Text="0.00";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 )
            {
                e.Handled = true;
            }
        }

        private void Txt_Qty_Leave(object sender, EventArgs e)
        {
            if (Txt_Qty.Text=="")
            {
                Txt_Qty.Text = "0";
            }
        }

        private void Txt_Qty_Click(object sender, EventArgs e)
        {
            if (Txt_Qty.Text=="0")
            {
                Txt_Qty.Text = "";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_note_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}