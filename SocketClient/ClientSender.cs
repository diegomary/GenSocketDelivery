using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsContainer;
using System.Net.Sockets;
using GenericSocketHelper;

namespace SocketClient
{
    public class ClientSender
    {
        private int tcpport;
        public int TcpPort { get {return tcpport; } set{TcpPort=value;} }
        private string  server;
        public string Server { get { return server; } set { server = value; } }
        private object  entity;
        public object Entity { get { return entity; } set { entity = value; } }
        public ClientSender(int _tcpport,string _server,object _entity)
        {
            tcpport = _tcpport;
            server = _server;
            entity = _entity;      
        } 

      public void Connect()
        {            
            TcpClient client = new TcpClient(server, tcpport);
            ByteHelper bt = new ByteHelper();
            byte[] data = bt.GenericToByteArray<object>(entity);           
            NetworkStream stream = client.GetStream();           
            stream.Write(data, 0, data.Length);
            byte[] datareceived = new Byte[4096];
            int bytes = stream.Read(datareceived, 0, datareceived.Length);          
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(datareceived, 0, bytes));           
            stream.Close();
            client.Close();
        }

    }
}
