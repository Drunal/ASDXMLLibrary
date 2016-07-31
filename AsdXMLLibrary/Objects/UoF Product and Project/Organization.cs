using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    
    public class Organization : ICanBeReferenced
    {
        [XmlElement(ElementName = "orgId")]
        public Identifier<OrganizationIdentifierClassification> OrgId { get; set; }

        [XmlElement(ElementName="name",IsNullable=true)]
        public Descriptor Name { get; set; }

        public Organization()
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>();
            Name = new Descriptor();

        }
    }
}
