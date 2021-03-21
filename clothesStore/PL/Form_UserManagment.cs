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
    public partial class Form_UserManagment : Form
    {
        Login l = new Login();
        Permession p = new Permession();
        public Form_UserManagment()
        {
           
            InitializeComponent();
            dataGridViewList.DataSource = l.SelectUsers();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            button1.Hide();
           
        }

        void delete()
        {
            txt_Fullname.Text = "";
            txt_User.Text = "";
            txt_Pass.Text = "";
            txt_PassRealy.Text = "";
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_User.Text == string.Empty || txt_Pass.Text == string.Empty || txt_PassRealy.Text == string.Empty || txt_Fullname.Text == string.Empty)
                {
                    MessageBox.Show("من فضلك ادخل البيانات كامله");


                }

                if (txt_Pass.Text != txt_PassRealy.Text)
                {
                    MessageBox.Show("كلمه السر غير متطابقه");
                    txt_PassRealy.Focus();

                    return;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        Login l = new Login();
        l.AddUser(txt_User.Text, txt_Pass.Text, txt_Fullname.Text);
            MessageBox.Show("تم اضافه المستخدم بنجاح");

            p.AddUserProduct(txt_User.Text, 1, 1, 1, 1,1,1);
            p.addUserClient(txt_User.Text, 1, 1, 1, 1,1,1,1);
            p.AddUserSuppliers(txt_User.Text, 1, 1, 1, 1, 1,1);
            p.AddUserOrder(txt_User.Text, 1, 1, 1, 1, 1);
            p.AddUserPurshise(txt_User.Text, 1, 1, 1, 1);
            p.AddUserStock(txt_User.Text, 1, 1, 1, 1,1,1,1,1);
            p.AddUserFile(txt_User.Text, 1, 1, 1, 1, 1);


            dataGridViewList.DataSource = l.SelectUsers();
            txt_Fullname.Text = "";
            txt_Pass.Text = "";
            txt_PassRealy.Text = "";
            txt_User.Text = "";
           
            txt_Fullname.Focus();

           


        
        } 


    

        private void txt_PassRealy_Validated(object sender, EventArgs e)
        {
            if (txt_Pass.Text!=txt_PassRealy.Text )
            {
                MessageBox.Show("كلمه السر غير متطابقه");
             
                return;
            
            }
           
        }

        private void Form_UserManagment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Login l = new Login();

                if (txt_Pass.Text == "")
                {
                    MessageBox.Show("يرجى كتابة الباسورد");
                    txt_Pass.Focus();
                }
                else if(txt_Fullname.Text=="")
                {
                    MessageBox.Show("يرجي التأكد من إسم الكاشير");
                }
                else if (txt_User.Text == "")
                {
                    MessageBox.Show("يرجي التأكد من إسم المستخدم");
                }

                else if (MessageBox.Show("هل تريد تعديل بيانات المستخدم", "تعديل بيانات المستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txt_Pass.Text != txt_PassRealy.Text)
                    {
                        MessageBox.Show("كلمه السر غير متطابقه");
                        return;

                    }
                    l.UpdateUsers(txt_User.Text, txt_Pass.Text, txt_Fullname.Text);
                    MessageBox.Show("تم التعديل بنجاح", "تعديل بيانات المستخدم", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    l.SelectUsers();
                    delete();
                    btn_delete.Enabled = false;
                    btn_update.Enabled = false;
                    btn_save.Show();
                    button1.Hide();
                    dataGridViewList.DataSource = l.SelectUsers();
                    txt_User.Enabled = true;
                }

                else
                {
                    MessageBox.Show("لم يتم التعديل ", "تعديل بيانات المستخدم", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewList_DoubleClick(object sender, EventArgs e)
        {
            txt_User.Text = dataGridViewList.CurrentRow.Cells[0].Value.ToString();
            txt_Pass.Text = dataGridViewList.CurrentRow.Cells[1].Value.ToString();
            txt_Fullname.Text = dataGridViewList.CurrentRow.Cells[2].Value.ToString();
            txt_PassRealy.Text = txt_Pass.Text;
            txt_Fullname.Enabled = true;
            txt_User.Enabled = false;
            btn_save.Hide();
            button1.Show();
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            try {
                if (MessageBox.Show("هل تريد مسح هذا المستخدم", "عملية مسح مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    l.deleteusers(txt_User.Text);
                    MessageBox.Show("تم مسح المستخدم بنجاح", "عملية مسح مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewList.DataSource = l.SelectUsers();
                    delete();
                    btn_delete.Enabled = false;
                    btn_update.Enabled = false;
                    btn_save.Show();
                    button1.Hide();
                    txt_User.Enabled = true;
                }
                else
                {
                    MessageBox.Show("لم يتم مسح المستخدم", "عملية مسح مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    delete();
                    btn_delete.Enabled = false;
                    btn_update.Enabled = false;
                    btn_save.Show();
                    button1.Hide();
                    txt_User.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            delete();
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            btn_save.Show();
            button1.Hide();
            txt_User.Enabled = true;
        }
    }
}
