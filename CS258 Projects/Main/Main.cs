using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Management;
using System.IO;

namespace NSMain
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


        }
        

        private void Main_Load(object sender, EventArgs e)
        {
           // readTypesAndPopulateList(Assembly.GetExecutingAssembly()); //self
            loadAssembliesFromPast();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(OFD.FileName))
                {
                     List<string> lines = File.ReadAllLines("Files.txt").ToList<String>();
                     lines.Add(OFD.FileName);
                     File.WriteAllLines("Files.txt", lines);
                     panel1.Controls.Clear();
                     loadAssembliesFromPast();
                }
            }
        }

        private void loadAssembliesFromPast()
        {
            if (System.IO.File.Exists("Files.txt"))
            {
                int i = 0;
                foreach (string line in File.ReadAllLines("Files.txt"))
                {

                    // the process of reading opening each assembly and working upon them starts here...
                    try
                    {
                        byte[] file = File.ReadAllBytes(line);

                        System.Reflection.Assembly target = Assembly.Load(file);
                        readTypesAndPopulateList(target);
                        i++;
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
                Status.Text = "loaded " + i + " assemblies";
            }else
            {
                System.IO.File.Create("Files.txt");
            }
        }
     
        private void readTypesAndPopulateList(Assembly AssemblyObject)
        {
            
            foreach (Type t in AssemblyObject.GetTypes())
            {
                
                if ((t.BaseType.ToString().ToUpper()) == "SYSTEM.WINDOWS.FORMS.FORM")
                {// If the type is a form...

                    if (!(t.Name == this.Name))
                    {

                        Item i = new Item();
                        i.Parent = panel1;
                        i.text = "Form: " + t.Name;
                        i.myType = Item.Type_.Form;



                        // pass the type to the control so it can run it if needed.
                        i.typeObject = t;
                    }
                    else
                    {   //found this form ...
                        Item i = new Item();
                        //i.Parent = panel1;
                        i.text = "Self: " + t.Name;
                        i.myType = Item.Type_.Self;
                        i.typeObject = t;
                    }
                }
                else if ((t.IsClass) && ((t.BaseType.ToString().ToUpper()) == "SYSTEM.OBJECT"))
                {
                    Item i = new Item();
                    //i.Parent = panel1;
                    i.text = "Class: " + t.Name;
                    i.myType = Item.Type_.Class;
                    // pass the type to the control so it can run it if needed.
                    i.typeObject = t;

                    if (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string[]) }, null) != null)
                    {
                        i.Parent = panel1;
                        i.myType = Item.Type_.Console;
                        i.text = "Console: " + t.Namespace + "." + t.Name;
                    }

                }
                else if ((t.BaseType.ToString().ToUpper()) == "SYSTEM.OBJECT")
                {
                    Item i = new Item();
                    //i.Parent = panel1;
                    i.text = "Object: " + t.Name;
                    i.myType = Item.Type_.Object;
                }
                else if ((t.BaseType.ToString().ToUpper()) == "SYSTEM.ENUM")
                {
                    Item i = new Item();
                    //i.Parent = panel1;
                    i.text = "Enum: " + t.Name;
                    i.myType = Item.Type_.Enum;
                }
                else if ((t.BaseType.ToString().ToUpper()) == "SYSTEM.WINDOWS.FORMS.USERCONTROL")
                {
                    Item i = new Item();
                    //i.Parent = panel1;
                    i.text = "User Control: " + t.Name;
                    i.myType = Item.Type_.UserControl;
                }
                else if (t.Name.ToUpper() == "SETTINGS")
                {
                    Item i = new Item();
                    //i.Parent = panel1;
                    i.text = "Setting: " + t.Name;
                    i.myType = Item.Type_.Setting;
                }
                else   // anything else..
                {
                    Item i = new Item();
                    //i.Parent = panel1;
                    i.text = "Unknown: " + t.Name;
                    i.myType = Item.Type_.Unknown;
                }





            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
  
}

  public class Item : UserControl
  {
      #region "imports"

      //using System.Runtime.InteropServices; required for DllImports...
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern
        bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
      #endregion

        private Type t; //used to have the type passed into this control...
      public Type typeObject
      {
          get { return t; }
          set {t = value; }
      }
      public enum Type_ {Class,Form,Self,Object,Setting,Resources,Console,Unknown,Enum,UserControl};
      private Type_ type_; //used for an identifier as to what type this is...
      public Type_ myType
      {
          get { return type_; }
          set { type_ = value; }
      }
      
      private bool overbutton = false;
      Rectangle buttonArea = new Rectangle(420, 2, 100, 20);
      private bool mouseInControl = false;

        private string text_;
        public string text
        {
            get { return text_ ; }
            set {text_ = value; }
        }


        public Item() //on new instance...
        {
                        
            this.DoubleBuffered = true;
            this.Height = 24;
            this.Dock = DockStyle.Top;
            
           
        
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Width = this.FindForm().Width;
         
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            // fill control with color
            g.FillRectangle(new SolidBrush(Color.FromArgb(126,223,247)), 0, 0, this.Width, this.Height);
            // draw border
            g.DrawRectangle(Pens.Azure, new Rectangle(0, 0, this.Width-1, this.Height-1));
            
            // Hover effect...
            if (mouseInControl)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(130,127,250)), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
            // draw the text
            g.DrawString(text_, new Font("Microsoft Tai Le", 10), Brushes.White, new PointF(30, 7));
           


            // If it's a Console or a Forms application draw the button...
            if (overbutton && ((type_ == Type_.Form) || (type_ == Type_.Console)))
            {
                g.FillRectangle(Brushes.White, buttonArea);
                g.DrawString("Run", new Font("Microsoft Tai Le", 10), Brushes.Black, buttonArea.X + 30, buttonArea.Y + 3);
            }
            else if ((type_ == Type_.Form) || (type_ == Type_.Console))
            {   //
                g.FillRectangle(Brushes.Black, buttonArea);
                g.DrawRectangle(new Pen(Color.FromArgb(120,200,250)),buttonArea.X,buttonArea.Y,buttonArea.Width-1, buttonArea.Height-1);
                g.DrawString("Run", new Font("Microsoft Tai Le", 10), Brushes.White, buttonArea.X + 30, buttonArea.Y + 3);
            }

            // Draws the icon for the type of control...
            switch (type_)
            {
                case Type_.Form:
                    g.DrawImage(NSMain.Properties.Resources.form, 4, 6);
                    break;
                case Type_.Self:
                    g.DrawImage(NSMain.Properties.Resources.form, 4, 6); break;
                case Type_.Enum:
                     g.DrawImage(NSMain.Properties.Resources._enum, 6, 8);
                    break;
                case Type_.Class:
                    g.DrawImage(NSMain.Properties.Resources._class, 4, 6);
                    break;
                case Type_.Setting:
                    g.DrawImage(NSMain.Properties.Resources.settings, 4, 6);
                    break;
                case Type_.UserControl:
                    g.DrawImage(NSMain.Properties.Resources.UserControl, 4, 6);
                    break;
                case Type_.Console:
                    g.DrawImage(NSMain.Properties.Resources.Console, 4, 5,16,13);
                    break;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            mouseInControl = true;
            if ((e.X > buttonArea.Location.X) && (e.X < (buttonArea.Location.X + buttonArea.Width)) && (e.Y > buttonArea.Location.Y) && (e.Y < (buttonArea.Location.Y + buttonArea.Height)))
            { overbutton = true; } else { overbutton = false; }
            this.Invalidate(); //causes the control to redraw itself

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            overbutton = false;
            mouseInControl = false;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //if (overbutton) // clicked the button
            //{ MessageBox.Show(Convert.ToString(this.type_)); }
            if (overbutton)
            {
                switch (type_)
                {
                    case Type_.Class:
                        try
                        {
                            if (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) != null)
                            {


                                if (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) != null)
                                {

                                    var mainMethod = (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static));

                                    string[] argss = new string[] { "", "" };

                                    //run the Main function with blank parameters...
                                    try
                                    {
                                        //mainMethod.Invoke(null, null);
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("error running: " + t.Name);

                                    }


                                }
                            }
                        }
                        catch (AmbiguousMatchException)
                        {
                            //MessageBox.Show("More than one main found: ");
                            if (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string[]) }, null) != null)
                            {

                                var mainMethod = (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string[]) }, null));

                                string[] argss = new string[] { "", "" };

                                //run the Main function with blank parameters...
                                mainMethod.Invoke(null, new object[] { argss });
                                
                            }
                        }
                        break;
                        //Main class running....
                    case Type_.Console:
                        
                        //Creates the console...
                        if (FindForm() != null)
                        {
                            FindForm().Visible = false;
                        }
                        RunConsoleApp(t);
                        FindForm().Visible = true;
                        break;


                    case Type_.Form:
                        try //try to launch the form selected...
                        {
                            //Type k = Type.GetType(t.FullName);
                            Form c = Activator.CreateInstance(t) as Form;
                            FindForm().Visible = false;
                            c.StartPosition = FormStartPosition.CenterScreen;
                            c.ShowDialog();
                            FindForm().Visible = true;
                            
                        }
                        catch (Exception)
                        {

                        }

                        break;
                }
            }
        }

      
       void RunConsoleApp(Type t)
      {
          
           //check if console exists for this app
           if (GetConsoleWindow() == IntPtr.Zero)
           {
                CreateConsole();
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND); // get rid of x button; prevents application from being shut down...
           }
           else // console exists... unhide it...
           {
               ShowWindow(GetConsoleWindow(), 4);
               //make active window...
               SetForegroundWindow(GetConsoleWindow());
           }
          
                        
          var MM = (t.GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string[]) }, null));

          string[] args = new string[] { "", "" };
          
          //run the Main function with blank parameters...
          MM.Invoke(null, new object[] { args });
          
           Console.ReadLine();
          
         

          //Hide console...
           ShowWindow(GetConsoleWindow(), 0);
           Console.Clear();
          //Disposes the console...
          //FreeConsole();
          
      }
       public static void CreateConsole()
       {
           AllocConsole();
           // reopen stdout
           TextWriter writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
           Console.SetOut(writer);
           TextReader reader = new StreamReader(Console.OpenStandardInput()) { };
           Console.SetIn(reader);
           TextWriter errWriter = new StreamWriter(Console.OpenStandardError()) { AutoFlush = true };
           Console.SetError(errWriter);
           
       }
      

    }
 
