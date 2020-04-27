using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUtility;

namespace lambda_anonymous_functactionpredicate
{
    /*LINQ sorgusu yaptığın koleksiyonda işlem yapana kadar geçen sürede bir değişklik olursa bunu da görürsün,yani liste dnamiktir.
     bunu istemiyorsan ilgili koleksiyonu ToList veya ToArray ile sabitle.

     As a rule using LINQ and extension methods is slower than using direct operations over a collection of elements, so beware of using LINQ when processing large collections or the performance is critical.
    */
    class LINQ_Lambda2
    {
        //bi de structtan dizi yapalım farklılık olarak
        Şirket[] şirketler = new Şirket[] {
                new Şirket("Akbank","İstanbul", 20000),
                new Şirket("Vakıfbank","ankara", 15000),
                new Şirket("Garanti","İstanbul", 25000),
                new Şirket("Abank","İstanbul", 4000),
                new Şirket("ykb","izmir", 25000)
            };

        public void Ana()
        {
            //anonim türden oluşan bir dizi yaratalım. bunu class sevisyesinde yaratamıyrum, çünkü var kelimesini kabl etmiyor. class seviyesinde tip ismi mutlaka gerekli.

            var kişiler = new[] {
                new { İsim="volkan", Soyisim="yurtseven" ,Şirket="Akbank" },
                new { İsim="meltem", Soyisim="yurtseven" ,Şirket="Vakıfbank" },
                new { İsim="doruk", Soyisim="yurtseven" ,Şirket="Garanti" },
                new { İsim="doğa", Soyisim="yurtseven" ,Şirket="Garanti" },
                new { İsim="Veli", Soyisim="baba" ,Şirket="Garanti" },
                new { İsim="doruk", Soyisim="huhu" ,Şirket="abank" },
                new { İsim="doğa", Soyisim="lulu" ,Şirket="ykb" },
            };


            //Select ile veriyi seç
            IEnumerable<string> isimler = kişiler.Select(kişi => kişi.İsim + "  " + kişi.Soyisim);
            Utilities.DiziYazdır(isimler, "isimler");

            IEnumerable firmaisimleri = şirketler.Select(şrk => şrk.şirketAd);
            Utilities.DiziYazdır(firmaisimleri, "firmaisimleri");

            //Where ile veriyi filtreleme
            var filtreliİsimler = kişiler.Where(kişi => kişi.İsim.StartsWith("V", StringComparison.CurrentCultureIgnoreCase));
            Utilities.DiziYazdır(filtreliİsimler, "filtreliİsimler");

            var sadeceisim = filtreliİsimler.Select(kişi => kişi.İsim + "  " + kişi.Soyisim);
            Utilities.DiziYazdır(sadeceisim, "sadeceisim");

            //sıralama
            var sıralıİsimler = kişiler.OrderBy(kişi => kişi.İsim).Select(kişi => kişi.İsim + "  " + kişi.Soyisim);
            Utilities.DiziYazdır(sıralıİsimler, "sıralıİsimler");

            //gruplama(bu biraz incelikli. Key kullanıysun. ilk dönen şey hala bir Ienumerable,ikinci bi foreach lazım. ayrıca Select kullanmıyoz
            var grupluŞirketler = şirketler.GroupBy(şrk => şrk.adres);
            foreach (var şirket in grupluŞirketler)
            {
                Console.WriteLine(şirket.Key + " ilindeki şirket sayısı: " + şirket.Count() + ". ve bu şirketler şunlar");
                foreach (var item in şirket)
                {
                    Console.WriteLine(item.şirketAd);
                }
            }

            //count ve distinct count
            int şirketİlAdetbasic = şirketler.Count();//5
            int şirketİlAdet = şirketler.Select(ş => ş.adres).Count();//5
            int şirketİlAdetDistinct = şirketler.Select(ş => ş.adres).Distinct().Count();//3

            //join collections
            var jointColl = kişiler.Select(k => new { k.İsim, k.Soyisim, k.Şirket })
                .Join(şirketler, kş => kş.Şirket, şrk => şrk.şirketAd,
                (kş, şrk) => new { kş.İsim, kş.Soyisim, kş.Şirket, şrk.adres, şrk.çalışanAdet });
            Utilities.DiziYazdır(jointColl, "jointColl");

            //GERÇEK LINQ,lambdasız
            var isimler2 = from kişi in kişiler
                           select kişi.İsim;
            Utilities.DiziYazdır(isimler2, "isimler2");

            var isimler3 = from kişi in kişiler
                           select new { kişi.İsim, kişi.Soyisim };
            Utilities.DiziYazdır(isimler3, "isimler3");

            var isimler4 = from kişi in kişiler
                           select (kişi.İsim + " " + kişi.Soyisim);
            Utilities.DiziYazdır(isimler4, "isimler4");

            //where(eşitlik kontrolünde == kullanırız
            var isimler5 = from kişi in kişiler
                           where kişi.İsim.StartsWith("V", StringComparison.CurrentCultureIgnoreCase)
                           select kişi.İsim;
            Utilities.DiziYazdır(isimler5, "isimler5");

            //sıra
            var isimler6 = from kişi in kişiler
                           orderby kişi.İsim
                           select kişi.İsim;
            Utilities.DiziYazdır(isimler6, "isimler6");

            //grup
            var isimler7 = from şrk in şirketler
                           group şrk by şrk.adres;
            //yazdırma kısmı lambalıyla aynı

            //distinct count
            var ilAdet = (from ş in şirketler
                          select ş.adres).Distinct().Count();

            //joining
            var joinliKüme = from k in kişiler
                             join ş in şirketler
                             on k.Şirket equals ş.şirketAd //burdak, sıra önemli. önce k olmalı.
                             select new { k.İsim, k.Soyisim, k.Şirket, ş.adres, ş.çalışanAdet };
            Utilities.DiziYazdır(joinliKüme, "joinliKüme");

            //subquery mantığndaki nested LINQ
            /*Since each query in LINQ returns a collection of items (irrespective of whether the result from it is of 0, 1 or more elements), we need to use the extension method First() over the result of the nested query.*/
            var subQueryNestedKüme = from k in kişiler
                                     select new {
                                         İsim = k.İsim, Soyisim = k.Soyisim,
                                         şirketAdres =
                                         (from ş in şirketler
                                          where ş.şirketAd == k.Şirket //iki tane = kullanmına dikkat
                                          select ş.adres).First()
                                     };


        }
        public void Detay()
        {
            //findall
            var find = şirketler.ToList().FindAll(x => (x.adres.StartsWith("İ"))).Select(y => y.şirketAd);
            Utilities.DiziYazdır(find, "find");
            Console.WriteLine("--------");

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);
            foreach (var num in evenNumbers)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();


        }

    }

    public struct Şirket
    {
        public string şirketAd;
        public string adres;
        public int çalışanAdet;

        public Şirket(string ad, string adr, int adet)//constructor
        {
            şirketAd = ad;
            adres = adr;
            çalışanAdet = adet;
        }
    }


}
