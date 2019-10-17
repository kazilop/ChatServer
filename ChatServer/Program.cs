using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {

            string ip = GetMyLocalIp();
            Thread t = new Thread(delegate ()
            {
               Server myserver = new Server(ip, 8888);
            });
            t.Start();

            Console.WriteLine("Server Started on ip {0} ...!", ip);

                        
        }


        static public string GetMyLocalIp()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }
    }


}
