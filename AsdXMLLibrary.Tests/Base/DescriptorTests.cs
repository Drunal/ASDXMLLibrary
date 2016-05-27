using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Base
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
        public void ShouldThrowOnMissingName()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            // remove the Name;
            expected.Name.Text = string.Empty;
            Organization result = new Organization();
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected.Name)                
            );
        }

        [TestMethod]
        public void SerializeMultipleDescriptors()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMultipleNames;

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }
    }
}
