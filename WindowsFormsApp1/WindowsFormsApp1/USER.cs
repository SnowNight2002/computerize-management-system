using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BLtd
{
    public class USER
    {
        private string _empid;
        private string _name;
        private string _password;
        private string _role;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public string EmpId
        {
            get { return _empid; }
            set { _empid = value; }
        }
    }
}
