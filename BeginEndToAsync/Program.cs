using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginEndToAsync
{
    class Program
    {
        private static async void StartServer()
        {
            while (true)
            {
                var pipe = new NamedPipeServerStream("Name", PipeDirection.InOut, 1, PipeTransmissionMode.Message,
                    PipeOptions.Asynchronous | PipeOptions.WriteThrough);

                await Task.Factory.FromAsync(pipe.BeginWaitForConnection,
                    pipe.EndWaitForConnection, null);

            }
        }

        private static async Task<String> AwaitWebClient(Uri uri)
        {
            var wc = new System.Net.WebClient();

            var tcs = new TaskCompletionSource<string>();

            wc.DownloadStringCompleted += (s, e) =>
            {
                if (e.Cancelled) tcs.SetCanceled();
                else if (e.Error != null) tcs.SetException(e.Error);
                else tcs.SetResult(e.Result);
            };

            wc.DownloadStringAsync(uri);

            string result = await tcs.Task;

            return result;
        }
        static void Main(string[] args)
        {
        }
    }
}
