using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAsyncFuncToFiniteStateMachine
{
    internal sealed class Type1 { }
    internal sealed class Type2 { }

    class Program
    {
        private static async Task<Type1> Method1Async() { return await Task.Run(() => new Type1()); }
        private static async Task<Type2> Method2Async() { return await Task.Run(() => new Type2()); }

        //private static async Task<string> MyMethodAsync(int argument)
        //{
        //    int local = argument;
        //    try
        //    {
        //        Type1 result1 = await Method1Async();
        //        for (int x = 0; x < 3; x++)
        //        {
        //            Type2 result2 = await Method2Async();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Catch");
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Finally");
        //    }
        //    return "Done";
        //}

        static void Main(string[] args)
        {
            Console.WriteLine(MyMethodAsync(1).Result);
        }

        [DebuggerStepThrough, AsyncStateMachine(typeof(StateMachine))]
        private static Task<string> MyMethodAsync(int argument)
        {
            StateMachine stateMachine = new StateMachine()
            {

                m_builder = AsyncTaskMethodBuilder<string>.Create(),

                m_state = 1,
                m_argument = argument
            };

            stateMachine.m_builder.Start(ref stateMachine);
            return stateMachine.m_builder.Task;
        }

        [CompilerGenerated, StructLayout(LayoutKind.Auto)]
        private struct StateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder<string> m_builder;
            public int m_state;

            public int m_argument, m_local, m_x;
            public Type1 m_resultType1;
            public Type2 m_resultType2;

            private TaskAwaiter<Type1> m_awaiterType1;
            private TaskAwaiter<Type2> m_awaiterType2;

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                
            }

            void IAsyncStateMachine.MoveNext()
            {
                string result = null;

                try
                {
                    bool executeFinally = true;
                    
                    if(m_state == 1)
                    {
                        m_local = m_argument;
                    }
                    try
                    {
                        TaskAwaiter<Type1> awaiterType1;
                        TaskAwaiter<Type2> awaiterType2;

                        switch (m_state)
                        {
                            case 1:
                                awaiterType1 = Method1Async().GetAwaiter();
                                if (awaiterType1.IsCompleted)
                                {
                                    m_state = 0;
                                    m_awaiterType1 = awaiterType1;

                                    m_builder.AwaitUnsafeOnCompleted(ref awaiterType1, ref this);

                                    executeFinally = false;
                                    return;
                                }
                                break;
                            case 0:
                                awaiterType1 = m_awaiterType1;
                                break;
                            case 2:
                                awaiterType2 = m_awaiterType2;
                                goto ForLoopEpilog;
                        }
                        m_resultType1 = awaiterType1.GetResult();

                        ForLoopProloge:
                        m_x = 0;
                        goto ForLoopBody;

                        ForLoopEpilog:
                        m_resultType2 = awaiterType2.GetResult();
                        m_x++;

                        ForLoopBody:
                        if (m_x < 3)
                        {
                            awaiterType2 = Method2Async().GetAwaiter();
                            if (!awaiterType2.IsCompleted)
                            {
                                m_state = 1;
                                m_builder.AwaitUnsafeOnCompleted(ref awaiterType2, ref this);
                                executeFinally = false;
                                return;
                            }

                            goto ForLoopEpilog;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Catch");
                    }
                    finally
                    {
                        if (executeFinally)
                        {
                            Console.WriteLine("Finally");
                        }
                    }
                    result = "Done";
                }
                catch(Exception exception)
                {
                    m_builder.SetException(exception);
                    return;
                }
                m_builder.SetResult(result);
            }
        }
    }
}