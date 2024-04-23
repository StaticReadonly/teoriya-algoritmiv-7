using System;

namespace Classes
{

    public class Algorithm
    {
        public static int BinarySearchArray(int[] array, int key, out int comparisons)
        {
            int left = 0;
            int right = array.Length - 1;
            comparisons = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                comparisons++;

                if (array[mid] == key)
                    return mid;

                if (array[mid] < key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public static DoublyLinkedListNode BinarySearchDoublyLinkedList(DoublyLinkedList list, int key, out int comparisons)
        {
            comparisons = 0;
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                DoublyLinkedListNode midNode = GetNodeAtIndex(list, mid);
                comparisons++;

                if (midNode.Value == key)
                {
                    return midNode;
                }
                else if (midNode.Value < key)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }

        public static DoublyLinkedListNode GetNodeAtIndex(DoublyLinkedList list, int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            DoublyLinkedListNode current = list.Head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }
    }

    public class DoublyLinkedListNode
    {
        public int Value { get; set; }
        public int Index { get; set; }
        public DoublyLinkedListNode Previous { get; set; }
        public DoublyLinkedListNode Next { get; set; }

        public DoublyLinkedListNode(int value, int index)
        {
            Value = value;
            Index = index;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedListNode Head { get; private set; }
        public DoublyLinkedListNode Tail { get; private set; }
        public int Count { get; private set; }

        public void AddLast(int value)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(value, Count);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }
    }
}

