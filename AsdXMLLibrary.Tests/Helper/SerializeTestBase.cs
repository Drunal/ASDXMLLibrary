using AsdXMLLibrary.Base;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Helper
{
    public abstract class SerializeTestBase : TestBase
    {
        protected abstract string TestRootElementName { get; }

        /// <summary>
        /// The set of schemas needed for validation
        /// </summary>
        protected static readonly XmlSchemaSet schemas;


        protected static readonly ContentManager manager;

        static SerializeTestBase()
        {
            schemas = new XmlSchemaSet();
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Basics.xsd");
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Descriptor.xsd");
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Identifier.xsd");
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Property.xsd");
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/SoftwarePartAsDesigned.xsd");

            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/S3000L/s3000l_1-1_lsa_dataset_without_assert.xsd");
            schemas.Add("http://www.asd-europe.org/spec/validValues", @"Schemas/S3000L/s3000l_1-1_valid_values.xsd");
            schemas.Add("http://www.asd-europe.org/spec/validValues", @"Schemas/S3000L/sx002d_1-1_applic_cond_valid_values.xsd");
            schemas.Add("http://www.asd-europe.org/spec/validValues", @"Schemas/S3000L/sx002d_1-1_units.xsd");
            schemas.Add("http://www.asd-europe.org/spec/validValues", @"Schemas/S3000L/sx002d_1-1_valid_values.xsd");
            schemas.Add("http://www.asd-europe.org/spec/validValues", @"Schemas/S3000L/s1000d_4-2_information_codes.xsd");

            manager = ContentManager.Initialize(schemas);
        }

        /// <summary>
        /// serializes the given object to a Stream.
        /// Loads that stream as an XDocument, which is validated against the schemas
        /// deserializes the stream and returns the new object.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="input">The actual object to be serialized</param>
        /// <returns>A deserialized object of type T</returns>
        internal T ObjectStreamtoObject<T>(T input) where T : SerializeBase, new()
        {
            return ObjectStreamtoObject(input, TestRootElementName);
        }

        internal T ObjectStreamtoObject<T>(T input, string rootElementName) where T: SerializeBase, new()
        {
            MemoryStream ms = new MemoryStream();
            manager.SerializeToStream<T>(input, ms, rootElementName);
            manager.SerializeToFile<T>(input, "output.xml", rootElementName);

            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            return manager.DeserializeFromStream<T>(ms);
        }
    }
}
