using System.Linq;
using System.Xml.Linq;

namespace XmlToObjectParser.XmlToObject
{
    public class ConvertableAttribute
    {
        public string? AttributeName { get; }

        public ConvertableAttribute()
        {
        }

        public ConvertableAttribute(string xAttributeName)
        {
            AttributeName = xAttributeName;
        }

        public ProcessResult<string> Convert(XElement parent, string propertyName)
        {
            var usedName = !string.IsNullOrEmpty(AttributeName) ? AttributeName : propertyName;
            var attribute = parent.Attributes().FirstOrDefault(attribute => attribute.Name.LocalName == usedName);
            
            return attribute != null 
                ? new ProcessResult<string>(attribute.Value) 
                : new ProcessResult<string>();
        }

        // public Func<XAttribute, string> ConvertAction { get; } = (element) => element.Value;
    }
}