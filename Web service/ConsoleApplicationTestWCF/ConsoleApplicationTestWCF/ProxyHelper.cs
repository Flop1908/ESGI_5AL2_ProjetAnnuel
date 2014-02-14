using System;
using System.ServiceModel;

namespace ConsoleApplicationTestWCF
{
    public static class ProxyHelper
    {
        public static void UsingProxyOf<TService>(Action<TService> action)
          where TService : ICommunicationObject, IDisposable, new()
        {
            var service = new TService();
            bool success = false;
            try
            {
                action(service);
                if (service.State != CommunicationState.Faulted)
                {
                    service.Close();
                    success = true;
                }
            }
            finally
            {
                if (!success)
                {
                    service.Abort();
                }
            }
        }
    }
}
