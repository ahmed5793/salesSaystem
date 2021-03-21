using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using clothesStore.DAL;
namespace clothesStore.Bl
{
    class Category
    {
        internal void Add_Category(string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Category_Name", SqlDbType.NVarChar,150);
            param[0].Value = name;
            da.excutequery("Add_Category",param);
            da.close();
        }
        internal void Update_Category( int ID ,string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Category_Id", SqlDbType.Int);
            param[0].Value = ID;
            param[1] = new SqlParameter("@Category_Name", SqlDbType.NVarChar, 150);
            param[1].Value = name;
            da.excutequery("Update_Category", param);
            da.close();
        }
        internal DataTable Select_Category()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_Category", null);
            da.close();
            return dt; 
        }
        internal DataTable Select_ComboCategory()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_ComboCategory", null);
            da.close();
            return dt;
        }
        internal DataTable Validate_CategoryName(int Id_Category)
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Category", SqlDbType.Int);
            param[0].Value = Id_Category;
            dt = da.selected("Validate_CategoryName", param);
            da.close();
            return dt;
        }
    }
}
