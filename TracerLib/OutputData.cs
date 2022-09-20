using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TracerLib
{
    [Serializable]
    [XmlRoot(ElementName = "OutputData")]
    public class OutputData
    {
        //public static Dictionary<ThreadInfo, List<MethodInfo>> ThreadInfos =
        //    new Dictionary<ThreadInfo,List<MethodInfo>>();
        [XmlArrayItem("Thread Info")]
        public List<ThreadInfo> threadInfo { get; set; }
        public OutputData() { }
    }
}
