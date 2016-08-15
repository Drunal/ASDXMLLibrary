using System.Xml.Linq;

namespace AsdXMLLibrary.Base.Classifications
{
    public static class ClassificationExtensionMethods
    {
        public static XElement CreateXMLWithAdditionalLevel(this Classification classification, string containerElement, string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement ele = new XElement(ns + containerElement);
            XElement sub = classification.CreateXML(elementName, ns, forceElement);
            if (sub == null)
                return null;

            ele.Add(sub);
            return ele;            
        }

        public static bool ReadfromXMLWithAdditionalLevel(this Classification classification, XElement containerElement, string elementName, XNamespace ns)
        {
            if (containerElement == null)
                return false;
            return classification.ReadfromXML(containerElement.Element(ns + elementName), ns);
        }
    }
}
