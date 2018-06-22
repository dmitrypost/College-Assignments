using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS358_Projects.Assignment_1;
using System.Globalization;

namespace CS358_Projects.Assignment_1
{
    public partial class BMI_BFP_Calculator : Form
    {
        public BMI_BFP_Calculator()
        {
            InitializeComponent();
        }

        Person p = new Person();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height);

            g.DrawString("Height", new Font("Microsoft Tai Le",10), Brushes.Black, new Point(20, 20));
           
            g.DrawString("Weight", new Font("Microsoft Tai Le", 10), Brushes.Black, new Point(20, 40));
            g.DrawString("Age", new Font("Microsoft Tai Le", 10), Brushes.Black, new Point(20, 60));

            g.DrawString("BMI " +  p.BMI.ToString("G5", CultureInfo.InvariantCulture), new Font("Microsoft Tai Le", 10), Brushes.Black, new Point(20, 150));
            g.DrawString("BFP " +  p.BodyFatPercentage.ToString("G5", CultureInfo.InvariantCulture), new Font("Microsoft Tai Le", 10), Brushes.Black, new Point(20, 170));
            g.DrawString("Ideal Weight " +  p.IdealWeight.ToString("G5", CultureInfo.InvariantCulture) + " lbs", new Font("Microsoft Tai Le", 10), Brushes.Black, new Point(20, 190));
            if (radioButton1.Checked)
                g.DrawImage(CS358_Projects.Properties.Resources.BFP_Chart_Men, 10, 212);
            else
                g.DrawImage(CS358_Projects.Properties.Resources.BFP_Chart_Women, 10, 212);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            p.heightInInches = Convert.ToInt32(textBox1.Text);
            p.weightInLBS = Convert.ToInt32(textBox2.Text);
            p.sex = radioButton1.Checked;
            Invalidate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        
    }
}
