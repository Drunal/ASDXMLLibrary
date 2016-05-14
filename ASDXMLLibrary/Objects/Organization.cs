using ASDXMLLibrary.Base;
using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Objects
{
    public class Organization
    {
        public Identifier<OrganizationIdentifierClassification> OrgID { get; set; }
        public Descriptor OrgName { get; set; }

        public Organization()
        {
            OrgName = new Descriptor();
            OrgID = new Identifier<OrganizationIdentifierClassification>();
        }
    }
}
