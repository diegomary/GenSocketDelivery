using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketClient;
using ModelsContainer;

namespace ClientEntitySender
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientSender css = new ClientSender(13000, "127.0.0.1", new person());
            css.Connect();
            css.Connect();
            css.Connect();
            css.Connect();
            Console.ReadLine();

        }
    }
}
