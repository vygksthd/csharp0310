﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Page221_서버
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkStream stream = null;
            TcpListener tcpListener = null;
            Socket clientsocket = null;
            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                //IPAddress ipAd = IPAddress.Parse("192.168.0.18");
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                tcpListener = new TcpListener(ipAd, 5001);
                tcpListener.Start();

                clientsocket = tcpListener.AcceptSocket();

                stream = new NetworkStream(clientsocket);
                Encoding encode = Encoding.GetEncoding("utf-8");

                reader = new StreamReader(stream, encode);
                writer = new StreamWriter(stream, encode) { AutoFlush = true };

                while(true)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine(str);
                    writer.WriteLine(str);
                }
            }
            catch (Exception e)
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
