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
        public double Time;
        public string MethodName, ClassName;
        public Stopwatch stopwatch { get; set; }
        public Tracer(string methodName, string className)
        {
            MethodName = methodName;
            ClassName = className;
        }

        public Tracer() { }

        // вызывается в начале замеряемого метода
        public void StartTrace()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        // вызывается в конце замеряемого метода 
        public void StopTrace()
        {
            stopwatch.Stop();
            Time = stopwatch.ElapsedTicks;
        }

        // получить результаты измерений  
        public TraceResult GetTraceResult()
        {
            return new TraceResult(Time, MethodName, ClassName);
        }
    }
}