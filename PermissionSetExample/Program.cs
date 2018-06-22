using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PermissionSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Assembly.GetExecutingAssembly().IsFullyTrusted);

            string pluginFolder = Path.Combine(@"C:\Users\PC\Source\repos\Prof\A\bin\Debug");
            string pluginInPath = Path.Combine(pluginFolder, "A.exe");

            //Создаем ограниченый набор разрешений для нашей сборки.
            //По меньшей мере ограничение должно включать права запуска 
            //и разрешение для подключаемого модуля на чтение собственной сборки
            //в противном случае подключаемый модуль не запустится
            PermissionSet ps = new PermissionSet(PermissionState.None);//запуск в песочнице
            ps.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            ps.AddPermission(new FileIOPermission(FileIOPermissionAccess.PathDiscovery |
                                                   FileIOPermissionAccess.Read, pluginInPath));
            ps.AddPermission(new UIPermission(PermissionState.Unrestricted)); //неограниченое разрешение 
                                                                               //на пользовательский интерфейс 
            AppDomainSetup setup = AppDomain.CurrentDomain.SetupInformation;
            AppDomain sanbox = AppDomain.CreateDomain("sbox", null, setup, ps);
            sanbox.ExecuteAssembly(pluginInPath);
            AppDomain.Unload(sanbox);
        }
    }

    
}
