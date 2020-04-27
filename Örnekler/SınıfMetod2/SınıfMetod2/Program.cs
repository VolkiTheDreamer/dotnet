using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ütü_Örnegi
    /*bu örnek, objelerin "referans tipi veri tipi"nde olduklarını göstermek içindir     
     * değer tipi olanlarda a=2 b=3 olsun, sonra a=b deyine a=3 olmuş oldu
     * sonra b=5 yapınca a=b oldugu için a=5 olmuyor, o geçti artı geride kaldı
     * ama nesnelerde böyle değil, ütü2=ütü1 diyince, artık ütü1 değiştikçe ütü2 de dğeieşcek
     * */
{

    static void Main(string[] args)
    {
        Ütü ütü1 = new Ütü("Beyaz", "AyBakır");
        Console.WriteLine("ütü1'nin ilk özellikleri: " +
                                ütü1.Özellikler());
        Console.WriteLine("ütü1'i 50 derece ısıtalım: " +
                                ütü1.Isın(50) + "\n\n");
        // ütü2 nesnemizi renksiz ve markasız olarak olusturalım:
        Ütü ütü2 = new Ütü("", "");

        //ütü2 nesnemizin özelliklerine bir göz atalım:
        Console.WriteLine("ütü2'nin ilk özellikleri: " +
                                ütü2.Özellikler());
        ütü2 = ütü1; // ütü2 nesnemizi ütü1 nesnemize atıyoruz. 
        Console.WriteLine("ütü2'nin özellikleri: " +
                                ütü2.Özellikler());
        Console.ReadLine();
    }
}
class Ütü
{
    public int sıcaklık;
    public string renk;
    public string marka;
    public Ütü(string renk, string marka)
    {
        sıcaklık = 15;
        this.renk = renk;
        this.marka = marka;
    }
    public string Isın(int derece)
    {
        sıcaklık += derece;
        return "şu an sıcaklığım: " + sıcaklık + " derece";
    }
    public string Özellikler()/*bu metod çağrıldığında özellikleri bi strine atıyor
                               * yani metodda direkt writelline kullanmak yerine, sonucu
                               * bi stringe atıyoruz. writelineı metodu çağırdığıımz yerde
                               * kullanıyourz*/
    {
        string sonuc = " Sıcaklık: " + sıcaklık +
                            "\n Renk: " + renk +
                            "\n Marka: " + marka + "\n\n";
        return sonuc;
    }
}