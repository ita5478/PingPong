using Client.BL.Core.Policy.Abstraction;
using Common.Abstractions.IO;
using System.Net;

namespace Client.BL.Core.Policy
{
    public class ClientRunner
    {
        protected IConverter<string, IPAddress> StringToIPConverter;
        protected IConnectionInitializer ConnectionInitializer;
        protected IClientAction ClientAction;

        public ClientRunner(
            IConnectionInitializer connectionInitializer,
            IClientAction clientAction,
            IConverter<string, IPAddress> stringToIPConverter)
        {
            ClientAction = clientAction;
            StringToIPConverter = stringToIPConverter;
            ConnectionInitializer = connectionInitializer;
        }

        public void Start(string ip, int port)
        {
            if (!ConnectionInitializer.Connect(StringToIPConverter.ConvertTo(ip), port))
            {
                return;
            }

            ClientAction.Execute();
        }
    }
}
