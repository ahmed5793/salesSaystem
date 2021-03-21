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
    class Login
    {
        
        internal DataTable st_login(string id,string pass)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] =new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            param[1] = new SqlParameter("@PASS", SqlDbType.VarChar, 50);
            param[1].Value = pass;
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("st_login", param);
           
            return dt;
         
        }
        internal void AddUser(string id,string pass,string fullName)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[]param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            param[1] = new SqlParameter("@pass", SqlDbType.VarChar, 50);
            param[1].Value = pass;
        
            param[2] = new SqlParameter("@FullName", SqlDbType.NVarChar, 100);
            param[2].Value = fullName;
            da.excutequery("AddUser", param);
            da.close();
        }




        internal DataTable SelectUsers()
        {
            DataAccessLayer da = new DataAccessLayer();
           
            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("SelectUsers", null);

            return dt;

        }

        internal void UpdateUsers(string id, string pass,string fullname)
        {

            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            param[1] = new SqlParameter("@pass", SqlDbType.VarChar,50);
            param[1].Value = pass;
            param[2] = new SqlParameter("@fullname", SqlDbType.NVarChar, 50);
            param[2].Value = fullname;
            da.excutequery("UpdateUsers", param);
            da.close();
        }

        internal void deleteusers(string id)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            da.excutequery("deleteusers", param);
            da.close();
        }

        internal void ADDLogin(string id,string login)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            param[1] = new SqlParameter("LogIn", SqlDbType.NVarChar, 50);
            param[1].Value = login;
            da.excutequery("ADDLogin", param);
            da.close();
        }

        internal DataTable LastIDLogin()
        {
            DataAccessLayer da = new DataAccessLayer();

            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("LastIDLogin", null);

            return dt;

        }
        internal void ADDLogOut( int idLOgin,string idUser, string logOut)
        {
            DataAccessLayer da = new DataAccessLayer();
            da.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id_Login", SqlDbType.Int);
            param[0].Value = idLOgin;
            param[1] = new SqlParameter("@id_User", SqlDbType.NVarChar, 50);
            param[1].Value = idUser;
            param[2] = new SqlParameter("@Log_Out", SqlDbType.NVarChar, 50);
            param[2].Value = logOut;
            da.excutequery("ADDLogOut", param);
            da.close();
        }


        internal DataTable SelectLogin(string id)
        {
            DataAccessLayer da = new DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[0].Value = id;

            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("SelectLogin", param);

            return dt;

        }

        internal DataTable selectIDUser()
        {
            DataAccessLayer da = new DataAccessLayer();

            da.open();
            DataTable dt = new DataTable();
            dt = da.selected("selectIDUser", null);

            return dt;

        }
    }
}
