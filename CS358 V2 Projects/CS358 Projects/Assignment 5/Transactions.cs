using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CS358_Projects.Assignment_5
{
    public class Transactions
    {
        #region "Records // manages the transations"  
        public RecieptList rl = new RecieptList();
        public RecieptTemplate Template = LoadTemplate();
        [Serializable]
        public class RecieptTemplate //template will be loaded ONCE... template editable via xml file...
        {
            public string welcomeMessage;
            public string storeName;
            public string location;
            public string phonenumber;

            public string website;
            public string thankYouMessage;
        }

        [Serializable]
        public class Reciept
        {
            public Reciept()
            {
                datetime = DateTime.Now;
            }
            public DateTime datetime;
            public List<LineItem> Items = new List<LineItem>();


            [XmlIgnore]
            public long InvoiceNumber
            {
                get { return (datetime.Ticks); }
            }//allow set for when getting this value from the xml file

            [Serializable]
            public class LineItem : Products.product
            {

                //has the contents of product + qunatity aka why we inherit from product :P
                public double quantity;
            }
            //[XmlIgnore] tag prevents this from being written to the xml file... since they are both calculated values it is unnessisary to write them to the file.

            [XmlIgnore]
            public double Total
            {
                get
                {
                    double _total = 0;
                    foreach (LineItem i in Items)
                    {
                        _total += i.price * i.quantity;
                    }
                    return _total;
                }
            }

            //since this shop is buying the product no need to do cashtend and change amount.
        }

        [Serializable]
        public class RecieptList // shows a list of all the reciepts... and calculation functions
        {
            [XmlIgnore]public List<YearPayment> yearPayments = new List<YearPayment>();
            public class YearPayment
            {
                public int year;
                public YearPayment(int year_)
                {
                    year = year_;
                }

                [XmlIgnore]
                public double[] MonthAmount = new double[12];
                public double Yearly()
                {
                    return Quarterly(1) + Quarterly(2) + Quarterly(3) + Quarterly(4);
                }

                public double Quarterly(int quarter)
                {

                    if ((quarter > 4) || (quarter < 1))
                        return 0; //quorters are only from 1-4
                    switch (quarter)
                    {
                        case 1:
                            return Monthly(1) + Monthly(2) + Monthly(3);
                        case 2:
                            return Monthly(4) + Monthly(5) + Monthly(6);
                        case 3:
                            return Monthly(7) + Monthly(8) + Monthly(9);
                        case 4:
                            return Monthly(10) + Monthly(11) + Monthly(12);

                    }
                    return 0; //never gets here...
                }

                public double Monthly(int month)
                {
                    //reCalculate();
                    return MonthAmount[month - 1];
                }

            }

            public YearPayment YearAmounts(int year)
            {
                
                foreach (YearPayment i in yearPayments)
                {
                    if (i.year == year)
                    {
                        return i;
                    }
                }
                YearPayment y = new YearPayment(year);
                yearPayments.Add(y);
                return y; //creates it if it does not exist
            }

            
            
            
            public void reCalculate()
            {
                
                //calculate the totals for monthly, quorterly, and yearly...
                foreach (Reciept transaction in TransactionReciepts)
                {
                    YearAmounts(transaction.datetime.Year).MonthAmount[transaction.datetime.Month - 1] += transaction.Total; //adds the total to the months total
                }
            }
            //collection of all the reciepts...
            public List<Reciept> TransactionReciepts = new List<Reciept>();

            public Reciept find(double invoicenumber)
            {
                foreach (Reciept p in TransactionReciepts)
                {
                    if (p.InvoiceNumber == invoicenumber)
                        return p;
                }
                return null;
            }
        }

        public void SaveTransations() //saves the contents to the xml
        {

            XmlSerializer serializer = new XmlSerializer(typeof(RecieptList));
            using (Stream stream = File.Open("transactions.xml", FileMode.Create))
            {
                serializer.Serialize(stream, rl);
            }
        }

        public void LoadTransactions()
        {
            if (File.Exists("transactions.xml"))
            {
                //opens up the shop.xml file for the information of the items...
                XmlSerializer serializer = new XmlSerializer(typeof(RecieptList));
                using (Stream stream = File.Open("transactions.xml", FileMode.Open))
                {
                    rl = (RecieptList)serializer.Deserialize(stream);
                }

            }

        } //loads the contents of the xml 

        public static RecieptTemplate LoadTemplate()
        {
            if (File.Exists("RecieptTemplate.xml"))
            {
                //opens up the shop.xml file for the information of the items...
                XmlSerializer serializer = new XmlSerializer(typeof(RecieptTemplate));
                using (Stream stream = File.Open("RecieptTemplate.xml", FileMode.Open))
                {
                    return (RecieptTemplate)serializer.Deserialize(stream);
                }

            }
            else
            {
                return new RecieptTemplate();
            }

        }
        public void SaveTemplate()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RecieptTemplate));
            using (Stream stream = File.Open("RecieptTemplate.xml", FileMode.Create))
            {
                serializer.Serialize(stream, Template);
            }
        }
        #endregion

    }
}
