using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TracerLib
{
    public class Tracer : ITracer
    {
        public int Time;
        public string MethodName, ClassName;
        public Stopwatch stopwatch { get; set; }
        public Tracer(string methodName, string className)
        {
            MethodName = methodName;
            ClassName = className;
            stopwatch = new Stopwatch();
        }

        public Tracer()
        {
            stopwatch = new Stopwatch();
        }

        // вызывается в начале замеряемого метода
        public void StartTrace()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {
            stopwatch.Stop();
            Time = (int)stopwatch.ElapsedTicks;
        }

        // получить результаты измерений  
        public TraceResult GetTraceResult()
        {
            return new TraceResult(Time, MethodName, ClassName);
        }
    }
}