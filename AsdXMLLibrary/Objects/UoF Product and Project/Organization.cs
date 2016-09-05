using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;

namespace AsdXMLLibrary.Objects
{
    
    public class Organization : ICanBeReferenced<OrganizationReference>
    {
        public MultipleValues<Identifier<OrganizationIdentifierClassification>> OrgIds { get; set; }

        public Descriptor Name { get; set; }

        private OrganizationReference _reference = null;

        public Organization()
        {
            OrgIds = new MultipleValues<Identifier<OrganizationIdentifierClassification>>();
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
