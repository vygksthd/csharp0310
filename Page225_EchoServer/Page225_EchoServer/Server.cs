using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Page225_EchoServer
{
    class ClientHadler
    {
        Socket socket = null;
        NetworkStream stream = null;
        StreamReader reader = null;
        StreamWriter writer = null;

        public ClientHadler(Socket socket)
        {
            this.socket = socket;
        }

        public void chat()
        {
            stream = new NetworkStream(socket);
            Encoding encode = Encoding.GetEncoding("utf-8");

            reader = new StreamReader(stream, encode);
            writer = new StreamWriter(stream, encode) { AutoFlush = true };

            while (true)
            {
                string str = reader.ReadLine();
                Console.WriteLine(str);

                writer.WriteLine(str);
            }
        }
    }

    class Server
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = null;
            Socket clientsocket = null;
            try
            {
                //IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                IPAddress ipAd = IPAddress.Parse("192.168.0.18");

                tcpListener = new TcpListener(ipAd, 5001);
                tcpListener.Start();

                while(true)
                {
                    clientsocket = tcpListener.AcceptSocket();

                    ClientHadler cHandler = new ClientHadler(clientsocket);
                    Thread t = new Thread(new ThreadStart(cHandler.chat));
                    t.Start();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                clientsocket.Close();
            }

        }
    }
}
