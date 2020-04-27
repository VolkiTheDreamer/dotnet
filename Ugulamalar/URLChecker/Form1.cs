//Download From
//Visual C# Kicks - http://www.vcskicks.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace URLChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckURL(string url)
        {
            //Update UI
            lStatus.Text = "Checking URL...";
            lStatus.ForeColor = Color.Black;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            Uri urlCheck = new Uri(url);

            WebRequest request = WebRequest.Create(urlCheck);
            request.Timeout = 15000;

            WebResponse response;
            try
            {
                //get URL web response
                response = request.GetResponse();
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                return false; //url does not exist
            }            

            string responseURL = response.ResponseUri.ToString();

            //Update UI
            this.Cursor = Cursors.Default;
            Application.DoEvents();
            if (string.Compare(responseURL, urlCheck.ToString(), true) != 0) //it was redirected, check to see if redirected to error page
                   return !(responseURL.IndexOf("404.php") > -1 ||
                          responseURL.IndexOf("500.php") > -1 ||
                          responseURL.IndexOf("404.htm") > -1 ||
                          responseURL.IndexOf("500.htm") > -1);
            else
                return true; //everything okay
        }

        private void btnURL_Click(object sender, EventArgs e)
        {
            lCheck.Visible = false;

            if (txtURL.Text == "http://" || txtURL.Text == string.Empty) return; //No URL entered

            if (CheckURL(txtURL.Text))
            {
                lStatus.Text = txtURL.Text + " Exists";
                lStatus.ForeColor = Color.Green;
            }
            else
            {
                lStatus.Text = txtURL.Text + Environment.NewLine + " Was Not Found";
                lStatus.ForeColor = Color.Red;

                lCheck.Left = lStatus.Left + lStatus.Width + 4;
                lCheck.Text = "Manual Check...";
                lCheck.Visible = true;
            }
        }

        private void txtURL_Leave(object sender, EventArgs e)
        {
            if (!txtURL.Text.StartsWith("http://"))
                txtURL.Text = "http://" + txtURL.Text;
        }

        private void lCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lStatus.Text != string.Empty && lStatus.Text.IndexOf("http://") != -1)
                System.Diagnostics.Process.Start(lStatus.Text.Substring(0, lStatus.Text.IndexOf(' ')));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.vcskicks.com");
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnURL.PerformClick();
        }
    }
}