using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziveColletionlar
{
    class YieldOrnek
    {
        static public IEnumerable<string> VerileriGetir()
        {
            string[] Gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            List<string> gunler = new List<string>();
            foreach (var Gun in Gunler)
                gunler.Add(Gun);
            return gunler;
        }

        static public IEnumerable<string> VerileriGetir2()
        {
            string[] Gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            foreach (var Gun in Gunler)
                yield return Gun;
        }

        static public IEnumerable<string> VerileriGetir3()
        {
            yield return "Pazartesi";
            yield return "Salı";
            yield return "Çarşamba";
            yield return "Perşembe";
            yield return "Cuma";
            yield return "Cumartesi";
            yield return "Pazar";
            yield break;
            yield return "falancagün_bu çalışmaz";//unreachable
        }

        
        public static void Ana()
        {
            foreach (var Gun in VerileriGetir())
                Console.WriteLine(Gun);

            Console.WriteLine("*************");

            foreach (var Gun in VerileriGetir2())
                Console.WriteLine(Gun);

            Console.WriteLine("*************");

            foreach (var Gun in VerileriGetir3())
                Console.WriteLine(Gun);            
        }
    }
}
