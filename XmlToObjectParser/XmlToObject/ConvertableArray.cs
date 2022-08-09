using System;
using System.Xml.Linq;

namespace XmlToObjectParser.XmlToObject
{
    public class ConvertableArray
    {
        public string? ElementName { get; }

        public object InstanceMapping { get; }
            
        public ConvertableArray(object instanceMapping)
        {
            InstanceMapping = instanceMapping;
        }

        public ConvertableArray(string xAttributeName, object instanceMapping)
        {
            InstanceMapping = instanceMapping;
            ElementName = xAttributeName;
        }
    }
}