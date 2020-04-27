using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          //  List<string> tumDosyaList = new List<string>();

            string[] oneFolderFileArray = null;
            oneFolderFileArray = Directory.GetFiles(@"C:\Users\Volkan\Desktop\rotasyon", "*.*", SearchOption.AllDirectories);
            //tumDosyaList.AddRange(oneFolderFileArray);
            foreach (var item in oneFolderFileArray)
            {
                checkedListBox1.Items.Add(item);
            }
         }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked) //sadece tick konuyorsa çalışsın, tick kalkıyorsa bişey yok
            {
                string dsy = checkedListBox1.SelectedItem.ToString();
                var img = Image.FromFile(dsy);
                pictureBox1.Image = img;

                if (Array.IndexOf(img.PropertyIdList, 274) > -1) //EXIF özelliği varsa, 8 seçenekli bir dizi döndürür, -1 ise boştur yani özellik yoktur
                {
                    string islem = String.Empty;
                    switch ((int)img.GetPropertyItem(274).Value[0])
                    {
                        case 1:
                            islem="Normal-Bişey ypaılmayack";
                            break;
                        case 2:
                            islem="X ekseninde flip edilecek";
                            break;
                        case 3:
                            islem = "180 döndürlecek";
                            break;
                        case 4:
                            islem = "180 döndürlecek ve X ekseninde flip";
                            break;
                        case 5:
                            islem = "270 dönmüş,90 döndürlecek ve X ekseninde flip";
                            break;
                        case 6:
                            islem = "270 dönmüş,90 döndürlecek";
                            break;
                        case 7:
                            islem = "90 dönmüş,270 döndürlecek ve X flip";
                            break;
                        case 8:
                            islem = "90 dönmüş,270 döndürlecek";
                            break;
                    }
                    label1.Text = img.GetPropertyItem(274).Value[0].ToString()+" - "+islem;                    
                }
                else
                {
                    label1.Text = "EXIF yön özelliği yok";
                }
            }
        }
    }
}
