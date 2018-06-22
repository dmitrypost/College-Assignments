/* Programmer:  Dima Post (Dmitry)
     Date:      9/24/2014
     CRN:       CS258
     Desc:      programming assignmnet 2
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class BMICalc
    {
        

        static void Main(string[] args)
        {

            Console.Write("Please enter name: ");
            string name = Console.ReadLine();
            double weight, heightInches, heightFeet;
            string height;
            GetInfo(name, out height, out heightFeet, out heightInches, out weight);

            Console.WriteLine("\nName: " + name + "\nWeight: " + weight.ToString() + "\nHeight: " + height + "\nBMI: " + String.Format("{0:##.00}", CalcBMI(heightFeet, heightInches,weight)));
            Console.ReadLine();

        }

        static double CalcBMI(double heightFeet, double heightInches, double weight)
        {
            //BMI = (Weight in Pounds / (Height in inches)^2) * 703

            return ((weight / (Math.Pow(((heightFeet * 12) + heightInches) ,2))* 703));
        }

        static void GetInfo(string name, out string height, out double heightFeet, out double heightInches, out double weight)
        {
            Console.Write("What is the weight of " + name + "? ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("What is the height of " + name + " in the format x'x\"? ");
            height = Console.ReadLine();
            heightFeet = Convert.ToDouble(height.Substring(0, height.IndexOf("'")));

            heightInches = Convert.ToDouble(height.Substring(height.IndexOf("'") + 1, height.Length - height.IndexOf("\"") + 1));
        }
    }
}
