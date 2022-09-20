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
        public static TestMethods test = new TestMethods();
        public static void JointAction(Action<int, int> method, string name)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Tracer tracer = new Tracer(name, test.GetType().ToString());
            tracer.StartTrace();
            method(2, 100000);
            tracer.StopTrace();
            TraceResult traceResult = tracer.GetTraceResult();
            sw.Stop();
            int threadTime = (int)sw.ElapsedTicks;
            ThreadInfo threadInfo = new ThreadInfo(Thread.CurrentThread.ManagedThreadId, threadTime);
            MethodInfo methodInfo = new MethodInfo(traceResult);
            threadInfo.AddMethodInfo(methodInfo);
            threadInfoList.Add(threadInfo);
            //traceResult.PrintResult();
        }
        public static void ThreadTest1()
        {
            JointAction(test.FastPower, nameof(test.FastPower));
        }
        public static void ThreadTest2()
        {
            JointAction(test.SlowPower, nameof(test.SlowPower));
        }
        public static void ThreadTest3()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Tracer tracer = new Tracer(nameof(test.ExternalMethod), test.GetType().ToString());
            tracer.StartTrace();
            MethodInfo methodResult = test.ExternalMethod();
            tracer.StopTrace();
            TraceResult traceResult = tracer.GetTraceResult();
            //add second method
            sw.Stop();
            int threadTime = (int)sw.ElapsedTicks;
            ThreadInfo threadInfo = new ThreadInfo(Thread.CurrentThread.ManagedThreadId, threadTime);
            MethodInfo methodInfo = new MethodInfo(traceResult);
            methodInfo.InnerMethods = methodResult.InnerMethods;
            threadInfo.AddMethodInfo(methodInfo);
            threadInfoList.Add(threadInfo);
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
            Serializer serializer = new Serializer();
            OutputData outputData = new OutputData();
            outputData.threadInfo = threadInfoList;
            Console.WriteLine(serializer.XmlSerialization(outputData));
            Console.WriteLine();
            Console.WriteLine(serializer.JsonSerialization(outputData));
        }
    }
}