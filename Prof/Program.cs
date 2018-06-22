using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prof
{
    abstract class Citizen
    {

    }
    class Student : Citizen
    {

    }
    class Pensioner : Citizen
    {

    }
    class Worker : Citizen
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Collection collection = new Collection();
            Console.WriteLine(collection.Add(new Worker()));
            Console.WriteLine(collection.Add(new Pensioner()));
            Console.WriteLine(collection.Add(new Student()));
            Console.WriteLine(collection.Add(new Worker()));
            Console.WriteLine(collection.Add(new Pensioner()));
            Console.WriteLine(collection.Add(new Pensioner()));
            Console.WriteLine(collection.Add(new Student()));
            
            foreach(var item in collection)
            {
                Console.WriteLine(item.GetType());
            }
        }
    }
}
