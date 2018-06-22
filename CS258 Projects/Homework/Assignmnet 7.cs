using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Homework
{
    class Assignmnet_7
    {
        static void Main(string[] args)
        {
            Console.Title = "Assignment 7 by Dima Post";
            List<ExerciseDay> Zuma = new List<ExerciseDay>();
            List<ExerciseDay> Spinning = new List<ExerciseDay>();
            PopulateExerciseClasses(Zuma, Spinning);
            Console.WriteLine("\t\t\tZUMA");
            DisplayInfo(Zuma);
            Console.WriteLine("\t\t\tSpinning");
            DisplayInfo(Spinning);
        }
        public static void DisplayInfo(List<ExerciseDay> ExerciseList)
        {
            Console.Write("Times: \t\t");
            foreach (time t in ExerciseList[0].availableTimes)
            {
                Console.Write(t.Time + "PM\t");
            }
            Console.Write("Revenue");
            int totalRev = 0;
            foreach (ExerciseDay eday in ExerciseList)
            {
                Console.Write("\n" + eday.day + "     \t");
                foreach (time t in eday.availableTimes)
                {
                    Console.Write(t.People + "\t");
                }
                Console.Write(" $" + eday.getRevenue());
                totalRev += eday.getRevenue();
            }
            Console.Write("\nTotal: \t");
           
            foreach (time t in ExerciseList[0].availableTimes)
            {
                int participants = 0;
                foreach (ExerciseDay eday in ExerciseList)
                {
                    participants += eday.getPerticipantsAtTime(t.Time);
                    
                }
                Console.Write("\t" + participants);
            }
            Console.Write("\t $" + totalRev);
            Console.WriteLine("\n");
        }
        public bool getDay(dayOfWeek day, List<ExerciseDay> listofDays, out ExerciseDay OutPutDay)
        {
            foreach (ExerciseDay d in listofDays)
            {
                if (d.day == day)
                {
                    OutPutDay = d;
                    return true; 
                }
            }
            OutPutDay = null;
            return false; 
        }
        public static void PopulateExerciseClasses(List<ExerciseDay> Zuma, List<ExerciseDay> Spinning)
        {

            List<time> times = new List<time> { }; //gets reused...
            times.Add(new time(1, 4, 12));
            times.Add(new time(3, 4, 10));
            times.Add(new time(5, 4, 17));
            times.Add(new time(7, 4, 22));
            ExerciseDay temp = new ExerciseDay(times); // gets reused...
            temp.day = dayOfWeek.monday;
            Zuma.Add(temp);

            times = new List<time> { };
            times.Add(new time(1, 4, 11));
            times.Add(new time(3, 4, 13));
            times.Add(new time(5, 4, 17));
            times.Add(new time(7, 4, 22));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.tuesday;
            Zuma.Add(temp);

            times = new List<time> { };
            times.Add(new time(1, 4, 12));
            times.Add(new time(3, 4, 10));
            times.Add(new time(5, 4, 22));
            times.Add(new time(7, 4, 22));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.wednesday;
            Zuma.Add(temp);

            times = new List<time> { };
            times.Add(new time(1, 4, 9));
            times.Add(new time(3, 4, 14));
            times.Add(new time(5, 4, 17));
            times.Add(new time(7, 4, 22));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.tuesday;
            Zuma.Add(temp);

            times = new List<time> { };
            times.Add(new time(1, 4, 12));
            times.Add(new time(3, 4, 10));
            times.Add(new time(5, 4, 21));
            times.Add(new time(7, 4, 12));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.friday;
            Zuma.Add(temp);

            times = new List<time> { };
            times.Add(new time(1, 4, 12));
            times.Add(new time(3, 4, 10));
            times.Add(new time(5, 4, 5));
            times.Add(new time(7, 4, 10));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.saturday;
            Zuma.Add(temp);

            //------------------------------------------------
            //Add data for Spinning exercise class....
            //------------------------------------------------

            times = new List<time> { };
            times.Add(new time(2, 5, 7));
            times.Add(new time(4, 5, 11));
            times.Add(new time(6, 5, 15));
            times.Add(new time(8, 5, 8));
            temp = new ExerciseDay(times); // gets reused...
            temp.day = dayOfWeek.monday;
            Spinning.Add(temp);

            times = new List<time> { };
            times.Add(new time(2, 5, 9));
            times.Add(new time(4, 5, 9));
            times.Add(new time(6, 5, 9));
            times.Add(new time(8, 5, 9));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.tuesday;
            Spinning.Add(temp);

            times = new List<time> { };
            times.Add(new time(2, 5, 3));
            times.Add(new time(4, 5, 12));
            times.Add(new time(6, 5, 13));
            times.Add(new time(8, 5, 7));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.wednesday;
            Spinning.Add(temp);

            times = new List<time> { };
            times.Add(new time(2, 5, 2));
            times.Add(new time(4, 5, 9));
            times.Add(new time(6, 5, 9));
            times.Add(new time(8, 5, 10));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.thursday;
            Spinning.Add(temp);

            times = new List<time> { };
            times.Add(new time(2, 5, 8));
            times.Add(new time(4, 5, 4));
            times.Add(new time(6, 5, 9));
            times.Add(new time(8, 5, 4));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.friday;
            Spinning.Add(temp);

            times = new List<time> { };
            times.Add(new time(2, 5, 4));
            times.Add(new time(4, 5, 5));
            times.Add(new time(6, 5, 9));
            times.Add(new time(8, 5, 3));
            temp = new ExerciseDay(times);
            temp.day = dayOfWeek.saturday;
            Spinning.Add(temp);
        }
    }
    public enum dayOfWeek
    {
        monday = 1,
        tuesday = 2,
        wednesday = 3,
        thursday = 4,
        friday = 5,
        saturday = 6,
    }
    public class ExerciseDay 
    {
        public dayOfWeek day { get; set; }
        public ExerciseDay(List<time> times)
        {
            availableTimes = times;
        }
        public List<time> availableTimes = new List<time>();
        public int getPerticipantsAtTime(int t) // returns the about of people for the time in each day...
        {
            foreach (time eval in availableTimes)
            {
                if (eval.Time == t)
                {
                    return eval.People;
                }
            }
            return 0;
        }
        public int getRevenueAtTime(int t) // returns the about of revenue for the time in each day...
        {
            foreach (time eval in availableTimes)
            {
                if (eval.Time == t)
                {
                    return eval.Revenue;
                }
            }
            return 0;
        }
        public int getRevenue()
        {
            int rev = 0;
            foreach (time eval in availableTimes)
            {
                rev += eval.Revenue;
            }
            return rev;
        }
        public int getParticipants()
        {
            int participants = 0;
            foreach (time eval in availableTimes)
            {
                participants += eval.People;
            }
            return participants;
        }
    }
    public class time
    {
        public time(int stringTime, int price, int people)
        {
            People = people;
            Price = price;
            Time = stringTime;
        }
        public int People { get; set; }
        public int Revenue { get { return Price * People; } }
        public int Price { get; set; }
        public int Time { get; set; }
    }
}
  