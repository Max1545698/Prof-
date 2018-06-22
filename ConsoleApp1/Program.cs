using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Element
    {
        public string name; public int age; public void M()
        {
            Console.WriteLine("sdasd");
        }
    }

    class Collection
    {
        public Element a;
        Element[] element = {
            new Element { name = "Vasa",age = 20},
            new Element { name = "Vas", age = 20 },
            new Element { name = "Vasas", age = 23 }
        };

       

        public IEnumerator GetEnumerator()
        {
            return element.GetEnumerator();
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Collection col = null;

            //foreach (Element item in col)
            //{
            //    Console.WriteLine(item.age+""+item.name);
            //}
           

          string a=  col?.a?.ToString();
           
            
        }
    }
}
