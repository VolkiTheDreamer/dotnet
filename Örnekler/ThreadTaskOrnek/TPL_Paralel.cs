using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ThreadOrnek
{
    class TPL_Paralel
    {
        public static void Ana()
        {
            //parallel sınıfındaki for v.s metodları thread-blockingdir,yani sonraki satıra geçmezler, bu yüzden wait gibi birşeye gerek yoktur.
            int[] numbers = Enumerable.Range(1, 100000).ToArray();

            #region Parallel.For Örneği

            // Action temsilcisinin söylediği kurallara uygun olaraktan, lambda operatöründen yararlanılır.
            Console.WriteLine("For\n");
            Parallel.For(1, numbers.Length,
                i =>
                {
                    if (i % 1500 == 0)
                        Console.Write("{0} ", i.ToString());
                }
            );

            Console.WriteLine("\n\nFor(İçeriden başka metod çağırarak)\n");
            Parallel.For(1, numbers.Length,
                (i) => {
                    if (i % 1500 == 0)
                        Task1(i);
                }
            );

            #endregion

            #region Parallel.ForEach Örneği

            /* ForEach metodunun 19 aşırı yüklenmiş versiyonu vardır. İlk dikkati çeken nokta, IEnumerable<T> generic arayüzünü(interface) implemente eden referanslarıda parametre olarak almasıdır. Dolayısıyla, her koleksiyon veya diziye uygulanabilir. */
            Console.WriteLine("\n\nForEach Örneği\n");
            Parallel.ForEach(numbers, number =>
            {
                if (number % 1500 == 0)
                    Console.Write("{0} ", number.ToString());
            }
            );

            #endregion

            #region Parallel.Invoke Örneği

            Console.WriteLine("\n\n");

            // Parallel.Invoke metodu Action temsilcisi tipinden referanslar alan bir diziyi parametre olarak kullanır.
            // Bu şekilde istenildiği kadar metodun paralel olarak başlatılması sağlanabilir            
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Toplam Tek sayı hesabı başladı\n");
                    Console.WriteLine("Managed Thread ID {0} ", Thread.CurrentThread.ManagedThreadId.ToString());
                    OddCount(numbers);
                    Console.WriteLine("Toplam Tek sayı bulma işi tamamlandı\n");
                },
                () =>
                {
                    Console.WriteLine("Toplam Çift sayı hesabı başladı\n");
                    EvenCount(numbers);
                    Console.WriteLine("Managed Thread ID {0} ", Thread.CurrentThread.ManagedThreadId.ToString());
                    Console.WriteLine("Toplam Çift sayı bulma işi tamamlandı\n");
                }
                ,
                () =>
                {
                    Console.WriteLine("9 ile bölünenlerin toplamını bulma işi başladı\n");
                    NineCount(numbers);
                    Console.WriteLine("Managed Thread ID {0} ", Thread.CurrentThread.ManagedThreadId.ToString());
                    Console.WriteLine("9 ile bölünenlerin toplamını bulma işi tamamlandı\n");
                }
        );

            #endregion
        }

        static void Task1(int number)
        {
            // Değişiklik işlemler
            Console.Write("{0} ", number.ToString());
        }
        static void EvenCount(int[] numbers)
        {
            int result = (from number in numbers
                          where number % 2 == 0
                          select number).Count();
            Console.WriteLine("\tDizi içerisinde {0} adet ÇİFT sayı vardır\n", result.ToString());
        }
        static void OddCount(int[] numbers)
        {
            int result = (from number in numbers
                          where number % 2 != 0
                          select number).Count();
            Console.WriteLine("\tDizi içerisinde {0} adet TEK sayı vardır\n", result.ToString());
        }
        static void NineCount(int[] numbers)
        {
            int result = (from number in numbers
                          where number % 9 == 0
                          select number).Count();
            Console.WriteLine("\tDizi içerisinde {0} adet 9 ile bölünebilen sayı vardır\n", result.ToString());
        }

    }
}




 
