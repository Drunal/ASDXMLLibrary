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
                org.Name.Language.Value = "en";
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
    }
}
