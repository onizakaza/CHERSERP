using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonLibrary
{
    public class clsPermission
    {
        private clsDatabase db = new clsDatabase();
        
        public string GetMainMenu(string loginName)
        {
            string strSQL = "select distinct MenuName from VW_SY_UserPermission where LoginName = '"+ loginName + "' and ParentName is null";
            DataTable dt = db.QueryDataTable(strSQL);
            string returnStr = "";

            foreach (DataRow row in dt.Rows)
            {
                returnStr += row[0].ToString().Trim()+"#";
            }
            returnStr.Remove(returnStr.Length-1, 1);
            return returnStr;
        }
        public string GetSubMenu(string loginName,string ParentName)
        {
            string strSQL = "select distinct MenuName from VW_SY_UserPermission where LoginName = '" + loginName + "' and ParentName = '"+ParentName+"'";
            DataTable dt = db.QueryDataTable(strSQL);
            string returnStr = "";

            foreach (DataRow row in dt.Rows)
            {
                returnStr += row[0].ToString().Trim() + "#";
            }
            if (returnStr.Length > 0)
            {
                returnStr.Remove(returnStr.Length - 1, 1);
            }
            return returnStr;
        }

        public string GetListItem(string SubMenu)
        {
            string strSQL = "select ListItemName,TabID,EXEName from VW_SY_MenuListItem where MenuName = '" + SubMenu + "'";
            DataTable dt = db.QueryDataTable(strSQL);
            string returnStr = "";

            foreach (DataRow row in dt.Rows)
            {
                returnStr += row[0].ToString().Trim() +","+ row[1].ToString().Trim() + "," + row[2].ToString().Trim() + "#";
            }
            if (returnStr.Length > 0)
            {
                returnStr.Remove(returnStr.Length - 1, 1);
            }
            return returnStr;
        }
    }
}
