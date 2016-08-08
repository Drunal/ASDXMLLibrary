using AsdXMLLibrary.Base;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects.Message
{
    public class S3000LSupportingContent : SerializeBase
    {
        public List<Organization> Organizations { get; set; }


        public S3000LSupportingContent()
        {
            Organizations = new List<Organization>();
        }

        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement supportItems = new XElement(ns + elementName);

            return supportItems;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;

            return true;
        }
    }
}
