﻿using AsdXMLLibrary.Base.Classifications;
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
       
            // Fill the validValues with default values.
            ClassificationManager.Add(new MessageIdentifierClassification { "MSN", "MID" });
            
            ClassificationManager.Add(new LanguageClassification { "EN", "DE", "ES" });
            ClassificationManager.Add(new PartIdentifierClassification { "PNO", "NSN", "OEM" });
            ClassificationManager.Add(new OrganizationIdentifierClassification { "CAGE" });
            ClassificationManager.Add(new ProjectIdentifierClassification { "PID", "MOI" });
            ClassificationManager.Add(new ValueDeterminationClassification {
                "ALC", "CALC", "CONTR", "DSG", "EMP", "EST", "MEAS", "PLAN", "REQ", "SET", "SPEC"
            });
            ClassificationManager.Add(new UnitClassification {
                "BIT", "B", "GB", "KB", "MB", "OC", "PB", "TB"
            });
            ClassificationManager.Add(new BinaryUnitClassification {
                "BIT", "B", "GB", "KB", "MB", "OC", "PB", "TB"
            });
            ClassificationManager.Add(new HazardousClassClassification());
            ClassificationManager.Add(new FitmentRequirementClassification {
                "MINOR", "MAJOR"
            });
            ClassificationManager.Add(new SoftwareTypeClassification { 
                "D", "E", "L"
            });
            ClassificationManager.Add(new DummyClassification());
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
            ContentManager.SerializeToFile<T>(input, "property.xml");
            
            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            return ContentManager.DeserializeFromStream<T>(ms);
        }
    }
}
