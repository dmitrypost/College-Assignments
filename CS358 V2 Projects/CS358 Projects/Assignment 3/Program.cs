using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnorderedArrayListNamespace;
using ArrayListNamespace;

namespace test
{
    class Assignment_3_ArrayList
    {
        static void Main(string[] args)
        {
            UnorderedArrayList<int> u = new UnorderedArrayList<int>();
            
            //insert function
            int i = 5;
            u.insert(ref i);
            u.insert(ref i);
            i = 6;
            u.insert(ref i);
            i = 7;
            u.insert(ref i);
            i = 5;
            u.insert(ref i);
            i = 5;
            u.insert(ref i);
            u.insert(ref i);
            i = 13;
            u.insert(ref i);
            i = 9;
            u.insert(ref i);
            
            //show current array
            Console.WriteLine("Current Array:");
            u.print();

          // removes all instances of 5
            Console.WriteLine("Removing all 5s");
            int var = 5;
            u.removeall(ref var);
            u.print();
            
            //shows smallest and largest
            Console.WriteLine("\nLargest: " + u.max());
            Console.WriteLine("Smallesst: " + u.min());

            //sorting
            Console.WriteLine("\nSorted list:");
            u.sort();
            u.print();
            
            //removing using the moving last element into the removed element...
            Console.WriteLine("remove 7; becomes unsorted: " );
            i = 7;
            u.remove(ref i);
            u.print();


            Console.WriteLine("OrderedLinkedList Testing...");
            OrderedLinkedList a = new OrderedLinkedList("cat");
            a.insert(new OrderedLinkedList("dog"));
            a.insert(new OrderedLinkedList("fish"));
            a.insert(new OrderedLinkedList("bird"));
            a.insert(new OrderedLinkedList("elephant"));
            a.insert(new OrderedLinkedList("cactus"));
            Console.WriteLine("OrderedLinkedList printing...");
            a.print();
            Console.WriteLine("OrderedLinkedList removing cat...");
            a.remove(new OrderedLinkedList("cat"));
            a.print();
            Console.WriteLine("OrderedLinkedList adding int's and double's");
            a.insert(new OrderedLinkedList(37));
            a.insert(new OrderedLinkedList(3.55));
            a.insert(new OrderedLinkedList(37.005));
            a.print();
        }
    }
}
