using AsdXMLLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class TestObjects
    {
        private static Organization _orgMini = null;
        private static Organization _orgMedium = null;
        private static Organization _orgFull = null;

        private static Organization _originator = new Organization();
        
        /// <summary>
        /// creates a MockOrganization with Name and ID
        /// </summary>
        /// <returns>an Organization with Name and ID</returns>
        public static Organization OrganizationMinimum
        {
            get
            {
                if (_orgMini == null) 
                {
                    _orgMini = new Organization();
                    _orgMini.Name.Text = "OrgMini";
                    _orgMini.OrgID.ID = "N1234";
                }
                return _orgMini;
            }
        }

        /// <summary>
        /// Create a MockOrganization with a localized Name and a classified ID
        /// </summary>
        public static Organization OrganizationMedium
        {
            get
            {
                if (_orgMedium == null)
                {
                    _orgMedium = new Organization();
                    _orgMedium.Name.Text = "OrgMedium";
                    _orgMedium.Name.Language.Value = "en";
                    _orgMedium.OrgID.ID = "N5678";
                    _orgMedium.OrgID.Class.Value = "CAGE";
                }
                return _orgMedium;
            }
        }

        /// <summary>
        /// Create a MockOrganization with a complete set of data!
        /// </summary>
        public static Organization OrganizationFull
        {
            get
            {
                if (_orgFull == null)
                {
                    _orgFull = new Organization();
                    _orgFull.Name.Text = "OrgMedium";
                    _orgFull.Name.Language.Value = "en";
                    _orgFull.Name.ProvidedBy = TestObjects.OrganizationMinimum.Reference;
                    _orgFull.Name.ProvidedDate = DateTime.Now;
                    _orgFull.OrgID.ID = "N5678";
                    _orgFull.OrgID.Class.Value = "CAGE";
                    _orgFull.OrgID.SetBy = TestObjects.OrganizationMinimum.Reference;
                    
                }
                return _orgFull;
            }
        }
    }
}
