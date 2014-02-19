using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketServer;

namespace ServerReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            ListenForEntities lf = new ListenForEntities(13000);
            lf.StartListening();
            Console.ReadLine();
        }
    }
}
