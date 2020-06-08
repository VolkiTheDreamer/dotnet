using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apicall
{
    public partial class Form1 : Form
    {
        //https://reqres.in/  
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
                      
            txtresponse.Clear(); 
            RestClient rClient = new RestClient();
            rClient.endPoint = txtUri.Text;
            
            string strResponse = string.Empty;
            //strResponse = await rClient.makeRequest();
            strResponse = await rClient.makeRequest2();

            string guzel = Guzellestir(strResponse);
            debugouptput(guzel);
            try
            {
                Dictionary<string, Dictionary<string, object>> dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(strResponse);
                var innerdict = dict["data"];
                var dizimsi = from row in innerdict select new { Bilgi = row.Key, Deger = row.Value };
                dataGridView1.DataSource = dizimsi.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            string Guzellestir(string s)
            {
                JToken j = JToken.Parse(s);
                return j.ToString(Formatting.Indented);
            }
            
        }

        private void debugouptput(string txt)
        {
            try
            {
                System.Diagnostics.Debug.Write(txt + Environment.NewLine);
                txtresponse.Text = txtresponse.Text + txt + Environment.NewLine;
                txtresponse.SelectionStart = txtresponse.TextLength;
                txtresponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message + Environment.NewLine);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = @"https://reqres.in/api/users";

            string strResponse = string.Empty;
            strResponse = await rClient.Postala("volkan","consultant");
            debugouptput(strResponse);
        }
    }
}
