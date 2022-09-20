using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class TraceResult
    {
        public int Time { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }

        public TraceResult(int time, string methodName, string className)
        {
            Time = time;
            MethodName = methodName;
            ClassName = className;
        }
        public void PrintResult()
        {
            Console.WriteLine(Time);
            Console.WriteLine(MethodName);
            Console.WriteLine(ClassName);
        }
    }
}