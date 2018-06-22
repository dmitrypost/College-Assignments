/* Programmer:  Dima Post (Dmitry)
     Date:      9/30/2014
     CRN:       CS258
     Desc:      programming assignmnet 3
*/
using System;
namespace Homework {
    class BodyFatPercentageCalculator {
        static void Main(string[] args) {
            Person p = PopulatePerson();
            BMI bmi = new BMI(p) { };
            BFP bfp = new BFP(p,bmi.value) { };
            Console.WriteLine("The person's BMI is: " + bmi.value);
            Console.WriteLine("The person's body fat percentage is: " + bfp.value);
            Console.ReadLine(); }
        public static Person PopulatePerson() {//module to populate person attributes
            Person p = new Person();
            Console.Write("Is the person a male? (Y,N):");
            if (Console.ReadLine().ToUpper() == "Y")
            { p.sex = true; } else { p.sex = false; }
            Console.Write("How old is the person? ");
            p.age = Convert.ToInt32(Console.ReadLine());
            Console.Write("How tall is the person in Inches? ");
            p.heightInInches = Convert.ToInt32(Console.ReadLine());
            Console.Write("How much does the person weigh? (LBS): ");
            p.weightInLBS = Convert.ToInt32(Console.ReadLine());
            return p; } }
    public struct Person { public bool sex; public int heightInInches; public int weightInLBS; public int age; }
    class BMI {
        public double value;
        public BMI(Person p_)
        {//BMI = (Weight in Pounds / (Height in inches)^2) * 703;
            value = (((p_.weightInLBS / (Math.Pow((p_.heightInInches), 2))) * 703)); } }
    class BFP {
        public double value;
        public BFP(Person p, double bmi) {
            if (p.age >= 18) {   //Adult body fat % = (1.20 × BMI) + (0.23 × Age) − (10.8 × sex) − 5.4                
                value = (1.2 * bmi) + (0.23 * p.age) - (1.8 * Convert.ToInt32(p.sex)) - 5.4; }
            else {    //Child body fat % = (1.51 × BMI) − (0.70 × Age) − (3.6 × sex) + 1.4 
                value = (1.51 * bmi) + (0.7 * p.age) - (3.6 * Convert.ToInt32(p.sex)) + 1.4; } } } }