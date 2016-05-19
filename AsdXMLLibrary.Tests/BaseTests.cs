using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using AsdXMLLibrary.Objects;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests
{
    [TestClass]
    public class BaseTests
    {
        private Organization createMockOrganization()
        {
            Organization organization = new Organization();
            organization.Name.Text = "OrgName";
            organization.Name.Language.Value = "en";
            organization.OrgID.ID = "N1234";
            organization.OrgID.Class.Value = "CAGE";
            return organization;
        }

        private XmlSchemaSet schemas;

        public BaseTests()
        {
            schemas = new XmlSchemaSet();
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Descriptor.xsd");
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Basics.xsd");
        }

        [TestInitialize]
        public void TestSetup()
        {
            ClassificationManager.FillDefaultValues();
        }

        [TestMethod]
        public void SerializeFullDescriptor()
        {
            Organization expected = createMockOrganization();

            expected.Name.ProvidedDate = DateTime.Today;
            expected.Name.ProvidedBy = expected.Reference;

            var ms = new MemoryStream();
            ContentManager.SerializeToStream<Descriptor>(expected.Name, ms);
            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            try
            {
                createdXML.Validate(schemas, null);
            }
            catch (XmlSchemaValidationException)
            {
                Assert.Fail();
            }

            ms.Position = 0;
            Organization result = new Organization();
            result.Name = ContentManager.DeserializeFromStream<Descriptor>(ms);

            Assert.AreEqual(expected.Name, result.Name);
            //Assert.AreEqual(expected.Name.Text, result.Name.Text);
            //Assert.AreEqual(expected.Name.Language.Value, createdXML.XPathSelectElement("/*", "lang", 2).Value);
            //Assert.AreEqual(expected.Name.ProvidedDate.ToXmlDateString(), createdXML.XPathSelectElement("/*", "date", 3).Value);
            //XElement providedBy = createdXML.XPathSelectElement("/*", "providedBy", 4);
            //Assert.IsNotNull(providedBy);
            //Assert.AreEqual(expected.Name.ProvidedBy.OrgID.ID, providedBy.XPathSelectElement("orgId", "id", 1).Value);
            //Assert.AreEqual(expected.Name.ProvidedBy.OrgID.Class.Value, providedBy.XPathSelectElement("orgId", "class", 2).Value);
        }
    }
}
