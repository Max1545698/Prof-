using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaslLoggerSample
{
    public static class TaskLogger
    {
        public enum TaskLogLevel { None, Pending }
        public static TaskLogLevel LogLevel { get; set; }

        public sealed class TaskLogEntry
        {
            public Task Task { get; internal set; }
            public string Tag { get; internal set; }
            public DateTime LogTime { get; internal set; }
            public string CallMemberName { get; internal set; }
            public string CallerFilePath { get; internal set; }
            public int CallerLineNumber { get; internal set; }
            public override string ToString()
            {
                return $"LogTime={LogTime}, Tag={Tag ?? "(none)"}," +
                    $" Member={CallMemberName}, File={CallerFilePath}({CallerLineNumber})";

            }
        }

        private static readonly ConcurrentDictionary<Task, TaskLogEntry> s_log =
            new ConcurrentDictionary<Task, TaskLogEntry>();

        public static IEnumerable<TaskLogEntry> GetLogEntries() { return s_log.Values; }

        public static Task<TResult> Log<TResult>(this Task<TResult> task,
            string tag = null,
            [CallerMemberName] string callerMemberName = null,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 1)
        {
            return (Task<TResult>)Log((Task)task, tag, callerMemberName, callerFilePath, callerLineNumber);
        }

        public static Task Log(this Task task, string tag = null,
            [CallerMemberName] string callerMemberName = null,
            [CallerFilePath] string callerFilePath = null,
            [CallerLineNumber] int callerLineNumber = 1)
        {
            if (LogLevel == TaskLogLevel.None) return task;
            var logEntry = new TaskLogEntry
            {
                Task = task,
                LogTime = DateTime.Now,
                Tag = tag,
                CallerFilePath = callerFilePath,
                CallerLineNumber = callerLineNumber,
                CallMemberName = callerMemberName
            };
            s_log[task] = logEntry;
            task.ContinueWith(t =>
            {
                TaskLogEntry entry;
                s_log.TryRemove(t, out entry);
            },
            TaskContinuationOptions.ExecuteSynchronously);
            return task;
        }
    }


    static class Program
    {
        static   void Main(string[] args)
        {
            Go();
        }

        public static async Task Go()
        {
#if DEBUG 
            TaskLogger.LogLevel = TaskLogger.TaskLogLevel.Pending;
#endif
            var tasks = new List<Task>
            {
                Task.Delay(2000).Log("2s op"),
                Task.Delay(5000).Log("5s op"),
                Task.Delay(6000).Log("6s op")
            };

            try
            {
                await Task.WhenAll(tasks).WithCancellation(new CancellationTokenSource(3000).Token);
            }
            catch (OperationCanceledException) { }
            foreach (var op in TaskLogger.GetLogEntries().OrderBy(tle => tle.LogTime))
            {
                Console.WriteLine(op);
            }
        }
        private struct Void { }
        private static async Task WithCancellation(this Task originalTask, CancellationToken ct)
        {
            var cancelTask = new TaskCompletionSource<Void>();

            using (ct.Register(t => ((TaskCompletionSource<Void>)t).TrySetResult(new Void()), cancelTask))
            {
                Task any = await Task.WhenAny(originalTask, cancelTask.Task);

                if (any == cancelTask.Task) ct.ThrowIfCancellationRequested();
            }
        }
    }
    public sealed class EventAwaiter<TEventArgs> : INotifyCompletion
    {
        private ConcurrentQueue<TEventArgs> m_events = new ConcurrentQueue<TEventArgs>();
        private Action m_continuation;
        #region
        public EventAwaiter<TEventArgs> GetAwaiter() { return this; }

        public bool IsCompleted { get { return m_events.Count > 0; } }

        public void OnCompleted(Action continuation)
        {
            Volatile.Write(ref m_continuation, continuation);
        }

        public TEventArgs GetResult()
        {
            TEventArgs e;
            m_events.TryDequeue(out e);
            return e;
        }
        #endregion

        public void EventRaised(object sender, TEventArgs eventArgs)
        {
            m_events.Enqueue(eventArgs);

            Interlocked.Exchange(ref m_continuation, null)?.Invoke();
        }

        private static async void ShowExceptions()
        {
            var eventAwaiter = new EventAwaiter<FirstChanceExceptionEventArgs>();
            AppDomain.CurrentDomain.FirstChanceException += eventAwaiter.EventRaised;

            while (true)
            {
                Console.WriteLine($"AppDomain exception: {(await eventAwaiter).Exception.GetType()}");
            }
        }

        public static void Go()
        {
            ShowExceptions();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0: throw new InvalidOperationException();
                        case 1: throw new ObjectDisposedException("");
                        case 2: throw new ArgumentOutOfRangeException();

                    }
                }
                catch { }
            }
        }
    }
}
