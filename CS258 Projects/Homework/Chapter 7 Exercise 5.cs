/* Programmer:  Dima Post (Dmitry)
     Date:      9/10/2014
     CRN:       CS258
     Desc:      Extra Programming Assignment
     Details:   Chapter 7 Exercise 5
*/
using System;
namespace Homework
{  class Ch7_Ex5 {   static void Main(string[] args)
        {
            string[] a = new string[0] ; // resize array upon needed extra space.
            int i = 0; 
            while (true) //Ctrl+C to exit
            {   Console.Write("Enter first name and last name: ");
                string fln = Console.ReadLine();
                a = ResizeArray(a);  //resize the array to fit new entry
                a[i] = fln;
                Array.Sort(a);       //only supported in 1 dimensional array :/
                Console.Clear();
                foreach(string name in a)
                {  Console.WriteLine("{0} ", name);  }
                i++; 
            }
        }
        static string[] ResizeArray(string[] oldArray)
        {
            string[] newArray = new string[oldArray.Length+1];   //add an extra spot into the new array
            for (int i = 0; i <= oldArray.GetUpperBound(0); i++) //copy old array into new array
            {  newArray[i] = oldArray[i];   }
            return newArray;
        }
    }
}
