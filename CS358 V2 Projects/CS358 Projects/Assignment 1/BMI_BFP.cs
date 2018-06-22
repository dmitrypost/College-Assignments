using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS358_Projects.Assignment_1
{
    //Created by Dmitry Post

    [Serializable()]
    public class Person : IEquatable<Person>, IComparable<Person>
    {
        public string name;
        public bool sex;
        public int heightInInches;
        public int weightInLBS;
        public int age; //true is male, false is female
        public double BodyFatPercentage {
            get {
                if (age >= 18)
                {   //Adult body fat % = (1.20 × BMI) + (0.23 × Age) − (10.8 × sex) − 5.4                
                    return (1.2 * BMI) + (0.23 * age) - (10.8 * Convert.ToInt32(sex)) - 5.4;
                }
                else
                {    //Child body fat % = (1.51 × BMI) − (0.70 × Age) − (3.6 × sex) + 1.4 
                    return (1.51 * BMI) + (0.7 * age) - (3.6 * Convert.ToInt32(sex)) + 1.4;
                }
            }
        }
        public double BMI
        {
            get { return  (((weightInLBS / (Math.Pow((heightInInches), 2))) * 703)); }

        }

        public double IdealWeight
        {
            get
            { return (22 * Math.Pow(heightInInches,2)/703); }
        }

        //used for binary search... (ToString)
        public override string ToString()
        {
            return "name: " + name + "   sex: " + sex + "   height: " + heightInInches + "   weight: " + weightInLBS + "   age: " + age + "   BFP: " + BodyFatPercentage + "   BMI: " + BMI;
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
                return this.BodyFatPercentage.CompareTo(p.BodyFatPercentage);
        }
        public int CompareByBMITo(Person p)
        {
            if (p == null)
                return 1;
            else
                return this.BMI.CompareTo(p.BMI);
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
            return (this.ToString() == (p.ToString()));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }





}
