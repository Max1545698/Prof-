using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate
{
    class Animal { }
    class Cat : Animal { }

    delegate T MyDelegate<out T>();
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate<Cat> delegateCat = () => new Cat();
            MyDelegate<Animal> my = delegateCat;
            Animal a = my.Invoke();
            Console.WriteLine(a.GetType().Name);
        }
    }
}
