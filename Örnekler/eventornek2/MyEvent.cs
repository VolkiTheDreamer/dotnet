using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventornek2
{
    // Bir olay icin bir delege deklare et. 
    delegate void MyEventHandler(); ///Form karşılığı arka planda EventHandler olarak var. Olaylara genellikle multicast uygulandığı için bir olay void döndürmelidir.
    // Bir olay sinifi deklare et. 
    class MyEvent
    {
        public event MyEventHandler SomeEvent; ///Form karşlığı Public event Eventhandler Click olarak var, web karşılğı da aynı. bu aslında bir delegdir.
        // Olayi ateslemek icin bu cagrilir. 
        public void OnSomeEvent() ///olay meydana gelince çağırlan metod budur, triggerdır, scractteki haber salmak gibi. Form karşılığı:butona tıklanması
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class EventDemo
    {
        // Bir olay yoneticisi. 
        static void Handler()///Form karşılığı:button_Click, web karşılığı button.OnClick
        {
            System.Windows.Forms.MessageBox.Show("Event occurred");

        }
        public void baslat()
        {
            MyEvent evt = new MyEvent();
            // handler()‘i olay listesine ekle. 
            evt.SomeEvent += new MyEventHandler(Handler);///Form karşışığı designer.cs içinde
            // Olayi atesle. 
            evt.OnSomeEvent();///Form kaşılığı: butona tıklama
        }
    }

}
