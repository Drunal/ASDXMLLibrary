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
    public class DescriptorTests : TestBase
    {

        /// <summary>
        /// serializes the given object to a Stream.
        /// Loads that stream as an XDocument, which is validated against the schemas
        /// deserializes the stream and returns the new object.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="input">The actual object to be serialized</param>
        /// <returns>A deserialized object of type T</returns>
        private T ObjectStreamtoObject<T>(T input)
        {
            MemoryStream ms = new MemoryStream();
            ContentManager.SerializeToStream<T>(input, ms);
            ms.Position = 0;

            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            return ContentManager.DeserializeFromStream<T>(ms);
        }

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
        [ExpectedException(typeof(XmlSchemaValidationException))]
        public void ShouldFailOnMissingName()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            // remove the Name;
            expected.Name.Text = "";
            Organization result = new Organization();
            result.Name = ObjectStreamtoObject(expected.Name);
            result.Name.ShouldDeepEqual(expected.Name);
        }
    }
}
