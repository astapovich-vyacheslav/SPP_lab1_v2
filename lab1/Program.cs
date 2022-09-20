using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using TracerLib;

namespace lab1
{
    public class Program
    {
        public static void ThreadTest1()
        {

        }
        public static void ThreadTest2()
        {

        }
        public static void ThreadTest3()
        {

        }
        public static void Main(string[] args)
        {
            //Tracer tracer = new Tracer();
            Thread thread1 = new Thread(ThreadTest1);
            Thread thread2 = new Thread(ThreadTest2);
            Thread thread3 = new Thread(ThreadTest3);
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }
    }
}