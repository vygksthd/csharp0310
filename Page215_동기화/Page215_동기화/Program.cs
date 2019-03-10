using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Page215_동기화
{
    public class ThreadTest
    {
        public string lockString = "Hello";
        private object obj = new object();
        public void Print(string rank)
        {
            Monitor.Enter(obj);
            {
                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        Thread.Sleep(100);
                        Console.Write(",");
                    }
                    Console.WriteLine("{0}{1}", rank, lockString);
                }
            }
            Monitor.Exit(obj);
        }
        public void FirstWork() { Print("F"); }
        public void SecondWork() { Print("S"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest t = new ThreadTest();
            Thread first = new Thread(new ThreadStart(t.FirstWork));
            Thread second = new Thread(new ThreadStart(t.SecondWork));

            first.Start();
            second.Start();
        }
    }
}
