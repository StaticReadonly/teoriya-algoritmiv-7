using Classes;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = { 100, 1000, 5000, 10000, 20000 };

            foreach (int size in sizes)
            {
                int[] array = GenerateRandomArray(size);
                int key = array[new Random().Next(size)];

                DateTime startTime = DateTime.Now;
                int comparisons;
                int result = Algorithm.BinarySearchArray(array, key, out comparisons);
                DateTime endTime = DateTime.Now;
                TimeSpan executionTime = endTime - startTime;

                Console.WriteLine($"Array size: {size}, Time: {executionTime.TotalMilliseconds} ms, Comparisons: {comparisons}");
            }

            foreach (int size in sizes)
            {
                DoublyLinkedList list = GenerateRandomDoublyLinkedList(size);
                int key = new Random().Next(1000); 

                DateTime startTime = DateTime.Now;
                int comparisons;
                DoublyLinkedListNode result = Algorithm.BinarySearchDoublyLinkedList(list, key, out comparisons);
                DateTime endTime = DateTime.Now;
                TimeSpan executionTime = endTime - startTime;

                Console.WriteLine($"List size: {size}, Time: {executionTime.TotalMilliseconds} ms, Comparisons: {comparisons}");
            }
        }

        public static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1000);
            }

            Array.Sort(array);
            return array;
        }

        public static DoublyLinkedList GenerateRandomDoublyLinkedList(int size)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                list.AddLast(rand.Next(1000)); 
            }

            return DoublyLinkedList.SortDoublyLinkedList(list);
        }


    }
    
}
