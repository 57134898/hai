using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static string GetCellValue(DataGridViewCell cell)
        {
            if (cell.Value == null)
                return string.Empty;
            return cell.Value.ToString();
        }
    }
}
