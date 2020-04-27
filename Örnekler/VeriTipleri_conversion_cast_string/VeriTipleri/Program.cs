using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTipleri_cast_convert
{
    //bu namepsace içinde iki class var
    class Program
    {
        //bu classın iki static metodu var, biri Main. Mainden başka bir metod çağırmak istersen onunu da static olması lazım, biz de öyle ypatık.
        //bu classın ayrıca 2 static 1 non-static field'ı var.

        static int a_static_int_field;//static olan Main içinde kullanacaığm için static yaptım, yoksa izin vermiyor. teknik bilgi edinilecek.....?
        static string a_static_string_field;
        int non_static_int_field_in_ProgramClass;//static yapmadım, ama ProgramWın instanceını alıcam

        static void Main(string[] args)
        {
            /*ÖNEMLİ...field ve variable aynı şey değil. 
             bir değişken tanımlansa bile değer atanmadan kullanılamaz. o yüzden özellikle döngüelerde
            ilk başta 0 değeri atamak gerekiyor, ancak, bir sınıfın field'ını sadece tanımlamak yeter, bunlardan default değerleri otomatik atanır.*/

            ///BLOK KAVRAMI:Her blok seviyesi variable o blokta geçerlidir.
            { //Birinci blok
                int a = 20;
                //bu a ile aşağıdaki a birbirinden bağımsızdır. çünkü ikisi de ayrı bloklarda tanımlanmış
                Console.WriteLine(a);
            }
            {//İkinci blok
                int a = 10;//her değişken tanımlı olduğu blokta çalışır.
                Console.WriteLine(a);
            }
            //Console.WriteLine(a); -- bu kısım çalışmaz çünkü, main bloğu içinde a diye bişey tanımsız




            ///FIELD VE VARIABLE FAKRI
            //fieldlara değer atanamasıa bile default valeuları ile kullanılabilirler
            int c;

            //Console.WriteLine(c); bu kısım çalışmaz çünkü c bir variable ama değer atanmamış
            Console.WriteLine("static INT elamana değer atamadım, value type olduğu için 0 gözükmeli:" + a_static_int_field);
            Console.WriteLine("static STRING elamana değer atamadım, ref type olduğu için null gözükmeli:" + a_static_string_field);

            Program p = new Program();
            Console.WriteLine("Program sınıfnı bir önreğiden yarattığm static olmayan bir INT, value oldugu için 0 gzükmeli:" + p.non_static_int_field_in_ProgramClass);


            Ornek exm = new Ornek();
            Console.WriteLine("Ornek classının non static INT tipli elamanınaı değer atamadım, value type olduğu için 0 gözükmeli:" + exm.non_static_int_field);//nonstatic iiçerden tanımlamama izin vermediği için başka classan örnek yarattım. 
            Console.WriteLine("Ornek classının non static STRING elamanınaı değer atamadım, bu da null gözükmeli:" + exm.non_static_string_field);//nonstatic iiçerden tanımlamama izin vermediği için başka classan örnek yarattım. 

            ///DÖNÜŞÜM TÜRLERİ
            //1.Kapalı(Implicit) Dönüşüm:Dönüşümün otomatik olduğu durumdur
            //veri tipi uyumluysa ikisi de numericse ve Küçük olanı büyüe atama durumunuda
            int asa = 12;
            float bas = asa;
            Console.WriteLine(bas);//otomatik olur
                                   //byte bt = asa; design time hatası

            /*Bir deyim/formül içinde iki değişken kullanılıyorsa işleme giren değişkenlerden küçük olan büyük olana dönüştürülür. Ör:biri int biri double ise ikisi de double dönüşür, sonuç da dobule olur. 
              İstisna:en küçük önüşüm int'tir. Yani iki byte işleme girse ikisi de int olur ve sonuc ta int olur.Ör:iki byte toplanırsa inte çevrililrler. Sen bellek yönetimini iyi yapma istersen sonucu yine byte çevirmen gerekir.
              Byte b=10
              b= (byte) (b*b) //sonuç hala byte sınırı içinde olmasına ragmen interger üretti, biz (byte) ifadesiyle bytea çevirdik.
              Not:bu tip önüşümü sadece deyim/formül içindedir. Yani deyimin/formülün dışında yine herkes kendi tipindedir
             */

            //2.Açık Dönüşüm:Dönüşüm otmatik olmaz, biz bişey yazarız
            //a)Convert sınıfı:her türü her türe
            //sayıya çevirmlerde arka planda parse ediyor , o yüzden performans olarak parsedan daha yavaş, ancak binlerce kezlik döngde kullanmıyorsan çok farketmezsin
            //eğer convert edilen null ise exception üretmez, 0 yapar.
            /*
            Convert.ToInt32 şunu yapıyor, resmi olarak:
            If(value == null)
            return 0;
            return Int32.Parse(value, CultureInfo.CurrentCulture);*/
            //****bu yüden metinden dönüşüm yapcaksan TyParse kullan, metin dışında için  convert.****
            int qw;
            Console.WriteLine("bi sayı gir");
            qw = Convert.ToInt16(Console.ReadLine());
            string yas = Convert.ToString(qw);
            string qp = null;
            int qpn = Convert.ToInt32(qp);
            Console.WriteLine("qp:" + qp);
            Console.WriteLine("qpn:" + qpn);//0

            //b)Parsing:Sadece strginleri sayıya çevirir. 
            //parsing çok stricttir, dönüştüremezse hata verir. hatayı yakalamk için try-catch yapabilrsin ama programdna çıkmış olursun, bunun yerine emin olamama durumu varsa TryParse kullanılır, eminsen normal parse kullan
            //parse edilen null ise exception üretir, tryparse?
            //parse ayrıca numberformat parametresi de alır. Tryparse da var tabiki
            int we;
            string sifre = "1234";
            string sifre1 = "1234";
            we = int.Parse(sifre, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));//number format almış hali
            Console.WriteLine(we);
            int we1;
            if (int.TryParse(sifre1, out we1))
            {
                Console.WriteLine(we1);
            }
            string sifre21 = null;
            int we21;
            if (int.TryParse(sifre21, out we21))
            {
                Console.WriteLine("buraya girmeyecek:" + we21);
            }
            else
            {
                Console.WriteLine("null sifre tryparse ediliyr:" + we21);
            }

            //c)toString metodu:bir değişkenin string GÖSTERİMİni ifade eder, bir dönüşümden ziyade, string olarak nasıl görünürdü, onunu cevabını veriri
            int we2 = 1234;
            string sifre2;
            sifre2 = we2.ToString();//sayının string gösterimi

            object op = DateTime.Now;
            string ops = op.ToString();
            Console.WriteLine("objede tutualn now değeri string olarak yazılcak:" + ops);
            Console.ReadKey();

            //d)Casting:özellikle bir objeden o objenin taşıdığı veri tipine uygun bir değişken yaratmak için kullanlır. yani dönüşen şeylerin uyumlu olması şarttır.
            /*Casting:Explicitly conversion olabilme ihtimali varsa. Ör:bir objeni string değeri ieçrdiğini kesinlikle biliyorsan casting yaparsın. cast ettikten sonra yeni nesnenini ilgili tipteki özelliklerini kullanabilirsin. ((Listbox)obj).Items.Add gibi:önce objetyi listboxa çevirdim, sonra Items özelliğini kullandım*/
            //null olsa bile cast edet
            ///buraya örnek koy

            //e)as keyword ile dönüşüm:cast edebiliyorsa cast eder, edemezse null döndürür, aynı şekilde değer null ise yine null döndüdür
            //value typleaarde kullanılamaz, yani şöle diyemezsin. int x=o as int   
            {
                object o = "sasdsds";
                string s = o as string;
            }
            {
                object o = null;
                string s;
                s = o as string;//null olsa bile cast eder, sonuç null
            }

            {
                object o = 12;
                string s;
                s = o as string;//dönüştürmedse bile null döndürür
            }

            //as, is'in türevidir, ve şu ikisi aynı şeydir
            {
                object o = 12;
                string s = o as string;
            }
            {
                object o = 12;
                string s;
                if (o is string)
                    s = (string)o;
                else
                    s = null;
            }


            //as, sadece ref typlarla kullanılır dedik ama aslında tam böyle değil, null değeri alabilen deişkenerle kullnıalabilir dmeek daha doğru sanki, normalde de sadece ref typlar null değer alailir ama nullable value typler da olaibliyor.
            { 
                object o3 = 1;
                int? k = o3 as int?;

                if (k != null)
                {
                    //use k for whatever we want to
                    Console.WriteLine(k.Value);
                }
            }
            ///STRING

            //Label1.Text=(string)ListBox1.SelectedItem //bu da geçerli, consol oldugu ve form elemana koyamadıgım için commentledim. burdaki string cast'ı listboxa değil, listboxın selectditem'ına yapılıd. listboxa cast edilmek istese şöyle olurdu: ((string)Listbox1).stringozellik
            {
                object o = "VOLKAN";
                string s = ((string)o).ToLower();
                //string k=(string)o.ToLower(); // bu olmaz, zaten intellisense çıkmadı bile

                //ancak as versiyonunda çift parantezze gerek yok
                string s2 = (o as string).ToLower();
            }


            ///STRİNG DÖNÜŞÜMLERİ
            //Kaynak nesne null ise ToString() hata verir, runtime. String respnsatatiaon sağlar.
            //Kaynak nesne null ise Convert.ToString() hata veremez, emtpy bir string üretir
            //Kaynak nesne string değilse castingde compile time hatası
            //as ile cast edersen null olsa a hata veremz sonuç null olur: yani kontrol eder, dönüşteürebiliyorsa dönüştürür, yoksa null çakar.
            //ille de castin lazımsa öncesinde null olup olmadıgını kontrol et veya as ile cast yap
            object str1 = "volki";
            string str2;
            str2 = (string)str1;
            Console.WriteLine(str2);

            object str11 = null;
            string str22;
            str22 = (string)str11;//null olsa bile cast edet
            Console.WriteLine(str22);
            Console.WriteLine(Convert.ToString(str11));
            //Console.WriteLine(str11.ToString()); //hata verir

            object o1 = "something";
            object o2 = 1;
            string so1 = o1 as string;//"somneting" döner
            string so2 = o2 as string; //null döner
            //string so3 = (string)o2;//hata verir
            string so4 = o2.ToString(); //"1"

            ///VB karşılıkları, tam bitmedi, son subpage bak in one-note, ayrıca google search yap
            //casting=Ctype
            //as=TryCast. Directcast'e de benziyor, ama dönüşüm geçrkeleşmezse C#'ın as'i null üretirken Directcast null(aslında nothing, çünkü vb'de null yerine nothing var) üretmez, hata verir.
          
            ///DÖNÜŞÜM ÖRNEKLERİ
            Console.WriteLine();
            Console.WriteLine("şimdi conversionlar başlıyor");
            string var1 = "5,12";
            //double varDouble = (double)variable; //bu design time hatası verir, çünkü casting yapıyor, casting olması için de explicitliy onversion ihiacı karşılanmalı, halbuki var1 bi string ve doublea çevrilemez
            double varDouble1 = Convert.ToDouble(var1);//bu ise çalışır, çünkü komple yeni birşey yaratılıyor
            Console.WriteLine("'5.12' şeklindeki strng ifadeyi ToDouble ile convert ediyorum:" + varDouble1);

            object var2 = "5,12";
            //double varDouble2 = (double)var2;//bu runtime hatası verir, çünkü hala elimizde bi string var
            //Console.WriteLine("'5.12' şeklindeki object ifadeyi cast yapıyorum:" + varDouble2);

            object var3 = 5.12;//virgülü yaptırmıyro noktalı olsun
            double varDouble3 = (double)var3;//bu çalışır, çünkü var3ün double oldugunu biliyorum
            Console.WriteLine("5.12 şeklindeki object ifadeyi cast yapıyorum:" + varDouble3);





            Console.WriteLine();
            Console.WriteLine("şimdi de ikisi de geçerli durumda, int casting ve convert.tonint32 farkı");
            int i1 = 5;
            double d1 = i1 + 0.99;
            int i2 = (int)d1; //result is 5
            Console.WriteLine("5.99 için,int cast etmek sayyı intege ypar, excelkide int gibi, basamaktan kuratırı:" + i2);
            i2 = Convert.ToInt32(d1);//result is 6
            Console.WriteLine("5.99 için,Convert.ToInt32 ie yukarıy yuvarlar:" + i2);


            Console.WriteLine();
            Console.WriteLine("boxing ve unboxing başlıyor, implicitly casting  var, herhangi bir cast convert ifadesi kullanamdan inti longa çevircem");
            int c1 = 3;
            Console.WriteLine("c1:" + c1);
            long b = 30;
            Console.WriteLine("b:" + b);
            //c1 = b;//buna hata veriyor, çünkü küçük olana büyük atanmaz
            b = c1;
            Console.WriteLine("b after conv:" + b);



            /*
            Because a type inherits the default Object.ToString method, you may find its behavior undesirable and want to change it. This is particularly true of arrays and collection classes. While you may expect the ToString method of an array or collection class to display the values of its members, it instead displays the type fully qualified type name, as the following example shows.*/
            Console.WriteLine();
            Console.WriteLine("diziyi listeye listeyi stringe çeviercez.");
            int[] values = { 1, 2, 4, 8, 16, 32, 64, 128 };
            Console.WriteLine(values.ToString());

            List<int> list = new List<int>(values);//System.Int32[]
            Console.WriteLine(list.ToString());//System.Collections.Generic.List`1[System.Int32]

            //istenen sonuç bu değil, deerleri yasın isiyoruz ya, bu işle biraz karışık, cevabı burda, Object.ToString Method ():https://msdn.microsoft.com/en-us/library/system.object.tostring%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396


            Console.WriteLine();
            Console.WriteLine("'500' metnini parse ediyoruz");
            string text = "500";
            int num = int.Parse(text);
            Console.WriteLine(num);



            //TryParse never throws an exception—even on invalid input and null. It is overall preferable to int.Parse in most program contexts. This method is ideal for input that is not always correct. When errors occur, performance is better. ama kesin eminsen normal parse ypa.
            Console.WriteLine();
            Console.WriteLine("try parese aypıyoruz");
            // See if we can parse the 'text' string.
            // If we can't, TryParse will return false.
            // Note the "out" keyword in TryParse.
            string text1 = "x";
            int num1;
            bool res = int.TryParse(text1, out num1);
            if (res == false)
            {
                // String is not a number.
            }

            // Use int.TryParse on a valid numeric string.
            string text2 = "10000";
            int num2;
            if (int.TryParse(text2, out num2))
            {
                // It was assigned.
            }

            // Display both results.
            Console.WriteLine(num1);//default valuesi olan 0 atanır.
            Console.WriteLine(num2);


            static_ornek();
            Console.ReadLine();
        }
        static void static_ornek()//bunu static yapamk lazım yoksa Main'den çağramıyoruz.
        {
            /*
             ToString() raise exception when the object is null, So in the case of object.ToString(), if object is null, it raise NullReferenceException.
             So in the case of object.ToString(), if object is null, it raise NullReferenceException.
             (string) cast assign the object in case of null, But when you use o to access any property, it will raise NullReferenceException.
             */
            //(string)obj casts obj into a string. obj must already be a string for this to succeed.
            Console.WriteLine();
            Console.WriteLine("objenin cast ve tostring hali");
            object obj = "Hello";
            string str1 = (string)obj;
            string str2 = obj.ToString();
            Console.WriteLine(str1);
            Console.WriteLine(str2);

            string s;
            object o = null;
            //s = o.ToString();//returns a null reference exception for s.

            string s1;
            object o1 = null;
            s1 = Convert.ToString(o1);
            //returns an empty string for s and does not throw an exception

        }
                
    }
    class Ornek
    {
        public int non_static_int_field;//static değil
        public string non_static_string_field;//static değil
    }
}
