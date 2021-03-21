using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clothesStore.DAL;
using System.Data;
using System.Data.SqlClient;

namespace clothesStore.Bl
{
    class SettingPrint
    {
        internal void AddSettingPrint(string Name_Company, string Addres, string Bottom_Note, string Phone1, string Phone2)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@Name_Company", SqlDbType.NVarChar, 200);
            param[0].Value = Name_Company;
            param[1] = new SqlParameter("@Addres", SqlDbType.NVarChar, 200);
            param[1].Value = Addres;
            param[2] = new SqlParameter("Bottom_Note", SqlDbType.NVarChar, 250);
            param[2].Value = Bottom_Note;
            param[3] = new SqlParameter("@Phone1", SqlDbType.NVarChar, 50);
            param[3].Value = Phone1;
            param[4] = new SqlParameter("@Phone2", SqlDbType.NVarChar, 50);
            param[4].Value = Phone2;

            da.excutequery("AddSettingPrint", param);
            da.close();
        }
        internal void UpdateSettingPrint(string Name_Company, string Addres,string Bottom_Note, string Phone1,string Phone2)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@Name_Company", SqlDbType.NVarChar, 200);
            param[0].Value = Name_Company;
            param[1] = new SqlParameter("@Addres", SqlDbType.NVarChar, 200);
            param[1].Value = Addres;
            param[2] = new SqlParameter("Bottom_Note", SqlDbType.NVarChar, 250);
            param[2].Value = Bottom_Note;
            param[3] = new SqlParameter("@Phone1", SqlDbType.NVarChar, 50);
            param[3].Value = Phone1;
            param[4] = new SqlParameter("@Phone2", SqlDbType.NVarChar, 50);
            param[4].Value = Phone2;

            da.excutequery("UpdateSettingPrint", param);
            da.close();
        }
        internal DataTable SelectSettingPrintOrder()
        {
            DataTable dt = new DataTable();
            DataAccessLayer da = new DataAccessLayer();
           dt= da.selected("SelectSettingPrintOrder", null);
            return dt;
        }
    }
}
