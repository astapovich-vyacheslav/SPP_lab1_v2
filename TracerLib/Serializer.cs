using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace TracerLib
{
    public class Serializer
    {
        public string XmlSerialization(OutputData obj)
        {
            var aSerializer = new XmlSerializer(typeof(OutputData));
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            aSerializer.Serialize(sw, obj); // pass an instance of A
            return sw.GetStringBuilder().ToString();
        }
        public string JsonSerialization(OutputData obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
