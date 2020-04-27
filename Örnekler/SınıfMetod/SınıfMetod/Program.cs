using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Ütü_Örnegi
{

    static void Main(string[] args)//program çalışınca burası çalışıyor
    {
        Ütü ütü1 = new Ütü("Beyaz", "AyBakır");/*Ütü sınıfndan nesne yaratılıp, metodu çağrılıyor
                                                * bu metod özellikleri atamakla birlikte, aynı zamana
                                                * bu özellikleri yazdırıoyr da, istersen breakpoint yapıp
                                                * gözlerinle gör
         *Yapılandırıcılar bir sınıftan oluşturulan nesnelerin ilk değerlerini atama ve baslangıç 
         * işlemlerini yapmak için kullanılırlar. Ütü sınıfınımızın yapılandırcısı, oluşturulan 
         * her ütü nesnesinin sıcaklığını varsayılan değer olarak 15 dereceye ayarlıyor. 
         * Ayrıca paratmetre olarak alınan renk ve marka değerlerini de atayıp, ütüye ait 
         * özellikleri ekrana yazdırıyor.*/
        Console.WriteLine("selam");
        Console.WriteLine(ütü1.Isın(70));
        Console.ReadLine();
    }
}

class Ütü
{
    public int sıcaklık;
    public string ren;
    public string mark;
    public Ütü(string renk, string marka) /*class adıyla aynı olan bir Constructor metodu
                                           * burda kaç paramentre varsa, yukarda nesne yaratılırken de
                                           * o kadar paramteryle yaratılmalı*/
    {

        sıcaklık = 15;
        this.renk = ren;
        this.marka = mark;

        Console.WriteLine(sıcaklık + " derece sıcaklığında,\n "
                                 + renk + " renginde ve\n "
                                 + marka + " markasıyla bir ütü nesnesi oluşturuldu\n\n");
    }
    public string Isın(int derece)
    {
        sıcaklık += derece;
        return "şu an sıcaklıgım: " + sıcaklık + " derece";
    }
}