using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using CommonLibrary;

namespace CommonLibrary
{
    public class clsRunningNo
    {
        public string GetNextNumber(ref clsDatabase db, string Code)
        {
            string strSQL = "SELECT NextNo,Format From SY_RunningNo WITH (XLOCK,ROWLOCK) Where EXEName = " + db.SQLText(Code).Trim();
            int nextNo = int.Parse(db.TransQuery(strSQL).ToString());
            strSQL = "SELECT Format From SY_RunningNo WITH (XLOCK,ROWLOCK) Where EXEName = " + db.SQLText(Code).Trim();
            string format = db.TransQuery(strSQL).ToString();

            string ret = RunningFormat(format, nextNo);

            strSQL = "Update SY_RunningNo SET NextNo = NextNo+1 WHERE EXEName = " + db.SQLText(Code).Trim();
            db.TransExecute(strSQL);
            return format;
        }

        private string RunningFormat(string format,int nextNo)
        {
            int count = format.Count(x => x == '#');
            string ret = nextNo.ToString().PadLeft(count,'0');
            return count.ToString();

            int a = format.IndexOf('#');


        }
    }
}
