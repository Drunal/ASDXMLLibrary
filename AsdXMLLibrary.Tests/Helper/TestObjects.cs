using AsdXMLLibrary.Objects;
using System;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class TestObjects
    {
        /// <summary>
        /// creates a MockOrganization with Name and ID
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
        /// Create a MockOrganization with a localized Name and a classified ID
        /// </summary>
        public static Organization OrganizationMedium
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
        /// Create a MockOrganization with a complete set of data!
        /// </summary>
        public static Organization OrganizationFull
        {
            get
            {
                var org = TestObjects.OrganizationMedium;
                org.Name.ProvidedBy = TestObjects.OrganizationMinimum.Reference;
                org.Name.ProvidedDate = DateTime.Now;
                org.OrgId.SetBy = TestObjects.OrganizationMinimum.Reference;
                return org;
            }
        }

        public static SoftwarePartAsDesigned SoftwarePartMinimum
        {
            get
            {
                var sw = new SoftwarePartAsDesigned();
                sw.PartId.ID = "PartNumber-1234";
                sw.PartId.SetBy = OrganizationMinimum.Reference;
                return sw;
            }
        }

        public static SoftwarePartAsDesigned SoftwarePartMultipleIds
        {
            get
            {
                var sw = new SoftwarePartAsDesigned();
                sw.PartId.ID = "Partnumber-1234";
                sw.PartIds.Add(new AsdXMLLibrary.Base.Identifier<AsdXMLLibrary.Base.Classifications.PartIdentifierClassification>("Partnumber-9876"));
                return sw;
            }
        }

        public static SoftwarePartAsDesigned SoftwarePartMultipleNames
        {
            get
            {
                var sw = TestObjects.SoftwarePartMinimum;
                sw.PartName.Text = "PartName1";
                sw.PartNames.Add(new AsdXMLLibrary.Base.Descriptor("Partname2", "EN"));
                return sw;
            }
        }
    }
}
