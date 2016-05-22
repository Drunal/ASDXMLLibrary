using AsdXMLLibrary.Base;
using AsdXMLLibrary.Objects.References;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    
    public class Organization : OrganizationReference
    {
        [XmlElement(ElementName="name",IsNullable=true)]
        public Descriptor Name { get; set; }

        private OrganizationReference _reference;

        public Organization()
            : base()
        {
            Name = new Descriptor();
        }

        [XmlIgnore]
        public OrganizationReference Reference
        {
            get
            {
                if (_reference == null)
                    _reference = new OrganizationReference();
                if( _reference.OrgId != this.OrgId)
                    _reference.OrgId = this.OrgId;

                return _reference;
            }
        }
    }
}
