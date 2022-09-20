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
        //public static Dictionary<ThreadInfo, List<MethodInfo>> outputDictionary = 
        //    new Dictionary<ThreadInfo, List<MethodInfo>>();
        public static List<ThreadInfo> threadInfoList = new List<ThreadInfo>();
        public static void ThreadTest1()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            TestMethods test = new TestMethods();
            Tracer tracer = new Tracer("FastPower", test.GetType().ToString());
            tracer.StartTrace();
            test.SlowPower(2, 100000);
            tracer.StopTrace();
            TraceResult traceResult = tracer.GetTraceResult();
            sw.Stop();
            int threadTime = (int)sw.ElapsedMilliseconds;
            ThreadInfo threadInfo = new ThreadInfo(Thread.CurrentThread.ManagedThreadId, threadTime);
            MethodInfo methodInfo = new MethodInfo(traceResult);
            threadInfo.AddMethodInfo(methodInfo);
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