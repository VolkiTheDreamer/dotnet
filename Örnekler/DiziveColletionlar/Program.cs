using System;
using System.Collections.Generic;
using MyUtility;

namespace DiziveColletionlar
{
    class Program
    {        
        static void Main(string[] args)
        {
            goto atla;
            
            //***************DİZİLER**********************
            Diziler Diz = new Diziler();

            Console.WriteLine("TEK BOYUTLU DİZİLER");
            Diz.TekBoyutlular();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("ÇOK BOYUTLU DİZİLER");
            Diz.CokBoyutlular();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("JAGGED DİZİLER");
            Diz.Jagged();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("ÇEŞİTLİ METODLAR");
            Diz.ÇeşitliMetodlar();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            //***********COLLECTIONLAR*******************
            Collectionlar col = new Collectionlar();

            Console.WriteLine("ARRAYLİST METODLAR");
            col.ArrayListMetod();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("HASTABLE METODLAR");
            col.HastableMetod();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("SORTEDLİST METODLAR");
            col.SortedListMetod();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("STACK METODLAR");
            col.StackMetod();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("QUEUE METODLAR");
            col.QueueMetod();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            //*******GENERECİLER***********
            Genericler gnrc = new Genericler();
            
            Console.WriteLine("LİST METODLAR");
            gnrc.ListMetods();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();
   atla:
            Console.WriteLine("SORTEDDICT<> METODLAR");
            SortedDictionary_WordCounting.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("benim SORTEDDICT<> METODLAR");
            KelimeSayac.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            //*******TREE NODE, DIRECTORY v.s***********

            Console.WriteLine("TREE NODE1");
            TreeExample.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("TREE NODE2-hard drive");
            DirectoryTraverser.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();



            //**************IENUMERABLE VE YIELD*****************            

            Console.WriteLine("Ienumrable Örnek");
            IEnumerableOrnek.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("Yield Örnek");
            YieldOrnek.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();

            Console.WriteLine("Kendi Yield Örneğim");
            KendiTestSınıfım.Ana();
            Console.WriteLine("\r\n*********************************************************");
            Console.Read();
                        
            Console.ReadLine();
        }

        

    }
}
