using System;
using System.Threading;

namespace Page207_Thread_Auto
{
    class Program
    {
        bool sleep = false;

        static AutoResetEvent autoEvent = new AutoResetEvent(false);

        public void FirsWork()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("F{0}", i);
                if(i == 5)
                {
                    sleep = true;
                    Console.WriteLine("");
                    Console.WriteLine("first 쉼...");
                    autoEvent.WaitOne();
                }
            }
        }

        static void Main(string[] args)
        {
            Program t = new Program();
            Thread first = new Thread(new ThreadStart(t.FirsWork));
            first.Start();
            while (t.sleep == false) { }
            Console.WriteLine("first를 깨웁니다..2초후 깨어 납니다.");
            Thread.Sleep(2000);
            autoEvent.Set();
        }
    }
}
