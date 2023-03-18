using System;

namespace project1
{
    public class Node<T>
    {
        public Node<T>? Next { get; set; }
        public T Data { get; set; }

        public Node(T data)
        { 
            this.Data = data;
            Next = null;
        }

    }

    public class List<T>
    {
        private Node<T>?head;
        private Node<T>?tail;

        public List()
        {
            head =tail= null;
        }
        public Node<T>? Head
        {
            get { return head; }
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (head == null)
            {
                head = tail= n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            Node<T>?p = head;
            while (p != null)
            {
                action(p.Data);
                p = p.Next;
            }
            
        }
    }
    class Test
    {
        static void Main(string[]args)
        {
            //创建double型list
            List<double> list = new List<double>();
            for(double i=1;i<=10;i++)
            {
                list.Add(i);
            }

            //打印链表
            Console.WriteLine("链表中的元素为:");
            list.ForEach(m => Console.Write(m +" ")) ;
            Console.WriteLine();

            //求最大值
            double max = Double.MinValue;
            Action<double> GetMax = (m =>
            {
                if (max < m) { max = m; }
            });
            list.ForEach(GetMax);
            Console.WriteLine("链表中最大值为:" + max);

            //求最小值
            double min = Double.MaxValue;
            Action<double> GetMin = (m =>
            {
                if (min > m) { min = m; }
            });
            list.ForEach(GetMin);
            Console.WriteLine("链表中最小值为:"+min);

            //求和
            double sum = 0;
            list.ForEach(i => sum += i);
            Console.WriteLine("链表中元素之和为:"+sum);
        }
    }
}