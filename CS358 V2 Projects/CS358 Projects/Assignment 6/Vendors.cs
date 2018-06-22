using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS358_Projects.Assignment_6
{
    public partial class Vendors : Form
    {
        MySQLConnector DB = new MySQLConnector();
        public Vendors()
        {
            InitializeComponent();
        }

        
        private void refreshList()
        {
            listView1.Items.Clear();
            List<MySQLConnector.Vendor> vendors = DB.VendorGetAll;
            foreach (MySQLConnector.Vendor v in vendors)
            {
                ListViewItem item2 = new ListViewItem(v.V_ID.ToString());
                item2.SubItems.Add(v.CarPlate);
                item2.SubItems.Add(v.CarColor);
                item2.SubItems.Add(v.DriverLicense);
                listView1.Items.Add(item2);
            }
        }

        private void Vendors_Load(object sender, EventArgs e)
        {
            refreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_Vendor V = new New_Vendor()
            {

            };
            if (V.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  
                    DB.VendorAdd(new MySQLConnector.Vendor() { CarPlate = V.CarPlate, CarColor = V.CarColor, DriverLicense = V.DriversLicense }); 
                }
                catch (Exception)
                {
                    
                }
            
            }
        }

        public static string Compress(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }

        public static string Decompress(string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            New_Vendor SC = new New_Vendor();
            MySQLConnector.Vendor V = DB.VendorGetByID(int.Parse(listView1.SelectedItems[0].Text));
            SC.CarPlate = V.CarPlate;
            SC.CarColor = V.CarColor;
            SC.DriversLicense = V.DriverLicense;
            SC.Text = "Update Vendor";
            File.WriteAllBytes("Temp.jpg", StringToByteArray(V.DriverLicense));
           
            if (SC.ShowDialog() == DialogResult.OK)
            {
                V.CarPlate = SC.CarPlate;
                V.CarColor = SC.CarColor;
                V.DriverLicense = SC.DriversLicense;
                if (String.IsNullOrEmpty(V.DriverLicense))
                    V.DriverLicense = "Temp.jpg";
                if (DB.VendorUpdate(V) == MySQLConnector.Result.Success)
                {
                    refreshList();
                }
            }
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }
}
