using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventornek2
///
/// C# istediğiniz her tipten olayı yazmanıza olanak tanımaktadır. Bununla birlikte, bileşenlerin .NET Framework ile uyumluluğu için Microsoft‟un bu amaca yönelik yerleştirdiği esasları takip etmeniz gerekecektir. Bu esasların özünde, olay yöneticilerinin iki parametreye sahip olması gerektiği yer almaktadır. İlk parametre, olayı üreten nesneye bir referanstır. İkincisi ise, yönetici tarafından istenen diğer bilgileri içeren EventArgs tipinde bir parametredir.
/// 
/// Genellikle kaynak parametresine metodu çağıran kod tarafından this aktarılır. EventArgs parametresi ek bilgiler içerir ve gerekli değilse dikkate alınmayabilir.
/// 
/// EventArgs sınıfının kendisi bir yöneticiye ek veri aktarmak için kullanacağınız alanlar içermez. Bunun yerine EventArgs, gerekli alanları içeren bir sınıfı kendisinden türetebileceğiniz bir temel sınıf olarak kullanılır. Ancak, birçok yönetici ek veri gerektirmediği için, veri içermeyen bir nesneyi belirten Empty adındaki static alan EventArgs içinde yer almaz.
/// 
/// Bir çok olay için EventArgs parametresi kullanılmaz. Bu gibi durumlarda kodun oluşturulmasına kolaylık sağlaması için .NET Framework, EventHandler adında standart bir delege tipi içerir. EventHandler, ek bir bilgi gerektirmeyen olay yöneticilerini deklare etmek için kullanılabilir.Bu örnekte, EventArgs parametresi kullanılmamıştır; yer belirleyici bir nesne olan EventArgs.Empty parametre olarak aktarılmıştır. Çıktı aşağıda gösterildiği gibidir:

{
    // Standart EventHandler delegesini kullan. 
    using System;
    // Bir olay sinıfi deklare et. 
    class MyEventh
    {
        public event EventHandler SomeEvent; // EventHandler delegesini kullanir
    // SomeEvent‘i ateslemek icin bu cagrilir. 
        public void OnSomeEvent()
            {
                if (SomeEvent != null)
                    SomeEvent(this, EventArgs.Empty);
            }
        }
    class EventDemoh
    {
        static void handler(object source, EventArgs arg)
        {
            System.Windows.Forms.MessageBox.Show("Event occurred");
            System.Windows.Forms.MessageBox.Show("Source is " +source);
        }
        public void baslat()
        {
            MyEventh evt = new MyEventh();
            // handler()‘i olay listesine ekle. 
            evt.SomeEvent += new EventHandler(handler);
            // Olayi atesle. 
            evt.OnSomeEvent();
        }
    }

}
