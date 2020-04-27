using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;

namespace HTMLElementiciGetirici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {            
            try
            {                
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string copyAddres = fbd.SelectedPath;
                ///null kontorlü, yani kalöasr seçemeze
                this.label1.Text = "Lütfen bekleyiniz...";

                if (this.rbSitemap.Checked)
                {                    
                    string root = this.txtUrl.Text.Substring(0, this.txtUrl.Text.Length - 11);
                    var urller = GetUrlsinSitemap(this.txtUrl.Text);                    
                    int adet = urller.Count;
                    int iptal = 0;
                    this.progressBar1.Visible = true;
                    this.label1.Text = "Tarama başladı...%0";
                    foreach (var u in urller)
                    {                       
                        HtmlWeb web = new HtmlWeb();
                        string pageName = u;
                        HtmlAgilityPack.HtmlDocument document = web.Load(pageName); ///burası async olabilir
                        string tagoridorclass = this.txtTagOrClass.Text; //ilerde burası çoklu değer alsın, ve dizi ile dön, veya htmlgilty imkan sağlıyorsa tek seferde de olabilir
                        HtmlNodeCollection hnc = document.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", tagoridorclass));
                      
                        if (hnc != null)
                        {
                            HtmlNode[] nodes = hnc.ToArray();
                            string content = string.Empty;

                            foreach (HtmlNode item in nodes)
                            {
                                content = item.InnerText.Replace("&nbsp;", " ").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;","&").Replace("&quot;","\"");
                                using (StreamWriter sw = new StreamWriter(copyAddres + "\\urlsonuc.txt", true))
                                {
                                    sw.WriteLine("'" + u);
                                    sw.WriteLine(content);
                                }
                            }
                            await ProgressHallet(urller.IndexOf(u)-iptal, adet-iptal, u);
                        }
                        else
                        {
                            iptal++;                             
                        }
                        
                               
                    }
                }
                else
                {                    
                    //progres görünmez kalsın
                    HtmlWeb web = new HtmlWeb();
                    string pageName = this.txtUrl.Text;
                    HtmlAgilityPack.HtmlDocument document = web.Load(pageName);
                    string tagoridorclass = this.txtTagOrClass.Text; //ilerde burası çoklu değer alsın, ve dizi ile dön, veya htmlgilty imkan sağlıyorsa tek seferde de olabilir
                    HtmlNodeCollection hnc = document.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", tagoridorclass));
                    if (hnc.Count > 0)
                    {
                        HtmlNode[] nodes = hnc.ToArray();
                        string content = string.Empty;

                        foreach (HtmlNode item in nodes)
                        {
                            content = item.InnerText.Replace("&nbsp;", " ").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;","&").Replace("&quot;","\"");
                            using (StreamWriter sw = new StreamWriter(copyAddres + "\\urlsonuc.txt", true))
                            {
                                sw.WriteLine(content);
                            }
                        }
                    }
                }
                
                
                MessageBox.Show("Tarama tamamlandı");
            }
            catch (Exception ex)
            {
                this.label1.Text = "";
                //this.label2.Text = ex.Message + "";
                this.progressBar1.Value = 0;
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ProgressHallet(int index, int adet, string url)
        {
            if (index == 56) /// ne iş?
            {
                this.progressBar1.Value = (int)index * 100 / adet;
            }
            await Task.Run(() =>
            {
                this.progressBar1.Value = (int)index * 100 / adet;
                this.label1.Text = "%" + (index * 100 / adet).ToString();
                this.label4.Text = adet + " site içinde " + index + " nolu site: " + url;
            });
        }

        private List<string> GetUrlsinSitemap(string url)
        {
            try
            {
                var liste = new List<string>();
                WebClient wc = new WebClient();
                wc.Encoding = System.Text.Encoding.UTF8;
                string reply = wc.DownloadString(url);
                XmlDocument urldoc = new XmlDocument();
                urldoc.LoadXml(reply);
                XmlNodeList xn = urldoc.GetElementsByTagName("url");
                foreach (XmlNode node in xn)
                {
                    liste.Add(node["loc"].InnerText);
                }

                liste.Remove(@"https://www.excelinefendisi.com/Sitemap.aspx");
                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void rbPage_CheckedChanged(object sender, EventArgs e)
        {
            
            if (((RadioButton)sender).Checked) //iki kere fire olmasın die.
            {
                if (((RadioButton)sender) == this.rbSitemap)
                {
                    this.rbPage.Checked = false;
                    this.lblUrl.Text = "Sitemap URL'si";
                }
                else if (((RadioButton)sender) == this.rbPage)
                {
                    this.rbSitemap.Checked = false;
                    this.lblUrl.Text = "Tek Sayfa URL";
                }
            }
            
        }

        private void txtTagOrClass_Enter(object sender, EventArgs e)
        {
            this.txtTagOrClass.Clear();
        }
    }
}
