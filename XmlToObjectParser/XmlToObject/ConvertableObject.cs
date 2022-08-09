using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace XmlToObjectParser.XmlToObject
{
    public class ConvertableObject
    {
        public string? ElementName { get; }

        public object InstanceMapping { get; }
            
        public ConvertableObject(object instanceMapping)
        {
            InstanceMapping = instanceMapping;
        }

        public ConvertableObject(string xAttributeName, object instanceMapping)
        {
            InstanceMapping = instanceMapping;
            ElementName = xAttributeName;
        }
        
        // public ProcessResult<JObject> Convert(XElement parent, string propertyName, ConvertablesExecutor executor)
        // {
        //     var usedName = !string.IsNullOrEmpty(ElementName) ? ElementName : propertyName;
        //     var element = parent.Elements().FirstOrDefault(element => element.Name.LocalName == usedName);
        //
        //     if (element == null)
        //     {
        //         return new ProcessResult<JObject>();
        //     }
        //     
        //     var result = executor.ExecuteFromMapping(InstanceMapping, element);
        //     return new ProcessResult<JObject>(result);
        // }
    }
}