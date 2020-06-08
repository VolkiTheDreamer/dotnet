using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolkansUtility
{
    public static class Extensions
    {
        public static int WordCount(this String str)
        {
            //kullanımı str.WordCount()
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
