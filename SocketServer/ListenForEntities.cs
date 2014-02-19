using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelsContainer;
using GenericSocketHelper;

namespace SocketServer
{
public class ListenForEntities
    {
        private IPAddress localAddr;
        private TcpListener server = null;
        private TcpClient client = null;
        private int tcpport;
        private Byte[] bytes = new Byte[20000];
        public String Prevlogdata { get; set; }
        public string Logdata { get; set; }
        private bool stopflag;
        public int TcpPort
        {
            get
            {
                return tcpport;
            }
            set
            {
                tcpport = value;
            }
        }
        public ListenForEntities(int _tcpport)
        {
            tcpport = _tcpport;
       
        }
        public void StopListening()
        {

            stopflag = true;
        }

        public void StartListening()
        {
            stopflag = false;
            Task t = Task.Factory.StartNew(() =>
            {
                localAddr = IPAddress.Parse("127.0.0.1");              
                server = new TcpListener(localAddr, tcpport);
                server.Start();
                Console.WriteLine("Listening for entities");
                while (!stopflag)
                {
                    client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    do
                    {
                        stream.Read(bytes, 0, bytes.Length);
                        using (ByteHelper bt = new ByteHelper())
                        {
                            object obj = bt.ByteArrayToGeneric<object>(bytes);
                            switch (obj.GetType().ToString())
                            {
                                case "ModelsContainer.person":
                                    person newpersonentity = (person)obj;                                  
                                    Logdata= string.Concat("......  Received an entity of type ...." , obj.GetType().ToString() , " " , newpersonentity.email);
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(Logdata);
                                    stream.Write(msg, 0, msg.Length);
                                    Console.WriteLine(Logdata);
                                    break;
                            }
                        }
                    }
                    while (stream.DataAvailable);
                   
                }
                client.Close();
                server.Stop();
            });
        }
    }
}
