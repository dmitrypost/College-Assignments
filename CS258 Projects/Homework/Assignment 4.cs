/* Programmer:  Dima Post (Dmitry)
     Date:      10/?/2014
     CRN:       CS258
     Desc:      programming assignment 4
*/
using System;
namespace Homework_Assgnment_4
{
    class BodyFatPercentageCalculator
    {
        static void Main(string[] args)
        {
            Console.Title = "Programming Assingment 4 by Dima Post";
            Person p = PopulatePerson();
            BMI bmi = new BMI(p) { };
            BFP bfp = new BFP(p, bmi.value) { };
            Console.WriteLine("The person's BMI is: " + bmi.value);
            Console.WriteLine("The person's body fat percentage is: " + bfp.value + " " + EvaluateBFP_HongKong(bfp.value));
            Console.WriteLine("According to Hospital Authority of Hong Kong the person is " + EvaluateBFP_HongKong(bfp.value));
            Console.WriteLine("According to American Council on Exercise the person is " + EvaluateBFP_AmericanCouncil(bfp.value,p.sex));
            Console.ReadLine();
        }
        public static Person PopulatePerson()
        {//module to populate person attributes
            Person p = new Person();
            Console.Write("Is the the gender? male or female: ");
        tryagain_gender:
            try
            {
                string t = Console.ReadLine().ToUpper();
                if (t == "MALE")
                { p.sex = true; }
                else if (t== "FEMALE") 
                { p.sex = false; }
                else { Console.WriteLine("Please enter 'male' or 'female'");
                goto tryagain_gender;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter 'male' or 'female'");
                goto tryagain_gender;
            }
            
            Console.Write("How old is the person? ");
            
        tryagain_age:
            string temp = Console.ReadLine();
            
            try
            {
                p.age = Convert.ToInt32(temp);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect format... Please enter a number...");
                goto tryagain_age;
            }
            
            Console.Write("How tall is the person in Inches? ");

        tryagain_height:
            temp = Console.ReadLine();
            try
            {
                p.heightInInches = Convert.ToInt32(temp);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect format... Please enter the height in inches...");
                goto tryagain_height;
            }
            
            Console.Write("How much does the person weigh? (LBS): ");
        tryagain_weight:
            temp = Console.ReadLine();
            try
            {
                p.weightInLBS = Convert.ToInt32(temp);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect format... Please enter the weight in LBS...");
                goto tryagain_weight;            
            }
            
            return p;
        }

        static string EvaluateBFP_HongKong(double BFP)
        {
           if (BFP < 18.5)
           {
               return "Underweight";
           }
           else if (BFP < 22.9)
           {
               return "Normal Range";
           }
           else if (BFP <24.9)
           {
               return "Overweight - At Risk";
           }
           else if (BFP < 29.9)
           {
               return "Overweight - Moderately Obese";
           }
           else if (BFP >= 29.9)
           {
               return "Overweight - Severely Obese";
           }
           else
           {
               return "this is awkward, something went wrong...";
           }
        }

        static string EvaluateBFP_AmericanCouncil(double BFP, bool sex)
        {
           if (sex) // Males
           {
               if (BFP < 2)
               {
                   return "not enough fat";
               }
               else if (BFP < 6) // 5.5 will not fall under this thus using < 6 instead
               {
                   return "Essential fat";
               }
               else if (BFP < 14)
               {
                   return "Athletes";
               }
               else if (BFP < 18)
               {
                   return "Fitness";
               }
               else if (BFP < 25)
               {
                   return "Average";
               }
               else if (BFP >= 25)
               {
                   return "Obese";
               }
               else
               {
                   return "this is awkward, something went wrong..." ;
               }
           }
           else // Females
           {
               if (BFP < 10)
               {
                   return "not enough fat";
               }
               else if (BFP < 14)
               {
                   return "Essential fat";
               }
               else if (BFP < 21)
               {
                   return "Athletes";
               }
               else if (BFP < 25)
               {
                   return "Fitness";
               }
               else if (BFP < 32)
               {
                   return "Average";
               }
               else if (BFP >= 32)
               {
                   return "Obese";
               }
               else
               {
                   return "this is awkward, something went wrong...";
               }
           }
            
        }
    }
    public struct Person { public bool sex; public int heightInInches; public int weightInLBS; public int age; }
    class BMI
    {
        public double value;
        public BMI(Person p_)
        {//BMI = (Weight in Pounds / (Height in inches)^2) * 703;
            value = (((p_.weightInLBS / (Math.Pow((p_.heightInInches), 2))) * 703));
        }
    }
    class BFP
    {
        public double value;
        public BFP(Person p, double bmi)
        {
            if (p.age >= 18)
            {   //Adult body fat % = (1.20 × BMI) + (0.23 × Age) − (10.8 × sex) − 5.4                
                value = (1.2 * bmi) + (0.23 * p.age) - (10.8 * Convert.ToInt32(p.sex)) - 5.4;
            }
            else
            {    //Child body fat % = (1.51 × BMI) − (0.70 × Age) − (3.6 × sex) + 1.4 
                value = (1.51 * bmi) + (0.7 * p.age) - (3.6 * Convert.ToInt32(p.sex)) + 1.4;
            }
        }
    }
}