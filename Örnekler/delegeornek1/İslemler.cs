using System;
class İslemler
{
    static int mystatic = 0;
    public static string Statikmetod(string s)
    {
        return "merhaba" + s;
    }
    public int Topla(int a,int b)
    {
        return a + b;
    }

    public int Carp(int a, int b)
    {
        return a * b;
    }

    public void Hesapla()
    {
        //2.aşama:delege yaratıyoruz(instantaion), 1.aşama yani deklerasyon, DelegateTest classını da üstünde namespace seviyesinde yapılmıştı
        delİslem myDel = new delİslem(Topla);
        
        // 3.aşama:delegeyi invoke ediyoruz
        int sonuc = myDel(5, 4); // sonuc 9. Topla yerine myDel koymuşuz gibi, delegenin görevi bu, Topla metdounu temsil ediyor.
        Console.WriteLine("5 ve 4 için Topla işleminin sonuc:" + sonuc);
        myDel = new delİslem(Carp);
        sonuc = myDel(5, 4); // sonuc 20
        Console.WriteLine("5 ve 4 için Çarpma işleminin sonuc:" + sonuc);
        

        //düz atama yöntem
        delİslem mydel2;
        mydel2 = Topla; //new falan demeden doğrudan atama, veya tek satıda "delİslem mydel2=Topla". bu yöntem c#2.0 ile geldi.
        Console.WriteLine("8 ve 2 için düz atama ile topla işleminin sonuc:" + mydel2(8,2));
        mydel2 = Carp; //şaun Carp'ı temsil ediyor
        Console.WriteLine("8 ve 2 için düz atama ile çarp işleminin sonuc:" + mydel2(8, 2));

        //+= yöntemi(multicasting. özellikle çoklu metodu çalıtşıracaksan)
        delİslem mydel3= new delİslem(Carp);
        mydel3 += Topla; //new falan demeden doğrudan atama
        Console.WriteLine("8 ve 2 için multicasting(+=) yöntemi ile topla işleminin sonuc:" + mydel3(8, 2)); //anlamsız oldu ama çalııştı. önce 8*2=16 yapar, bunu bi yerde kulanmaz, sonra 8+2=10 yapar, bunu gösterir. Multicasting kullanımını ayrca göreceğiz

        //anonymous metod ile tanımlama, c# 2.0 ve sonrası
        delİslem mydel4 = delegate (int a, int b) { return (a + b); }; //anonymouslarda gövde içinde parametre yoksa delegateten sornaki() içinde de gerek yok
        Console.WriteLine("3 ve 4 için anonymous ile toplam :" + mydel4(3, 4));

        //lambda exp ile tanımlama, c# 3.0 ve sonrası
        delİslem mydel5 = (a, b) => a * b;
        Console.WriteLine("5 ve 2 için lambda ile çarpım: "+ mydel5(5, 2)); 

        //Func ile. func<input1,input2,output>, bu da .NET 3,5 ile geldi. func kullandığımızda delege tanımlamaya gerek kalmamaktadır. son paremteresi sonuç, öncekiler inputtur. tek paramter varsa, bu input anlmaındadır, sonucu voiddir. Funcları lambdalı da yazabiliyoruz lambdasız da, lambdalı daha kısadır tabi.
        Func<int, int, int> Toplam = (a, b) => a + b;
                Console.WriteLine("5 ve 8 için Func ile Toplam:" + Toplam(5,8));
        Console.ReadLine();

        //metodarı parametre olarak gönderme örneği
        Console.WriteLine("Metodlar paramtere olarak gidecek");
        Console.WriteLine("");
        Console.WriteLine("metodu paremtre olarak göndermenin toplam soncu 505 olmalı:" + ozelyontem("volki", Topla)); //Topla yerine new delİslem(Topla) da yazılabilirdi, ama c#2.0 ile simple way yöntemini kullandım. volki kelimesi 5 harfli, özelyönteme gidiyor, 5le 100 çarpılıyor ve 500 hesaplanır, sonra Topla metdu devreye girer ve 5le 500ü toplar, 505 yapar.
        Console.WriteLine("metodu paremtre olarak göndermenin toplam soncu 5000 olmalı:" + ozelyontem("volki", Carp));//static değişken hazfızdadır, 500dür, sonra 500+5*100=1000 olur, Carp metodu devereye girer, 5*1000=5000 olur.
    }

    public static int ozelyontem(string str, delİslem mydel)
    {
        mystatic = mystatic + str.Length * 100;
        return mydel(str.Length, mystatic);
    }
}
