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
using DeepEqual.Syntax;
using AsdXMLLibrary.Tests.Helper;

namespace AsdXMLLibrary.Tests
{
    [TestClass]
    public class BaseTests
    {
        /// <summary>
        /// The set of schemas needed for validation
        /// </summary>
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
            // Fill the validValues with default values.
            ClassificationManager.FillDefaultValues();
        }

        [TestMethod]
        public void SerializeFullDescriptor()
        {
            Organization expected = TestObjects.MinimumOrganization;

            // expand the minimum organization by its optional fields
            expected.Name.ProvidedDate = DateTime.Today;
            expected.Name.ProvidedBy = expected.Reference;

            var ms = new MemoryStream();
            ContentManager.SerializeToStream<Descriptor>(expected.Name, ms);
            ContentManager.SerializeToFile<Descriptor>(expected.Name, "descriptor.xml");
            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            try
            {
                createdXML.Validate(schemas, null);
            }
            catch (XmlSchemaValidationException xsve)
            {
                Assert.Fail(String.Format("Created XML does not comply with the XML Schema:\n{0}", xsve.ToString()));
            }

            ms.Position = 0;
            Organization result = new Organization();
            result.Name = ContentManager.DeserializeFromStream<Descriptor>(ms);

            result.Name.ShouldDeepEqual(expected.Name);
        }
    }
}
