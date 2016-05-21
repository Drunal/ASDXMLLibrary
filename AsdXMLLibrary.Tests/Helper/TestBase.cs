using AsdXMLLibrary.Base.Classifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
