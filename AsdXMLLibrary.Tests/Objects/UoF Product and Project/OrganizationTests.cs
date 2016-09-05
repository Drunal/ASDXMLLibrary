using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Objects.UoF_Product_and_Project
{
    [TestClass]
    public class OrganizationTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "lsaDataSet"; } }

        [TestMethod]
        public void SerializeOrganizationMinimum()
        {
            var expected = TestObjects.BasicMessage;
            expected.SupportingItems.Organizations.Add(TestObjects.OrganizationMinimum);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeMultipleOrganizations()
        {
            var expected = TestObjects.BasicMessage;
            expected.SupportingItems.Organizations.Add(TestObjects.OrganizationMinimum);
            expected.SupportingItems.Organizations.Add(TestObjects.OrganizationFull);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void ShouldThrowOnMissingID()
        {
            var expected = TestObjects.BasicMessage;
            var org = TestObjects.OrganizationMinimum;
            org.OrgIds.Primary.ID = null;
            
            expected.SupportingItems.Organizations.Add(org);
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected)
            );
        }
    }
}
