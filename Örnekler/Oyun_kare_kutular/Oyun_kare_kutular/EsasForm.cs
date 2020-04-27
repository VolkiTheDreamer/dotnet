using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Oyun_kare_kutular
{
    public partial class EsasForm : Form
    {
        public EsasForm()
        {
            InitializeComponent();
        }

        //private PictureBox btnAdd = new PictureBox();
        

        private void EsasForm_Load(object sender, EventArgs e)
        {

            PictureBox[] lDizi = new PictureBox[10];
                        for (int k = 0; k <= 1; k++)
            {
                for (int i = 0; i < lDizi.Length / 2; i++)
                {

                    lDizi[i] = new PictureBox();

                    //lDizi[i].Text = "Label" + i.ToString();
                    lDizi[i].BorderStyle = BorderStyle.FixedSingle;

                    this.Controls.Add(lDizi[i]);


                    lDizi[i].Location = new Point(100*k, 100*i);
                    lDizi[i].Size = new Size(50, 50);

                }
            }
            /*
            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(155, 265);
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
  
             
             // seçime göre kutu yarat ve hepsini invisible yap

            int fCount = Directory.GetFiles(@"C:\Users\Volkan\OneDrive\Photos\0_Volkan\PORTRELER\", "*", SearchOption.TopDirectoryOnly).Length;
            
              //dizi objelere resim atama metodu
             string[] filePaths = Directory.GetFiles(@"C:\Users\Volkan\OneDrive\Photos\0_Volkan\PORTRELER\");
             string[] rsm=new string[8];
             string[] used=new string[8];
            
            Random rstgl=new Random();
          
            
             for (int i=0; i<=7; i++)
            {
                rsm[i]=filePaths[rstgl.Next(1, fCount)];
             
             yeniden:                 
            
             int x=rstgl.Next(1, 16);
             //if(used.Contains(x)) goto yeniden;
             if (Array.IndexOf(used, x)>-1) goto yeniden;

             //image.item(x)=obj(k)
             used[k*2]=x;
             
             //şimdi de eşini atayalım
             yeniden2:
             y=rand(1 to 16)
             if y is a .....
             image.item(y)=obj(k)
             used[k*2+1]=y
                //label.items(1).text=rsm[i]                
            }
            

            /*
            label1.Text = rsm[0];
            label2.Text = rsm[1];
            label3.Text = rsm[2];
            label4.Text = rsm[3];
            label5.Text = rsm[4];
            label6.Text = rsm[5];
            label7.Text = rsm[6];
            label8.Text = rsm[7];
            */
             
            //   rsm(i)=image.add(rand(1 to 1000) in iligli path)
             
             
             // kutulara dizi objeleri atama
             
/*             * son olarak da tıklama kontrolü
             * 
             * img(any in collection).click olayı
             *tıklananı visible yap
             *if visiblerarın sayısı=2 then
             *  if visible1=visible2 then
             *      2sini de remove
             *      mesaj"aferin"
             *      if kalan kutu=0 then "braboo"
             *  ikisi de invisible again
             *
             * */
            
        }
        private void process1_Exited(object sender, EventArgs e)
        {

        }       
    }
}
