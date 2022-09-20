using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib
{
    public class ThreadInfo
    {
        public int ThreadId { get; set; }
        public int Time { get; set; }

        public List<MethodInfo> Methods { get; set; }

        public ThreadInfo(int id, int time)
        {
            ThreadId = id;
            Time = time;
            Methods = new List<MethodInfo>();
        }
        public void AddMethodInfo(MethodInfo methodInfo)
        {
            Methods.Add(methodInfo);
        }
    }
}
