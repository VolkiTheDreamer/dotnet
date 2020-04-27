using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventornek2
{    
    // Bir olay icin bir delege deklare et. 
    delegate void MyEventHandlerc();
    // Bir olay sinifi deklare et. 
    class MyEventc
    {
        public event MyEventHandlerc SomeEvent;
        // Olayi ateslemek icin bu cagrilir. 
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class X
    {
        ///bunda olay yok ama MyEventHandlerc ile uyumlu olay yöneticileri tanımlamaktadırlar
        public void Xhandler()
        {
            System.Windows.Forms.MessageBox.Show("Event received by X object");
        }
    }
    class Y
    {
        ///bunda olay yok ama MyEventHandlerc ile uyumlu olay yöneticileri tanımlamaktadırlar
        public void Yhandler()
        {
            System.Windows.Forms.MessageBox.Show("Event received by Y object");
        }
    }
    class EventDemoc
    {
        static void Handler()
        {
            ///İlk parametre, olayı üreten nesneye bir referanstır. Ġkincisi ise, yönetici tarafından istenen diğer bilgileri içeren EventArgs tipinde bir parametredir. Genellikle kaynak parametresine metodu çağıran kod tarafından this aktarılır. EventArgs parametresi ek bilgiler içerir ve gerekli değilse dikkate alınmayabilir.
            System.Windows.Forms.MessageBox.Show("Event received by EventDemo");
        }
        public void Baslat()
        {
            MyEventc evt = new MyEventc();///eventi olan class bu
            X xOb = new X();
            Y yOb = new Y();
            // Yoneticileri olay listesine ekle. 
            evt.SomeEvent += new MyEventHandlerc(Handler); //bu classtaki statik metod
            evt.SomeEvent += new MyEventHandlerc(xOb.Xhandler);//ilgili classın instance metdou
            evt.SomeEvent += new MyEventHandlerc(yOb.Yhandler);//bu da
            // Olayi atesle. 
            evt.OnSomeEvent();
            
            // Yoneticiyi ortadan kaldir. 
            evt.SomeEvent -= new MyEventHandlerc(xOb.Xhandler);
            evt.OnSomeEvent();
        }
    }

}
