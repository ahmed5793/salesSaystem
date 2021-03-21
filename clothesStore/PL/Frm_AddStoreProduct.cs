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
    public partial class Frm_AddStoreProduct : Form
    {
        DataTable dt = new DataTable();
        Proudect P = new Proudect();
        Store S = new Store();
        public Frm_AddStoreProduct()
        {
            InitializeComponent();
            Cmb_ProdName.DataSource = P.select_ComboProduct();
            Cmb_ProdName.DisplayMember = "Name_Prod";
            Cmb_ProdName.ValueMember = "ID_Prod";

            Cmb_Store.DataSource = S.Select_ComboStore();
            Cmb_Store.DisplayMember = "Store_Name";
            Cmb_Store.ValueMember = "Store_Id";
            //dataGridViewPR.DataSource = S.Select_ProductStore();
            btn_add.Enabled = true;
            btn_update.Enabled = false;
            Btn_Delete.Enabled = false;
            btn_new.Hide();
            Btn_Delete.Hide();
            btn_update.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProudect frm_prod = new FormProudect();
            frm_prod.ShowDialog();
            Cmb_ProdName.DataSource = P.select_ComboProduct();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Store store = new Frm_Store();
            store.ShowDialog();
            Cmb_Store.DataSource = S.Select_ComboStore();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_quantity.Text=="0" || txt_quantity.Text=="")
                {
                    MessageBox.Show("لا بد ان تكون الكمية اكبر من الصفر");
                    txt_quantity.Focus();
                    return;
                }
                else
                {
                    dt.Clear();
                    //dt = S.Validate_ProductStore(Convert.ToInt32(Cmb_ProdName.SelectedValue), Convert.ToInt32(Cmb_Store.SelectedValue));
                    if (dt.Rows.Count > 0)
                    {
                        //S.Update_StoreProduct(Convert.ToInt32(Cmb_ProdName.SelectedValue),
                        //    Convert.ToDecimal(txt_quantity.Text));
                    }
                    else if (dt.Rows.Count == 0)
                    {
                    //    S.Add_StoreProduct(Convert.ToInt32(Cmb_ProdName.SelectedValue), Convert.ToInt32(Cmb_Store.SelectedValue),
                    //        Convert.ToDecimal(txt_quantity.Text));
                    }
                    MessageBox.Show("تم إضافة الصنف للمخزن بنجاح");
                    txt_quantity.Text = "0";
                    //dataGridViewPR.DataSource = S.Select_ProductStore();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد تعديل الصنف","عملية التعديل",MessageBoxButtons.YesNo , MessageBoxIcon.Question)==DialogResult.Yes)
                {
                 S.Delete_StoreProduct(Convert.ToInt32(dataGridViewPR.CurrentRow.Cells[0].Value), 
                 Convert.ToInt32(dataGridViewPR.CurrentRow.Cells[2].Value),Convert.ToDecimal(dataGridViewPR.CurrentRow.Cells[4].Value));
                  dt.Clear();
                  //dt = S.Validate_ProductStore(Convert.ToInt32(Cmb_ProdName.SelectedValue), Convert.ToInt32(Cmb_Store.SelectedValue));
                    if (dt.Rows.Count>0)
                    {
                        //S.Update_StoreProduct(Convert.ToInt32(Cmb_ProdName.SelectedValue),  
                        //    Convert.ToDecimal(txt_quantity.Text));
                    }
                    else if (dt.Rows.Count==0)
                    {
                    //    S.Add_StoreProduct(Convert.ToInt32(Cmb_ProdName.SelectedValue), Convert.ToInt32(Cmb_Store.SelectedValue), 
                    //        Convert.ToDecimal(txt_quantity.Text));
                    }
                    MessageBox.Show("تم تعديل الصنف بنجاح");
                }
                else
                {
                    MessageBox.Show("تم إلغاء التعديل");
                }
                txt_quantity.Text = "0";
                //dataGridViewPR.DataSource = S.Select_ProductStore();
                btn_add.Show();
                btn_new.Hide();
                btn_update.Enabled = true;
                Btn_Delete.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewPR_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dataGridViewPR.Rows.Count>0)
            //    {

            //        Cmb_ProdName.Text = dataGridViewPR.CurrentRow.Cells[1].Value.ToString();
            //        Cmb_Store.Text = dataGridViewPR.CurrentRow.Cells[3].Value.ToString();
            //        txt_quantity.Text = dataGridViewPR.CurrentRow.Cells[4].Value.ToString();
            //        btn_add.Hide();
            //        btn_new.Show();
            //        btn_update.Enabled = true;
            //        Btn_Delete.Enabled = true;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txt_quantity.Text = "0";
            btn_add.Show();
            btn_new.Hide();
            btn_update.Enabled = false;
            Btn_Delete.Enabled = false;
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد تعديل الصنف", "عملية التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    S.Delete_StoreProduct(Convert.ToInt32(dataGridViewPR.CurrentRow.Cells[0].Value),
                    Convert.ToInt32(dataGridViewPR.CurrentRow.Cells[2].Value), Convert.ToDecimal(dataGridViewPR.CurrentRow.Cells[4].Value));
                    MessageBox.Show("تم مسح الصنف من المخزن بنجاح");
                }
                else
                {
                    MessageBox.Show("تم إلغاء المسح");
                }
                txt_quantity.Text = "0";
                //dataGridViewPR.DataSource = S.Select_ProductStore();
                btn_add.Show();
                btn_new.Hide();
                btn_update.Enabled = false;
                Btn_Delete.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = S.Search_ProductStore(txt_search.Text);
                dataGridViewPR.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
