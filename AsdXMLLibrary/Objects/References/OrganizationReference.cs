using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects.References
{
    public class OrganizationReference : SerializeBase, IAmReference, IHaveValue
    {
        public Identifier<OrganizationIdentifierClassification> OrgId { get; set; }

        public OrganizationReference()
            : base()
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>();
        }

        public OrganizationReference(Organization org)
            : this()
        {
            OrgId = org.OrgId;
        }

        public bool HasValue
        {
            get { return OrgId != null && OrgId.HasValue; }
        }

        #region ISerialize Members

        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            return HasValue ? new XElement(ns + elementName, OrgId.CreateXML(Constants.OrganizationIdElementName, ns)) : null;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false; // TODO: throw an error here? no element was passed, so the expected element did not exist.

            return OrgId.ReadfromXML(element.Element(ns + Constants.OrganizationIdElementName), ns);
        }

        #endregion
    }
}
