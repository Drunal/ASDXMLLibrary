using AsdXMLLibrary.Base;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects.Message
{
    public class S3000LSupportingContent : SerializeBase
    {
        public MultipleValues<Organization> Organizations { get; set; }


        public S3000LSupportingContent()
        {
            Organizations = new MultipleValues<Organization>();
        }

        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement supportItems = new XElement(ns + elementName);
            XElement organizations = new XElement(ns + Constants.OrganizationsContainerElementName);
            organizations.Add(Organizations.CreateXML(Constants.OrganizationElementName, ns));
            supportItems.Add(organizations);

            return supportItems;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;

            Organizations.ReadfromXML(element.Element(ns + Constants.OrganizationsContainerElementName).Elements(ns + Constants.OrganizationElementName), ns);

            return true;
        }
    }
}
