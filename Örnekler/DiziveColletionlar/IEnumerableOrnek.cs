using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziveColletionlar
{
    public static class IEnumerableOrnek
    {
        public static void Ana()
        {
            PersoneList list = new PersoneList();
            list.Ekle("Sinan", "BARAN");
            list.Ekle("Ibrahim", "BARAN");
            list.Ekle("Murat", "BARAN");
            list.Ekle("Ramazan", "BARAN");
            list.Ekle("Muharrem", "BARAN");
            list.Ekle("Aydın", "BARAN");
            list.Ekle("Fatih", "BARAN");
            list.Ekle("Gokhan", "BARAN");
            list.Ekle("Hakan", "BARAN");

            foreach (Personel item in list)
            {
                Console.WriteLine(item.Ad + " " + item.Soyad);
            }
        }
    }

    public class Personel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public Personel() { }

        public Personel(string ad, string soyad)
        {
            this.Ad = ad;
            this.Soyad = soyad;
        }
    }

    public class PersoneList : IEnumerable
    {
        List<Personel> list = new List<Personel>();

        public void Ekle(Personel p)
        {
            list.Add(p);
        }

        public void Ekle(string ad, string soyad)
        {
            list.Add(new Personel(ad, soyad));
        }

        public IEnumerator GetEnumerator()
        {
            return new PersonelEnumerator(list);
        }

    }

    public class PersonelEnumerator : IEnumerator
    {
        public List<Personel> listem = new List<Personel>();
        int CurrentLocation = -1;

        public PersonelEnumerator(List<Personel> p)
        {
            this.listem = p;
        }

        public object Current
        {
            get
            {
                return this.listem[CurrentLocation];
            }
        }

        public bool MoveNext()
        {
            CurrentLocation++;
            return (CurrentLocation < this.listem.Count);
        }

        public void Reset()
        {
            CurrentLocation = -1;
        }
    }


    ///burdan aşağısı benim örnek. yield da kullanılacak
    public static class KendiTestSınıfım
    {
        public static void Ana()
        {
            KendiPersoneListem mylist = new KendiPersoneListem();
            mylist.Ekle(new { Name = "Volkan", Surname = "Yurtseven" });
            mylist.Ekle(new { Name = "Meltem", Surname = "Yurtseven" });
            mylist.Ekle(new { Name = "Doruk", Surname = "Yurtseven" });
            mylist.Ekle(new { Name = "Doğa", Surname = "Yurtseven" });

            foreach (dynamic item in mylist)
            {
                Console.WriteLine(item[0]);//böyle yazınca alıyor, ama name ve surname ifadelerini de gösteriyor,çünkü {} içindeki herşeyi bir dizi elemanı gibi alıyor
                //sanki esas çözüm bu aşağıdaki linkte verile Tuple örneği
            }
        }

    }

    public class KendiPersoneListem : IEnumerable
    {
        //bunda Personel sınıfın da ihtiyaç duymuycam, anonim sınıf kullancam, metod da param arrayli olcak
        //kaynak:https://stackoverflow.com/questions/612689/a-generic-list-of-anonymous-class

        List<dynamic> liste = new List<dynamic>();
        public void Ekle(params dynamic[] elements)
        {
            liste.Add(elements);
        }

        public IEnumerator GetEnumerator()

        {
            foreach (dynamic item in liste)
            {
                yield return item;
            }

        }
    }
}
