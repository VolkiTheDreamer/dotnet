using System;

delegate void kalanisleriyap(); //parametresiz void metodları temsil eden bir delege
public class Robot
{
          
    public void İslerihallet()
    {
        //...
        //evi topamakla ilgili  çeşitli komutlar. yereri sil, toz al, evi süpür, çamaşır yıka v.s        
        //......
        Console.WriteLine("ev toplandı");
        Digerisler();
    }

    public void Digerisler()
    {
        kalanisleriyap mydel = null;
        mydel += Faturalarıöde;
        mydel += Eveyemeksiparişver;
        mydel += Falanfilanyap;        
        mydel.Invoke();//metod gibi çağırmak için Invoke metodu kullanılır. Direkt mydel() de yazılabilir
    }

    public void Faturalarıöde()
    {
        Console.WriteLine("faturalar ödendi");
    }

    public void Eveyemeksiparişver()
    {
        Console.WriteLine("Yemek siparişi verildi");

    }

    public void Falanfilanyap()
    {
        Console.WriteLine("falan filan yapıldı");

    }


}