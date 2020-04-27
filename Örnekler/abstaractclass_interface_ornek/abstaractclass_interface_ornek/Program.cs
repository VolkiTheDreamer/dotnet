using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstaractclass_interface_ornek
{
    #region Açıklamalar
    /*bence özeti şu:interface ile baştan kontratı bleirliyon. şu şu metodt ve propertyeri mutlaka kullan diye
     abssratc class ile de kendinden türeyecek sınıfların ortak özelliklerini tanımlıyorsun. Ör:Kişiler abstrac class olur, bundan personel, müşteri gibi sınıflar türer.
         */
    /*
     Interfaceler çoklu kalıtımı sağlamaya yardımcı abstract classlar ise çoklu kalıtımı desteklemez.
    Interfacelerde metodların içerisini dolduramayız ama abstract classlarda doldurabiliriz Böylece bütün alt sınıfların belli bir özelliğe sahip olmasını sağlayabiliriz.
    Interface ile yapabildiğimiz herşeyi hatta daha fazlasını abstract classlar ile de yapabiliriz.
    Eğer türeteceğimiz classlarda belli başlı varsayılan özellikleri tekrar tekrar kopyala-yapıştır yapmak istemiyorsak o zaman abstract class kullanmamız gerekir. Çünkü abstract classlarla bir metodu tüm alt classlarda varsayılan metod şeklinde tanımlayabiliriz ve alt classlarda bunları tekrar yazmamıza gerek kalmaz kalıtımla aktarılmış olur.
    Kalıtım sağlamak istiyorsak abstract classlar kullanmamız gerekir.
    Abstract classları kullanmak hız açısından avantaj sağlar.
    Interface de yeni bir metod yazdığımız zaman bu interfaceden implement ettiğimiz tüm classlarda bu metodun içini tek tek doldurmak gerekiyor ancak abstract classlarda durum farklıdır burada bir metod tanımlayıp içini doldurduğumuzda abstract sınıfımızdan türetilmiş bütün sınıflar bu özelliği kazanmış olur.
         */

    /*
    Abstract Class lar miras (inheritance) vermek amacıyla iplemente edilen classlardır.Yalnız Abstract class ta oluşturulan metodlar veya değişkenler türetilen class ta veyahut miras alan class ta tekrar yazmak zorunda deiliz. Ayrıca Abstract Classın diğer class lar gibi nesnesi oluşturulamaz.Bide Abstract Class ta tanımlayıpta bunu alan class ta aynı metodu iplemente ederken mutlaka o metodu override olarak belirtmeliyiz.

     Projelerde özellikle sizden sonra gelecek yazılım geliştiricilerin, oluşturduğunuz temel sınıflar üzerinde değişiklik yapmasını birnevi önleyebilecek ve altyapınızı daha sağlam yapmanızı sağlayabilecek bir yapıdır.
     */

    /*
  İnterface ler bir nevi kalıtım gibidir fakat temel amaçlarından biriside şablon olarak bazı metodları sürekli kullanmak. Interface ler aslında şablon gibidir interface içerisinde oluşturulan metotlar tüm diğer class larda kullanılabilir yalnız bu metotlar interface de gerçeklenmediğinden mecburen interface i alan class ta iplemente etmek zorundayız aldığımız metotları..Abstract Class ta olduğu gibi interfacede de nesne oluşturamıyoruz.*/

    /*interfacin metodlarda public yazmana gerek yok, defaut publictir
    interfacelerde field olmaz, prpoerty olur
    interfacede tanımlanan metodun bunu implente eden sınıflarda kullanılması ZORUNLUDUR, yoksa hata verir
    
    Interface içinde property, event (olay), method, indexer, temsilci (delagate) gibi üyeler tanımlanabilir fakat constructor, destructor ve operator overloading gibi işlemler olamaz. Ayrıca bir interface içinde static metotlar veya static değişkenler tanımlanamaz.Interfaceler implement edildiğinde default olarak public olarak tanımlanmaktadırlar.

        bir class hem bir classdan miras alıp hemde interface veya interfacelerden implement edilebilir mi? Bunun cevabı tabii ki evet. Fakat burada dikkat edilecek nokta tanımlama da önce miras alınan sınıf yazılır, sonra “,” ile interfaceler..*/

    /*
     Öncelikle daha önceki yazılarda Abstract sınıfların genellikle IS-A(dır,dir) ilişkilerinde,kalıtım(inheritance) özelliğini kullanarak kod tekrarını azaltmak için kullanıldığını söylemiştik. Interface sınıfların ise daha çok CAN-DO(yapabilir..) tarzı ilişkilerde değişen kavramları uygulamadan soyutlamak için kullanıldığını söylemiştik. Birde bu iki kavramın avantaj ve dezavantajlarına bakalım.Sonuçta Abstract bir sınıfın bütün metodlarını abstract yaparak onu da aynı bir interface gibide kullanabiliriz.

        Öncelikle bence en büyük fark Abstract sınıfların tekli kalıtım(inheritance ) kullanması Interface sınıfların ise çoklu kalıtıma(multiple inheritance) izin vermesidir.Bildiğiniz gibi bir sınıfı başka bir sınıftan,ya da abstract bir sınıftan türettiğiniz zaman başka bir sınıftan daha türetme imkanınız olmuyor. Fakat interface sınıflarda durum daha farklı. Bir sınıfı istediğiniz kadar interfaceden türetebilirsiniz. Bu bakımdan interface sınıflar abstract sınıflardan oldukça daha esnek diyebiliriz. Fakat interface sınıflara baktığımızda abstract sınıflardan daha yavaş çalıştığı için hız bakımından devavantajı var diyebiliriz.

        Şimdi hız mı esneklik mi diye bana soracak olursanız tabiki tercihim esneklikten yana olacaktır.

        Kendi kişisel tercihim olarak eğer soyutlamak istediğim yapıda ilişki CAN-DO ise ve hiç ortak kod yoksa sadece interface kullanırım. Fakat ortak kod içeriyorsa öncelikle bir interface(dikkat edin yine interface koyarım) koyup ardından ortak kodu kullanan bir abstract sınıf koyup onu o interfaceden türetir ve diğer sınıfları interface sınıfını kullanır hale getiririm.Burada interface i koymasakta olur fakat koymamın sebebi esnekliği arttırması ve özellikle Test Driven Development açısından Mock objelerin oluşturulması için interface kullanan sınıfların test edilmesinin çok daha kolay olması.Mock objelere ayrı bir konu başlığı altında değiniriz fazla uzatmayalım.

Eğer soyutlamak istediğim yapı IS-A ilişkisi ise sadece Abstract sınıf kullanırım. Abstract sınıfların sevmediğim yanı kalıtım(inheritance) diyebilirim.Kalıtım ilişkisi herzaman bağımlılığı(coupling) fazla olan bir ilişkidir. Yani türettiğiniz sınıfa tamamen bağımlı oluyorsunuz. Türettiğiniz sınıftaki herhangi bir değişiklik alt sınıfları etkiliyor. Fakat interface sınıflarda bu tarz bir problem daha az interface içindeki bir metodu değiştirmedikçe hiç bir sınıf bundan etkilenmiyor.Geliştirdiğiniz sınıflar tamamen plug-in mantığı ile interface sınıflar sayesinde hiç problemsiz değiştirilebiliyor. Bu yüzden kalıtıma her zaman şüpheyle yaklaşıyorum. Zaten Object OOP nin insanlar tarafından uzun yıllar kullanıldıktan sonra da aynı fikre varılmış. Kalıtımın bu problemli yapısı görüldüğü için daha sonra kalıtım yerine birleşim(Composition over Inheritance) kullanmak çoğu durumda tercih edilen bir yöntem.OOP için oldukça önemli olan bu konuyuda başka bir yazı konusu olarak ileriye bırakıyorum.

Konu ile ilgili yazıyı yazdığım gün konu ile alakalı çok güzel bir webcast e denk geldim. sizde izleyebilirsiniz. Konu Interface vs Abstract sınıflar. Burada konuşmacı benden daha katı olarak tamamen interface kullanılması gerektiğini savunuyor.Kısmen katılsamda bu şekile katı bir interface kullanımı her zaman doğru olmayabilir. Ayrıca konu ile ilgili daha derin bilgi edinmek için okumaya fırsat bulamadığım Interface Oriented Design kitabını okuyabilirsiniz. Ayrıca Wikide de  kısa bir bilgi verilmiş(Interface Based Programming).
     */
    #endregion
    public interface IVarliklar
    {
        int Boy { get; set;}
        int En { get; set; }
        int Genislik { get; set; }

        int hacimhesap(int boy, int en, int genislik);
        int atom_adedi(int atomno, int boy, int en, int genislik);//burda parametre olarak hacimhesap metodunu da kullanabilrdik, ama delegate lazımmış, bunu ayrıca incele
        //ayrıca aomno için bir property tanımalmadım        
    }

    public interface ICanlilar
    {
        int Ayak { get; set; }
        int Parmak { get; set; }

        int toplam_parmak(int ayak, int parmak);
        
    }

    class deneme
    {//aynı anda hem interfacelerden hem de classtan kalıtım alma orneği
        public bool flag;
        
        
    }
    abstract class hayvanlar:deneme,IVarliklar, ICanlilar
    {
        //Varlıklardan gelen kısım
        int boy;//bunar propertylerin backing fieldları
        int en;
        int genislik;
        public int Boy
        {
            get{return boy;}
            set{boy = value;}
        }
        public int En
        {
            get { return en; }
            set { en = value; }
        }
        public int Genislik
        {
            get { return genislik; }
            set { genislik = value; }
        }

        public int hacimhesap(int boy, int en, int genislik)
        {
            return boy * en * genislik;
        }

        public int atom_adedi(int atomno, int boy, int en, int genislik)
        {
            return atomno * boy * en * genislik;
        }
        public int kilo_bul(int atomno, int atomagirlik, int boy, int en, int genislik)
        {
            return atomno * atomagirlik * boy * en * genislik;
        }
        
        //Canlılardan gelen kısımlar
        int ayak, parmak;
        public int Ayak
        {
            get { return ayak; }
            set { ayak = value; }
        }
        public int Parmak
        {
            get { return parmak; }
            set { parmak = value; }
        }
        public int toplam_parmak(int ayak,int parmak)
        {
            return ayak * parmak;
        }        
    }

       
    class Memeli:hayvanlar
    {
        //override?
    }
    
    class Surungen:hayvanlar
    {

    }

   
    class Program
    {
        static void Main(string[] args)
        {
            Memeli m = new Memeli();
            Surungen s = new Surungen();

            m.Ayak = 4;
            m.Parmak = 5;
            Console.WriteLine("Memelilerde toplam {0} ayak parmağı bulunur", m.toplam_parmak(m.Ayak,m.Parmak));

            s.Boy = 5;
            s.En = 1;
            s.Genislik = 1;
            Console.WriteLine("Sürüngenlerde toplam {0} atom bulunur", m.atom_adedi(10000000, s.Boy, s.En, s.Genislik));
            
            Console.ReadLine();
        }
    }



}

