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
    public partial class FRM_ReportUser : Form
    {
        Login l = new Login();
        public FRM_ReportUser()
        {
            InitializeComponent();
            comboBox1.DataSource = l.selectIDUser();
            comboBox1.DisplayMember = "ID";
            comboBox1.ValueMember = "ID";

        }

        private void FRM_ReportUser_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = l.SelectLogin(Convert.ToString( comboBox1.SelectedValue));
        }
    }
}
