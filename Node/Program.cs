using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Node
    {
        protected Node m_next;

        public Node(Node next)
        {
            m_next = next;
        }
    }
    internal sealed class Node<T> : Node
    {
        public T m_date;

        public Node(T data) : this(data, null)
        {

        }
        public Node(T data, Node next) : base(next)
        {
            m_date = data;
        }
        public override string ToString()
        {
            return m_date.ToString() +
                ((m_next != null) ? m_next.ToString() : null);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node<char>('.');
            head = new Node<DateTime>(DateTime.Now, head);
            head = new Node<string>("Today is ", head);
            Console.WriteLine(head.ToString());
        }
    }
}
