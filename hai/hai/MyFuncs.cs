using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hai
{
    public class MyFuncs
    {
        public static decimal StringToDcimal(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            return decimal.Parse(str);
        }
    }
}
