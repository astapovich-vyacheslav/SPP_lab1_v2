using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    [Serializable]
    public class MethodInfo
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int Time { get; set; }
        public List<MethodInfo> InnerMethods { get; set; }

        public MethodInfo(int time, string name, string className)
        {
            Time = time;
            Name = name;
            ClassName = className;
            InnerMethods = new List<MethodInfo>();
        }

        public MethodInfo(TraceResult traceResult)
        {
            Time = traceResult.Time;
            Name = traceResult.MethodName;
            ClassName = traceResult.ClassName;
        }
        public MethodInfo() { }
    }
}
