using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser_C_
{
    
    public partial class Form1 : Form
    {
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStrip1.Dock = DockStyle.Top;

        }
        private WebView2 webView;

        public Form1()
        {
            InitializeComponent();

            
            toolStrip1.Dock = DockStyle.Top;

           
            webView = new WebView2
            {
                Dock = DockStyle.Fill 
            };

            
            this.Controls.Add(webView); 
            this.Controls.Add(toolStrip1);

            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            var env = await CoreWebView2Environment.CreateAsync(null, @"WebView2");
            await webView.EnsureCoreWebView2Async();
            webView.Source = new Uri("https://www.google.com");

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            webView.GoBack();
        }

        private void btnForward_Click(object senter, EventArgs e)
        {
            webView.GoForward();
        }
        private void btnGo_Click(object senter, EventArgs e)
        {
            string url = toolStripComboBox1.Text.Trim();
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            try
            {
                if (webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate(url);
                }
                else
                {
                    MessageBox.Show("WebView2 is not initialized yet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to navigate: {ex.Message}");
            }
        }
        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = toolStripComboBox1.Text.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                try
                {
                    if (webView.CoreWebView2 != null)
                    {
                        webView.CoreWebView2.Navigate(url);
                    }
                    else
                    {
                        MessageBox.Show("WebView2 is not initialized yet.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to navigate: {ex.Message}");
                }
            }
        }

       
    }
}
