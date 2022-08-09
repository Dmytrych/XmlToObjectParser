using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using XmlToObjectParser.XmlToObject;

namespace XmlToObjectParser
{
    public class TestLayout
    {
        public object Convert()
        {
            return new
            {
                Nodes = new ConvertableArray("Node", new {
                    NodeName = new ConvertableAttribute("nodeName")
                })
            };
        }

        // private static ConvertableObject<JArray> TreatAsArray<TJsonElement>(string elementName, ConvertableObject<TJsonElement> parameter) where TJsonElement : JContainer
        // {
        //     return new ConvertableObject<JArray>((element, propName) =>
        //     {
        //         var matches = element.Elements().Where(property => property.Name.LocalName == elementName);
        //         var convertResult = new JArray();
        //         foreach (var match in matches)
        //         {
        //             convertResult.Add(parameter.ConvertAction(match, elementName));
        //         }
        //
        //         return convertResult;
        //     });
        // }
    }
}