using ASDXMLLibrary.Base;
using ASDXMLLibrary.Base.Classifications;
using ASDXMLLibrary.Base.Properties;
using System.Xml.Serialization;

namespace ASDXMLLibrary.Objects
{
    
    public class Organization : OrganizationReference
    {
        [XmlElement(ElementName="name",IsNullable=true)]
        public Descriptor OrgName { get; set; }

        private OrganizationReference _reference;

        public Organization()
            : base()
        {
            OrgName = new Descriptor();
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
