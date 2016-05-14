using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class OrganizationReference
    {
        [XmlElement(ElementName = "orgId")]
        public Identifier<OrganizationIdentifierClassification> OrgID { get; set; }

        public OrganizationReference()
        {
            OrgID = new Identifier<OrganizationIdentifierClassification>();
        }
    }
}
