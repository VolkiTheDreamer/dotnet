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
    public partial class LambdaLINQForm : Form
    {
        public LambdaLINQForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //uzun kod, ek metod var. 5ten küçük lambda  funcvari metod
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new int[rakamlar.Length];
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rakamlar[i]);
            }

            var sonuc = numbers.Where(beştenküçük); //predicate alır
            foreach (var item in sonuc)
            {
                System.Diagnostics.Trace.WriteLine(item);
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //kısa kod, ek metoda gerek yok. 5ten küçük lambda  delegate
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new int[rakamlar.Length];
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rakamlar[i]);
            }

            var sonuc = numbers.Where(delegate (int x) { return x < 5; }); //
            foreach (var item in sonuc)
            {
                System.Diagnostics.Trace.WriteLine(item);
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }

        private void button1_Click(object sender, EventArgs e)
        {//daha kısa kod. lambda
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new int[rakamlar.Length];
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rakamlar[i]);
            }

            var sonuc = numbers.Where(x => x < 5);
            foreach (var item in sonuc)
            {
                System.Diagnostics.Trace.WriteLine(item);
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LINQ
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new List<int>();
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers.Add(Convert.ToInt32(rakamlar[i]));

            }

            var sonuc = from n in numbers //bu LINQ
                        where n < 5
                        select n;

            foreach (var item in sonuc)
            {
                System.Diagnostics.Trace.WriteLine(item);
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }


        public bool beştenküçük(int i)
        {
            return i < 5;
        }



        private void button5_Click(object sender, EventArgs e)
        {//predicate
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new int[rakamlar.Length];
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rakamlar[i]);
            }

            Predicate<int> prdct_sayılar = Sayıbul;
            int[] bul = Array.FindAll(numbers, prdct_sayılar);
            foreach (var item in bul)
            {
                System.Diagnostics.Trace.WriteLine(item);
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }

        private static bool Sayıbul(int i)
        {
            return i < 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //predicate+lambda(findall)
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new int[rakamlar.Length];
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rakamlar[i]);
            }

            int[] bul = Array.FindAll(numbers, i => i < 5);
            foreach (var item in bul)
            {
                System.Diagnostics.Trace.WriteLine(item);
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }

        private void button7_Click(object sender, EventArgs e)
        {//geleneksel
            string[] rakamlar = textBox1.Text.Split(separator: ';');
            var numbers = new int[rakamlar.Length];
            for (int i = 0; i < rakamlar.Length; i++)
            {
                numbers[i] = Convert.ToInt32(rakamlar[i]);
            }
            BestenKucukleriYaz(numbers);
        }
        static void BestenKucukleriYaz(int[] dizi)
        {
            foreach (var item in dizi)
            {
                if (item < 5)
                {
                    System.Diagnostics.Trace.WriteLine(item);
                }
            }
            System.Diagnostics.Trace.WriteLine("------------------");
        }



        private void button8_Click(object sender, EventArgs e)
        {
            LINQ_Lambda2 linqlambda = new LINQ_Lambda2();
            linqlambda.Ana();
            Console.ReadLine();
            linqlambda.Detay();

        }
    }
}
