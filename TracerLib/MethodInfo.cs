using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    internal class MethodInfo
    {
        public int Time { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public List<MethodInfo> InnerMethods { get; set; }

        public MethodInfo(int time, string name, string className)
        {
            Time = time;
            Name = name;
            ClassName = className;
            InnerMethods = new List<MethodInfo>();
        }
    }
}
