using AsdXMLLibrary.Base.Classifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Helper
{
    [TestClass]
    public abstract class TestBase
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
    }
}
