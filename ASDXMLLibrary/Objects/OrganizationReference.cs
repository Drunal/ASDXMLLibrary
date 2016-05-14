using ASDXMLLibrary.Base;
using ASDXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace ASDXMLLibrary.Objects
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
