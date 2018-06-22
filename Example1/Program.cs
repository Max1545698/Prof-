using System;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
            }
        }
    }
}
