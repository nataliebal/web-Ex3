using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;



namespace WebApplication1.Models
{
    class MyServer
    {
       private DataModel data = DataModel.getInstance();
        TcpListener listener;
        static MyServer instance = null;
        private string serverIp ;
        private int serverPort;
        public  bool set;
        private MyServer()
        {
            set = false;
        }
        public string ServerIp { get { return serverIp; } set { ServerIp = value; } }
        public int Port { get { return serverPort; } set { serverPort = value; } }
        public static MyServer getInstance()
        {
            if (instance == null)
            {
                instance = new MyServer();
                return instance;
            }
            else return instance;
        }

        public void connect_server()
        {
            serverIp = data.Ip;
            Port = data.Port;
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(ServerIp);
            listener = new TcpListener(localAdd, Port);
            Console.WriteLine("Listening...");
            listener.Start();
          
           // Console.ReadLine();
        }

        public void open(int sign)
        {
            while (true)
            {
                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //split the string by ,
                string[] words = System.Text.Encoding.Default.GetString(buffer).Split(',');
                data.Lon = Double.Parse(words[0]);
                data.Lat = Double.Parse(words[1]);
                set = true;
                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received : " + dataReceived);

                //---write back the text to the client---
                Console.WriteLine("Sending back : " + dataReceived);
                // nwStream.Write(buffer, 0, bytesRead);
                //client.Close();
                if (sign == 1)
                {
                    listener.Stop();
                    break;
                }
            }
            listener.Stop();
        }
    }
}






