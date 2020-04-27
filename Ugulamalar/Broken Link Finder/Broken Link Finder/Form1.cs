using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Net.Http;
using HtmlAgilityPack;


namespace Broken_Link_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }     

        //private bool UrlExists(string url)
        //{            
        //    try
        //    {
        //        //Creating the HttpWebRequest
        //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        //        //Setting the Request method HEAD, you can also use GET too.
        //        request.Method = "HEAD";

        //        //Getting the Web Response.
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        //Returns TRUE if the Status code == 200
        //        return (response.StatusCode == HttpStatusCode.OK);
        //    }
        //    catch
        //    {
        //        //Any exception will returns false.
        //        return false;
        //    }
        //}

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.label1.Text = "Lütfen bekleyiniz...";
                string root = this.txtAddress.Text.Substring(0, this.txtAddress.Text.Length-11); ///buraya ayar çek, bi kalsör içinde de olabilir
                var urller = GetUrlsinSitemap(this.txtAddress.Text);
                List<string> sorgulananlar = new List<string>();
                int adet = urller.Count;
                this.label1.Text = "Tarama başladı...%0";
                foreach (var u in urller)
                {
                    HtmlWeb web = new HtmlWeb();
                    string pageName = u;
                    HtmlAgilityPack.HtmlDocument document = web.Load(pageName); ///burası async olabilir
                    HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a[@href]").ToArray();
                    string sayfaLink = string.Empty;
                    string requestYapılacakLinq = string.Empty;
                    string muafString = string.Empty;
                    bool statü = false;
                    List<string> muaflar = new List<string>(); ///bunu listbox ile yapalım, kullanıcı girsin
                    muaflar.Add("hyp");
                    muaflar.Add("DataList");
                    
                    foreach (HtmlNode item in nodes)
                    {
                        sayfaLink = item.GetAttributeValue("href", string.Empty);
                        muafString = item.GetAttributeValue("id", string.Empty);
                        foreach (var m in muaflar)
                        {
                            if (muafString.Contains(m))
                            {
                                goto atla; //continue mu desek
                            }
                        }

                        if (sayfaLink.Substring(0, 1) == "#")
                            requestYapılacakLinq = pageName + sayfaLink;
                        else if (sayfaLink.Substring(0, 3) == "www" | sayfaLink.Substring(0, 4) == "http")
                            requestYapılacakLinq = sayfaLink;
                        else if (sayfaLink.Contains(".."))
                            requestYapılacakLinq = root + sayfaLink.Replace("..", ""); // birden falza / işareti sorun olmuyor linklerde
                        else if (sayfaLink.Substring(0, 4) == "java" || sayfaLink.Substring(0, 6) == "mailto")
                            goto atla;
                        else
                            requestYapılacakLinq = pageName.Substring(0,pageName.LastIndexOf("/")+1) + sayfaLink;
                        

                        if (!sorgulananlar.Contains(requestYapılacakLinq))
                        {
                            try
                            {
                                statü = await RemoteFileExists(requestYapılacakLinq);
                            }
                            catch 
                            {
                                this.dataGridView1.MultiSelect = true;///sil burayı sonra
                            }
                                
                            sorgulananlar.Add(requestYapılacakLinq);
                            if (statü == false) //sadece falselar yazsın
                            {
                                string[] row = new string[] { pageName, sayfaLink, requestYapılacakLinq, statü.ToString() };
                                this.dataGridView1.Rows.Add(row);
                            }
                        }       
                        
                        atla:;
                    }
                    await ProgressHallet(urller.IndexOf(u),adet,u);
                }
                MessageBox.Show("Tarama tamamlandı");
            }
            catch(Exception ex)
            {
                this.label1.Text = "";
               //this.label2.Text = ex.Message + "";
                this.progressBar1.Value = 0;
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ProgressHallet(int index, int adet,string url)
        {
            if (index==56)
            {
                this.progressBar1.Value = (int)index * 100 / adet;
            }
            await Task.Run(() =>
                {
                    this.progressBar1.Value = (int)index * 100 / adet;
                    this.label1.Text = "%" + (index * 100 / adet).ToString();
                    this.label2.Text = adet + " site içinde " + index + " nolu site: " + url;
                });
        }
        private async Task<bool>RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 1000;
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                bool sonuç = (response.StatusCode == HttpStatusCode.OK);
                response.Close();//bunu yapmazsak 1-2 responsedan sonrapatlıyor
                return sonuç;
            }
            catch 
            {
                return false;
            }
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



    }
}
