using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonVariable
{
    public static class GlobalUser
    {
        private static string loginName = "";
        private static string firstName = "";
        private static string lastName = "";

        public static string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        public static string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public static string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
