using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clothesStore.PL
{
    public partial class form_main : Form
    {
        private static form_main frm;
        static void formclosed(object sender, FormClosedEventArgs e)
        {

            frm = null;

        }
        internal static form_main geter
        {
            get
            {
                if (frm == null)
                {
                    frm = new form_main();
                    frm.FormClosed += new FormClosedEventHandler(formclosed);
                }
                return frm;
            }
        }


            public form_main()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;

            this.ToolSuppliers.Enabled = false;
            this.ToolStripProduct.Enabled = false;
            this.ToolMasrofat.Enabled = false;
            this.ToolPurchases.Enabled = false;
            this.ToolCustomer.Enabled = false;


            txtDATETIME.Hide();
            txt_idLogin.Hide();
            Txt_IDUsers.Hide();

        }

        private void اضافهمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProudect fp = new FormProudect();
            fp.ShowDialog();
        }

        private void form_main_Load(object sender, EventArgs e)
        {
            Frm_LoginMain f = new Frm_LoginMain();
            f.Hide();
          
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void اضافهعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Frm_Customer cm = new Frm_Customer();
            cm.ShowDialog();
            
           
        }

        private void اضافهمخزنجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void اضافهموردجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Suppliers s = new Form_Suppliers();
            s.ShowDialog();
        }

        private void اضافهفاتورهبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void اضافهفاتورهموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void استرجاعفاتورةشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void ادارهالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void عرضكلفواتيرالشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void تقاريرعنالاصناففيالمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void إدارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ادارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void فاتورةمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void مدفوعاتعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayCustomer p = new PayCustomer();
            p.ShowDialog();
        }

        private void مدفوعاتموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ReportPaySuppliers fps = new Frm_ReportPaySuppliers();
            fps.Show();
        }

        private void اضافهمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void استرجاعفاتورةشراءToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void فاتورةشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_SuppliersDetalis sd = new Form_SuppliersDetalis();
            //sd.ShowDialog();
                
        }

        private void استرجاعفاتورةشراءToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void البحثفيالفواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      

        private void المشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void انشاءنسخهاحتياطيهللبرنامجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Masrofat fm = new Frm_Masrofat();
            fm.Show();
        }

        private void استرجاعنسخهاحتياطيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Allmasroft fl = new Frm_Allmasroft();
            fl.Show();
        }

        private void مرتجعمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }    

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ادارهالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    Form_ReturnSuppliers r = new Form_ReturnSuppliers();
        //    r.Show();
        }

        private void lableTime_Click(object sender, EventArgs e)
        {

        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
    

       
        }

        private void تقريرعنفواتيرالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void فاتورةمبيعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void البحثفيفواتيرالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void مرتجعمبيعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
      
        }

        private void فاتورةشراءToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void البحثفيالفواتيرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        
        }

        private void استرجاعفاتورةشراءToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          
        }

        private void تقاريرعنالاصناففيالمخزنToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
          
        }

        private void تقريرعنفواتيرالمبيعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //DAL.DataAccessLayer da = new DAL.DataAccessLayer();
            //da.open();
            //Rpt.FrmSingleReport f = new Rpt.FrmSingleReport();
            //Rpt.RprSelectAllOrdes r = new Rpt.RprSelectAllOrdes();
            //f.crystalReportViewer1.ReportSource = r;
            //f.ShowDialog();
            //da.close();
     
        }

        private void تقريرعنفواتيرالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
      

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Debit d = new Debit();
            d.Show();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            FrmSalesReb7 fm = new FrmSalesReb7();
            fm.Show();
        }

        private void ToolStripButton5_Click_1(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FrmSalesReb7 sb = new FrmSalesReb7();
            sb.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OrderSales o = new OrderSales();
            o.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Frm_AllProduct fb = new Frm_AllProduct();
            fb.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FrmOrderReturn f = new FrmOrderReturn();
            f.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Debit d = new Debit();
            d.Show();
        }

        private void حركةبيعالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MoveProduct fm = new Frm_MoveProduct();
            fm.Show();
        }

        private void المصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void تقريرعنكلالمصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Frm_Allmasroft ms = new Frm_Allmasroft();
            ms.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_ReportPayCustomer rpc = new Frm_ReportPayCustomer();
            rpc.Show();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PaySuppliers p = new PaySuppliers();
            p.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //Form_ReturnSuppliers rs = new Form_ReturnSuppliers();
            //rs.Show();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Frm_MoveProduct fm = new Frm_MoveProduct();
            fm.Show();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Form_OrderManagment om = new Form_OrderManagment();
            om.Show();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Form_suppliermanagement sm = new Form_suppliermanagement();
            sm.Show();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            Frm_Masrofat fm = new Frm_Masrofat();
            fm.Show();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            PL.Frm_Customer cm = new Frm_Customer();
            cm.ShowDialog();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            Form_Suppliers s = new Form_Suppliers();
            s.ShowDialog();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            FrmAllOrder fo = new FrmAllOrder();
            fo.Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            FrmAllPurshacing fp = new FrmAllPurshacing();
            fp.Show();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            PayCustomer p = new PayCustomer();
            p.ShowDialog();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            PaySuppliers p = new PaySuppliers();
            p.ShowDialog();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            Frm_ReportPayCustomer rpc = new Frm_ReportPayCustomer();
            rpc.Show();
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            Frm_ReportPaySuppliers fps = new Frm_ReportPaySuppliers();
            fps.Show();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            FormProudect fp = new FormProudect();
            fp.ShowDialog();
        }

        private void إضافةخزنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Stock form_Stock = new Form_Stock();
            form_Stock.Show();
        }

        private void تقريرعنالاصناففيالمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_AllProduct fu = new Frm_AllProduct();
            fu.Show();
        }

        private void إدارةالمستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_UserManagment s = new Form_UserManagment();
            s.ShowDialog();
        }

        private void ادارهالموظفينToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_ReportUser fu = new FRM_ReportUser();
            fu.Show();
        }

        private void انشاءنسخهاحتياطيهللبرنامجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PL.Form_BackUp f = new Form_BackUp();
            f.ShowDialog();
        }

        private void استرجاعنسخهاحتياطيهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Restore r = new Form_Restore();
            r.ShowDialog();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Bl.Login l = new Bl.Login();
            txtDATETIME.Text = " الوقت:" + DateTime.Now.ToShortTimeString() + " / " + " التاريخ :" + DateTime.Now.ToShortDateString();
            DataTable dt = new DataTable();
            dt = l.SelectUsers();
            Program.salesman = dt.Rows[0][0].ToString();
            Txt_IDUsers.Text = Program.salesman;

            txt_idLogin.Text = l.LastIDLogin().Rows[0][0].ToString();
            l.ADDLogOut(Convert.ToInt32(txt_idLogin.Text), Txt_IDUsers.Text, txtDATETIME.Text);
            Application.Exit();
        }

        private void بحثفىفواتيرالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_suppliermanagement sm = new Form_suppliermanagement();
            sm.Show();
        }

        private void تقريرعنفواتيرالمشترياتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAllPurshacing fp = new FrmAllPurshacing();
            fp.Show();
        }

        private void تقريرعنفواتيرالمبيعاتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmAllOrder fo = new FrmAllOrder();
            fo.Show();
        }

        private void فاتورةمبيعاتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OrderSales ad = new OrderSales();
            ad.Show();
        }

        private void مرتجعمبيعاتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmOrderReturn frm = new FrmOrderReturn();
            frm.Show();
        }

        private void بحثفىفواتيرالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_OrderManagment om = new Form_OrderManagment();
            om.Show();
        }

        private void ارباحالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalesReb7 sb = new FrmSalesReb7();
            sb.Show();
        }

        private void مديونيةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debit d = new Debit();
            d.Show();
        }

        private void Txt_IDUsers_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            Form_DebitSupplier fds = new Form_DebitSupplier();
            fds.Show();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            //Form_ReturnSuppliers r = new Form_ReturnSuppliers();
            //r.Show();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            FrmOrderReturn frm = new FrmOrderReturn();
            frm.Show();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            OrderSales ad = new OrderSales();
            ad.Show();
        }

        private void إضافةخزنةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form_Stock form_Stock = new Form_Stock();
            form_Stock.Show();
        }

        private void إضافةرصيدخزنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_addStockMoney fsm = new Form_addStockMoney();
            fsm.Show();
        }

        private void سحبرصيدمنالخزنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_StockPull fsp = new Form_StockPull();
            fsp.Show();
        }

        private void تحويلرصيدمنخزنةإلىخزنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_StockTransfair fst = new Form_StockTransfair();
            fst.Show();
        }

        private void تقريرعنالاصدةالمضافةفىالخزنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ReportInsertStock fris = new Form_ReportInsertStock();
            fris.Show();
        }

        private void Report_StockPull_Click(object sender, EventArgs e)
        {
            Form_reportStockPull frs = new Form_reportStockPull();
            frs.Show();
        }

        private void DepitSuppliers_Click(object sender, EventArgs e)
        {
            Form_DebitSupplier fds = new Form_DebitSupplier();
            fds.Show();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToShortDateString();
            label7.Text = DateTime.Now.ToLongTimeString();
        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            Debit d = new Debit();
            d.Show();
        }

        private void تقريرعنالحدالادنيللاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_QuantityMinmum qm = new Frm_QuantityMinmum();
            qm.ShowDialog();
        }

        private void تقريرعنالعملاءالدائمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountOrderCustomer co = new CountOrderCustomer();
            co.Show();
        }

        private void بحثعناسعارالاصنافبالباركودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_SearchBarcodeProudect sp = new Frm_SearchBarcodeProudect();
            sp.Show();
        }

        private void Tool_StoreProduct_Click(object sender, EventArgs e)
        {
            Frm_AddStoreProduct fasp = new Frm_AddStoreProduct();
            fasp.ShowDialog();
        }
    }
    }
    


