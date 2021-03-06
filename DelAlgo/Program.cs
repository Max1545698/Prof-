﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DelAlgo
{
    internal sealed class Light
    {
        public string SwitchPosition()
        {
            return "The light is off";
        }
    }

    internal sealed class Fan
    {
        public string Speed()
        {
            throw new InvalidOperationException("The fan broke due to overheating");
        }
    }
    internal sealed class Speaker
    {
        public string Volume()
        {
            return "The volume is loud";
        }
    }
    public sealed class Program
    {
        private delegate string GetStatus();

        static void Main(string[] args)
        {
            Func<double, double> a = null;

            a += Math.Sqrt;
            Console.WriteLine(a(256));

            GetStatus getStatus = null;

            getStatus += new GetStatus(new Light().SwitchPosition);
            getStatus += new GetStatus(new Fan().Speed);
            getStatus += new GetStatus(new Speaker().Volume);

            Console.WriteLine(GetComponentStatusReport(getStatus));
        }
        private static string GetComponentStatusReport(GetStatus status)
        {
            if (status == null) return null;

            StringBuilder report = new StringBuilder();

            Delegate[] arrayOfDelegates = status.GetInvocationList();

            foreach (GetStatus getStatus in arrayOfDelegates)
            {
                try
                {
                    report.AppendFormat($"{getStatus()}{Environment.NewLine}{Environment.NewLine}");
                }
                catch (InvalidOperationException e)
                {
                    object component = getStatus.Target;
                    report.AppendFormat(
                        "Failed to get status from{1}{2}{0} Error{3}{0}{0}",
                        Environment.NewLine,
                        ((component == null) ? "" : component.GetType() + "."),
                        getStatus.Method.Name,
                        e.Message);
                }
            }
            return report.ToString();

        }
    }
}
