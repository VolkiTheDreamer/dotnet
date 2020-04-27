using System;
using System.Collections.Generic;
using System.Collections;
using MyUtility;

namespace DiziveColletionlar
{
    class Collectionlar
    {        
        ArrayList ar1 = new ArrayList() { 1, 2, 3, 4 };
        ArrayList ar2 = new ArrayList() { 5, 6, 7 };
        ArrayList ar3 = new ArrayList() { "a", "b" };
        ArrayList ar4 = new ArrayList() { 0.25, 3.14 };

        Hashtable ht1 = new Hashtable() { { 1, "one" }, { 2, "two" } };
        Hashtable ht2 = new Hashtable() { { "bir", "one" }, { "iki", "two" } };
        Hashtable ht3 = new Hashtable();

        public void ArrayListMetod()
        {   
            ar1.AddRange(ar2);//sona ekler
            Utilities.DiziYazdır(ar1,"ar1");
            ar1.InsertRange(2, ar3);//araya eklenir
            Utilities.DiziYazdır(ar1, "ar1");
            ar1.SetRange(3, ar4);//ilgili indekse varolanın üzerine yapıştırır
            Utilities.DiziYazdır(ar1, "ar1");
            //ar1.Sort();/*hata verir.Bir ArrayList aynı liste içinde herhangi tipte nesneler saklayabilmesine rağmen, bir listeyi sıralarken ya da ararken bu nesnelerin karĢılaĢtırılabilir olmaları gereklidir. Söz geliĢi, önceki programda eğer liste bir karakter katarı içermiĢ olsaydı, program kural dıĢı bir durum üretmiĢ olurdu. (Her Ģeye ragmen, karakter katarlarını ve tamsayıları karĢılaĢtırmaya imkan veren özel karĢılaĢtırma metotları oluĢturmak mümkündür.*/
            ar1.RemoveRange(2, 3);
            Utilities.DiziYazdır(ar1, "ar1");
            ar2[2] = 99;
            Utilities.DiziYazdır(ar1, "ar1");//ar2 değişse bile ar1 sabit,çünkü artık ref değil, sabit eklendi
            object[] objArr = ar1.ToArray();//Neden gereksin? Mesela belirli işlemler için daha hızlı iĢlem süreleri elde etmek isteyebilirsiniz
            int[] ia = (int[])ar1.ToArray(typeof(int));//bu da ikinci şekli.ToArray()‟in dönüĢ tipi Array olduğu için dizinin içeriği yine de int[]‟e dönüĢtürülmelidir.
            Utilities.DiziYazdır(objArr, "objArr");
            Console.WriteLine("ar1 capcty:" + ar1.Capacity);
            ar1.TrimToSize();
            Console.WriteLine("ar1 capcty after trim:" + ar1.Capacity);

            /*
             diziler gbi sort edildikten sonra BinarySearch ile aranabilir.
             */
        }

        public void HastableMetod()
        {
            /*Ilisti inherit etmez. bu yüzden indeksle erişelemez
             * 
             * Hashtable ile sıralı bir koleksiyon desteklenmediği için elde edilen anahtar ya da değer koleksiyonunun belirli bir sırası yoktur. bir hash tablosu, hashing denilen bir mekanizmayı kullanarak bilgileri saklar. Hashing‟de bir anahtarın bilgi taĢıyan içeriği, hash kod denilen benzersiz bir değeri belirlemek için kullanılır. Hashing‟in avantajı; arama, alma ve ayarlama iĢlemlerinin çalıĢma sürelerinin büyük kümeler için bile sabit olarak kalmasına olanak tanımasıdır.
             
             * Hashtable, anahtar/deger çiftlerini bir DictionaryEntry yapısı Ģeklinde saklar.fakat, çoğu zaman bu durumdan direkt olarak haberiniz olmayacaktır, çünkü söz konusu özellikler ve metotlar, anahtar ve değerlerle ayrı ayrı çalıĢmaktadırlar. Söz geliĢi, bir Hashtable‟a bir eleman eklerseniz, iki argüman alan Add()‟i çağırırsınız
             */
             
            ht1.Add(3, "three");
            ht2.Add("üç", "three");
            ht3["akdeniz"] = 7010;//doğrudan ekleme, ama indeksle değil dikkat et,key ile ekliyoruz
            Utilities.DiziYazdır(ht1, "ht1");

            Console.WriteLine("3 Key'ini içeroymu:"+ht1.ContainsKey(3));
            Console.WriteLine("5 Valuesunu içeroymu:" + ht1.ContainsValue("beş"));
            Console.WriteLine(ht1[3]);//burdaki 3 index değil key. hashlerde sıra olmadığı için index de yok
        }

        public void SortedListMetod()
        {
            /*Ilisti inherit etmez. bu yüzden indeksle erişelemez
             * SortedList, anahtarların değerlerine bağlı olarak anahtar/değer çiftlerini sıralı olarak saklayan bir koleksiyon oluĢturur.yani hashtableın sıralı versiyonu. birçok özellik ve metod aynen geçerli*/
            SortedList sl1 = new SortedList() { { 2, "two" }, { 1, "one" }, { 99, "doksandokuz" } }; //önce 2 eklenmiş olsa bile bunu kendi çinde sıralar be başa "1,one" ikilisini alır 

            Console.WriteLine("sl1deki eleman sayısı: "+sl1.Keys.Count);
            Console.WriteLine("99 keyiinin valuseu:"+sl1[99]);//burdaki 99, index değil, key. indexli yazmak için getbyindex
            Console.WriteLine("0. indeksteki value:"+sl1.GetByIndex(0));//value döndürür
            //sl1.SetByIndex(10, "osman");//hata veriri. çünkü varolan bir indexteki elemanın valluesını değiştirir
            Console.WriteLine("0. indeksteki key:" + sl1.GetKey(0));//key döndürür
            ///bu yukrıdai ikisini DicitonaryEntry tanımlayp tek seferde de alabiliriz, de.Value ve de.Key diye
            ///bu ikisinin tersini yani key/valuden indexii şöyle buluryz
            Console.WriteLine("99 keyinin indeksi:"+sl1.IndexOfKey(99));
            Console.WriteLine("üç valuseunun indeksi:"+sl1.IndexOfValue("üç"));
            var keyler = sl1.GetKeyList();
            IList valuler = sl1.GetValueList(); 
            Utilities.DiziYazdır(sl1, "sl1");
        }

        public void StackMetod()
        {
            /*ilk giren son çıkar*/
            Stack stack1 = new Stack();//{} ile baştan ekleme yok. Add metodu da yok zaten
            stack1.Push("altın");
            stack1.Push("gümüş");
            stack1.Push("zümrüt");
            stack1.Push("bakır");
            Console.WriteLine("en son yani en üstteki eleman çıkmadan önceki eleman sayısı:"+stack1.Count);
            Console.WriteLine(stack1.Pop());//en sondakini çıkar ve döndürür as object.
            Console.WriteLine("en son yani en üstteki eleman çıktıktan sonraki eleman sayısı:" + stack1.Count);
            Console.WriteLine("şimdi en üstteki eleman:"+stack1.Peek());
        }

        public void QueueMetod()
        {
            /*ilk giren ilk çıkar*/
            Queue kuyruk = new Queue();
            kuyruk.Enqueue(1);
            kuyruk.Enqueue(2);
            kuyruk.Enqueue(3);
            Console.WriteLine("en baştaki eleman:"+kuyruk.Peek());
            int i=(int)kuyruk.Dequeue();//en baştakini koparır ve döndürür as object. cast etmen lazım. generic versiyonda buna gerek yok
            Console.WriteLine("şimdi en baştaki eleman:" + kuyruk.Peek());
        }
              
    }
}
