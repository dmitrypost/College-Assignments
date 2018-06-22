using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CS358_Projects.Assignment_2
{
    public partial class Recycle_Shop : Form
    {
        productlist pl = new productlist();
        public Recycle_Shop()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <= 0)
            {
                StatusLabel.Text = "please select an item before delete";
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the product with the name that matches
            product p = pl.find(comboBox1.SelectedItem.ToString());
            //
            double price = p.price * Convert.ToDouble(numericUpDown1.Value);
            label1.Text = "Price " + Convert.ToString(price);

            listBox1.Items.Add(comboBox1.SelectedItem.ToString() + " " + Convert.ToString(price));
        }

        [Serializable]
        public class product
        {
            public double price { get; set; }
            public string name { get; set; }

        }

        [Serializable]
        public class productlist
        {
            public List<product> product_list = new List<product>();
            public void add(product product)
            {
                product_list.Add(product);
            }
            public void add(string name, double price)
            {
                product p = new product();
                p.name = name; p.price = price;
            }
            public product find(string name)
            {
                foreach(product p in product_list)
                {
                    if (p.name == name)
                        return p;
                }
                return null;
            }
        }
        


        private void Calculate(object sender, EventArgs e)
        {
            //get the product with the name that matches
            product p = pl.find(comboBox1.SelectedItem.ToString());
            //
            label1.Text = Convert.ToString("Price " + p.price * Convert.ToDouble(numericUpDown1.Value));

        }

        private void Recycle_Shop_Load(object sender, EventArgs e)
        {
            if (File.Exists("shop.xml"))
            {
                //opens up the shop.xml file for the information of the items...
                XmlSerializer serializer = new XmlSerializer(typeof(productlist));
                using (Stream stream = File.Open("shop.xml", FileMode.Open))
                {
                    pl = (productlist)serializer.Deserialize(stream);
                }
                
            }
            foreach (product p in pl.product_list)
            {
                comboBox1.Items.Add(p.name);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            product p = new product();
            p.name = textBox1.Text;
            p.price = double.Parse(textBox2.Text);
            pl.add(p);
            //saves entry to the shop.xml
            XmlSerializer serializer = new XmlSerializer(typeof(productlist));
            using (Stream stream = File.Open("shop.xml", FileMode.Create))
            {
                serializer.Serialize(stream, pl);
            }
            //reload the list
            comboBox1.Items.Clear();
            Recycle_Shop_Load(this, null);
        }
    }
}
