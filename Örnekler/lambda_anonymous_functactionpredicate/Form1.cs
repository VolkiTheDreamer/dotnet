using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lambda_anonymous_functactionpredicate
{
    public partial class Form1 : Form
    {
        public delegate double delegateHesapla(double a, double b);
        static delegateHesapla mydel = NIMHesapla;

        public Form1()
        {
            InitializeComponent();
        }

        public static double NIMHesapla(double hacim, double spread)
        {
            return hacim * spread / 12;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblSonuc.Text= "NIM:" + mydel(double.Parse(textBox1.Text),Convert.ToDouble(textBox2.Text));
        }

        private void btnAnonymous_Click(object sender, EventArgs e)
        {
            //bunda yine delege kullanımı var, ama ayrı metoda gerek yok, metoddan tasarrufsağlıyor,  c# 2.0 ve sonrası
            delegateHesapla hesap = delegate(double hacim, double spread)
             {
                 return hacim * spread / 12;
             }
            ;
            lblSonuc.Text = "NIM:" + hesap(double.Parse(textBox1.Text), Convert.ToDouble(textBox2.Text));

        }

        private void btnLambda_Click(object sender, EventArgs e)
        {
            //bunda da yine delege kullanımı var, ama anonymoustan bile daha kısa,  c# 3.0 ve sonrası
            delegateHesapla hesap = (h, s) => h * s / 12;
            lblSonuc.Text = "NIM:" + hesap(double.Parse(textBox1.Text), Convert.ToDouble(textBox2.Text));
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            //Func ile. func<input1,input2,output>, bu da .NET 3,5 ile geldi. func kullandığımızda delege tanımlamaya gerek kalmamaktadır, zira Func'in kendisi bir delegedir. son paremteresi sonuç, öncekiler inputtur.  Funcları lambdalı da yazabiliyoruz lambdasız da, lambdalı daha kısadır tabi.
            Func<double,double,double> Hesap = (a, b) => a * b /12; //a ve b'nin önüne tip yazmaya gerek yok   
            lblSonuc.Text = "NIM:" + Hesap(double.Parse(textBox1.Text), Convert.ToDouble(textBox2.Text));
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            //Functan farklı olarak out parametresi yok, yani sonuç döndürmez, voiddirler.            
            double sonuc=double.Parse(textBox1.Text)* Convert.ToDouble(textBox2.Text)/12;

            Action<double> myAction = x => lblSonuc.Text = "NIM:" + x.ToString();
            myAction(sonuc);
        }

        private void btnPredicate_Click(object sender, EventArgs e)
        {
            //Predicate, Func'ın extensiondır, bi koşulun sağlanaıp sağlanmadığına bakar, ve bu yüzden hep voiddir. tek parametre alır.
            var dict = new Dictionary<double, double>();
            dict.Add(double.Parse(textBox1.Text) , Convert.ToDouble(textBox2.Text));            
           // Predicate<Dictionary<double, double>> besbidenBuyukMu =  x => x.Keys[0]*x.Values[0] > 5000;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("design viewda hep hata gibi gösteriyor, aslında çalışıyor ama design viewdaki butonlar herien hata ekranı gösteriyor.\n Normalde şöyle olmalı: delegeate{lblsonus.text='NIM:'+double.Parse(textBox1.Text)* System.Convert.ToDouble(textBox2.Text)/12}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LambdaLINQForm frm2 = new LambdaLINQForm();
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
