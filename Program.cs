using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrQueues;

namespace Program
{
    class MainProg
    {
        static void Main(string[] args)
        {
            StrQueue myqueue = new StrQueue();// creates the queue
            bool end = false;
            while (end != true)//whilst the user hasn't ended the app
            {
                Console.WriteLine("Please enter what you'd like to do to the queue (in lower case)");
                Console.WriteLine("Number of items in your queue: " + myqueue.NumOfItems());
                Console.WriteLine("'add','remove','display','reverse' or 'end'");
                string choice = Console.ReadLine();
                if (choice == "add")
                {
                    if(myqueue.IsFull() == true)
                    {
                        Console.WriteLine("queue is full");
                    }
                    else
                    {
                        Console.WriteLine("type string: ");
                        string value = Console.ReadLine();
                        myqueue.Enqueue(value);//enqueue item
                    }                    
                }
                else if (choice == "remove")
                {
                    myqueue.Dequeue();//remove item
                }
                else if (choice == "display")
                {
                    myqueue.printqueue();//display
                }
                else if (choice == "reverse")
                {
                    myqueue.printqueue();
                    Console.WriteLine("select the position you want to move to the front, first item's position is 1 : ");
                    string value = Console.ReadLine();
                    int number;
                    bool parseSuccess = int.TryParse(value, out number);//boolean that tells you if the input is a number or something else
                    if (parseSuccess == true)// if it is a number
                    {
                        int num;
                        num = Int16.Parse(value);
                        myqueue.reverse(num);
                    }
                    else
                    {
                        Console.WriteLine("try again ");//throw error
                    }
                    
                }
                else if (choice == "end")//ends application
                {
                    end = true;
                    Console.WriteLine("Goodbye.");
                }
                else
                {
                    Console.WriteLine("wrong input, try again");
                }
            }



            Console.ReadKey();//end of code

        }


    }

}
