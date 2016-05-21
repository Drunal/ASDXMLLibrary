using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests
{
    [TestClass]
    public class DescriptorTests : TestBase
    {
        [TestMethod]
        public void SerializeCompleteDescriptor()
        {
            Organization expected = TestObjects.OrganizationFull;
            Organization result = new Organization();
            result.Name = ObjectStreamtoObject(expected.Name);
            result.Name.ShouldDeepEqualwithDate(expected.Name);
        }

        [TestMethod]
        public void SerializeMinimalDescriptor()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            Organization result = new Organization();
            result.Name = ObjectStreamtoObject(expected.Name);
            result.Name.ShouldDeepEqual(expected.Name);
        }

        [TestMethod]
        public void ShouldFailOnMissingName()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            // remove the Name;
            expected.Name.Text = string.Empty;
            Organization result = new Organization();
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected.Name)                
            );
        }
    }
}
