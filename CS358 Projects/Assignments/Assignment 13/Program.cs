using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Data;
using System.ComponentModel;
using SQLDll;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection c;
            Statement s;
            ResultSet r;

            try
            {
                SQL sql = new SQL();
                String url = "http://www.boehnecamp.com/phpMyAdmin/razorsql_mysql_bridge.php";
                c = sql.getConnection(url);
                Console.WriteLine("Returned from getConnection");
                s = c.createStatement(url);
                Console.WriteLine("Returned from createStatement");
                r = s.executeQuery("SELECT * FROM accountInformation");
                Console.WriteLine("Returned from executeQuery");
                while (r.next())
                {
                    Console.WriteLine(r.getString("accountNumber"));
                }
                s.executeUpdate("UPDATE accountInformation SET balanceAmount = 1000.00 WHERE accountNumber = '12548693'");
                Console.WriteLine("Returned from executeUpdate");
            }
            catch (Exception)
            {
                Console.WriteLine("EEEERRRRRRRROOORRR");
            }
        }
    }
}