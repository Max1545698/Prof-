using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContVarienty
{
    abstract class En { }
    class Engine : En { }
    interface IEngine<out T>
    {
        
    }
    public class Car<T> : IEngine<T>
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            IEngine<En> c = new Car<Engine>();
        }
    }
}
