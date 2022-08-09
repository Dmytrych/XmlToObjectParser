using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace XmlToObjectParser.XmlToObject
{
    public class ConvertablesExecutor
    {
        public JObject ExecuteFromMapping(object mapping, XElement element)
        {
            var result = new JObject();
            var props = mapping.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (typeof(ConvertableObject).IsAssignableFrom(prop.PropertyType))
                {
                    var innerProp = (ConvertableObject)prop.GetValue(mapping);

                    var innerElement = GetObjectToConvert(innerProp, prop.Name, element);
                    if (innerElement != null)
                    {
                        result.Add(prop.Name, ExecuteFromMapping(innerProp.InstanceMapping, innerElement));   
                    }
                }
                else if (typeof(ConvertableAttribute).IsAssignableFrom(prop.PropertyType))
                {
                    var innerProp = (ConvertableAttribute)prop.GetValue(mapping);

                    var innerAttribute = GetAttributeToConvert(innerProp, prop.Name, element);

                    if (innerAttribute != null)
                    {
                        result.Add(prop.Name, innerAttribute.Value);   
                    }
                }
                else if (typeof(ConvertableArray).IsAssignableFrom(prop.PropertyType))
                {
                    var innerProp = (ConvertableArray)prop.GetValue(mapping);

                    var innerArray = GetObjectsToConvert(innerProp, prop.Name, element);

                    var array = new JArray();
                    foreach (var arrayElement in innerArray)
                    {
                        array.Add(ExecuteFromMapping(innerProp.InstanceMapping, arrayElement));
                    }
                    
                    result.Add(prop.Name, array);
                }
            }

            return result;
        }

        private XElement? GetObjectToConvert(ConvertableObject convertableObject, string propName, XElement parent)
        {
            var usedName = !string.IsNullOrEmpty(convertableObject.ElementName) ? convertableObject.ElementName : propName;
            return parent.Elements().FirstOrDefault(element => element.Name.LocalName == usedName);
        }
        
        private IReadOnlyCollection<XElement> GetObjectsToConvert(ConvertableArray convertableArray, string propName, XElement parent)
        {
            var usedName = !string.IsNullOrEmpty(convertableArray.ElementName) ? convertableArray.ElementName : propName;
            return parent.Elements().Where(element => element.Name.LocalName == usedName).ToList();
        }
        
        private XAttribute? GetAttributeToConvert(ConvertableAttribute convertableAttribute, string propName, XElement parent)
        {
            var usedName = !string.IsNullOrEmpty(convertableAttribute.AttributeName) ? convertableAttribute.AttributeName : propName;
            return parent.Attributes().FirstOrDefault(attribute => attribute.Name.LocalName == usedName);
        }
    }
}