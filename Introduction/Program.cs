using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            PrincipalPermission jay = new PrincipalPermission("Jay", null);
            PrincipalPermission sue = new PrincipalPermission("Sue", null);

            PrincipalPermission jayAndSue = (PrincipalPermission)jay.Union(sue);
            Console.WriteLine(jay.IsSubsetOf(jayAndSue));
        }
    }
}
