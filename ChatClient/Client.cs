using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
    class Client
    {
        private string clientIp = "127.0.0.1";
        private int port = 8888;

        public Client(string ip, int port)
        {
            try
            {
                TcpClient client = new TcpClient(clientIp, port);
                NetworkStream stream = client.GetStream();
                
            }

            catch (Exception e)
            {
                
            }
        }

        public string Send(string str)
        {
            try
            {
                TcpClient client = new TcpClient(clientIp, port);
                NetworkStream stream = client.GetStream();

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(str);
                stream.Write(data, 0, data.Length);

                data = new Byte[256];
                String response = String.Empty;
                
                Int32 bytes = stream.Read(data, 0, data.Length);
                response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                

                return response;
            }

            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public void SetClient(string ip, int port)
        {
            this.clientIp = ip;
            this.port = port;
        }

        
    }
}
