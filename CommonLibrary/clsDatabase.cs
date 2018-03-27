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
        private bool isTransStart = false;

        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlTransaction Trans;

        public clsDatabase()
        {
            conn.ConnectionString = sqlCon;
        }

        public string ConnectionString
        {
            get { return sqlCon; }
            set { sqlCon = value; }
        }

        public DataTable QueryDataTable(string strSQL)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch
            {
                throw new Exception("Server Connection Failed");
            }
            cmd.CommandText = strSQL;
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

        public Boolean QueryExecute(string strSQL)
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = sqlCon;
                conn.Open();


                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                cmd.ExecuteNonQuery();
                return true; //*** Return True ***//
            }
            catch (Exception)
            {
                return false; //*** Return False ***//
            }
        }

        public void TransStart()
        {
            conn = new SqlConnection();
            conn.ConnectionString = sqlCon;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            Trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            isTransStart = true;
        }


        public void TransExecute(String strSQL)
        {
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.Transaction = Trans;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
        }

        public object TransQuery(String strSQL)
        {
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.Transaction = Trans;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;

            // create data reader
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return cmd.ExecuteScalar();

            
        }


        public void TransRollBack()
        {
            if (isTransStart)
            {
                Trans.Rollback();
                conn.Close();
            }
        }

        public void TransCommit()
        {
            Trans.Commit();
            conn.Close();
            isTransStart = false;
        }





        public string SQLText(string strText)
        {
            string newStr = strText;
            newStr = newStr.Replace("'","'+char(39)+'");
            newStr = newStr.Replace("+''+", "+");
            newStr = "'" + newStr + "'";
            newStr = newStr.Replace("''", "");
            newStr = newStr.Trim('+');
            return newStr;
        }
        public string SQLNumber(string strNumber)
        {
            try
            {
                string newStr = strNumber;
                double d= 0;
                newStr = newStr.Replace(",", "");
                if (!double.TryParse(newStr, out d))
                { throw new Exception("Invalid SQLNumber"); }
                else
                {
                    return newStr;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string SQLCheckBox(bool boolCheckBox)
        {
            if(boolCheckBox)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public string SQLDateTime(DateTime dt)
        {
            return "";
        }
    }
}
