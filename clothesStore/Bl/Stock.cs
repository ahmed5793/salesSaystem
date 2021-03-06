using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using clothesStore.DAL;

namespace clothesStore.Bl
{
    class Stock
    {
        internal void add_stock(int id, string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id_treasury", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@Treasury_name", SqlDbType.NVarChar, 100);
            param[1].Value = name;
            da.excutequery("add_stock", param);
            da.close();
        }
        internal void Update_Stock(int id, string name)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id_Treasury", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@Treasury_name", SqlDbType.NVarChar, 100);
            param[1].Value = name;
            da.excutequery("Update_Stock", param);
            da.close();


        }


        internal void Delete_Stock(int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_Treasury", SqlDbType.Int);
            param[0].Value = id;
            da.excutequery("Delete_Stock", param);
            da.close();
        }
        internal DataTable select_Stock()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            dt = da.selected("select_Stock", null);

            return dt;
        }

        internal DataTable Select_LastIdStock()
        {
            DataAccessLayer da = new DataAccessLayer();
            DataTable dt = new DataTable();
            da.open();
            dt = da.selected("Select_LastIdStock", null);

            return dt;
        }
        internal DataTable Compo_Stock()
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Compo_Stock", null);
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
        internal void add_stockData(int id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_Treasury", SqlDbType.Int);
            param[0].Value = id;
            da.excutequery("add_stockData", param);
            da.close();
        }

        internal void add_insertStock(int id, decimal money, DateTime date, string name, string type, string reason)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id_Treasury", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@Money", SqlDbType.Real);
            param[1].Value = money;
            param[2] = new SqlParameter("@Date", SqlDbType.DateTime);
            param[2].Value = date;
            param[3] = new SqlParameter("@Name", SqlDbType.NVarChar, 250);
            param[3].Value = name;
            param[4] = new SqlParameter("@Type", SqlDbType.NVarChar, 250);
            param[4].Value = type;
            param[5] = new SqlParameter("@Reason", SqlDbType.NVarChar, 250);
            param[5].Value = reason;
            da.excutequery("add_insertStock", param);
            da.close();
        }

        internal void Add_StockPull(int id, decimal money, DateTime date, string name, string type, string reason)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id_Treasury", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@Money", SqlDbType.Real);
            param[1].Value = money;
            param[2] = new SqlParameter("@Date", SqlDbType.DateTime);
            param[2].Value = date;
            param[3] = new SqlParameter("@Name", SqlDbType.NVarChar, 250);
            param[3].Value = name;
            param[4] = new SqlParameter("@Type", SqlDbType.NVarChar, 250);
            param[4].Value = type;
            param[5] = new SqlParameter("@Reason", SqlDbType.NVarChar, 250);
            param[5].Value = reason;
            da.excutequery("Add_StockPull", param);
            da.close();
        }

        internal void Add_StockTransfair(decimal money, DateTime date, string from, string to, string name, string reason)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Money", SqlDbType.Real);
            param[0].Value = money;
            param[1] = new SqlParameter("@Date", SqlDbType.NVarChar, 50);
            param[1].Value = date;
            param[2] = new SqlParameter("@From_", SqlDbType.NVarChar, 50);
            param[2].Value = from;
            param[3] = new SqlParameter("@To_", SqlDbType.NVarChar, 50);
            param[3].Value = to;
            param[4] = new SqlParameter("@Name", SqlDbType.NVarChar, 75);
            param[4].Value = name;
            param[5] = new SqlParameter("@Reason", SqlDbType.NVarChar, 150);
            param[5].Value = reason;
            da.excutequery("Add_StockTransfair", param);
            da.close();
        }
        internal DataTable Insert_Stock(int Id_Stock)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Stock", SqlDbType.Int);
            param[0].Value = Id_Stock;
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Insert_Stock", param);
            return dt;
        }
        internal DataTable Search_Insert_Stock(int Id_Stock,DateTime dateFrom, DateTime DateTo)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Stock", SqlDbType.Int);
            param[0].Value = Id_Stock;
            param[1] = new SqlParameter("@data_from", SqlDbType.Date);
            param[1].Value = dateFrom;
            param[2] = new SqlParameter("@data_to", SqlDbType.Date);
            param[2].Value = DateTo;
            dt = da.selected("Search_Insert_Stock", param);
            return dt;
        }
        internal DataTable Report_PullStock(int Id_Stock)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Stock", SqlDbType.Int);
            param[0].Value = Id_Stock;
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("Report_PullStock", param);
            return dt;
        }
        internal DataTable Search_PullStock(int Id_Stock,DateTime dateFrom, DateTime DateTo)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Id_Stock", SqlDbType.Int);
            param[0].Value = Id_Stock;
            param[1] = new SqlParameter("@data_from", SqlDbType.Date);
            param[1].Value = dateFrom;
            param[2] = new SqlParameter("@data_to", SqlDbType.Date);
            param[2].Value = DateTo;
            dt = da.selected("Search_PullStock", param);
            return dt;


        }
        internal void DeletePullStock(int id_stock, DateTime date, decimal money)
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id_stock", SqlDbType.Int);
            param[0].Value = id_stock;
            param[1] = new SqlParameter("@Date", SqlDbType.DateTime);
            param[1].Value = date;
            param[2] = new SqlParameter("@Money", SqlDbType.Real);
            param[2].Value = money;
            da.selected("DeletePullStock", param);
            da.close();
        }
        internal void DeleteInsertStock(int id_stock, DateTime date, decimal money)
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id_stock", SqlDbType.Int);
            param[0].Value = id_stock;
            param[1] = new SqlParameter("@Date", SqlDbType.DateTime);
            param[1].Value = date;
            param[2] = new SqlParameter("@Money", SqlDbType.Real);
            param[2].Value = money;
            da.selected("DeletePullStock", param);
            da.close();
        }
        internal void UpdateinsertStockMoney(int id, decimal money)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id_Stock", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@moeny", SqlDbType.Decimal);
            param[1].Value = money;
            da.excutequery("UpdateinsertStockMoney", param);
            da.close();
        }

    }
}
