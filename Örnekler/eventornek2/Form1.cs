using System;
using System.Drawing;
using System.Windows.Forms;

namespace eventornek2
{
    public partial class Form1 : Form
    {

        public delegate void userDelegate(int formNo);
        public event userDelegate UserEvent;

        //public delegate void EventHandler(object source, EventArgs args);//bunu yaratmak yerine c#2.0 iel gelen EventHandler deglesini kullanabiliriz
        //bununu bi de generic vfomru var EventHanlder<TEventArgs> diye. eğer args göndermeyeceksen noral olanı kullan
        public event EventHandler Listbecomefull;


        protected virtual void OnListbecomefull(object source, EventArgs e) //veya parametresiz, veya sadece eventargs. bunda zorunluluk yok, bu iki parematernin zorunlu olduğu yer bu metod değil eventhandler metodu
        {
            if (Listbecomefull != null)
            {
                Listbecomefull(this, e); //tanımlarken paramaetersiz olsydaı burya eventargs.empty                
            }

            //veya kısaa  Listbecomefull?.Invoke(this, e);
        }

        public Form1()
        {
            InitializeComponent();

            this.Listbecomefull += new EventHandler(Listedoluhaberiver); //bu subscriber tarafın metoddur, ki aynı zamanda Eventhandler metod da denir. . delegeyle aynı imzada tanımalnırlar. sonda () olamdığıan dikkat
            //veya kısaca Listbecomefull += listedoluhaberiver;
            //kısa formu kullanmak daha iyi, çünkü evnethandler delege tipini değiştiridiğinde her yerde değiştirmen gerekir
            this.Listbecomefull += MakeLabel2VisibelAndRed;

        }

        public void Listedoluhaberiver(object sender, EventArgs e)//tüm butonclicklerde de bu iki parametre var. Bu ir eventhandlerdır tüm butoncikler ibi
        {
            MessageBox.Show("event trigger oldu, liste doludur");
        }

        public void MakeLabel2VisibelAndRed(object source, EventArgs e)
        {
            //kalıcı etki yapıyor, liste biraz boşaldığında tekrar terse çevirmek lazım
            label2.Visible = true;
            label2.ForeColor = Color.Red;
            label2.Text = "liste dolduuuuuuuu";
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("selam");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventDemo ed = new EventDemo();
            ed.baslat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EventDemoc edc = new EventDemoc();
            edc.Baslat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EventDemoh edh = new EventDemoh();
            edh.baslat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KeyEventDemo kd = new KeyEventDemo();
            kd.baslat();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Form1.metodTetikle(formNo);
        }

        public void MetodTetikle(int formNo)
        {
            UserEvent(formNo);
        }

        public void writeFormNo(int tetiklenenNo)
        {
            //lblAciklama.Text = "Tuşa Basılan Form Numarası:" + tetiklenenNo;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = new Random();
            if (listBox1.Items.Count < 10)
            {
                listBox1.Items.Add(r.Next(1, 100).ToString());
                if (listBox1.Items.Count == 10)
                {
                    MessageBox.Show("liste doldu, başka kayıt ekleyemezsiniz");
                    OnListbecomefull(this, EventArgs.Empty);//eventin mantığı:buraya bu event yerie eventin tetiklediğimetoları da yazaibliriz ama bunların bu buton8click metoduyal bi ilgisi yok, buton8in bunu bilmesi geremiyor....... hele hele 10larca meto tetiklencekse burada olmaları gerekimyor, eventi yarat, diğer 10 metod da bu evente üye olsun                    
                }
            }
            else
            {
                MessageBox.Show("liste şuan dolu, daha kayıt ekleyemezsiniz");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //button8 disabled iken performclik yapılamzken invokeonclik yapılabilir
            button8.PerformClick(); //C#4.0ten itibaren

            /*referecen source
             public void PerformClick() {
                  if (CanSelect) {
                     bool validatedControlAllowsFocusChange;
                     bool validate = ValidateActiveControl(out validatedControlAllowsFocusChange);
                     if (!ValidationCancelled && (validate || validatedControlAllowsFocusChange))
                     {
                       //Paint in raised state...
                       ResetFlagsandPaint();
                       OnClick(EventArgs.Empty);
                     }
                  }
                }
             */
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            InvokeOnClick(button8, EventArgs.Empty);//InvokeOnClick just calls the OnClick function of the control.

            /* reference soruce in MSDN
             protected void InvokeOnClick(Control toInvoke, EventArgs e) {
                  if (toInvoke != null) {
                    toInvoke.OnClick(e);
                  }
                }
             */
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("açıklamaya bak");
            /*
             OnClick allows you to add a handler for when the Click event occurs on the control. InvokeOnClick will "Raise the Click event for the specified control".

               So if you have assigned a handler to OnClick and then call InvokeOnClick on that control then your handler will be called.
             */

            /*
             protected override void OnClick(EventArgs e)
	            {
		            this.SelectAll();
		            base.OnClick(e);
	            }
             */

            /*benim anladığım şu:onclik trigger metodudur. Click event. button8_click da eventhandler metodu. onclicki sadece yuakrdaki örnekteki gibi override etmek için kullanırız.
             
             */
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button8_Click(this, EventArgs.Empty);
            //veya button8_Click(null, EventArgs.Empty);
            //veya button8_Click(this,null); veya button8_Click(null,null);
        }
    }
}
