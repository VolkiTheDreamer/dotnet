#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Program
    {
        static void DoWork()
        {
            Console.Write("x koordinat gir:");
            int kox = int.Parse(Console.ReadLine());
            Console.Write("y koordinat gir:");
            int koy = int.Parse(Console.ReadLine());
            Point nokta1 = new Point();
            Point nokta2 = new Point(kox, koy);
            //parametre olarak nesne alan bir metod olan uzaklıkolcten yararlancaz. nokta1in metodudur bu ve nokta1e göre nokta2 nerde kalıyor, onu ölçer
            double uzaklik = nokta1.UzaklıkOlc(nokta2);
            Console.WriteLine("ilk nokta koordinatları:{0} ve {1}", nokta1.DegerGosterx(), nokta1.DegerGostery());
            Console.WriteLine("ikinci nokta koordinatları:{0} ve {1}", kox, koy);
            Console.WriteLine("iki nokta arasındaki fark:{0}", uzaklik);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
