using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebResponseSample
{
    class Program
    {
        public static void ReadHtml()
        {
            WebRequest request = WebRequest.Create("https://www.microsoft.com/uk-ua/");
            request.Proxy = null;

            using (WebResponse res = request.GetResponse())
            using (Stream rs = res.GetResponseStream())
            using (FileStream fs = File.Create("code.html"))
                rs.CopyToAsync(fs);
        }

        public static async void ReadHtmlAsync()
        {
            WebRequest request = WebRequest.Create("https://www.microsoft.com/uk-ua/");
            request.Proxy = null;

            using (WebResponse res = await request.GetResponseAsync())
            using (Stream rs = res.GetResponseStream())
            using (FileStream fs = File.Create("code.html"))
                await rs.CopyToAsync(fs);

        }
        static void Main(string[] args)
        {
            ReadHtmlAsync();
        }
    }
}
