using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7.list
{
    public class SinglyLinkedList<T>
    {
        public Node Head { get; private set; }

        public void AddAfterFirst(int data)
        {
            if (this.IsEmpty())
            {
                Head = new Node { Data = data };
                return;
            }

            Node newNode = new Node { Data = data };

            newNode.Next = Head.Next;

            Head.Next = newNode;
        }

        public void Print()
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public IEnumerable<int> ToEnumerable()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public string FindHigherElement(int key)
        {
            if (this.IsEmpty())
            {
                return "List is empty";
            }

            var current = Head;
            while (current.Data <= key)
            {
                if (current.Next == null)
                {
                    return "Couldn't find a bigger elemnt";
                }
                current = current.Next;
            }

            return current.Data.ToString();
        }

        public string FindSum(int value)
        {
            int sum = 0;
            int count = 0;

            if (this.IsEmpty())
            {
                return "List is empty";
            }
            
            var current = Head;
            while (current.Next != null)
            {
                if (current.Data < value)
                {
                    sum += current.Data;
                    count++;
                }
                current = current.Next;
            }
            if (count == 0)
            {
                return "No elements smaller than the key";
            }

            return sum.ToString();
        }
        public SinglyLinkedList<int> CreateNewList(int value, out string message)
        {
            var newList = new SinglyLinkedList<int>();
            

            var current = Head;
            
            while (current != null)
            {
                if (current.Data < value)
                {
                    newList.AddAfterFirst(current.Data);
                }

                current = current.Next;
            }
            if (this.IsEmpty())
            {
                message = "List is empty";
            }
            else if (newList.IsEmpty())
            {
                message = "Couldn't create new list";
            }
            else
            {
                message = "success";
            }
            return newList;
        }
        public string DeleteAfterMax()
        {
            if (this.IsEmpty())
                return "List is empty";
            else if (Head.Next == null)
                return "List only has 1 element";

            FindMaxNode().Next = null;
            if (this.IsEmpty())
            {
                return "Max element was the first";
            }

            return "Succes";
        }

        private Node FindMaxNode()
        {
            var current = Head;
            var maxNode = Head;

            while (current != null)
            {
                if (current.Data > maxNode.Data)
                {
                    maxNode = current;
                }

                current = current.Next;
            }

            return maxNode;
        }
        private bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }
            return false;
        }
    }
}
