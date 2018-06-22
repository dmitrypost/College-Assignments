using System;

namespace ArrayListNamespace
{
    public abstract class ArrayList<T>
    {
        protected T[] list;
        protected int next;

        public ArrayList()
        {
            list = new T[100];
            next = 0;
        }

        public abstract void insert(ref T item);
        

        public void remove(ref T item)
        {
            if (next == 0)
            {
            }
            else
            {
 //find value, if it exists
                for (int i = 0; i < next; i++)
                {
                    if (item.Equals(list[i]))
                    {
                        for (int j = i; j < next; j++) list[j] = list[j + 1];
                        next--;
                        break;
                    }
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < next; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine(next + " elements in list");
        }

       

        //To Do: remove all occurances of this item in the array
        public void removeall(ref T item)
        {
            foreach (T elem in list)
            {
                if (elem.Equals(item))
                {

                  
                        for (int i = 0; i < next; i++)
                        {
                            if (item.Equals(list[i]))
                            {
                                for (int j = i; j < next; j++)
                                    list[j] = list[j + 1];
                                
                                next--;
                            }

                        }
                        

                }

            }



        }

        //To Do: returns the largest item in array
        public T max()
        {
            T evaluation1;
            T evaluation2;
           
            if (list.Length == 0)
            {
                T item;
                object o = null;
                item = (T)o;
                return item;
            }
            evaluation1 = list[0];
            foreach (T elem in list)
            {
                
                evaluation2 = elem;
                if (evaluation1.GetHashCode() < evaluation2.GetHashCode())
                {
                    evaluation1 = evaluation2;
                }
                


            }
            return evaluation1;

        }

        //To Do: returns the smallest item in array
        public T min()
        {
            T evaluation1;
            T evaluation2;

            if (next == 0)
            {
                T item;
                object o = null;
                item = (T)o;
                return item;
            }
            evaluation1 = list[0];
            foreach (T elem in list)
            {
                //makes sure that the predefined 0s in the array are not included int the evaluation
                if (list[next].GetHashCode() == elem.GetHashCode())
                {
                    return evaluation1;
                }
                evaluation2 = elem;
                if (evaluation1.GetHashCode() > evaluation2.GetHashCode())
                {
                    evaluation1 = evaluation2;
                }



            }
            return evaluation1;


        }

        //To Do: sorts the array list
        public  void sort()
        {
            T[] newlist = new T[100];
            int originalnext = next;
            int elemIndex = 0;
            for (int i = 0; i < originalnext; i++)
            {
                T minimum = min();
                
                    newlist[elemIndex] = minimum;
                    remove(ref minimum);
                    elemIndex++;
            }
            
            
            list = newlist;
            next = originalnext;
        }


        //non required helper method
        public int find(ref T item)
        {
            if (next == 0)
            {
            }
            else
            {
                //find value, if it exists
                for (int i = 0; i < next; i++)
                {
                    if (item.Equals(list[i]))
                    {
                        return i;
                        
                    }
                }
            }
            return next;
        }

    }
}