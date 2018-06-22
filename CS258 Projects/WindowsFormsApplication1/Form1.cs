using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;



using System.Globalization;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Threading;

using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using System.Diagnostics.Contracts;
using System.Diagnostics.CodeAnalysis;


namespace System
{
    public struct COORD
    {

        public short X;
        public short Y;
    }

    public struct SMALL_RECT
    {

        public short Left;
        public short Top;
        public short Right;
        public short Bottom;
    }

    public struct CONSOLE_SCREEN_BUFFER_INFO
    {

        public COORD dwSize;
        public COORD dwCursorPosition;
        public ushort wAttributes;
        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;
    }

  

    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();

        }
        public static void CreateConsole()
        {
            AllocConsole();
            // reopen stdout
            TextWriter writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            Console.SetOut(writer);
            TextReader reader = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(reader);
            TextWriter errWriter = new StreamWriter(Console.OpenStandardError()) { AutoFlush = true };
            Console.SetError(errWriter);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateConsole();
            Console.WriteLine("first line");
            FreeConsole();
            CreateConsole();
            Console.WriteLine("Second line");
            Clear();
            Clear();
            //Disposes the console...
            FreeConsole();

            CreateConsole();

            Console.WriteLine("third line");
            Clear();
            IntPtr inPutHwnd =  GetStdHandle(-10);
            IntPtr outputHwnd =  GetStdHandle(-11);
            IntPtr errHwnd =  GetStdHandle(-12);
            Clear();
          
            const int STD_OUTPUT_HANDLE = -11;

            CONSOLE_SCREEN_BUFFER_INFO csbi;
            if (GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE), out csbi))
            {
                //MessageBox.Show("CSBI: " + csbi.dwCursorPosition);
            }
            if (GetConsoleWindow() != null)
            {
                MessageBox.Show("Console handle exists still " + GetConsoleWindow().ToString());
            }
            Clear();
            Clear();

            Clear();
            
        }

       
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AllocConsole();

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool FreeConsole();
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);
    [DllImport("Kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();
    [DllImport("kernel32.dll")]
    static extern bool GetConsoleScreenBufferInfo(IntPtr hConsoleOutput, out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo);
       

    [DllImport("kernel32.dll")]
    static extern bool FillConsoleOutputCharacter(IntPtr hConsoleOutput,
       char cCharacter, uint nLength, COORD dwWriteCoord, out uint
       lpNumberOfCharsWritten);
    [DllImport("kernel32.dll")]
    static extern bool FillConsoleOutputAttribute(IntPtr hConsoleOutput,
    ushort wAttribute, uint nLength, COORD dwWriteCoord, out uint
    lpNumberOfAttrsWritten);

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput,
       COORD dwCursorPosition);
     
    [System.Security.SecuritySafeCritical]  // auto-generated
    [ResourceExposure(ResourceScope.Process)]
    [ResourceConsumption(ResourceScope.Process)]
    public static void Clear()
    {
        COORD coordScreen = new COORD();
        CONSOLE_SCREEN_BUFFER_INFO csbi;
        bool success;
        uint conSize;

        IntPtr hConsole = GetStdHandle(-11);

        // Retrieves String and Image resources.

        if (hConsole == null)
            throw new IOException(("Failed to get handle of console write handle"));

        // get the number of character cells in the current buffer
        // Go through my helper method for fetching a screen buffer info
        // to correctly handle default console colors.
        GetConsoleScreenBufferInfo((hConsole), out csbi);
        //csbi = GetBufferInfo(); // ^ code puts the info into csbi
        conSize = Convert.ToUInt32(csbi.dwSize.X * csbi.dwSize.Y);

        // fill the entire screen with blanks

        uint numCellsWritten = 0;
        //  success = Win32Native.FillConsoleOutputCharacter(hConsole, ' ', conSize, coordScreen, out numCellsWritten);
        success = FillConsoleOutputCharacter(hConsole, (Char)32, conSize, coordScreen, out numCellsWritten);
        if (!success)
            throw new Win32Exception("Failed to FillConsoleOutputCharacter");

        // now set the buffer's attributes accordingly

        numCellsWritten = 0;
        //success = Win32Native.FillConsoleOutputAttribute(hConsole, csbi.wAttributes, conSize, coordScreen, out numCellsWritten);
        success = FillConsoleOutputAttribute(hConsole, csbi.wAttributes, conSize, coordScreen, out numCellsWritten);
        if (!success)
            throw new Win32Exception("Failed to FillConsoleOutputAttricbute");

        // put the cursor at (0, 0)

        // success = Win32Native.SetConsoleCursorPosition(hConsole, coordScreen);
        success = SetConsoleCursorPosition(hConsole, coordScreen);
        if (!success)
            throw new IOException("Failed to SetConsoleCursorPosition");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Console.Clear();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Clear();
    }

    //private static byte[] buffer = new byte[350];
    //public static int sendPacket(int mode, int verson, int chan, int port, String ip, String name, String compName)
    //{
    //    try
    //    {
    //        System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(ip);
    //        System.Net.Sockets.Socket mysocket;

    //        buffer[0] = (byte)mode;
    //        buffer[1] = (byte)verson;
    //        buffer[2] = (byte)chan;

    //        if (verson != 2)
    //            buffer[3] = (byte)0x00;
    //        else
    //            buffer[3] = (byte)0x3f;

    //        if (verson == 9)
    //            verson = 2;


    //        for (int i = 55; i < compName.Length + 55; i++)
    //            buffer[i] = (byte)compName.charAt(i - 55);

    //        for (int ii = 123; ii < name.length() + 123; ii++)
    //            buffer[ii] = (byte)name.charAt(ii - 123);
    //        System.Net.Sockets.
    //        DatagramPacket dataPacket = new DatagramPacket(buffer, buffer.length, ipaddr, port);
    //        mysocket.send(dataPacket);

    //    }
    //    catch (Exception e)
    //    {
    //        msg.setText("Network error, check your port and ip values as well as your network setings.");
    //        stats.setText("Failed...");
    //        return 0;
    //    }
    //}
    }
 
}
