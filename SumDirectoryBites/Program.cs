using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SumDirectoryBites
{
    class Program
    {
        private static long DirectoryBytes(string path, string searchPattern, SearchOption searchOption)
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);

            long maseterTotal = 0;
            ParallelLoopResult result = Parallel.ForEach<string, long>(files,
                () => 0,
                (file, loopState, index, taskLocalTotal) =>
                {
                    long fileLength = 0;
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenRead(file);
                        fileLength = fs.Length;
                    }
                    catch (IOException) { }
                    finally { if (fs != null) fs.Dispose(); }
                    return taskLocalTotal + fileLength;
                },
            taskLocalTotal => { Interlocked.Add(ref maseterTotal, taskLocalTotal);
            });
            return maseterTotal;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
