using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace lab7.list
{

    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private const string empty = "Список порожній";
        private int countIndex = 0;
        public Node Head { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= countIndex) 
                { 
                    throw new IndexOutOfRangeException(); 
                }

                Node current = Head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Data;
            }
        }

        public void AddAfterFirst(int data)
        {
            if (this.IsEmpty())
            {
                Head = new Node { Data = data };
                this.countIndex++;
                return;
            }

            Node newNode = new Node { Data = data };

            newNode.Next = Head.Next;

            Head.Next = newNode;
            this.countIndex++;
        }

        public string Print()
        {
            if (this.IsEmpty())
            {
                return empty;
            }
            string output = string.Empty;
            Node current = Head;
            while (current != null)
            {
                output += current.Data.ToString() + " -> ";
                current = current.Next;
            }
            output += "null";

            return output;
        }

        public string FindHigherElement(int key)
        {
            if (this.IsEmpty())
            {
                return empty;
            }

            var current = Head;
            while (current.Data <= key)
            {
                if (current.Next == null)
                {
                    return "В списку немає елемента більшого за заданий";
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
                return empty;
            }
            
            var current = Head;
            while (current != null)
            {
                if (current.Data < value)
                {
                    sum = sum + current.Data;
                    count++;
                }
                current = current.Next;
            }
            if (count == 0)
            {
                return "Немає елементів менших за заданий";
            }

            return sum.ToString();
        }
        public SinglyLinkedList<int> CreateNewList(int value, out string message)
        {
            var newList = new SinglyLinkedList<int>();
            

            var current = Head;
            
            while (current != null)
            {
                if (current.Data > value)
                {
                    newList.AddAfterFirst(current.Data);
                }

                current = current.Next;
            }
            if (this.IsEmpty())
            {
                message = empty;
            }
            else if (newList.IsEmpty())
            {
                message = "Не вдалося створити новий список за таким критерієм";
            }
            else
            {
                message = "Успішно";
            }
            return newList;
        }

        public string DeleteAfterMax()
        {
            if (this.IsEmpty())
                return empty;
            else if (Head.Next == null)
                return $"Список має лише 1 елемент ({Head.Data})";

            FindMaxNode().Next = null;
           
            return "Успішно";
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

        public IEnumerator<T> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return (T)(object)current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
