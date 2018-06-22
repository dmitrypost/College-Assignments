using System;

namespace LinkedListADTNamespace
{
    public interface LinkedListADT<T>
    {
        //insert() method places one item in the list
        void insert(ref T item);
        //remove() method removes first instance of item in list
        void remove(ref T item);
        //print() method prints all items in list
        void print();
    }
}