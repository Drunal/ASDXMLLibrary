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

        private OrganizationReference _reference;

        public Organization()
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>();
            Name = new Descriptor();

        }

        [XmlIgnore]
        public OrganizationReference Reference
        {
            get
            {
                return (OrganizationReference) GetReference();
            }
        }

        public IAmReference GetReference()
        {
            if (_reference == null)
                _reference = new OrganizationReference();
            if (_reference.OrgId != this.OrgId)
                _reference.OrgId = this.OrgId;

            return _reference;
        }
    }
}
