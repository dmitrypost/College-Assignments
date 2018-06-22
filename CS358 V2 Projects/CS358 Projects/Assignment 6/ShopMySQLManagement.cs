using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;

namespace CS358_Projects.Assignment_6
{
    public partial class MySQLConnector
    {

        public enum Result
        {
            Success, NotExist , Failed
        }

        private Result Query(string query)
        {
            
            if (OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
                return Result.Success;
            }
            return Result.Failed;
        }

        #region "Product table section"
        [StructLayout(LayoutKind.Sequential)]
        public struct Product
        {
            public int P_ID;
            public string P_Code;
            public double P_Price;
            public string P_Discription;
        }

        public Result ProductAdd(Product P)
        {
            string query = "INSERT INTO Product (P_Code, P_Price, P_Discription)Values( '" + P.P_Code + "'," + P.P_Price + ",'" + P.P_Discription + "');";
            return Query(query);
        }

        public List<Product> ProductGetAll
        {
            get
            {

                string query = "SELECT * FROM Product;";
                List<Product> list = new List<Product>();

                //Open connection
                if (OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(new Product()
                        {
                            P_ID = (int)dataReader["P_ID"],
                            P_Code = (string)dataReader["P_Code"],
                            P_Price = (double)dataReader["P_Price"],
                            P_Discription = (string)dataReader["P_Discription"]
                           
                        });
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
        }

        public Product ProductGetByID(int ID)
        {
            string query = "SELECT * FROM Product WHERE P_ID = '" + ID + "';";

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Product p = new Product();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    p = new Product()
                    {
                        P_ID = (int)dataReader["P_ID"],
                        P_Code = (string)dataReader["P_Code"],
                        P_Discription = (string)dataReader["P_Discription"],
                        P_Price = (double)dataReader["P_Price"]
                    };

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return p;
            }
            return new Product();
        }

        public Result ProductUpdate(Product P)
        {
            string query = "UPDATE Product SET P_Code = '" + P.P_Code + "',P_Discription= '" + P.P_Discription + "',P_Price=" + P.P_Price + " WHERE P_ID = " + P.P_ID + ";";
            return Query(query);
        }
        #endregion


        #region "Vendor table section"
        [StructLayout(LayoutKind.Sequential)]
        public struct Vendor
        {
            public int V_ID;
            public string CarPlate;
            public string CarColor;
            public string DriverLicense;
        }
       
        public Result VendorAdd(Vendor V)
        {
            Query("SET GLOBAL max_allowed_packet = 16777216;"); //allow to send up to 16MB image...

            try
            {
                MySqlCommand cmd;
                FileStream fs;
                BinaryReader br;

                try
                {

                    string FileName = V.DriverLicense;
                    byte[] ImageData;
                    fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    string CmdString = "INSERT INTO Vendor(CarPlate, CarColor, DriverLicense) VALUES(@CarPlate, @CarColor, @DriverLicense);";
                    cmd = new MySqlCommand(CmdString, connection);

                    cmd.Parameters.Add("@CarPlate", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@CarColor", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@DriverLicense", MySqlDbType.LongBlob);

                    cmd.Parameters["@CarPlate"].Value = V.CarPlate;
                    cmd.Parameters["@CarColor"].Value = V.CarColor;
                    cmd.Parameters["@DriverLicense"].Value = ImageData;

                    connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Image saved sucessfully!");
                    }
                    connection.Close();
                    CloseConnection();
                    return Result.Success;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to Add Vendor record: " + ex.Message);
                    CloseConnection();
                    return Result.Failed;
                }

            }
            catch (Exception)
            {
                return Result.Failed;
             
            }
            
        }

        public List<Vendor> VendorGetAll
        {
            get
            {
                //SELECT * FROM Customer;

                string query = "SELECT * FROM Vendor;";
                List<Vendor> list = new List<Vendor>();

                //Open connection
                if (OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        try
                        {
                            list.Add(new Vendor()
                            {
                                V_ID = (int)dataReader["V_ID"],
                                CarPlate = (string)dataReader["CarPlate"],
                                CarColor = (string)dataReader["CarColor"],
                                DriverLicense = (string)dataReader["DriverLicense"]
                            });
                        }
                        catch (InvalidCastException)
                        {
                            list.Add(new Vendor()
                            {
                                V_ID = (int)dataReader["V_ID"],
                                CarPlate = (string)dataReader["CarPlate"],
                                CarColor = (string)dataReader["CarColor"],
                               
                            });
                        }
                       
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
        }

        public Vendor VendorGetByID(int ID)
        {

            string query = "SELECT * FROM Vendor WHERE V_ID = '" + ID + "';";

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Vendor c = new Vendor();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    try
                    {
                        c = new Vendor()
                        {
                            V_ID = (int)dataReader["V_ID"],
                            CarPlate = (string)dataReader["CarPlate"],
                            CarColor = (string)dataReader["CarColor"],

                            DriverLicense = ByteArrayToString((byte[])dataReader["DriverLicense"])
                        };
                    }
                    catch (InvalidCastException)
                    {
                        c = new Vendor()
                        {
                            V_ID = (int)dataReader["V_ID"],
                            CarPlate = (string)dataReader["CarPlate"],
                            CarColor = (string)dataReader["CarColor"]
                        };
                    }
                   

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return c;
            }
            return new Vendor();
        }
        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        public Result VendorUpdate(Vendor V)
        {
            Query("SET GLOBAL max_allowed_packet = 16777216;"); //allow to send up to 16MB image...

            MySqlCommand cmd;
            FileStream fs;
            BinaryReader br;

            try
            {
                
                string FileName = V.DriverLicense;
                byte[] ImageData;
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                
                string CmdString = "UPDATE Vendor SET CarPlate = @CarPlate, CarColor = @CarColor, DriverLicense = @DriverLicense WHERE V_ID = " + V.V_ID + ";";
                cmd = new MySqlCommand(CmdString, connection);

                cmd.Parameters.Add("@CarPlate", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@CarColor", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@DriverLicense", MySqlDbType.LongBlob);
                    
                cmd.Parameters["@CarPlate"].Value = V.CarPlate;
                cmd.Parameters["@CarColor"].Value = V.CarColor;
                cmd.Parameters["@DriverLicense"].Value = ImageData;
                    
                connection.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Image saved sucessfully!");
                }
                connection.Close();
                CloseConnection();
                return Result.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update Vendor record: " + ex.Message);
                CloseConnection();
                return Result.Failed;
            }
            
        }

        #endregion


        #region "Customer table section"
        public Result CustomerAdd(Customer C)
        {
            string query = "INSERT INTO Buyer (Name, Company, Address, Phone, Email)Values( '" + C.B_Name + "','" + C.B_Company + "','" + C.B_Address + "','" + C.B_Phone + "','" + C.B_Email + "');";
            return Query(query);

        }

        public enum CustomerColumn
        {  B_ID, B_Company, B_Name, B_Address, B_Phone, B_Email  }
        [StructLayout(LayoutKind.Sequential)] public struct Customer
        {
            public int B_ID;
            public string B_Company;
            public string B_Name;
            public string B_Address;
            public string B_Phone;
            public string B_Email;
        }
        public List<Customer> CustomerGetAll
        {
            get
            {
                //SELECT * FROM Customer;

                string query = "SELECT * FROM Buyer;";
                List<Customer> list = new List<Customer>();

                //Open connection
                if (OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list.Add(new Customer() { B_ID = (int)dataReader["B_ID"] ,
                            B_Name = (string)dataReader["Name"],
                            B_Company = (string)dataReader["Company"],
                            B_Address = (string)dataReader["Address"],
                            B_Phone = (string)(dataReader["Phone"].ToString()),
                            B_Email = (string)dataReader["Email"]
                        });
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
        }

        public Customer CustomerGetByID(int ID)
        {

            string query = "SELECT * FROM Buyer WHERE B_ID = '" + ID + "';";

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                Customer c = new Customer();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    c = new Customer()
                    {
                        B_ID = (int)dataReader["B_ID"],
                        B_Name = (string)dataReader["Name"],
                        B_Company = (string)dataReader["Company"],
                        B_Address = (string)dataReader["Address"],
                        B_Phone = (string)(dataReader["Phone"].ToString()),
                        B_Email = (string)dataReader["Email"]
                    };

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return c;
            }
            return new Customer();
        }

        public Result CustomerUpdate(Customer c)
        {
            string query = "UPDATE Buyer SET Name = '" + c.B_Name + "',Address= '" + c.B_Address + "',Company='" + c.B_Company + "',Email='" + c.B_Email + "',Phone='" + c.B_Phone + "'" + " WHERE B_ID = " + c.B_ID +";";
            return Query(query);

        }

        #endregion
    }
}
