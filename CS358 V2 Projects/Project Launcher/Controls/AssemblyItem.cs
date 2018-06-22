using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class AssemblyItem : UserControl
    {
        public AssemblyItem()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            folded = true;
            openedSize = this.Height;

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

        private int openedSize { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

        }

        private void CtrlContainer_ControlAdded(object sender, ControlEventArgs e)
        {
            openedSize += 24;
            if (folded)
            {
                this.Height = 33;
                //ItemContainer.Visible = false;
                
            }
            else
            {
                
                openedSize = this.Height;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folded)
            {
                button2.Text = "▼";
                folded = false;
                this.Height = openedSize;
                ItemContainer.Visible = true;
                
            }
            else
            {
                button2.Text = "▲";
                folded = true;
                this.Height = 33;
                ItemContainer.Visible = false;
            }
        }
    }
}
