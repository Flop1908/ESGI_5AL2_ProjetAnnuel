using System;
using ConsoleApplicationTestWCF.HelloWebService;

namespace ConsoleApplicationTestWCF
{
    class Program
    {
        static void Main()
        {
            var rep = "";

            /*
            HelloWebService.ServiceHelloClient client = new HelloWebService.ServiceHelloClient();
            rep = client.SayHello("Joe");
            */

            //ProxyHelper.UsingProxyOf<ServiceHelloClient>(client => repAne = client.NewAnecdote());
            ProxyHelper.UsingProxyOf<ServiceHelloClient>(client => rep = client.);

            Console.WriteLine(rep);
            
            Console.WriteLine("FIN");

            Console.Read();
        }

    }
}
