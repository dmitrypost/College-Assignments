
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//created by Dmitry Post
//      not to be distributed without permission
//
namespace Launcher
{

    public partial class LauncherForm : Form
    {

        protected override CreateParams CreateParams
        { //adds a shadow to the form...
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public LauncherForm()
        {
            InitializeComponent();

            FilesToLoad = "Files.txt";
            if (!File.Exists(FilesToLoad))
            {
                System.IO.File.Create(FilesToLoad);
            }
        }
        private string FilesToLoad { get; set; }

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
                    List<string> lines = new List<string>();
                    if (File.Exists(FilesToLoad))
                    { lines =  File.ReadAllLines(FilesToLoad).ToList(); }
                    //lines.Add(OFD.FileName);                                                    //add the full path of the file
                    lines.Add(MakeRelativePath(Environment.CurrentDirectory, OFD.FileName));    //add the relative path of the file
                    File.WriteAllLines(FilesToLoad, lines);
                    panel1.Controls.Clear();
                    loadAssembliesFromPast();
                }
            }
        }

        private void loadAssembliesFromPast()
        {
            if (System.IO.File.Exists(FilesToLoad))
            {
                int i = 0;
                foreach (string line in File.ReadAllLines(FilesToLoad))
                {
                    if (System.IO.File.Exists(line)) //trys to read the absolute path
                    {
                        // the process of reading opening each assembly and working upon them starts here...
                        try
                        {
                            byte[] file = File.ReadAllBytes(line);

                            System.Reflection.Assembly target = Assembly.Load(file);
                            readTypesAndPopulateList(target, line);
                            i++;
                            
                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                    }
                    else if (System.IO.File.Exists(PathFromRelative(line))) // trys to read the relative path... 
                    {
                        try
                        {
                            byte[] file = File.ReadAllBytes(line);

                            System.Reflection.Assembly target = Assembly.Load(file);
                            readTypesAndPopulateList(target, line);
                            i++;

                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                    }
                    else
                    {

                    }

                }
                if (i == 1) Status.Text = "loaded " + i + " assembly";
                else
                Status.Text = "loaded " + i + " assemblies";
            }
            else
            {
                System.IO.File.Create(FilesToLoad);
            }
        }

        private string PathFromRelative(string fullPath)
        {
            String s = Path.GetFullPath(fullPath);
            return s;
        }

        private void readTypesAndPopulateList(Assembly AssemblyObject, string filepath)
        {
            AssemblyItem AI = new AssemblyItem();
            AI.Parent = panel1;
            AI.Text = filepath.Substring(0,3) + "‹≈›" + filepath.Substring(filepath.LastIndexOf("\\"));

            foreach (Type t in AssemblyObject.GetTypes())
            {
                try
                {
                    if (t.BaseType == null)
                    {
                        continue; //causes an error trying to read a refence without a basetype... (custom things)
                    }
                    if ((t.BaseType.ToString().ToUpper()) == "SYSTEM.WINDOWS.FORMS.FORM")
                    {// If the type is a form...

                        if (!(t.Name == this.Name))
                        {

                            Item i = new Item();
                            i.Parent = AI.ItemContainer;
                            i.text = "Form: "  + t.Name;
                            i.myType = Item.Type_.Form;
                            i.PathExe = filepath;


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
                            i.Parent = AI.ItemContainer;
                            i.myType = Item.Type_.Console;
                            i.text = "Console: "  + t.Name;
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
                catch (NullReferenceException )
                {
                    MessageBox.Show("null reference");
                }





            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public string MakeRelativePath(string workingDirectory, string fullPath)
        {
            string result = string.Empty;
            int offset;

            // this is the easy case.  The file is inside of the working directory.
            if (fullPath.StartsWith(workingDirectory))
            {
                return fullPath.Substring(workingDirectory.Length + 1);
            }

            // the hard case has to back out of the working directory
            string[] baseDirs = workingDirectory.Split(new char[] { ':', '\\', '/' });
            string[] fileDirs = fullPath.Split(new char[] { ':', '\\', '/' });

            // if we failed to split (empty strings?) or the drive letter does not match
            if (baseDirs.Length <= 0 || fileDirs.Length <= 0 || baseDirs[0] != fileDirs[0])
            {
                // can't create a relative path between separate harddrives/partitions.
                return fullPath;
            }

            // skip all leading directories that match
            for (offset = 1; offset < baseDirs.Length; offset++)
            {
                if (baseDirs[offset] != fileDirs[offset])
                    break;
            }

            // back out of the working directory
            for (int i = 0; i < (baseDirs.Length - offset); i++)
            {
                result += "..\\";
            }

            // step into the file path
            for (int i = offset; i < fileDirs.Length - 1; i++)
            {
                result += fileDirs[i] + "\\";
            }

            // append the file
            result += fileDirs[fileDirs.Length - 1];

            return result;
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

    public static Type GetCurrentNamespace()
    {
        return Assembly.GetExecutingAssembly().EntryPoint.DeclaringType;
    }

    private Type t; //used to have the type passed into this control...
    private string exeLocation;

    public string PathExe
    {
        get { return exeLocation; }
        set { exeLocation = NormalizeFilePath(value); }
    }


    public Type typeObject
    {
        get { return t; }
        set { t = value; }
    }


    public enum Type_ { Class, Form, Self, Object, Setting, Resources, Console, Unknown, Enum, UserControl };
    private Type_ type_; //used for an identifier as to what type this is...
    public Type_ myType
    {
        get { return type_; }
        set { type_ = value; }
    }

    private bool overbutton = false;
    private Rectangle buttonArea = new Rectangle(420, 2, 100, 20);
    private bool mouseInControl = false;

    private string text_;
    public string text
    {
        get { return text_; }
        set { text_ = value; }
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
        g.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), 0, 0, this.Width, this.Height);
        // draw border
        g.DrawRectangle(Pens.LightCyan, new Rectangle(0, 0, this.Width - 1, this.Height - 1));

        // Hover effect...
        if (mouseInControl)
        {
            g.DrawRectangle(new Pen(Color.FromArgb(130, 127, 250)), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
        // draw the text
        g.DrawString(text_, new Font("Microsoft Tai Le", 10), Brushes.Black, new PointF(30, 7));



        // If it's a Console or a Forms application draw the button...
        if (overbutton && ((type_ == Type_.Form) || (type_ == Type_.Console)))
        {
            g.FillRectangle(Brushes.White, buttonArea);
            g.DrawString("Run", new Font("Microsoft Tai Le", 10), Brushes.Black, buttonArea.X + 30, buttonArea.Y + 3);
        }
        else if ((type_ == Type_.Form) || (type_ == Type_.Console))
        {   //
            g.FillRectangle(Brushes.Black, buttonArea);
            g.DrawRectangle(new Pen(Color.FromArgb(120, 200, 250)), buttonArea.X, buttonArea.Y, buttonArea.Width - 1, buttonArea.Height - 1);
            g.DrawString("Run", new Font("Microsoft Tai Le", 10), Brushes.White, buttonArea.X + 30, buttonArea.Y + 3);
        }

        // Draws the icon for the type of control...
        switch (type_)
        {
            case Type_.Form:
                g.DrawImage(Project_Launcher.Properties.Resources.form, 4, 6);
                
                break;
            case Type_.Self:
                g.DrawImage(Project_Launcher.Properties.Resources.form, 4, 6); break;
            case Type_.Enum:
                g.DrawImage(Project_Launcher.Properties.Resources._enum, 6, 8);
                break;
            case Type_.Class:
                g.DrawImage(Project_Launcher.Properties.Resources._class, 4, 6);
                break;
            case Type_.Setting:
                g.DrawImage(Project_Launcher.Properties.Resources.settings, 4, 6);
                break;
            case Type_.UserControl:
                g.DrawImage(Project_Launcher.Properties.Resources.UserControl, 4, 6);
                break;
            case Type_.Console:
                g.DrawImage(Project_Launcher.Properties.Resources.Console, 4, 5, 16, 13);
                break;
        }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        mouseInControl = true;
        if ((e.X > buttonArea.Location.X) && (e.X < (buttonArea.Location.X + buttonArea.Width)) && (e.Y > buttonArea.Location.Y) && (e.Y < (buttonArea.Location.Y + buttonArea.Height)))
        { overbutton = true; }
        else { overbutton = false; }
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
                    retry:
                    try //try to launch the form selected...
                    {
                        //Type k = Type.GetType(t.FullName);
                        Form c = Activator.CreateInstance(t) as Form;
                        FindForm().Visible = false;
                        c.StartPosition = FormStartPosition.CenterScreen;
                        c.ShowDialog();
                        FindForm().Visible = true;
                        Form myForm = FindForm();
                        myForm.Show();

                    }
                    catch (FileNotFoundException ex)
                    {
                        // find the executables file location and then use relative location to try to find it....

                        //filepath needs normalization...
                        if (System.IO.File.Exists((exeLocation)))
                        {
                            string exeFolder = exeLocation.Substring(0, exeLocation.LastIndexOf("/") + 1);
                            string shortFileName = ex.FileName.Substring(ex.FileName.LastIndexOf("\\") + 1);
                            string oldFilePath = exeFolder + shortFileName;
                            oldFilePath = oldFilePath.Substring(oldFilePath.LastIndexOf(":") - 1);

                            //file is found... copy it...
                            string newPath = NormalizeFilePath(ex.FileName);
                            System.IO.File.Copy(oldFilePath, shortFileName);
                            MessageBox.Show("Files copied for proper execution: restarting form");
                            goto retry;
                        }


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


    public string NormalizeFilePath(string currentPath)
    {
        return currentPath.Replace("\\", "/");

    }
}

