using System;

//1.Aşama:sınıf üstünde deklarasyon, assembly içindeki tüm sınıflarda kullanılabilir.

delegate string strMod(string str);//dönüş tipi de parametresi de string olan metodları temsil eden bir delege
delegate int delİslem(int x, int y);//dönüş tipi int ve int tipinde iki parametresi olan metodları temsil eden bir delege


class DelegateTest
{

    static string ReplaceSpaces(string a)
    {
        Console.WriteLine("Boşluklar tire ile değişti");
        return a.Replace(' ', '-');
    }

    static string RemoveSpaces(string a)
    {
        string temp = "";
        int i;
        Console.WriteLine("Boşluklar silindi");
        for (i = 0; i < a.Length; i++)
            if (a[i] != ' ')
                temp += a[i];
        return temp;
    }

    static string MakeZero(string a)
    {
        Console.WriteLine("Boşluklar 0 yapıldı");
        return a.Replace(' ', '0');
    }


    public static void Main()
    {
        //2.aşama:delege instantiation'ı yani yaratımı.
        strMod strOp = new strMod(ReplaceSpaces);

        //3.aşama:Invoke ediyoruz, yani delege aracılığıyla ilgili metotlari çağırıyoruz. 
        string str = strOp("Bu bir denemedir");

        Console.WriteLine("Sonuç: " + str);
        Console.WriteLine();

        str = strOp.Invoke("Bu da invoke metodoyla çağrı");
        Console.WriteLine("Sonuç: " + str);
        Console.WriteLine();

        strOp = new strMod(RemoveSpaces);//başka bir metodu temsil etsin istedik
        str = strOp("Bu bir denemedir");
        Console.WriteLine("Sonuç: " + str);
        Console.WriteLine();

        strOp = new strMod(MakeZero);//şimdi de başka bir metodu temsil etsin istedik
        str = strOp("Bu bir denemedir");
        Console.WriteLine("Sonuç: " + str);
        Console.WriteLine();
        Console.ReadLine();


        //Şimdi farklı bir class olan işlemler classındn bir obje üretilip onda aritmetik işlemler başlayacak
        Console.WriteLine("İşlemler objesi yaratılıyor...");
        İslemler isl = new İslemler();
        isl.Hesapla();
        strMod delSta = İslemler.Statikmetod;
        Console.WriteLine("Statik metod çağırlıyor");
        Console.WriteLine("Sonuç: " + delSta("volkan"));
        Console.WriteLine();
        Console.ReadLine();

        //şimdi de farklı bir class olan Myclass classından bir obje üretilip callback örneği yapacağız. Bu ayrıcai metodun paramtere olarak gönderilmesi örneğidir
        Console.WriteLine("Callback örneği başlıyor...");
        Console.ReadLine();
        Myclass myc = new Myclass();
        Console.WriteLine("Önce callbacksiz versiyonu");
        Console.ReadLine();
        myc.UzunÇalışanAmaCallBacksiz();
        Console.ReadLine();
        Console.WriteLine("Şimdi callbackli versiyonu");
        Console.ReadLine();
        myc.UzunÇalışanMetod(CallBackMetodu);
        //burada bir yerde i'nin değerini elde edebiliriz. farklı bir konu olduğu için burada detaya girmeyeceğim
        Console.ReadLine();


        //multicasting örneği 
        Console.WriteLine("Multicasting başlıyor...");
        Console.WriteLine("");
        Robot r = new Robot();
        r.İslerihallet();
        Console.ReadLine();


    }

    static void CallBackMetodu(int i)
    {
        Console.WriteLine(i);
    }
    
}
