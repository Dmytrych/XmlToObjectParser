using System.Xml.Linq;
using XmlToObjectParser.XmlToObject;

namespace XmlToObjectParser
{
    public static class Program
    {
        public static void Main()
        {
            var xml = XDocument.Parse(Xml);
            var layout = new TestLayout();
            var executor = new ConvertablesExecutor();

            var a = executor.ExecuteFromMapping(layout.Convert(), xml.Root);
        }

        private const string Xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                     <NodeCreation>
                                        <Node nodeName=""The name"" />
                                        <Node nodeName=""Next name"" />
                                     </NodeCreation>";
    }
}