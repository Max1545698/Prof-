using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainSample
{
    class Program
    {
        private static void Marshalling()
        {
            // Получаем ссылку на домен, в котором исполняется вызывающий поток
            AppDomain adCallingThreadDomain = Thread.GetDomain();

            // Каждому домену присваивается значимое имя, облегчающее отладку
            // Получаем имя домена и выводим его 
            string callingDomainName = adCallingThreadDomain.FriendlyName;
            Console.WriteLine($"Default AppDomain's friendly name = {callingDomainName}");

            // Получаем и выводи сборку в домене, содержащем метод Main
            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine($"Main assembly = {exeAssembly}");

            AppDomain ad2 = null;

            //Пример №1. доступ к объектам другого домена приложений с продвижением по ссылке
            Console.WriteLine($"{Environment.NewLine}Demo #1");
            //Создаем  новый домен (с теми же параметрами защиты и конфигурирования)
            ad2 = AppDomain.CreateDomain("AD #2", null, null);
            MarshalByRefType mbrt = null;
            // Загружаем нашу сборку в новый домен, конструируем объект и продвигаем его обратно в наш домен 
            // (в дейсвительности мы получаем ссылку на представителя)
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "DomainSample.MarshalByRefType");

            Console.WriteLine($"Type={mbrt.GetType()}"); //CLR не верно определяет тип

            //Убеждаемся, что получили ссылку на объект представитель
            Console.WriteLine($"Is proxy={RemotingServices.IsTransparentProxy(mbrt)}");

            // Все выглядит так, как будто мы вызываем метод экземпляра
            // MarshalByRefType, но на самом деле мы вызываем метод типа
            // представителя. Именно представитель переносит поток в тот домен, 
            // в котором находится объект, и вызывает метод для реального объекта
            mbrt.DoSomething();
            //Выгружаем новый домен
            AppDomain.Unload(ad2);
            //mbrt ссылается на правильный объект-представитель;
            // объект-представитель ссылается на неправильный домен

            try
            {
                // Вызываем метод, определенный в типе представителя
                // Поскольку домен приложений неправильный, появляется исключения
                mbrt.DoSomething();
                Console.WriteLine("Successful call");
            }
            catch (AppDomainUnloadedException)
            {
                Console.WriteLine("Failed call");
            }

            Console.WriteLine($"{Environment.NewLine}Demo #2");
            ad2 = AppDomain.CreateDomain("AD #2", null, null);

            // Получили представителя
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "DomainSample.MarshalByRefType");

            // Метод возвращает копию возвращенного объекта
            // продвижение объекта происходит по значению, а не по ссылке
            MarshalByValType mbvt = mbrt.MethodWithReturn();

            //Убеждаемся что мы не получили ссылку на объект представитель
            Console.WriteLine($"Is proxy={RemotingServices.IsTransparentProxy(mbvt)}");

            Console.WriteLine($"Returned object created {mbvt.ToString()}");

            AppDomain.Unload(ad2);
            // mbrt ссылается на действительный объект
            // выгрузка домена не имеет никакого эффекта
            try
            {
                // исключение не генерируется
                Console.WriteLine($"Returned object created {mbvt.ToString()}");
                Console.WriteLine("Success call");
            }
            catch (AppDomainUnloadedException)
            {
                Console.WriteLine("Failed call");
            }

            Console.WriteLine($"{Environment.NewLine}Demo #3");

            ad2 = AppDomain.CreateDomain("AD #2", null, null);

            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "DomainSample.MarshalByRefType");

            NonMarsalableType nmt = mbrt.MethodArgAndReturn(callingDomainName);
        }

        static void Main(string[] args)
        {
            Marshalling();
        }
    }

    public sealed class MarshalByRefType : MarshalByRefObject
    {
        public MarshalByRefType()
        {
            Console.WriteLine($"{this.GetType()} ctor running in {Thread.GetDomain().FriendlyName}");
        }

        public void DoSomething()
        {
            Console.WriteLine($"Executing in {Thread.GetDomain().FriendlyName}");
        }

        public MarshalByValType MethodWithReturn()
        {
            Console.WriteLine($"Executing in {Thread.GetDomain().FriendlyName}");
            MarshalByValType t = new MarshalByValType();
            return t;
        }

        public NonMarsalableType MethodArgAndReturn(string callingDomainName)
        {
            Console.WriteLine($"Calling from '{callingDomainName}' to '{Thread.GetDomain().FriendlyName}'.");
            NonMarsalableType t = new NonMarsalableType();
            return t;
        }
    }

    [Serializable]
    public sealed class MarshalByValType
    {
        private DateTime m_creationTime = DateTime.Now;
        public MarshalByValType()
        {
            Console.WriteLine($"{this.GetType().ToString()} ctor running in {Thread.GetDomain().FriendlyName}, Created on{m_creationTime:D}");
        }

        public override string ToString()
        {
            return m_creationTime.ToLongDateString();
        }
    }
    //[Serializable]
    public sealed class NonMarsalableType
    {
        public NonMarsalableType()
        {
            Console.WriteLine($"Executing in {Thread.GetDomain().FriendlyName}");
        }
    }
}
