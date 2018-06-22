using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _GUI_Projects_CSharp
{
    class Character_Sequence_Challenge
    {
        public static void main()
        {
            System.Console.WriteLine(getOccurences("abcdefghgggijklaaaaayurr"));
        }

        public static int getOccurences(string input)
        {
            string previousChar = "";
            int occurences = 0;
            int V = 0;
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (input.Substring(i,1) == previousChar)  occurences++;
                else
                {
                    previousChar = input.Substring(i, 1);
                    if ( occurences > V) 
                        V=occurences;
                    occurences = 1;
                }
            }
            return V;
        }
    }
}
