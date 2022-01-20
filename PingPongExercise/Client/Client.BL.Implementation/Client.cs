using Client.BL.Abstraction.IO;

namespace Client.BL
{
    public class Client
    {
        protected ClientSocketBase ClientSocket;
        protected IWriter<string> Writer;
        protected IReader<string> Reader;

        public Client (ClientSocketBase socket, IWriter<string> writer, IReader<string> reader)
	    {
            ClientSocket = socket;
            Writer = writer;
            Reader = reader;
	    }


    }
}
