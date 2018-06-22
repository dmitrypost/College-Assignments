using System;
using System.Windows.Forms;
namespace ArrayListNamespace
{

    public class OrderedLinkedList 
    {
        public string value;
        public OrderedLinkedList next;
        

        public OrderedLinkedList(int newObj)
        {
            value = Convert.ToString(newObj);
          
        }

        public OrderedLinkedList(double newObj)
        {
            value = Convert.ToString(newObj);
           
        }

        public OrderedLinkedList(string newObj)
        {
            value = newObj;
 
        }


        public void insert(OrderedLinkedList insertedObj)
        {
            //if compareto returns  1 than it comes     after this
            //if compareto returns  0 than it equals    this
            //if compareto returns -1 than it comes     before this
            OrderedLinkedList eval = this;
           
            
    evaluate:
            if (String.Compare(eval.value, insertedObj.value) == -1)
                goto comesAfter;
            else if (String.Compare(eval.value, insertedObj.value) == 1)
                goto comesBefore;
            else
                goto equals;


    comesAfter:
    //MessageBox.Show(insertedObj.value + " comes after " + eval.value);
    if (eval.next == null)
    {
        eval.next = insertedObj; //put this after eval
        return;
    }
    else
    {
        eval = eval.next;
        goto evaluate;
    }

    comesBefore:
    //MessageBox.Show(insertedObj.value + " comes before " + eval.value);
    //print();
    //Console.WriteLine("swapping...");
    swap(eval, insertedObj);
    

    equals:

            return;
            
        }

        private void swap(OrderedLinkedList obj1, OrderedLinkedList obj2)
        {
            if (obj1.Equals(this)) 
            {
                if (obj1.next != null) //if cat has a next
                {
                    OrderedLinkedList temp = new OrderedLinkedList(this.value);
                    this.value = obj2.value;
                    OrderedLinkedList temp2 = this.next;
                    this.next = temp;
                    temp.next = temp2;
                }
                else //no next
                {
                    OrderedLinkedList temp = new OrderedLinkedList(this.value);
                    this.value = obj2.value;
                    this.next = obj2;

                }
            }
            else
            {
                OrderedLinkedList temp = new OrderedLinkedList(obj1.value);
                obj1.value = obj2.value;
                temp.next = obj1.next;
                obj1.next = temp;

            }
           
        }

        public void remove(OrderedLinkedList objToRemove)
        {
            OrderedLinkedList eval = this;
            do
            {
                if (eval.next == null)
                    return; //can't do anything since not found the one that does match the one to be removed.
                eval = eval.next;
            } while (eval.Equals(objToRemove) == false);


           if (eval.Equals(objToRemove))
           {
               //need to know whom points to me...(this instance)
               //   or can overwrite my value with the next and remove the next.
               if (eval.next == null)
                   eval = null; //get rid of this... 
               else
               {
                   eval.value = eval.next.value;
                   eval.next = eval.next.next;

               }
           }

        }

        public void print()
        {
            OrderedLinkedList eval = this;
            do
            {
                Console.WriteLine(eval.value); 
                eval = eval.next; //change to next spot..
                   
            } while (eval != null);

        }


        private int CompareTo(OrderedLinkedList comparison1, OrderedLinkedList comparison2) 
        {
            
            return String.Compare(comparison1.value, comparison2.value);
        }

        private bool Equals(OrderedLinkedList comparedTo)
        {
            return String.Equals(this.value, comparedTo.value);
        }
    }
}
