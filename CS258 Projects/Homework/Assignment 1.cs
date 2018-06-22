/* Programmer:  Dima Post (Dmitry)
     Date:      9/10/2014
     CRN:       CS258
     Desc:      programming assignmnet 1
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        enum Semester { Spring, Fall, Summer };
        static void Main(string[] args)
        {
            // part 1 A
            const string Institution = "University of Southern Indiana";
            const int BuildYear = 1965;
            double CurrentYear = DateTime.Today.Year;
            double CurrentEnrollmentNum = 9902;
            double FemalePercentage = 0.61;
            double MalePercentage = 0.39;

            // part 1 B
            CurrentYear += 1;
            double AgeOfInstitution = CurrentYear - BuildYear;
            CurrentEnrollmentNum += CurrentEnrollmentNum * 0.1;

            int FemaleStudents = (int)(CurrentEnrollmentNum * FemalePercentage);
            double MaleStudents = (int)(CurrentEnrollmentNum * MalePercentage);
            
            Semester currentSemester = Semester.Spring;
            
            // part 1 C
            Console.WriteLine();
            Console.WriteLine("************** " + Institution + " ************" + CurrentYear + " " + currentSemester + "    \n");
            Console.WriteLine("Age: " + AgeOfInstitution + ("\t\tEnrollment: " + (int)CurrentEnrollmentNum) + "\n");
            Console.WriteLine("Women: " + FemaleStudents + "(61%)\tMed: " + MaleStudents + "(39%)\n");

            // part 2
            string employeeName = "Nesbith Lang";
            const double commissionRate = 0.07;
            const double fedTaxRate = .18;
            const double retirementContribRate = .1;
            const double SScontribRate = .06;
            double sales = 161432;
            


            Console.WriteLine("\n\n");
            Console.WriteLine("Employee: " + employeeName);
            Console.WriteLine("\nCommission amount: {0:C2}", (commissionRate * sales));
            Console.WriteLine("Federal Tax amount: {0:C2}", (fedTaxRate * sales));
            Console.WriteLine("Retirement amount: {0:C2}", (retirementContribRate * sales));
            Console.WriteLine("Social Security amount: {0:C2}", (SScontribRate * sales));
            Console.WriteLine("\nSales amount: {0:C2}", (sales));


            Console.ReadLine();




        }
    }
}
