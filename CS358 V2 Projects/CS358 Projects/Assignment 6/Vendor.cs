using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS358_Projects.Assignment_6
{
    public partial class New_Vendor : Form
    {
        public New_Vendor()
        {
            InitializeComponent();
        }

        
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public string CarPlate
        {
            get
            {
                return textBoxEx1.Text;
            }
            set
            {
                textBoxEx1.Text = value;
            }
        }

        public string CarColor
        {
            get
            {
                return textBoxEx2.Text;
            }
            set
            {
                textBoxEx2.Text = value;
            }
        }

        private string path;
        public string DriversLicense
        {
            get
            {
                return path;
            }
            set
            {
                try
                {
                    pictureBox1.Image = byteArrayToImage(File.ReadAllBytes(value)); //if the path of the file is passed to this property
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        pictureBox1.Image = byteArrayToImage(StringToByteArray(value)); //if hex value is passed to this property 
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error in setting driverlicense property with hex input");
                    }
                    Console.WriteLine("Error in setting driverlicense property with file path input");
                }

                
                
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //pictureBox1.Image = byteArrayToImage(File.ReadAllBytes(OFD.FileName));
                    DriversLicense = OFD.FileName;
                    path = OFD.FileName;
                }
                catch (Exception)
                {
                    
                }
               
            }
        }
    }
}
