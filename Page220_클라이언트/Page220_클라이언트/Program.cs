using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Page220_클라이언트
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient();
                client.Connect("localhost", 5001);
                NetworkStream stream = client.GetStream();

                Encoding encode = Encoding.GetEncoding("utf-8");
                StreamReader reader = new StreamReader(stream, encode);
                StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

                string dataToSend = Console.ReadLine();

                while(true)
                {
                    writer.WriteLine(dataToSend);
                    String str = reader.ReadLine();
                    Console.WriteLine(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                client.Close();
            }
        }
    }
}
