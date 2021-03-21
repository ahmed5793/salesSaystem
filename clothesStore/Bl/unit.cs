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
    class unit
    {
        internal void Add_Unit(string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Unit_Name", SqlDbType.NVarChar, 150);
            param[0].Value = name;
            da.excutequery("Add_Unit", param);
            da.close();
        }
        internal void Update_Unit(int ID, string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Unit_Id", SqlDbType.Int);
            param[0].Value = name;
            param[1] = new SqlParameter("@Unit_Name", SqlDbType.NVarChar, 150);
            param[1].Value = name;
            da.excutequery("Update_Unit", param);
            da.close();
        }
        internal DataTable Select_Unit()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_Unit", null);
            da.close();
            return dt;
        }
        internal DataTable Select_ComboUnit()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_ComboUnit", null);
            da.close();
            return dt;
        }
        internal void Add_ProductUnit(int id_Product, int ID_Unit, decimal Number_InLargeUnit, decimal Price_Unit)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = id_Product;
            param[1] = new SqlParameter("@Id_Unit", SqlDbType.Int);
            param[1].Value = ID_Unit;
            param[2] = new SqlParameter("@numInLargeUnit", SqlDbType.Decimal);
            param[2].Value = Number_InLargeUnit;
            param[3] = new SqlParameter("@Unit_SalePrice", SqlDbType.Decimal);
            param[3].Value = Price_Unit;
      
            da.excutequery("Add_ProductUnit", param);
            da.close();
        }
        internal void Update_ProductUnit(int id_Product, int ID_Unit, decimal Number_InLargeUnit, decimal Price_Unit)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = id_Product;
            param[1] = new SqlParameter("@Id_Unit", SqlDbType.Int);
            param[1].Value = ID_Unit;
            param[2] = new SqlParameter("@numInLargeUnit", SqlDbType.Decimal);
            param[2].Value = Number_InLargeUnit;
            param[3] = new SqlParameter("@Unit_SalePrice", SqlDbType.Decimal);
            param[3].Value = Price_Unit;
            da.excutequery("Update_ProductUnit", param);
            da.close();
        }
        internal void Delete_ProductUnit(int id_Product)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = id_Product;

            da.excutequery("Delete_ProductUnit", param);
            da.close();
        }
    }
}
