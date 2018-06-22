using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _GUI_Projects_CSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Character_Sequence_Challenge.main();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
