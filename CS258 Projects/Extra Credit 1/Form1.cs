using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace Extra_Credit_1
{
    public partial class Form1 : Form
    {
        
        WebBrowser wb = new WebBrowser();
        
            
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e) 
        {

            webBrowser1.DocumentCompleted += wb_DocumentCompleted;
            webBrowser1.Navigate("https://redhoop.com/search/?q=+&selected_facets=category_exact:Technology#.VBcgjPldUmp");
           
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (textBox1.Text == "") {  } else { return; } // so it does this code once and once only...
            
            foreach (HtmlElement el in webBrowser1.Document.All)
            {
                if (el.GetAttribute("id") == "video_courses")
                {
                    foreach (HtmlElement el1 in el.FirstChild.FirstChild.Children)
                    {
                        
                        
                        string element = el1.InnerHtml;

                        string link = element.Substring(element.IndexOf("href")+6);
                        link = link.Substring(0, link.IndexOf((char)34));
                        // link extracted!!!

                        string title = element.Substring(element.IndexOf("html") + 6);
                        title = title.Substring(0, title.IndexOf((Char)60));
                        // title extracted!!!

                        string discription = element.Substring(element.LastIndexOf("<DIV>")+5);
                        discription = discription.Substring(0, discription.IndexOf((Char)60));
                        // discription extracted!!!


                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = ""; // course type column
                        ListViewItem.ListViewSubItem lvi2 = new ListViewItem.ListViewSubItem();
                        lvi.SubItems.Add(lvi2);
                        lvi2.Text = title; // title column
                        ListViewItem.ListViewSubItem lvi3 = new ListViewItem.ListViewSubItem();
                        lvi.SubItems.Add(lvi3);
                        lvi3.Text = ""; // instructor column
                        ListViewItem.ListViewSubItem lvi4 = new ListViewItem.ListViewSubItem();
                        lvi.SubItems.Add(lvi4);
                        lvi4.Text = discription; // discription column
                        ListViewItem.ListViewSubItem lvi5 = new ListViewItem.ListViewSubItem();
                        lvi.SubItems.Add(lvi5);
                        lvi5.Text = link; // link column
                        
                        //add a button which will direct to site
                        Button btn = new Button();
                        btn.Text = "<---->";
                        btn.Font = new Font(btn.Font.FontFamily,7);
                        btn.TextAlign = ContentAlignment.TopCenter;
                        
                        btn.Size = new Size(lvi5.Bounds.Width,lvi5.Bounds.Height);
                       // btn.Parent = lvi5;
                        listViewEx1.Items.Add(lvi);
                        


                        int row = listViewEx1.Items.IndexOf(lvi);
                        listViewEx1.AddEmbeddedControl(btn,4, row);
                        btn.Click += btn_Click;
                        
                        // instructor
                        // have to open link and extract from there...
                       HttpListener hlistner;
                       // HttpListenerRequest request = new HttpListenerRequest();
                        //request.
                    }   

                   
                   
                }
               
                   
            }
            textBox1.Text += "Done";

        }

       
        void btn_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            

           try
           {
            var info = listViewEx1.HitTest(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y);
            var row = info.Item.Index;
            var col = info.Item.SubItems.IndexOf(info.SubItem);
            var value = info.Item.SubItems[col].Text;
            Process.Start("chrome.exe", (string)"https://redhoop.com/" + (string)value);
            
           }
           catch (Exception ex)
           {

           }
        }     
    }
}
