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
    class Store
    {
        internal void Add_Store(string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Store_Name", SqlDbType.NVarChar, 150);
            param[0].Value = name;
            da.excutequery("Add_Store", param);
            da.close();
        }
        internal void Update_Store(int ID, string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Store_Id", SqlDbType.Int);
            param[0].Value = name;
            param[1] = new SqlParameter("@Store_Name", SqlDbType.NVarChar, 150);
            param[1].Value = name;
            da.excutequery("Update_Store", param);
            da.close();
        }
        internal DataTable Select_Store()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_Store", null);
            da.close();
            return dt;
        }
        internal DataTable Select_ComboStore()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Select_ComboStore", null);
            da.close();
            return dt;
        }
        internal void Add_StoreProduct(int  Id_Product , decimal Buy_Price )
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.Int);
            param[0].Value = Id_Product;
            param[1] = new SqlParameter("@Buy_price", SqlDbType.Decimal);
            param[1].Value = Buy_Price;           
            da.excutequery("Add_StoreProduct", param);
            da.close();
        }
        internal void Update_StoreProduct(int Id_Product, decimal New_Buy_Price , decimal Old_Buy_Price)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.Int);
            param[0].Value = Id_Product;
            param[1] = new SqlParameter("@NewBuy_price", SqlDbType.Decimal);
            param[1].Value = New_Buy_Price;
            param[2] = new SqlParameter("@old_BuyPrice", SqlDbType.Decimal);
            param[2].Value = Old_Buy_Price;
            da.excutequery("Update_StoreProduct", param);
            da.close();
        }
        internal void Delete_StoreProduct(int Id_Product, int Id_Store, decimal Quantity)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = Id_Product;
            param[1] = new SqlParameter("@Id_Store", SqlDbType.Int);
            param[1].Value = Id_Store;
            param[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            param[2].Value = Quantity;
            da.excutequery("Delete_StoreProduct", param);
            da.close();
        }
        internal DataTable Select_ProductStore(int Id_Product , int Id_Store)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = Id_Product;
            param[1] = new SqlParameter("@Id_Store", SqlDbType.Int);
            param[1].Value = Id_Store;
            dt = da.selected("Select_ProductStore", param);
            da.close();
            return dt;
        }
        internal DataTable Search_ProductStore(string Id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", SqlDbType.Int);
            param[0].Value = Id;
            DataTable dt = new DataTable();
            dt = da.selected("Search_ProductStore", param);
            da.close();
            return dt;
        }
        internal DataTable Validate_ProductStore(int Id_Product , decimal Buy_Price)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = Id_Product;
            param[1] = new SqlParameter("@Buy_price", SqlDbType.Decimal);
            param[1].Value = Buy_Price;
            DataTable dt = new DataTable();
            dt = da.selected("Validate_ProductStore", param);
            da.close();
            return dt;
        }
        internal DataTable Select_ProductQuntity(int ID_Product)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID_Product;
            DataTable dt = new DataTable();
            dt = da.selected("Select_ProductQuntity", param);
            da.close();
            return dt;
        }
        internal DataTable SelectBuyPriceFromProductStore(int ID_Product, int Id_Store , decimal Buy_Price)
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Product", SqlDbType.Int);
            param[0].Value = ID_Product;
            param[1] = new SqlParameter("@ID_Store", SqlDbType.Int);
            param[1].Value = Id_Store;
            param[2] = new SqlParameter("@Buy_Price", SqlDbType.Decimal);
            param[2].Value = Buy_Price;
            dt = da.selected("SelectBuyPriceFromProductStore", param);
            da.close();
            return dt;
        }
    }
}
