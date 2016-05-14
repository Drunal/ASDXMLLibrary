using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
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
                if( _reference.OrgID != this.OrgID)
                    _reference.OrgID = this.OrgID;

                return _reference;
            }
        }
    }
}
