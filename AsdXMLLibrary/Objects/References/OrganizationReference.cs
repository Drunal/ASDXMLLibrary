using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class OrganizationReference : IAmReference, IHaveValue
    {
        [XmlElement(ElementName = "orgId")]
        public Identifier<OrganizationIdentifierClassification> OrgId { get; set; }

        public OrganizationReference()
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>();
        }

        public bool HasValue
        {
            get { return OrgId != null && OrgId.HasValue; }
        }
    }
}
