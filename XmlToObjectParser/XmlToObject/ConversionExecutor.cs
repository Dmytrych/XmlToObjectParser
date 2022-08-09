// using System.Linq;
// using System.Reflection;
// using System.Xml.Linq;
// using Newtonsoft.Json.Linq;
//
// namespace XmlToObjectParser.XmlToObject
// {
//     public class ConversionExecutor
//     {
//         public void Execute(ConvertableObject convertableObject, XElement element)
//         {
//             var toReturn = ProcessObject(convertableObject.InstanceMapping, element);
//         }
//
//         private JObject ProcessObject(object convertedObject, XElement element)
//         {
//             var result = new JObject();
//             var props = convertedObject.GetType().GetProperties();
//
//             foreach (var prop in props)
//             {
//                 if (typeof(ConvertableObject).IsAssignableFrom(prop.PropertyType))
//                 {
//                     var innerProp = (ConvertableObject)prop.GetValue(convertedObject);
//
//                     var innerElement = element.Elements()
//                         .FirstOrDefault(e => e.Name.LocalName.ToLower() == prop.Name.ToLower());
//                     var conversionResult = innerProp.ConvertAction(innerElement);
//
//                     result.Add(prop.Name, ProcessObject(conversionResult, innerElement));
//                 }
//                 else if (typeof(ConvertableAttribute).IsAssignableFrom(prop.PropertyType))
//                 {
//                     var innerProp = (ConvertableAttribute)prop.GetValue(convertedObject);
//                     
//                     var innerAttribute = element.Attributes()
//                         .FirstOrDefault(e => e.Name.LocalName.ToLower() == prop.Name.ToLower());
//                     result.Add(prop.Name, innerProp.ConvertAction(innerAttribute));
//                 }
//             }
//
//             return result;
//         }
//     }
// }