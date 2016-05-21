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
        private static Organization _org = null;
        
        /// <summary>
        /// creates a MockOrganisation with Name with Language and ID with Class
        /// </summary>
        /// <returns>an Organization with Name and ID</returns>
        public static Organization MinimumOrganization
        {
            get
            {
                if (_org == null) 
                {
                    _org = new Organization();
                    _org.Name.Text = "OrgName";
                    _org.Name.Language.Value = "en";
                    _org.OrgID.ID = "N1234";
                    _org.OrgID.Class.Value = "CAGE";
                }
                return _org;
            }
        }
    }
}
