using System;

namespace Linked_List_Cycles
{
    class Program
    {
        public class Node
        {
            public int Value
            {
                get;
                set;
            }
            public Node Next
            {
                get;
                set;
            }
        }
        public class LinkedList
        {
            private Node head;
            public void AddFirst(int value)
            {
                Node toAdd = new Node();
                toAdd.Value = value;
                toAdd.Next = head;
                head = toAdd;
            }
            public Node GetHead()
            {
                return head;
            }
        }
        

        static void Main(string[] args)
        {
            LinkedList List = new LinkedList();
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "end")
                {
                    break;
                }
                List.AddFirst(int.Parse(input));
            }
            Console.WriteLine(DetectCycleFastAndSlow(List.GetHead()));
        }
        static bool DetectCycleFastAndSlow(Node head)
        {
            Node slow = head;
            Node fast = head;

            while (fast != null && fast.Next != null)
            {

                slow = slow.Next;
                fast = fast.Next.Next;

                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
