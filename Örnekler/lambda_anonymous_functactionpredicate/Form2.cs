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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                Action printText = new Action(MethodCollections.PrintText);//generic olmayan hali, parametre almaz
                Action<string> print = new Action<string>(MethodCollections.Print);
                Action<int, int> printNumber = MethodCollections.PrintNumbers;//kısa yazım şekli, new action demeden

                Func<int, int, int> add1 = new Func<int, int, int>(MethodCollections.Addition);
                Func<int, int, string> add2 = MethodCollections.DisplayAddition;//kısa yazım
                    Func<string, string, string> completeName = MethodCollections.SHowCompleteName;
                Func<int> random = new Func<int>(MethodCollections.ShowNumber);

                Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");
                printText();    //Parameter: 0 , Returns: nothing  
                print("Abhishek");  //Parameter: 1 , Returns: nothing  
                printNumber(5, 20); //Parameter: 2 , Returns: nothing  
                Console.WriteLine();
                Console.WriteLine("**************** Func<> Delegate Methods *****************\n");
                int addition = add1(2, 5);  //Parameter: 2 , Returns: int  
                string addition2 = add2(5, 8);  //Parameter: 2 , Returns: string  
                string name = completeName("volkan", "yurtseven");    //Parameter:2 , Returns: string  
                int randomNumbers = random();   ////Parameter: 0 , Returns: int  

                Console.WriteLine("Addition: {0}", addition);
                Console.WriteLine(addition2);
                Console.WriteLine(name);
                Console.WriteLine("Random Number is: {0}", randomNumbers);

                Console.ReadLine();
            
        }
    }
}
