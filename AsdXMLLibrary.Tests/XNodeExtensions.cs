using System.Xml.Linq;
using System.Xml.XPath;

namespace AsdXMLLibrary.Tests
{
    public static class XNodeExtensions
    {
        public static XElement XPathSelectElement(this XNode context, string expression, string elementName, int position)
        {
            string finalExpression = string.Format("{0}/*[name() = '{1}' and position()={2}]", expression, elementName, position);
            return context.XPathSelectElement(finalExpression);
        }
    }
}
