using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagsSample
{
    [Flags,Serializable]
    public enum FileAttributes
    {
        ReadOnly = 0x0001,
        Hidden = 0x0002,
        System = 0x0004,
        Directory = 0x0010,
        Archive = 0x0020,
        Device = 0x0040,
        Normal = 0x0080,
        Temprorary = 0x0100,
        SparseFile = 0x0200,
        ReparsePoint = 0x0400,
        Compressed = 0x0800,
        Offline = 0x1000,
        NotContentIndexed = 0x2000,
        Encrypted = 0x4000
    }

    internal static class FileAttributesExtensionMethods
    {
        public static bool IsSet(this FileAttributes flags, FileAttributes flagToTest)
        {
            if (flagToTest == 0)
            {
                throw new ArgumentOutOfRangeException("flagToTest", "Value must not be 0");
            }
            return (flags & flagToTest) == flagToTest;
        }
        public static bool IsClear(this FileAttributes flags, FileAttributes flagToTest)
        {
            if(flagToTest == 0)
            {
                throw new ArgumentOutOfRangeException("flagToTest", "Value must not be 0");
            }
            return !IsSet(flags, flagToTest);
        }
        public static bool AnyFlagsSet(this FileAttributes flags, FileAttributes testFlags)
        {
            return ((flags & testFlags) != 0);
        }

        public static FileAttributes Set(this FileAttributes flags, FileAttributes setFlags)
        {
            return flags | setFlags;
        }

        public static FileAttributes Clear(this FileAttributes flags, FileAttributes clearFlags)
        {
            return flags & ~clearFlags;
        }

        public static void ForEach(this FileAttributes flags, Action<FileAttributes> processFlag)
        {
            if(processFlag == null)
            {
                throw new ArgumentNullException("processFlag");
            }
            for (uint bit = 1; bit != 0; bit <<= 1)
            {
                uint temp = ((uint)flags) & bit;

                if(temp != 0)
                {
                    processFlag((FileAttributes)temp);
                }
            }
        }
        public static int Count(this FileAttributes flags)
        {
            if(flags == 0)
            {
                throw new ArgumentNullException("flags");
            }
            int count = 0;
            for (int i = 1; i != 0; i <<= 1)
            {
                int temp = ((int)flags) & i;
                
                if(temp != 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileAttributes fa = FileAttributes.System;
            fa = fa.Set(FileAttributes.ReadOnly);
            fa = fa.Clear(FileAttributes.System);
            FileAttributes ff = FileAttributes.System | FileAttributes.SparseFile |
                FileAttributes.Offline | FileAttributes.Normal;
            ff.ForEach(f => Console.WriteLine(f));
            Console.WriteLine(ff.Count());
        }
    }
}
