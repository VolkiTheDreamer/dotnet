using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtility
{
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            //kullanımı str.WordCount()
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static void Yazdır(this String str)
        {
            System.Diagnostics.Trace.WriteLine(str);
        }

        //public static void DizimsiYazdır(this IEnumerable dizimsi)
        //{
        //    foreach (var item in dizimsi)
        //    {
        //        System.Diagnostics.Trace.WriteLine(item);
        //    }            
        //}
    }
}
