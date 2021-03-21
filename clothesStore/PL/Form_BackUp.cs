using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace clothesStore.PL
{
    public partial class Form_BackUp : Form
    {
        SqlConnection con = new SqlConnection(@"server =.; database=DB_A54A03_EasySystem;integrated security=true");
        SqlCommand cmd;
        public Form_BackUp()
        {
            InitializeComponent();
             
            
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_backUp_Click(object sender, EventArgs e)
        {
            try {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("من فضلك قم بتحديد المسار ");
                }
                else
                {
                    string fileName = textBox1.Text + "\\DB_A54A03_EasySystem " + DateTime.Now.ToShortDateString().Replace('/', '-') + "-" + DateTime.Now.ToLongTimeString().Replace(':', '-');
                    string sqlQuary = "BackUp Database DB_A54A03_EasySystem to Disk= '" + fileName + ".bak '";
                    cmd = new SqlCommand(sqlQuary, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم إنشاء نسخة إحتياطية بنجاح", "إنشاء النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("ممنوع حفظ نسخه علي سطح المكتب");
                MessageBox.Show(ex.Message);
              
            }
            }

        private void Form_BackUp_Load(object sender, EventArgs e)
        {

        }
    }
}
