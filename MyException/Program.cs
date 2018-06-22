using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MyException
{
    [Serializable]
    public sealed class Exception<TExceptionArgs> : Exception, ISerializable
         where TExceptionArgs : ExceptionArgs
    {
        private const string c_args = "Args";

        public TExceptionArgs Args { get; }

        public Exception(string message = null, Exception innerException = null)
            : this(null, message, innerException) { }

        public Exception(TExceptionArgs args, string message = null, Exception innerException = null)
            : base(message, innerException) {
            Args = args;
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        private Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Args = (TExceptionArgs)info.GetValue(c_args, typeof(TExceptionArgs));
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(c_args, Args);
            base.GetObjectData(info, context);
        }

        public override string Message
        {
            get
            {
                string baseMsg = base.Message;
                return (Args == null) ? baseMsg : baseMsg + " (" + Args.Message + ")";
            }
        }

        public override bool Equals(object obj)
        {
            Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
            if (obj == null) return false;
            return Equals(Args, other) && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [Serializable]
    public abstract class ExceptionArgs
    {
        public virtual string Message { get { return string.Empty; } }
    }

    [Serializable]
    public sealed class DiskFullExceptionArgs : ExceptionArgs
    {
        public DiskFullExceptionArgs(string diskpath)
        {
            DiskPath = diskpath;
        }

        public string DiskPath { get; }

        public override string Message
        {
            get
            {
                return (DiskPath == null) ? base.Message : "DiskPath=" + DiskPath;
            }
        }
    }
    class Program
    {
        public static void TestException()
        {
            try
            {
                throw new Exception<DiskFullExceptionArgs>(
                    new DiskFullExceptionArgs(@"C:\"), "The disk is full");
            }
            catch(Exception<DiskFullExceptionArgs> e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            TestException();
        }
    }
}
