using System;
public class Myclass
{
    //sınıf içi deklerasyon örneği, sadece bu sınıfta kullanılabilir
    public delegate void CallBackDelegesi(int i);
    public void UzunÇalışanMetod(CallBackDelegesi del) //bu metod, içine bu delegate imzasını taşıyan bir metdou parametre olarak alıyor
    {
        //bunda geçen rakamlar(yani i), Main içinde yakalanabiliyor, belli bi an i'nin değeri alınabilir, async kullanım lazım tabi.
        for (int i = 0; i < 10000; i++)
        {
            del(i);
        }
    }

    public void UzunÇalışanAmaCallBacksiz()
    {
        //bunda geçen rakamlara müdahalemiz yok, yakalayamıyoruz, rakamalr akıp geçiyor
        for (int i = 0; i < 10000; i++)
        {
            Console.WriteLine(i);
        }
    }

    
}