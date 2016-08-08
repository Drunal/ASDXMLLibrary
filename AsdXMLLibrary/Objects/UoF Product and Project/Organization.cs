using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;

namespace AsdXMLLibrary.Objects
{
    
    public class Organization : ICanBeReferenced<OrganizationReference>
    {
        public Identifier<OrganizationIdentifierClassification> OrgId { get; set; }

        public Descriptor Name { get; set; }

        private OrganizationReference _reference = null;

        public Organization()
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>();
            Name = new Descriptor();

        }

        public OrganizationReference GetReference()
        {
            if(_reference == null)
            {
                _reference = new OrganizationReference(this);
            }
            return _reference;
        }
    }
}
