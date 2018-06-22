using System;
using ArrayListNamespace;
using ArrayListADTNamespace;

namespace UnorderedArrayListNamespace
{
    public class UnorderedArrayList<T> : ArrayList<T>, ArrayListADT<T>
    {
        public UnorderedArrayList()
        {
        }

        public override void insert(ref T item)
        {
            list[next] = item;
            next++;
        }


        // to do: put last element into the spot where the element is removed at...
        new public void remove(ref T item)
        {
              //find value, if it exists
            foreach (T elem in list)
            {
                if (elem.GetHashCode() == item.GetHashCode())
                {
                    list[find(ref item)] =list[next -1];
                    next--;
                    break;
                }
            }
           

        }
    }
}