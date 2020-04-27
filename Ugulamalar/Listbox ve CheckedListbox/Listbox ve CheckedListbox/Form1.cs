using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Listbox_ve_CheckedListbox
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// kontroller eklendikten sonra, checkedlistbox'ın CheckOnClik özelliğini true yaptım,
        /// listboxın da  selection modunu multi yaptım, bunlar default özellike dğeiller, manuel yapılması lazım
        /// </summary>

        public Form1()
        {
            InitializeComponent();
        }       
        private void btnRasgeleNumber_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();            
            int sayi = rastgele.Next(0, 1000);
            checkedListBox1.Items.Add(sayi);
        }
        private void btnRasgeleHarf_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int ascii = rastgele.Next(65, 91);
            char harf = Convert.ToChar(ascii);
            listBox1.Items.Add(harf);
        }
        private void chkChkListTumunuIsaretle_CheckedChanged(object sender, EventArgs e)
        {
          checkedListBox1.ItemCheck -= checkedListBox1_ItemCheck;//tümünü seç dediğinde checkedlistboxın item_check eventi trigger olmasın diye eventi detach ediyorum, en altta tekrar bağlıycam. gerçi "itemcheck kontrolü olmasın" kutusu işareltendiğinde zaten onu orada durduruyorum ama seçilmeme durumunda bu iş görsün
            bool b = chkChkListTumunuIsaretle.Checked;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, b);                
            }
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;//eventi tekrar bağlıyorum
            if (b == true)
            { chkChkListTumunuIsaretle.Text = "Tüm işaretleri kaldır"; }
            else
            { chkChkListTumunuIsaretle.Text = "Tümünü işaretle"; }
        }
        private void chkListBxtumunusec_CheckedChanged(object sender, EventArgs e)
        {
            //listboxın selectionmodunu multilerden biri yapmak lazım. yukardaki checkedlistboxtan farklı olarak bunda select yapıcaz, multiselect.
            bool b = chkListBxtumunusec.Checked;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SetSelected(i, b);                                 
            }

            if (b == true)
            { chkListBxtumunusec.Text = "Tüm seçimi temizle"; }
            else
            { chkListBxtumunusec.Text = "Tümünü seç"; }
        }
        private void btnChkRemoveChekli_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0) //chlb boşken yanlışlıkla bastığında ve/veya işaretli bir kayıt yokken çalışmasın
            {
                checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[0]);                
            }
        }
        private void btnChkRemoveChekliler_Click(object sender, EventArgs e)
        {
            //işaretliler içinde hep 0 indeksli olan elemanı silme yöntemini
            if (checkedListBox1.CheckedItems.Count > 0)// items demedim, checkeditems dedim, çünkü belki bişeyler olcak ama işaretlenmediyse çalışmasın
            {
                for (int s = 0; s < checkedListBox1.CheckedItems.Count; s++)
                {
                    checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[s]);                    
                    s--;//s'nin hiç artmamasını sağlıyorum, böylece her iterasyonda hep 0. indexteki eleman üerinde işlem yapmış oluyorum  
                }
            }
        }
        private void btnListClearAll_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void btnListRemoveSecili_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) //seçim yapılmadıysa çalışmasın
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
        private void btnListRemoveMultiselect_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) //seçim yapılmadıysa çalışmasın
            {                 
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                {                                       
                    listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                }                    
            }            
        }
        private void btnMoveSelected_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.CheckedIndices.Count - 1; i >= 0; i--)
            {
                int idx = checkedListBox1.CheckedIndices[i];
                listBox1.Items.Add(checkedListBox1.Items[idx]);
                checkedListBox1.Items.RemoveAt(idx);//bunu demezsem copy olmuş olur
            }
        }
        private void btnChkClearAll_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seçimden sonraki durumu gösterir, ItemCheck olayı ise öncesini gsöteriyor
            System.Text.StringBuilder ms = new System.Text.StringBuilder();
            ms.Append("chkList_selectedindexchanged tetiklendi");
            ms.AppendLine();
            ms.Append("Seçili ve İşaretli kayıt sayısına bakalım, seçim sonrası durumu gösterir");
            ms.AppendLine();
            ms.AppendFormat("Seçili Kayıt:{0}", checkedListBox1.SelectedItems.Count.ToString());//her zaman 1dir, çünkü cb'lada çoklu kayıt modu izin veirlmiyor
            ms.AppendLine();
            ms.AppendFormat("İşaretli kayıt:{0}", checkedListBox1.CheckedItems.Count.ToString());
            MessageBox.Show(ms.ToString(),"ChklistSelectedChange olayı");

        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //ItemChecked is fired before CheckedItems is updated.

            if (chkItemCheckKontrol.Checked==true)
            {
                return;
            }
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.Append("ItemCheck tetiklendi");
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("Item = {0}", checkedListBox1.GetItemText(checkedListBox1.Items[e.Index]));
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("Index = {0}", e.Index);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("CurrentValue = {0}", e.CurrentValue);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("NewValue = {0}", e.NewValue);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "ItemCheck olayı");


            //işaret kondu mu kalktı mı ona bakalım
            MessageBox.Show("hala itemcheck içindeyiz,işaret kondu mu kalktı mı ona bakalım.");
            if (e.NewValue==CheckState.Checked)// veya if (e.NewValue.ToString() == "Checked")           
            {
                MessageBox.Show("İşaretleme yapıldı");
            }
            else
            {
                MessageBox.Show("İşaretleme kalktı");
            }

            //şimbi yeni seçim öncesinde kimler seçili bi ona bakalım
            {
                MessageBox.Show("hala itemcheck içindeyiz,şimdi seçim öncesi duruma bakalım");
                //ilk kez seçim ypaıılıyorsa farklı bi mesaj çıkarlaım
                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Seçim öncesinde henüz bi seçim yok, yani ilk kez seçim yapılıyor");
                }
  
                foreach (int cekli_index in checkedListBox1.CheckedIndices)
                {

                    MessageBox.Show("Index#: " + cekli_index.ToString() + ", işaretli. İşaret durumu:" +
                                    checkedListBox1.GetItemCheckState(cekli_index).ToString() + ".");
                }

                foreach (object cekli_item in checkedListBox1.CheckedItems)
                {
                    MessageBox.Show("Şu eleman: \"" + cekli_item.ToString() +
                                    "\", işaretli. İşaret durumu: " +
                                    checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(cekli_item)).ToString() + ".");
                }
            }

            //şimbi bi de yeni seçim sonrasında kimler seçili bi ona bakalım
            {
                MessageBox.Show("Şimdi bakalım bu seçim sonrasında kimler seçili, List Yöntemi, hala itemcheck içindeyiz");
                List<string> secililer = new List<string>();
                foreach (var item in checkedListBox1.CheckedItems)
                    secililer.Add(item.ToString());
                //yukarıyı şöyle de yapablridik: List<string> secililer = checkedListBox1.CheckedItems.Cast<string>().ToList(); ama olmadı, çünkü değerler integer, o yüzden cast yapaymıo, string olsaydı olurdu
            

                if (e.NewValue == CheckState.Checked)
                {
                    secililer.Add(checkedListBox1.Items[e.Index].ToString());
                }
                else//işareti kalkan kaydı çıkar
                {
                    secililer.Remove(checkedListBox1.Items[e.Index].ToString());
                }
                int i = 1;
                foreach (string item in secililer)
                {
                    MessageBox.Show(i + ".eleman:" + item);
                    i++;
                }
            }

        }
        private void btnListSecimCancel_Click(object sender, EventArgs e)
        {            
            listBox1.ClearSelected();            
        }
        private void btnClbIsaretCancel_Click(object sender, EventArgs e)
        {
            //hep işaretlilerden 0. indeksteki kaydın işaretini kadırıyoruz
            while (checkedListBox1.CheckedIndices.Count > 0)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            }
            chkChkListTumunuIsaretle.Checked = false;
            chkChkListTumunuIsaretle.Text = "Tümünü işaretle";

        }
        private void txtIndexforChkList_MouseClick(object sender, MouseEventArgs e)
        {
            txtIndexforChkList.Clear();
            txtIndexforChkList.ForeColor = System.Drawing.Color.Black;
        }
        private void rdList_CheckedChanged(object sender, EventArgs e)
        {
            bool b = rdList.Checked;
                btnIndexliIsaretClear.Enabled = !b;
                btnIndexliIsaretdurumu.Enabled = !b;
                btnIndexliIsaretle.Enabled = !b;            
        }
        private void btnIndexliSec_Click(object sender, EventArgs e)
        {            
            int i =int.Parse(txtIndexforChkList.Text);

            if (rdChkList.Checked)
            {
                if (i <= checkedListBox1.Items.Count - 1)
                {
                    checkedListBox1.SetSelected(i, true);
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }
            else
            {
                if (i <= listBox1.Items.Count - 1)
                {
                    listBox1.SetSelected(i, true);
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }

        }
        private void btnIndexliSecimiclear_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtIndexforChkList.Text);

            if (rdChkList.Checked)
            {
                if (i <= checkedListBox1.Items.Count - 1)
                {
                    checkedListBox1.SetSelected(i, false);//buraya ayrıca, eleman zaten seçiliyse bunu belirten bir mesaj çıkartan kod parçası da yazılabilir ama o kadara da gerek yok bu aşamada
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }
            else
            {
                if (i <= listBox1.Items.Count - 1)
                {
                    listBox1.SetSelected(i, false);//buraya ayrıca, eleman zaten seçiliyse bunu belirten bir mesaj çıkartan kod parçası da yazılabilir ama o kadara da gerek yok bu aşamada
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }
        }
        private void btnIndexliSecimdurumu_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtIndexforChkList.Text);

            if (rdChkList.Checked)
            {
                if (i <= checkedListBox1.Items.Count - 1)
                {
                    MessageBox.Show(checkedListBox1.GetSelected(i).ToString());
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }
            else
            {
                if (i <= listBox1.Items.Count - 1)
                {
                    MessageBox.Show(listBox1.GetSelected(i).ToString());
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }
        }
        private void btnIndexliIsaretle_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtIndexforChkList.Text);

            if (rdChkList.Checked)
            {
                if (i <= checkedListBox1.Items.Count - 1)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten daha büyük");
                }
            }
            else
            {
               //buraya bişey yazmıyoruz aslında else'i hiç olmayacak çünkü rdChklisst seçieli dğeilse yani Listbox seçili dğeilse bu butona hiç tıklanamayaak bu bu event hiç trigger olmayack
            }
        }
        private void btnIndexliIsaretClear_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtIndexforChkList.Text);

            if (rdChkList.Checked)
            {
                if (i <= checkedListBox1.Items.Count - 1)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");
                }
            }
            else
            {
                //buraya bişey yazmıyoruz aslında else'i hiç olmayacak çünkü rdChklisst seçieli dğeilse yani Listbox seçili dğeilse bu butona hiç tıklanamayaak bu bu event hiç trigger olmayack
            }
        }
        private void btnIndexliIsaretdurumu_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtIndexforChkList.Text);

            if (rdChkList.Checked)
            {
                if (i <= checkedListBox1.Items.Count - 1)
                {
                    MessageBox.Show(checkedListBox1.GetItemChecked(i).ToString());
                }
                else
                {
                    MessageBox.Show("girilen index değeri en yüksek indexten dah büyük");                    
                }
            }
            else
            {
                //buraya bişey yazmıyoruz aslında else'i hiç olmayacak çünkü rdChklisst seçieli dğeilse yani Listbox seçili dğeilse bu butona hiç tıklanamayaak bu bu event hiç trigger olmayack
            }
        }
        private void btnListIndex_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {                
                MessageBox.Show(String.Format("Seçili eleman: {0}, selectedvalue: {1}, getitemtext:{2} indexi:{3} ve selectedindexi {4} ", 
                    item.ToString(),
                    "N/A",
                    listBox1.GetItemText(item),
                    listBox1.Items.IndexOf(item), 
                    listBox1.SelectedItems.IndexOf(item)
                    ));                
            }

        }
        private void btnListVarmi_Click(object sender, EventArgs e)
        {
            string a = txtListVarmi.Text;

            if (listBox1.FindStringExact(a) != ListBox.NoMatches)   //veya -1 
                //burdalistbox1.items.indexof kullanılmaz çnkü, indexof parametre olarak object alır, halbuki bizde string var                         
            {
                MessageBox.Show("bu harf listede mevcut ve sırası:"+ listBox1.FindStringExact(a));
            }
            else
            {
                MessageBox.Show("bu harf listede yok");
            }
            //bir diğer yöntem de listbox elemanlarını bir List'e atamak ve orada contains özelliğinie kullanmak olabilirdi
        }
        private void txtListVarmi_MouseClick(object sender, MouseEventArgs e)
        {
            txtListVarmi.Clear();            
            txtListVarmi.ForeColor = System.Drawing.Color.Black;
        }
    }
}
