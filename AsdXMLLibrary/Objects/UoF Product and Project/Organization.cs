using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;

namespace AsdXMLLibrary.Objects
{
    
    public class Organization : ICanBeReferenced
    {
        public Identifier<OrganizationIdentifierClassification> OrgId { get; set; }

        public Descriptor Name { get; set; }

        public Organization()
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>();
            Name = new Descriptor();

        }
    }
}
