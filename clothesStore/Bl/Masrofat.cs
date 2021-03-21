using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using clothesStore.DAL;
namespace clothesStore.Bl
{
    class Masrofat
    {
        internal void Add_masrof(int Id_Masrof, decimal amount, DateTime date, string descrpsion, int id_stock, string Sales_Man)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Masrof_Id", SqlDbType.Int);
            param[0].Value = Id_Masrof;
            param[1] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[1].Value = amount;
            param[2] = new SqlParameter("@date", SqlDbType.DateTime);
            param[2].Value = date;
            param[3] = new SqlParameter("@descrpsion", SqlDbType.NVarChar, 100);
            param[3].Value = descrpsion;
            param[4] = new SqlParameter("@ID_stock", SqlDbType.Int);
            param[4].Value = id_stock;
            param[5] = new SqlParameter("@Sales_man", SqlDbType.NVarChar, 100);
            param[5].Value = Sales_Man;
            da.excutequery("Add_masrof", param);
            da.close();
        }

        internal void Update_masrof(int id, decimal amount, DateTime date, string descrpsion, int Id_Stock, String sales_man, int Id_Count)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@id_masrof", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[1].Value = amount;
            param[2] = new SqlParameter("@date", SqlDbType.DateTime);
            param[2].Value = date;
            param[3] = new SqlParameter("@descrpsion", SqlDbType.NVarChar, 100);
            param[3].Value = descrpsion;
            param[4] = new SqlParameter("@Id_Stock", SqlDbType.Int);
            param[4].Value = Id_Stock;
            param[5] = new SqlParameter("@Sales_man", SqlDbType.NVarChar, 100);
            param[5].Value = sales_man;
            param[6] = new SqlParameter("@Id_CountPk", SqlDbType.Int);
            param[6].Value = Id_Count;
            da.excutequery("Update_masrof", param);
            da.close();
        }
        internal void Delete_masrof(int id )
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_Count", SqlDbType.Int);
            param[0].Value = id;
            da.excutequery("Delete_masrof", param);
            da.close();

        }

        internal DataTable Select_masrofat()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_masrofat", null);
            return dt;
        }

        internal DataTable Searech_masrofat(string id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,100);
            param[0].Value = id;
            dt = da.selected("Searech_masrofat", param);
            da.close();
            return dt;
       
        }
        internal DataTable Searech_masrofatDate(DateTime DAtefrom ,DateTime DateTo)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Datefrom", SqlDbType.Date);
            param[0].Value = DAtefrom;
            param[1] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[1].Value =DateTo ;
            dt = da.selected("Searech_masrofatDate", param);
            da.close();
            return dt;  
        }
        internal void Add_MAsrofCategory(string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Masrof_Name", SqlDbType.NVarChar, 150);
            param[0].Value = name;
            da.excutequery("Add_MAsrofCategory", param);
            da.close();
        }
        internal void Update_MAsrofCategory(int Id_Masrof, string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Masrof", SqlDbType.Int);
            param[0].Value = Id_Masrof;
            param[1] = new SqlParameter("@Masrof_Name", SqlDbType.NVarChar, 150);
            param[1].Value = name;

            da.excutequery("Update_MAsrofCategory", param);
            da.close();
        }
        internal DataTable Select_MasrofatCategory()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_MasrofatCategory", null);
            return dt;
        }
        internal DataTable Select_moneyStock(int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_Treasury", SqlDbType.Int);
            param[0].Value = id;

            dt = da.selected("Select_moneyStock", param);
            return dt;
        }
        internal DataTable Select_MoneyMasrof(int Id_Count)
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Count", SqlDbType.Int);
            param[0].Value = Id_Count;

            dt = da.selected("Select_MoneyMasrof", param);
            return dt;
        }
        internal DataTable Select_Onemasrofat(int id_masrof)
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Masrof", SqlDbType.Int);
            param[0].Value = id_masrof;
            dt = da.selected("Select_Onemasrofat", param);
            return dt;
        }
        internal DataTable Searech_onemasrofatDate( int Id_Masrof,DateTime DAtefrom, DateTime DateTo)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Masrof", SqlDbType.Int);
            param[0].Value = Id_Masrof;
            param[1] = new SqlParameter("@Datefrom", SqlDbType.Date);
            param[1].Value = DAtefrom;
            param[2] = new SqlParameter("@DateTo", SqlDbType.Date);
            param[2].Value = DateTo;
            dt = da.selected("Searech_onemasrofatDate", param);
            da.close();
            return dt;
        }
    }
}
