using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veritipi_ornek_reftipi
{//bu örnek istediğim gibi çalışmadı, ref tiplerini ayrıca incele. sınıf_metod örneğinde
    //ütü için çalışıtı ama burda string için çalışmadı
    class Program
    {
        static void Main(string[] args)
        {
            /** değer tipi olanlarda a=2 b=3 olsun, sonra a=b deyine a=3 olmuş oldu
            * sonra b=5 yapınca a=b oldugu için a=5 olmuyor, o geçti artı geride kaldı 
            * ama nesnelerde ve stringler böyle değil, ütü2=ütü1 diyince, 
            * artık ütü1 değiştikçe ütü2 de dğeieşcek*/
            string a = "Volkan";
            Console.WriteLine("a="+a);
            string b = "Meltem";
            Console.WriteLine("b="+b);
            b = a;
            Console.WriteLine("b'yi aya eşitledik. b artık= " + b);
            b = "Doruk";
            Console.WriteLine("a=" + a);
            Console.WriteLine("b=" + b);
            a = "Doga";
            Console.WriteLine("a=" + a);
            Console.WriteLine("b=" + b);
            //Console.WriteLine("b değişti ve Doruk oldu. a artık= " + a);

            Main2();
            Console.ReadLine();
            Console.WriteLine("şimdi nullable örnek geliyor");
            nullable_ornek();
            Console.ReadLine();


        }

        static void Main2()
        {
            int value = (int)1.5; // Cast 1.
            Console.WriteLine(value);

            object val = new StringBuilder();
            if (val is StringBuilder) // Cast 2.
            {
                StringBuilder builder = val as StringBuilder; // Cast 3.
                Console.WriteLine(builder.Length == 0);
            }

            
        }

        static void nullable_ornek()
        {
            {
                //normalde int, long giibi valu type'lar null değer almaz. null sadece ref tiplerde olur.
                //ancak bu rnekteki gibi nullable tnıamlarsan olur.
                int? num1 = null;
                int? num2 = 45;
                double? num3 = new double?();
                double? num4 = 3.14157;

                bool? boolval = new bool?();

                // display the values

                Console.WriteLine("Nullables at Show: {0}, {1}, {2}, {3}", num1, num2, num3, num4);
                Console.WriteLine("A Nullable boolean value: {0}", boolval);
                Console.ReadLine();
            }
        }
    }
}
