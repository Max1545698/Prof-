

namespace ClassLibrary1
{
    public class Class1
    {
        int __declspec(dllexport) SampleMethod(int i)
        {
            return i * 10;
        }
    }
}
