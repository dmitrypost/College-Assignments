using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CS358_Projects.Assignment_5
{
    public class Products
    {
        #region "serialized product list"

        public productlist pl = new productlist();
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
                foreach (product p in product_list)
                {
                    if (p.name == name)
                        return p;
                }
                return null;
            }
        }
        public void SaveDatabase()
        {
            //saves entry to the shop.xml
            XmlSerializer serializer = new XmlSerializer(typeof(productlist));
            using (Stream stream = File.Open("shop.xml", FileMode.Create))
            {
                serializer.Serialize(stream, pl);
            }
        }

        //loads the contents of the xml 
        public void LoadDatabase()
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

        }

        #endregion

    }
}
