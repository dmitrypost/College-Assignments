using System;
using System.Collections.Generic;

using System.Collections;
using System.Net;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool clickDown = true;

        public class Item
        {
            public string ItemLine1 { get; set; }
            public string ItemLine2 { get; set; }
            public string Term { get; set; }

            public int page { get; set; }
        }

        public List<ClassType> ClassTypes = new List<ClassType>();

        public class ClassType
        {
            public List<classInfo> Classes = new List<classInfo>();
            public string ShortName;
            public string LongName;
        }
        public class classInfo
        {
            
            public String term;
            public String subj;
            public String Subject_desc;
            public String numb;
            public String title;
            public String instr_fname;
            public String instr_lname;
            public String CRN;
            public String campus;
            public String building;
            public String room;
            public String mon;
            public String tue;
            public String wed;
            public String thu;
            public String fri;
            public String sat;
            public String sun;
            public String begin_time;
            public String end_time;
            public String start_date;
            public String end_date;
        }
        public MainWindow()
        {
            InitializeComponent();

            List<Item> list = new List<Item>();
            Item item = new Item();
            item.ItemLine1 = "Spring 2013";
            item.ItemLine2 = "Classes";
            item.Term = "201320";
            item.page = 1;
            list.Add(item);
            item = new Item();
            item.ItemLine1 = "Fall 2013";
            item.ItemLine2 = "Classes";
            item.Term = "201310";
            item.page = 1;
            list.Add(item);
            item = new Item();
            item.ItemLine1 = "Summer 2013 Semester 1";
            item.ItemLine2 = "Classes";
            item.Term = "201330";
            item.page = 1;
            list.Add(item);
            item = new Item();
            item.ItemLine1 = "Summer 2013 Semester 2";
            item.ItemLine2 = "Classes";
            item.Term = "201340";
            item.page = 1;
            list.Add(item);
            item = new Item();
            item.ItemLine1 = "Summer 2013 Semester 3";
            item.ItemLine2 = "Classes";
            item.Term = "201350";
            item.page = 1;
            list.Add(item);
            Dispatcher.BeginInvoke(new Action(() => ListBox1.ItemsSource = list));

        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //PageTitle.Text = e.Result;
            // now change to go to next page...
            String xmlString = e.Result;
            do
            {
                int rowindex = xmlString.IndexOf("</row>");
                String rowinfo = xmlString.Substring(0,rowindex);

                rowinfo = rowinfo.Substring(rowinfo.IndexOf("<row>")+6);

                
                xmlString = xmlString.Substring(rowindex +7);

                classInfo ci;
               
                     ci = new classInfo();
                    string value;
                    int eIndex;
                    int sIndex;
                    //term
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0,eIndex);
                    value = value.Substring(sIndex);
                    ci.term = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //subj
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") +7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.subj = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //subj discription
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.Subject_desc = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //number
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.numb = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //unknown....
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);

                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //title
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.title = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //instructor first name
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.instr_fname = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //instructor last name
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.instr_lname = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //CRN
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.CRN = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //campus
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.campus = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //building
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.building = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //room
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.room = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //monday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.mon = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //tuesday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.tue = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //wednesday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.wed = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //thursday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.thu = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //friday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.fri = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //saturday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.sat = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //sunday
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.sun = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //beguin time
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.begin_time = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //end time
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.end_time = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //start date
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.start_date = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);
                    //end date
                    eIndex = rowinfo.IndexOf("</value>");
                    sIndex = rowinfo.IndexOf("<value>") + 7;
                    value = rowinfo.Substring(0, eIndex);
                    value = value.Substring(sIndex);
                    ci.end_date = value;
                    rowinfo = rowinfo.Substring(eIndex + 8);

                if (ClassTypeExist(ci.subj) == null)
                {
                    ClassType ct = new ClassType();
                    ct.ShortName = ci.subj;
                    ct.LongName = ci.Subject_desc;
                    ClassTypes.Add(ct);
                    ct.Classes.Add(ci);
                }
                else
                {

                    ClassTypeExist(ci.subj).Classes.Add(ci);
                }

            } while (xmlString.Contains("<row>"));
            PopulateClassTypes();
        }


        private ClassType ClassTypeExist(string classTypeName) // returns true only if there already is an existing in the list...
        {
            foreach (ClassType ct in ClassTypes)
            {
                if (ct.ShortName == classTypeName)
                {
                    return ct;
                }
            }
            return null;
        }

        private void PopulateClassTypes()
        {
            
            List<Item> list = new List<Item>();
            foreach (ClassType ct in ClassTypes)
            {
                Item item = new Item();
                item.ItemLine1 = ct.LongName;
                item.ItemLine2 = ct.ShortName;
                item.page = 2;
                list.Add(item);
            }
            clickDown = false;

            Dispatcher.BeginInvoke(new Action(() => ListBox1.ItemsSource = list));
           // clickDown = true;
        }

        
        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e != null)
            {
                if (clickDown)
                {
                    IEnumerator ie = e.AddedItems.GetEnumerator();
                    ie.MoveNext();
                    
                    if (((Item)ie.Current).page == 1)
                    {
                        PageTitle.Text = ((Item)ie.Current).Term;


                        string term = ((Item)ie.Current).Term;

                        WebClient wc = new WebClient();
                        wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                        wc.DownloadStringAsync(new Uri("http://usi.edu/webservices/iphone/USIINFO" + term + ".xml"));
                        clickDown = true;
                    }
                    else if (((Item)ie.Current).page == 2)
                    {
                        PageTitle.Text = ((Item)ie.Current).ItemLine1;
                        List<Item> list = new List<Item>();
                        ClassType ct = ClassTypeExist(((Item)ie.Current).ItemLine2);
                        foreach (classInfo ci in ct.Classes)
                        {
                            Item item = new Item();
                            item.ItemLine1 = ci.Subject_desc;
                            item.ItemLine2 = ci.instr_lname;
                            item.page = 3;
                            list.Add(item);
                        }
                        clickDown = false;

                        Dispatcher.BeginInvoke(new Action(() => ListBox1.ItemsSource = list));
                    }
                    else if (((Item)ie.Current).page == 3)
                    {
                        PageTitle.Text = ((Item)ie.Current).ItemLine1;
                        List<Item> list = new List<Item>();
                        ClassType ct = ClassTypeExist(((Item)ie.Current).ItemLine2);
                        foreach (classInfo ci in ct.Classes)
                        {
                            Item item = new Item();
                            item.ItemLine1 = ci.Subject_desc;
                            item.ItemLine2 = ci.instr_lname;
                            item.page = 4;
                            list.Add(item);
                        }
                        clickDown = false;

                        Dispatcher.BeginInvoke(new Action(() => ListBox1.ItemsSource = list));
                    }
                    

                }
                else
                {
                    clickDown = true;
                }
            }
        }

    }

}
