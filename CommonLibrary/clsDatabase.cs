using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CommonLibrary
{
    public class clsDatabase
    {

        private string sqlCon = @"Server=.\sqlexpress;Database=CHERSERP;User Id=CHERSERP;Password=CHERSERP;";
        private string sqlUser = "";
        private string sqlPassword = "";

        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();


        public clsDatabase()
        {
            conn.ConnectionString = sqlCon;
        }

        public string ConnectionString
        {
            get { return sqlCon; }
            set { sqlCon = value; }
        }

        public DataTable QueryDataTable(string q)
        {
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Exception("Server Connection Failed");
            }
            cmd.CommandText = q;
            cmd.Connection = conn;
            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            da.Dispose();

            return dt;
        }

    }
}
