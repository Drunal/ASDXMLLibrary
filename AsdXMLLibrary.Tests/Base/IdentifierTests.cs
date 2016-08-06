using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class IdentifierTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "Identifier"; } }

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
        public void SerializeMinimalProvidedIdentifier()
        {
            ProvidedIdentifier<DummyClassification> expected = new ProvidedIdentifier<DummyClassification>("12345");
            ProvidedIdentifier<DummyClassification> result = ObjectStreamtoObjectNew(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteProvidedIdentifier()
        {
            // add classification to avoid an unwanted exception, while creating the testobject
            ClassificationManager.Add(new DummyClassification { 
                "TEST"
            }, true);
            ProvidedIdentifier<DummyClassification> expected = new ProvidedIdentifier<DummyClassification>("12345", "TEST", TestObjects.OrganizationMinimum);
            ProvidedIdentifier<DummyClassification> result = ObjectStreamtoObjectNew(expected);
            result.ShouldDeepEqualwithDate(expected);
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

        [TestMethod]
        public void SerializeMultipleIdentifiers()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMultipleIds;

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result = ObjectStreamtoObject(expected);
            result.PartIds.ShouldDeepEqualwithDate(expected.PartIds);
        }

        [TestMethod]
        public void ShouldThrowOnMissingIdWithMultipleIdsPossibility()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.PartIds.MainID.ID = string.Empty;
            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected)
            );
        }
    }
}
