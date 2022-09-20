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
            Tracer tracer = new Tracer(nameof(test.FastPower), test.GetType().ToString());
            tracer.StartTrace();
            test.FastPower(2, 100000);
            tracer.StopTrace();
            TraceResult traceResult = tracer.GetTraceResult();
            sw.Stop();
            int threadTime = (int)sw.ElapsedTicks;
            ThreadInfo threadInfo = new ThreadInfo(Thread.CurrentThread.ManagedThreadId, threadTime);
            MethodInfo methodInfo = new MethodInfo(traceResult);
            threadInfo.AddMethodInfo(methodInfo);
            threadInfoList.Add(threadInfo);
            //Console.WriteLine($"{traceResult.ClassName} {traceResult.MethodName} {traceResult.Time}");
            traceResult.PrintResult();
        }
        public static void ThreadTest2()
        {

        }
        public static void ThreadTest3()
        {

        }
        public static void Main(string[] args)
        {
            
            //------------------------------------
            Thread thread1 = new Thread(ThreadTest1);
            Thread thread2 = new Thread(ThreadTest2);
            Thread thread3 = new Thread(ThreadTest3);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            //------------------------------------
            Console.WriteLine(threadInfoList.ToString());
            //OutputData outputData = new OutputData(threadInfoList);
            Serializer serializer = new Serializer();
            OutputData outputData = new OutputData();
            outputData.threadInfo = threadInfoList;
            Console.WriteLine(serializer.XmlSerialization(outputData));
            Console.WriteLine(serializer.JsonSerialization(outputData));
        }
    }
}