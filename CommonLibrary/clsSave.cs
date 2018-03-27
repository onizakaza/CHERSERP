using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class clsSave
    {
        public class FieldValue
        {
            public string Field { get; }
            public string Value { get; }

            public FieldValue(string field,string value)
            {
                Field = field;
                Value = value;
            }
        }
        public String table;
       
        private List<FieldValue> fieldValues = new List<FieldValue>();

        private List<FieldValue> fieldKeys = new List<FieldValue>();

        public clsSave(string TableName)
        {
            table = TableName;
        }

        public void SetValue(string field, string value)
        {
            if (value == "")
                value = "''";
            fieldValues.Add(new FieldValue(field, value));
        }

        public void SetKey(string field, string value)
        {
            fieldKeys.Add(new FieldValue(field, value));
        }

        public string SQLInsert()
        {
            
                string strSQL = "INSERT INTO " + this.table + " ( ";

                int count = 0;
                foreach (FieldValue fv in fieldValues)
                {
                    strSQL += fv.Field;
                    count += 1;

                    if (count < fieldValues.Count)
                    {
                        strSQL += ", ";
                    }
                }
                strSQL += " ) VALUES ( ";

                count = 0;
                foreach (FieldValue fv in fieldValues)
                {
                    strSQL += fv.Value;
                    count += 1;

                    if (count < fieldValues.Count)
                    {
                        strSQL += ", ";
                    }
                }
                strSQL += " )";

                fieldValues.Clear();
                return strSQL;

            
            
        }

        public string SQLUpdate()
        {
            string strSQL = "UPDATE " + this.table + " SET ";

            int count = 0;
            foreach (FieldValue fv in fieldValues)
            {
                strSQL += fv.Field + " = " + fv.Value;
                count += 1;
                if (count < fieldValues.Count)
                {
                    strSQL += ", ";
                }
            }

            strSQL += " WHERE 1 = 1 AND ";

            foreach (FieldValue fk in fieldKeys)
            {
                strSQL += fk.Field + " = " + fk.Value;
                count += 1;
                if (count < fieldValues.Count)
                {
                    strSQL += " AND ";
                }
            }

            return strSQL;
        }

        
    }
    
}
