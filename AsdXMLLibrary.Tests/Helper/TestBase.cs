using AsdXMLLibrary.Base;
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


        protected static readonly ContentManager manager;
        /// <summary>
        /// Constructor for the Base Class
        /// Is called just once through out the complete test suite... 
        /// ... well up to now I only have one test class
        /// </summary>
        static TestBase()
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

        [TestInitialize]
        public void Initialize()
        {
            // reset Classifications to defaults
            ClassificationManager.ClearClassifications();
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
        internal T ObjectStreamtoObject<T>(T input) where T: new()
        {
            MemoryStream ms = new MemoryStream();
            manager.SerializeToStream<T>(input, ms);
            manager.SerializeToFile<T>(input, "output.xml");
            
            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            //return manager.DeserializeFromStream<T>(ms);
            return input;
        }

        internal T ObjectStreamtoObjectNew<T>(T input) where T : SerializeBase, new()
        {
            MemoryStream ms = new MemoryStream();
            manager.SerializeToStream<T>(input, ms);
            manager.SerializeToFile<T>(input, "output.xml");

            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            return manager.DeserializeFromStream<T>(ms);
        }
    }
}
