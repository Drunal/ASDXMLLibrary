using AsdXMLLibrary.Objects;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class TestObjects
    {
        /// <summary>
        /// creates a NEW MockOrganization with Name and ID
        /// </summary>
        /// <returns>an Organization with Name and ID</returns>
        public static Organization OrganizationMinimum
        {
            get
            {
                var org = new Organization();
                org.Name.Text = "OrgMini";
                org.OrgId.ID = "N1234";
                return org;
            }
        }

        /// <summary>
        /// Create a NEW MockOrganization with a localized Name and a classified ID
        /// </summary>
        public static Organization OrganizationFull
        {
            get
            {
                var org = TestObjects.OrganizationMinimum;
                org.Name.Language.Value = "EN";
                org.OrgId.Class.Value = "CAGE";
                return org;
            }
        }

        /// <summary>
        /// Create a NEW Mock SoftwarePart As Designed with PartID set by a <see cref="OrganizationMinimum"/>
        /// </summary>
        public static SoftwarePartAsDesigned SoftwarePartMinimum
        {
            get
            {
                var sw = new SoftwarePartAsDesigned();
                sw.PartIds.Primary.ID = "PartNumber-1234";
                sw.PartIds.Primary.SetBy = OrganizationMinimum.GetReference();
                return sw;
            }
        }

        /// <summary>
        /// Creates a NEW Mock SoftwarePart as Designed with two PartIds - set by noone.
        /// </summary>
        public static SoftwarePartAsDesigned SoftwarePartMultipleIds
        {
            get
            {
                var sw = new SoftwarePartAsDesigned();
                sw.PartIds.Primary.ID = "Partnumber-1234";
                sw.PartIds.Add(new AsdXMLLibrary.Base.ProvidedIdentifier<AsdXMLLibrary.Base.Classifications.PartIdentifierClassification>("Partnumber-9876"));
                return sw;
            }
        }

        /// <summary>
        /// Create a NEW Mock Software as Designed with two PartNames
        /// </summary>
        public static SoftwarePartAsDesigned SoftwarePartMultipleNames
        {
            get
            {
                var sw = TestObjects.SoftwarePartMinimum;
                sw.PartNames.Primary.Text = "PartName1";
                sw.PartNames.Add(new AsdXMLLibrary.Base.ProvidedDescriptor("Partname2", "EN"));
                return sw;
            }
        }
    }
}
