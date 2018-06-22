using System;
using Wintellect.HostSDK;

namespace Sborka
{
    public sealed class AddIn_A : IAddIn
    {
        public AddIn_A()
        {

        }
        public string DoSomething(int x)
        {
            return "AddIn_A: " + x.ToString();
        }
    }
    public sealed class AddIn_B : IAddIn
    {
        public AddIn_B()
        {

        }
        public string DoSomething(int x)
        {
            return "AddIn_B: " + (x * 2).ToString();
        }
    }
}
