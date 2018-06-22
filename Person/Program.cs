using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    internal class PersonBirthDay
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        protected PersonBirthDay(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public bool IsYearLeap()
        {
            return (Year % 4 == 0) ? true : false;
        }
    }

    internal sealed class Person : PersonBirthDay
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public Person(int day, int month, int year, string name, string phone)
            : base(day, month, year)
        {
            Name = name;
            Phone = phone;
        }

        public int DaysToBirthDate()
        {
            if(Month < DateTime.Now.Month)
            {
                return (int)(new DateTime(DateTime.Now.Year + 1, Month, Day) - DateTime.Now).TotalDays;
            }
            else if (Day < DateTime.Now.Day && Month <= DateTime.Now.Month)
            {
                return (int)(new DateTime(DateTime.Now.Year + 1, Month, Day) - DateTime.Now).TotalDays;
            }
            else
            {
                return (int)(new DateTime(DateTime.Now.Year, Month, Day) - DateTime.Now).TotalDays;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(5, 3, 1999, "Max", "0636229650");
            Console.WriteLine(p.DaysToBirthDate());
        }
    }
}
