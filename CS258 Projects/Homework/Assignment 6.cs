using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Homework6
{
    class Assignment_6
    {

        static void Main(string[] args)
        {

          
            List<Person> people = new List<Person> { }; //add person to the list...
            
            Console.Title = "Programming Assingment 6 by Dima Post";

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Exit); // handles the Ctrl + C event... (exit) 
            

            do
            {

                
                Console.WriteLine("Enter a command: ");
                Console.WriteLine("\t Currently " + people.Count + " recorded.");
                Console.WriteLine("\t Add: \t\tAdd another person's information");
                Console.WriteLine("\t Edit: \t\tEdit an existing person's information"); //TO DO: edit...
                Console.WriteLine("\t List: \t\tShows all the people's information added");
                Console.WriteLine("\t Sort: \t\tSorts the people by type");
                Console.WriteLine("\t Search: \tSearches for a person"); 
                Console.WriteLine("\t Save: \t\tsaves all recorded information");
                Console.WriteLine("\t Load: \t\tRead recoded information");


                switch (Console.ReadLine().ToLower())   
                {
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    case "add":
                        Person p = PopulatePerson();
                        Console.Clear();

                        people.Add(p);
                        // PPL = ResizeAndAdd(PPL, p);

                        Console.WriteLine("Name: " + p.name.ToUpper());
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        Console.WriteLine("Body mass index:     " + Math.Round(p.BodyMassIndex.value,2));
                        Console.WriteLine("Body fat percentage: " + Math.Round(p.BodyFatPercentage.value,2));
                        Console.WriteLine("Hong Kong Hospital Authority evaluation: " + EvaluateBFP_HongKong(p.BodyFatPercentage.value));
                        Console.WriteLine("American Council on Exercise evaluation: " + EvaluateBFP_AmericanCouncil(p.BodyFatPercentage.value, p.sex));
                        
                        
                        Console.WriteLine("\n" + people.Count + " people's information recorded.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "list":
                        ShowAll(people);  
                        break;
                    case "sort":
                        Console.WriteLine("What would you like to sort by? \n\t sort options: name, sex, height, weight, age, BMI, BFP");

                       
                        switch (Console.ReadLine())
	                    {
                            case "name":
                                people.Sort(delegate(Person x, Person y) //sort by name...
                                {
                                    if (x.name == null && y.name == null) return 0;
                                    else if (x.name == null) return -1;
                                    else if (y.name == null) return 1;
                                    else return x.name.CompareTo(y.name);
                                });
                            break;
                            case "sex":
                            people.Sort(delegate(Person x, Person y)
                            {
                                return x.sex.CompareTo(y.sex);
                            });
                            break;
                            case "height": //returned decending....
                            people.Sort(delegate(Person x, Person y)
                            {
                                if (x.heightInInches == 0 && y.heightInInches == 0) return 0;
                                else if (x.heightInInches == 0) return -1;
                                else if (y.heightInInches == 0) return 1;
                                else return x.heightInInches.CompareTo(y.heightInInches);
                            });
                            break;
                            case "weight": //returned decending....
                            people.Sort(delegate(Person x, Person y)
                            {
                                if (x.weightInLBS == 0 && y.weightInLBS == 0) return 0;
                                else if (x.weightInLBS == 0) return -1;
                                else if (y.weightInLBS == 0) return 1;
                                else return x.weightInLBS.CompareTo(y.weightInLBS);
                            });
                            break;
                            case "age":
                            people.Sort(delegate(Person x, Person y)
                            {
                                if (x.age == 0 && y.age == 0) return 0;
                                else if (x.age == 0) return -1;
                                else if (y.age == 0) return 1;
                                else return x.age.CompareTo(y.age);
                            });
                            break;
                            case "bmi": //returned decending....
                            people.Sort(delegate(Person x, Person y)
                            {
                                if (x.BodyMassIndex.value == 0 && y.BodyMassIndex.value == 0) return 0;
                                else if (x.BodyMassIndex.value == 0) return -1;
                                else if (y.BodyMassIndex.value == 0) return 1;
                                else return x.BodyMassIndex.value.CompareTo(y.BodyMassIndex.value);
                            });
                            break;
                            case "bfp": //returned decending....
                            people.Sort(delegate(Person x, Person y)
                            {
                                if (x.BodyFatPercentage.value == 0 && y.BodyFatPercentage.value == 0) return 0;
                                else if (x.BodyFatPercentage.value == 0) return -1;
                                else if (y.BodyFatPercentage.value == 0) return 1;
                                else return x.BodyFatPercentage.value.CompareTo(y.BodyFatPercentage.value);
                            });
                            break;

	                    }
                        ShowAll(people);

                        break; //on sort command...
                    case "search":
                        Search(people, false); //no editing allowed of the results
                        break;
                    case "edit":
                        Search(people, true); //allows editing of the search results
                        break;
                    case "save":
                        try
                        {
                            using (Stream stream = File.Open("data.bin", FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, people);
                            }
                            Console.WriteLine("Data saved...");
                        }
                        catch (IOException) { Console.WriteLine("error writing data..."); }
                        break;
                    case "load":
                        try
                        {
                            using (Stream stream = File.Open("data.bin", FileMode.Open))
                            {
                                BinaryFormatter bin = new BinaryFormatter();

                                people = (List<Person>)bin.Deserialize(stream);
                                Console.WriteLine("Data loaded...");
                            }
                        }
                        catch (InvalidCastException) { Console.WriteLine("error invalid case exception... no loaded data..."); }
                        catch (IOException) { Console.WriteLine("error reading data..."); }
                        break;
                }


            } while (true);



        }

        public static void Search(List<Person> people, bool editResult)
        {
                Console.WriteLine("What field would you like to search in? \n\t search options: name, sex, height, weight, age, BMI, BFP \n\tall records with search value will be returned.");
                string field = Console.ReadLine().ToLower();
                Console.WriteLine("What is the search term?");
            tryagainInput:
                string term = Console.ReadLine().ToLower();
                try
                {
                    switch (field)
                    {
                        case "name":
                            foreach (Person psn in people)
                            {
                                if (psn.name.ToUpper() == term.ToUpper())
                                    DisplaySpecificOne( psn, editResult);
                            }
                            break;
                        case "sex":
                            if (term == "male")
                            {
                                foreach (Person psn in people)
                                {
                                    if (psn.sex == true)
                                        DisplaySpecificOne( psn, editResult);
                                }
                            }
                            else if (term == "female")
                            {
                                foreach (Person psn in people)
                                {
                                    if (psn.sex == false)
                                        DisplaySpecificOne( psn, editResult);
                                }
                            }
                            else { Console.WriteLine("type male or female for the type of sex"); }
                            break;
                        case "height":
                            foreach (Person psn in people)
                            {
                                if (psn.heightInInches == Convert.ToInt32(term))
                                    DisplaySpecificOne( psn, editResult);
                            }
                            break;
                        case "weight":
                            foreach (Person psn in people)
                            {
                                if (psn.weightInLBS == Convert.ToInt32(term))
                                    DisplaySpecificOne( psn, editResult);
                            }
                            break;
                        case "age":
                            foreach (Person psn in people)
                            {
                                if (psn.age == Convert.ToInt32(term))
                                    DisplaySpecificOne( psn, editResult);
                            }
                            break;
                        case "bmi":
                            foreach (Person psn in people)
                            {
                                if (Math.Round(psn.BodyMassIndex.value, 2) == Convert.ToDouble(term))
                                    DisplaySpecificOne( psn, editResult);
                            }
                            break;
                        case "bfp":
                            foreach (Person psn in people)
                            {
                                if (Math.Round(psn.BodyFatPercentage.value, 2) == Convert.ToDouble(term))
                                    DisplaySpecificOne( psn, editResult);
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("error converting input...\ntry again.");
                    goto tryagainInput;
                }    
           
                       

        }
        public static void DisplaySpecificOne(Person p, bool edit)
        {
            if (edit)
            {
            tryAgainEdit:
                try
                {

                    Console.Write("Name: ");
                    SendKeys.SendWait(p.name.ToUpper());
                    p.name = Console.ReadLine();
                    Console.Write("--------------------------------------------------------------------------------");
                    Console.Write("Sex (male):     ");
                    if (p.sex == true)
                        SendKeys.SendWait("male");
                    else
                        SendKeys.SendWait("female");
                    if (Console.ReadLine().ToLower() == "male")
                        p.sex = true;
                    else
                        p.sex = false;
                    Console.Write("Height (Inches):     ");
                    SendKeys.SendWait(Convert.ToString(decimal.Round(p.heightInInches, 2)));
                    p.heightInInches = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Weight (LBS):        ");
                    SendKeys.SendWait(Convert.ToString(decimal.Round(p.weightInLBS, 2)));
                    p.weightInLBS = Convert.ToInt32(Console.ReadLine());
                    p.BodyMassIndex = new BMI(p);
                    p.BodyFatPercentage = new BFP(p, p.BodyMassIndex.value);
                    Console.WriteLine("Updated sucessfully!");
                }
                catch (Exception)
                {
                    Console.WriteLine("error incorrect input type. Try again");
                    goto tryAgainEdit;
                }
            
            }
            else
            {
                Console.WriteLine("Name: " + p.name.ToUpper());
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("Height (Inches):     " + decimal.Round(p.heightInInches, 2));
                Console.WriteLine("Weight (LBS):        " + decimal.Round(p.weightInLBS, 2));
                Console.WriteLine("Body mass index:     " + Math.Round(p.BodyMassIndex.value, 2));
                Console.WriteLine("Body fat percentage: " + Math.Round(p.BodyFatPercentage.value, 2));
                Console.WriteLine("Hong Kong Hospital Authority evaluation: " + EvaluateBFP_HongKong(p.BodyFatPercentage.value));
                Console.WriteLine("American Council on Exercise evaluation: " + EvaluateBFP_AmericanCouncil(p.BodyFatPercentage.value, p.sex) + "\n");
            }
        }
        public static void ShowAll(List<Person> peopleList)
        {
            Console.Clear();
            foreach (Person p in peopleList)
            {
                DisplaySpecificOne(p, false);
            }
        }
        public static void Exit(object sender, ConsoleCancelEventArgs args)
        {
            System.Console.Clear();
            DialogResult dialogResult = MessageBox.Show("Would you like to exit?", "Exit applcation?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                System.Environment.Exit(0);
            }
            else if (dialogResult == DialogResult.No)
            {

                args.Cancel = true;

            }



        }
        public static Person PopulatePerson()
        {//module to populate person attributes
            Person p = new Person();
            Console.Write("What is the name of the person?");
        tryagain_name:
            try
            {
                p.name = Console.ReadLine();
                if (p.name == "") { goto tryagain_name; }
            }
            catch (Exception)
            {
                Console.WriteLine("Format error please try again: Name of person.");
                goto tryagain_name;
            }
            Console.Write("Is the the gender? male or female: ");
        tryagain_gender:
            try
            {
                string t = Console.ReadLine().ToUpper();
                if (t == "MALE")
                { p.sex = true; }
                else if (t == "FEMALE")
                { p.sex = false; }
                else
                {
                    Console.WriteLine("Please enter 'male' or 'female'");
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
            //Adds the bmi and bfp to this Person object
            p.BodyMassIndex = new BMI(p);
            p.BodyFatPercentage = new BFP(p, p.BodyMassIndex.value);
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
            else if (BFP < 24.9)
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
                    return "this is awkward, something went wrong...";
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

    [Serializable()]
    public class Person : IEquatable<Person> , IComparable<Person>
    {
        public string name;
        public bool sex;
        public int heightInInches;
        public int weightInLBS;
        public int age;
        public BFP BodyFatPercentage;
        public BMI BodyMassIndex;

        //used for binary search... (ToString)
        public override string ToString()
        {
            return "name: " + name + "   sex: " + sex + "   height: " + heightInInches + "   weight: " + weightInLBS + "   age: " + age + "   BFP: " + BodyFatPercentage.value + "   BMI: " + BodyMassIndex.value;
        }
       
        public int SortByNameAscending(string name1, string name2)
        {
            //reorders by ascending...
            return name1.CompareTo(name2);
        }

        public int CompareTo(Person p) //default comparer; Compares this instacne of person's name with another instance of person's name
        {
            // A null value means that this object is greater. 
            if (p == null)
                return 1;

            else
                return this.name.CompareTo(p.name);
        }
        public int CompareBySexTo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.sex.CompareTo(p.sex);
        }
        public int CompareByHeightTo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.heightInInches.CompareTo(p.heightInInches);
        }
        public int CompareByWeightTo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.weightInLBS.CompareTo(p.weightInLBS);
        }
        public int CompareByAgeTo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.age.CompareTo(p.age);
        }
        public int CompareByBFPTo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.BodyFatPercentage.value.CompareTo(p.BodyFatPercentage.value);
        }
        public int CompareByBMITo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.BodyMassIndex.value.CompareTo(p.BodyMassIndex.value);
        }
         public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Person p = obj as Person;
            if (p == null) return false;
            else return Equals(p);
        }
        public bool Equals(Person p) //determines if this instance of person is the same as another instance of person...; However this is overwritten to allow compareison to an object... 
        {
            if (p == null) return false;
            return (this.ToString()==(p.ToString()));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    [Serializable()]
    public class BMI
    {
        public double value;
        public BMI(Person p_)
        {//BMI = (Weight in Pounds / (Height in inches)^2) * 703;
            value = (((p_.weightInLBS / (Math.Pow((p_.heightInInches), 2))) * 703));
        }
    }

    [Serializable()]
    public class BFP
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