using AsdXMLLibrary.Base.Classifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Helper
{
    [TestClass]
    public class TestBase
    {
        /// <summary>
        /// The set of schemas needed for validation
        /// </summary>
        protected static readonly XmlSchemaSet schemas;

        /// <summary>
        /// Constructor for the Base Class
        /// Is called just once through out the complete test suite... 
        /// ... well up to now I only have one test class
        /// </summary>
        static TestBase()
        {
            schemas = new XmlSchemaSet();
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Descriptor.xsd");
            schemas.Add("http://www.asd-europe.org/s-series/s3000l", @"Schemas/Basics.xsd");

            // Fill the validValues with default values.
            ClassificationManager.FillDefaultValues();
        }

        /// <summary>
        /// serializes the given object to a Stream.
        /// Loads that stream as an XDocument, which is validated against the schemas
        /// deserializes the stream and returns the new object.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="input">The actual object to be serialized</param>
        /// <returns>A deserialized object of type T</returns>
        protected T ObjectStreamtoObject<T>(T input)
        {
            MemoryStream ms = new MemoryStream();
            ContentManager.SerializeToStream<T>(input, ms);
            ms.Position = 0;

            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            return ContentManager.DeserializeFromStream<T>(ms);
        }
    }
}
