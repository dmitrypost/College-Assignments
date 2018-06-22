using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Project_Launcher
{
      public partial class NamespaceItem : UserControl
    {
        public NamespaceItem()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            
        }
        public override string Text
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public Panel ItemContainer
        {
            get { return CtrlContainer; }
        }
        private bool folded { get; set; }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

        }

    
    }


}
