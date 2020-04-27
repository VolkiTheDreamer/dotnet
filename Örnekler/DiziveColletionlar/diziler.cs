using System;
using System.Collections.Generic;
using System.Linq;
using MyUtility;

namespace DiziveColletionlar
{
    class Diziler
    {
        public void TekBoyutlular()
        {
            int[] d1 = new int[0];
            int[] d2 = new int[] { 10, 20, 30 };
            d1 = d2;//d1 ilk başta sııfır boyutluydu, ama yeniden yaratlmış oldu, 3 boyutlu

            Console.WriteLine(d1[0]);
            
            Dictionary<int[], string> Diziler = new Dictionary<int[], string>();

            int[] dizi1;// Null dizi. Hatalı değildir. Tüm dizilerin default değeri Null'dır, çünkü diziler referans tipli nesnelerdir. İçeriği belirtilmediği için bu dizinin de şuanki değeri null'dır.
            int[] dizi1b;//bu da null
            //int[] dizi1 = new int[];//bu ise hatalıdır, ya boyut beliritlmeli ya da bi eleman.


            //Klasik tanımlama. sadece boyut belirtilen tanımlama şekli en yaygın halidir
            int[] dizi2 = new int[4];
            Diziler.Add(dizi2, "dizi2");

            //elemanalrın baştan belirtilmiş halleri'
            int[] dizi3 = new int[4] { 2, 4, 6, 8 }; //en uzun hali
            Diziler.Add(dizi3, "dizi3");
            int[] dizi4 = new int[] { 2, 4, 6, 8 }; //boyut belirtmeye gerek yok
            Diziler.Add(dizi4, "dizi4");
            int[] dizi5 = new[] { 1, 2, 3, 4, 5, 6 };//int demeye de gerek yok
            Diziler.Add(dizi5, "dizi5");
            int[] dizi6 = { 1, 2, 3, 4, 5, 6 };//new demeye de gerek yok, sadece leelmanlar yeterli
            Diziler.Add(dizi6, "dizi6");
            var dizix = new[] { 1,2, 3 };//var ile tanımlyacaksan new[] de demelisin


            //boş ve null diziler
            int[] dizi7 = { }; //boş kümeli tanımlanıyor
            Diziler.Add(dizi7, "dizi7");
            int[] dizi8 = new int[0]; // Boş yani sıfır elemanlı dizi
            Diziler.Add(dizi8, "dizi8");

            //dizi kopyalama
            /*
             The Clone() method returns a new array (a shallow copy) object containing all the elements in the original array. The CopyTo() method copies the elements into another existing array. Both perform a shallow copy. A shallow copy means the contents (each array element) contains references to the same object as the elements in the original array. A deep copy (which neither of these methods performs) would create a new instance of each element's object, resulting in a different, yet identical object. deep copy için for döngüsü ile tek tek ataman lazım

            özetle
            1- CopyTo require to have a destination array when Clone return a new array.
            2- CopyTo let you specify an index (if required) to the destination array.
            
            bi de aşağıda Array.Copy var
             */
            dizi1 = new int[dizi3.Length];//Copy yapmadan önce new ile başlatılması lazım. dizi1=dizi3 tarzı atamalarda ise başltaymaya gerek yok, ama onun sakıncaıs bir alt satırda
            dizi3.CopyTo(dizi1, 0);//en baştaki null diziye başka diziyi atadık. Eğer direkt dizi1=dizi3 deseydik, dizilerin referans tipli olmasında dolayı dicitinaryde "Aynı Key" hatası alırdık.
            Diziler.Add(dizi1, "dizi1");
            Console.WriteLine("dizi1'in 0 nolu elemanı:" + dizi1[0]);


            dizi1b = (int[])dizi3.Clone();//Clone metodu object döndürdüğü için cast edilmeli. Clone öncesinde new ile başlatmaya gerek yok
            Diziler.Add(dizi1b, "dizi1b");
            Console.WriteLine("dizi1b'nin 0 nolu elemanı:" + dizi1b[0]);


            foreach (KeyValuePair<int[], string> kv in Diziler)
            {
                Console.WriteLine(kv.Value + " eleman sayısı yazdırılıyor: " + kv.Key.Length);
                Utilities.DiziYazdır(kv.Key, kv.Value);
            }
        }

        public void CokBoyutlular()
        {
            int[,] cokb1 = new int[3, 4];
            cokb1[0, 0] = 100;
            cokb1[0, 1] = 200;
            cokb1[1, 0] = 300;

            for (int i = 0; i < cokb1.GetLength(0); i++)
            {
                for (int k = 0; k < cokb1.GetLength(1); k++)
                {
                    Console.WriteLine("(" + i + "," + k + "):" + cokb1[i, k]);
                }
            }
        }

        public void Jagged()
        {
            int[][] jagged1 = new int[3][];//ikinci boyut için sayıya gerek yok, legal de değil            
            for (int i = 0; i < jagged1.Length; i++)
            {
                jagged1[i] = new int[4];//3 diziyi de 4 boyutlu yaptım
            }

            //biri 3 diğeri 4 boyutlu dizi içeren 2 boyutlu bir dizi
            int[][] jagged2 = new int[2][] { new int[] { 92, 93, 94 }, new int[] { 85, 66, 87, 88 } };

            int[][] jagged3 = new int[3][];
            jagged3[0] = new int[4];
            jagged3[1] = new int[4];
            jagged3[2] = new int[4];
            for (int i = 0; i < 4; i++)
            {
                jagged3[0][i] = i;//3 dizinin sadece ilkine değer atıyorum
            }
            for (int i = 0; i < 4; i++)
            {
                jagged3[1][i] = i;//3 dizinin ikincisine değer atıyorum
            }
            for (int i = 0; i < 4; i++)
            {
                jagged3[2][i] = i;//3 dizinin sonuncusuna değer atıyorum
            }

            Console.WriteLine(jagged3[2][1]);
        }

        public void ÇeşitliMetodlar()
        {
            int[] dizi = new int[] { 12, 4, 86, 8 }; //boyut belirtmeye gerek yok
            Console.WriteLine("Sort öncesi:" + dizi[0]);
            Array.Sort(dizi);
            Console.WriteLine("Sort sonrası:" + dizi[0]);

            int idx = Array.BinarySearch(dizi, 12); //sıralı olmalı çünkü hep kümenin ortasından başlar ve hangi yarısında olduğuna bakar
            /*
             contains
             indexof
             find--predicate alır, LINQ
             findalld--predicate alır, LINQ
             existsd--predicate alır, LINQ
             */
            Console.WriteLine("Index of 12 is :" + idx);

            int[] dizi2 = new int[] { 33, 45, 89, 98, 78 };
            int[] dizi3 = new int[] { 33, 45, 89, 98, 78 };
            Array.Copy(dizi, dizi2, dizi.Length); //direkt üzerine yapışıtıyor, 33,45,89 ve 98 üzerine 4,8,12,86 gelir. o yüzden dizi2nin en az dizi kadar boyuty olmalı
            Array.Copy(dizi, 2, dizi3, 3, 2); //dizi3ün 3.elemanının olduğu yere, dizi'nin 2.elemandan sonraki 2 karakteri yapıştırır
            Utilities.DiziYazdır(dizi, "dizi");
            Utilities.DiziYazdır(dizi2, "dizi2");
            Utilities.DiziYazdır(dizi3, "dizi3");
            Console.WriteLine("99 varsa indexi:" + Array.IndexOf(dizi, 99));
            dizi[2] = 99;
            Console.WriteLine("99 varsa indexi:" + Array.IndexOf(dizi, 99));
            dizi.SetValue(100, 2);//dizi[2]=100 demenin bi diğer yolu
            Console.WriteLine(dizi.GetValue(2));
        }
    }
}
