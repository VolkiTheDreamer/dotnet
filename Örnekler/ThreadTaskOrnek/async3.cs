using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadOrnek
{
    delegate void AsenkronHandler();
    
    public partial class async3 : Form
    {
        public async3()
        {
            InitializeComponent();
        }


        private void X()
        {
            while (DateTime.Now.Second != 20)
            {
                this.Text = DateTime.Now.Second.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            X();
        }


#region ornek2
        private void button2_Click(object sender, EventArgs e)
        {
            /*
             AsenkronHandler adında delegate nesnesinin “Begin” ile başlayan metodları, asenkron çalıştırma yapabilmek içindir.
             */
            AsenkronHandler asenkron = new AsenkronHandler(X);
            //asenkron(); //Böyle çalıştırırsam da senkron çalışır.
            //asenkron.Invoke(); //Böyle çalıştırırsam da senkron çalışacaktır.
            asenkron.BeginInvoke(new AsyncCallback(Y), this);
            /*BeginInvoke metodu 1. parametresinde, AsyncCallback delegesinden, geriye dönüş
            tipi olmayan ve IAsyncResult tipinden parametre alan bir metod istiyor.
            IAsyncResult tipinden parametre alan Y() metodunu yazıp ben BeginInvoke
            metodunun 1. parametresine gördüğünüz gibi yazıyorum.2. parametresine ise,
            this(yani bu formu) gönderiyorum.Buraya gönderilen object değer,Y metodunun
            IAsyncResult tipinden olan dd adlı parametresine gönderilecektir.
            */
        }

        void Y(IAsyncResult dd)
        {
            /*Bu metoddaki IAsyncResult tipinden dd parametresine gelen değer,
            AsyncState özelliğinden elde edilebilir.*/
        }

#endregion
    }
}
