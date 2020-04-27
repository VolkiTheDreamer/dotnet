using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;
using System.Xml;
using System.Diagnostics;
using OfficeOpenXml;
using System.IO;
using MyUtility;

namespace Web_Site_TOC
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// muaflar ve subfolderlar içn bi giriş yeri olsun, ben şimdilki sadece alt klaösr olarak VBA seçiyorum, GetUrlsinSitemap içinde
        /// </summary>

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Debug.Assert(this.dataGridView1.Rows.Count>48,);
                this.label1.Text = "Lütfen bekleyiniz...";
                string root = this.txtAdress.Text.Substring(0, this.txtAdress.Text.Length - 11); ///buraya ayar çek, bi kalsör içinde de olabilir
                var urller = GetUrlsinSitemap(this.txtAdress.Text);
                //List<string> sorgulananlar = new List<string>();
                int adet = urller.Count;
                this.label1.Text = "Tarama başladı...%0";

                var fi = new FileInfo(@"C:\Users\volka\Desktop\dikeyeksen2.xlsx");
                int r = 1;//excel row start
                using (var p = new ExcelPackage(fi))
                {
                    var ws = p.Workbook.Worksheets.Add("TOC");
                    foreach (var u in urller)
                    {
                        HtmlWeb web = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument document = web.Load(u); ///burası async olabilir
                        string title = string.Empty;
                        string eleman = string.Empty;                                             
                        
                        {                            
                            try
                            {
                                var xpath = "//*[self::h1 or self::h2 or self::h3 or self::h4 or self::h5]";
                                foreach (var node in document.DocumentNode.SelectNodes(xpath))
                                {
                                    //do something
                                    title = node.InnerText;
                                    eleman = node.Name;// + "-" + node.NodeType + "-" + node.OriginalName+ "-" + node.XPath+ "-"+ node.GetAttributeValue("name",string.Empty) + "-" /*+node.Attributes["name"].Value + "-"*/ + node.OuterHtml;
                                    string[] row = new string[] { u, title, eleman };
                                    this.dataGridView1.Rows.Add(row);

                                    //excele de yazalım
                                    ws.Cells[r, 1].Value = u;
                                    ws.Cells[r, 2].Value = title;
                                    ws.Cells[r, 3].Value = eleman;
                                    r++;
                                }
                            }
                            catch (Exception ex)
                            {
                                Ut.DumpToOutput(ex.Message);
                                r++;
                            }

                            p.Save();
                        }
                        await ProgressHallet(urller.IndexOf(u), adet, u);
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
                    if (node["loc"].InnerText.Contains("VBA"))
                    {
                        liste.Add(node["loc"].InnerText);
                    }                    
                }

                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async Task ProgressHallet(int index, int adet, string url)
        {
            if (index == 56) //? 56 ne ?
            {
                this.progressBar1.Value = (int)index * 100 / adet;
            }
            await Task.Run(() =>
            {
                this.progressBar1.Value = (int)index * 100 / adet;
                this.label1.Text = "%" + (index * 100 / adet).ToString();
                this.label2.Text = adet + " sayfa içinde " + index + " nolu sayfa: " + url;
            });
        }

    }
}
