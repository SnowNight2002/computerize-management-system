using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
        class userdetail
        {
            private static string EmpName;

            public void setUname(string name)
            {
            EmpName = name;
            }
            public string getUname()
            {
                return EmpName;
            }
        }
  
}
