using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeepEqual.Syntax;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class IdentifierTests : TestBase
    {
        [TestMethod]
        public void SerializeCompleteIdentifier()
        {
            Organization expected = TestObjects.OrganizationFull;
            Organization result = new Organization();
            result.OrgId = ObjectStreamtoObject(expected.OrgId);
            result.OrgId.ShouldDeepEqualwithDate(expected.OrgId);
        }

        [TestMethod]
        public void SerializeMinimalIdentifier()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            Organization result = new Organization();
            result.OrgId = ObjectStreamtoObject(expected.OrgId);
            result.OrgId.ShouldDeepEqual(expected.OrgId);
        }

        [TestMethod]
        public void ShouldThrowOnMissingId()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            expected.OrgId.ID = string.Empty;
            Organization result = new Organization();
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected.OrgId)
            );
        }
    }
}
