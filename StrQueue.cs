using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrQueues
{
    class StrQueue
    {
        private readonly int maxsize = 11; // maximum size of the queue
        private string[] store;
        private int head = 0; // this is so that the queue doesn't think its always empty
        private int tail = 0;
        private int numItems;

        public StrQueue()// constructor with set size of queue
        {
            store = new string [maxsize];
        }

        public StrQueue(int size)// constructor with users desired size of queue
        {
            maxsize = size+1;
            store = new string [maxsize];
        }

        public void Enqueue(string value)//adds item to queue
        {
            numItems++;
            store[tail] = value;
            if (++tail == maxsize) // if tail meets the max size
            {
                tail = 0;//reset the tail to the beginning of the queue
            }

        }
        public string Dequeue()//removes item from queue
        {
            string headItem;
            numItems--;
            headItem = store[head];

            if (++head == maxsize)//if head meets the max size
            {
                head = 0; //reset head to the beginning of queue
            }
            return headItem;
        }
        public string Peek()// shows the first item of the queue
        {
            return store[head];
        }

        public bool IsEmpty()//shows if queue is empty
        {
            return head == -1;
        }

        public bool IsFull()//shows if queue is full
        {
            return ((head == 0 && tail == maxsize - 1) || (tail == (head - 1) % (maxsize - 1)));
        }

        public int NumOfItems()//shows number of items in the queue
        {
            return numItems;
        }

        public void printqueue()//prints all items in the queue
        {
            if (tail == head)// if stack is empty
            {
                Console.Write("Queue is Empty");
                return;
            }
            else if (tail >= head)// if tail is greater than head
            {
                for (int i = head; i < tail; i++) // for head to tail
                {
                    Console.Write(store[i]);//print each item out
                    Console.Write("|");
                }
                Console.Write("\n");
            }
            else
            {
                for (int i = head; i < maxsize; i++)// loops between the head and the max size of the queue first
                {
                    Console.Write(store[i]);
                    Console.Write("|");
                }

                // 0th index till tail position printed out
                for (int i = 0; i <= tail - 1; i++)
                {
                    Console.Write(store[i]);
                    Console.Write("|");
                }
            }

        }

        public void reverse(int k)//reverse queue
        {
            if (k <= 0)//returns nothing if queue is empty
            {
                return;
            }
            if (numItems == 0 || numItems == 1)//returns nothing if queue has one item
            {
                return;
            }
            int n = numItems; // amount of items in the queue
            Stack<string> stack = new Stack<string>();// creates a stack to push items in
            for (int i = 0; i < k; i++)// from the first item to k item in queue
            {
                stack.Push(Peek());//push the item from queue into the stack
                Dequeue();//dequeue so that it isn't in the list
            }
            while (stack.Count > 0)//whilst stack isn't empty
            {
                Enqueue(stack.Pop());//enqueue the top item of the stack into the queue, this will send the items in reverse order to the end
            }
            for (int i = 1; i <= n - k; i++)//between k and the end of the queue
            {
                Enqueue(Peek());//add the item to the back of the queue
                Dequeue();// dequeue it 
            }
            printqueue();

        }
    }

}
