using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace eventornek2
{
    // Tusu tutan, istege uygun bir EventArgs sinifi turet. 
    class KeyEventArgs : EventArgs
    {
        public char ch;
    }
    // Bir olay icin bir delege deklare et. 
    delegate void KeyHandler(object source, KeyEventArgs arg);


    // Tus vuruslariyla ilgili bir olay sinifi deklare et. 
    class KeyEvent
    {
        public event KeyHandler KeyPress;
        // Bir tusa basildiginda bu cagrilir. 
        public void OnKeyPress(char key)
        {
            KeyEventArgs k = new KeyEventArgs();
            if (KeyPress != null)
            {
                k.ch = key;
                KeyPress(this, k);
            }
        }
    }


    // Tusa basildiginin haberini alan bir sinif. 
    class ProcessKey
    {
        public void keyhandler(object source, KeyEventArgs arg)
        {
            System.Windows.Forms.MessageBox.Show("Received keystroke: " +arg.ch);
        }
    }


    // Tusa basildiginin haberini alan bir baska sinif. 
    class CountKeys
    {
        public int count = 0;
        public void keyhandler(object source, KeyEventArgs arg)
        {
            count++;
        }
    }
    // KeyEvent‘i goster. 
    class KeyEventDemo
    {
        public void baslat()
        {
            KeyEvent kevt = new KeyEvent();
            ProcessKey pk = new ProcessKey();
            CountKeys ck = new CountKeys();
            char ch;
            kevt.KeyPress += new KeyHandler(pk.keyhandler);
            kevt.KeyPress += new KeyHandler(ck.keyhandler);
            System.Windows.Forms.MessageBox.Show("Enter some characters. " +
            "Enter a period to stop.");
            do
            {
                ch = Char.Parse(Interaction.InputBox("karakter gir"));
                kevt.OnKeyPress(ch);
            } while (ch !='.');
            System.Windows.Forms.MessageBox.Show(ck.count + "keys pressed.");
        }
    }

}
