using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using AsdXMLLibrary.Objects.UoF_Part_Definition;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class PropertyTests : TestBase
    {

        #region SingleValueProperty Tests
        [TestMethod]
        public void SerializeSingleValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(12.5,"BIT");

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void SerializeCompleteSingleValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(12.5, "BIT");
            expected.SoftwarePartSize.RecordingDate = DateTime.Now;
            expected.SoftwarePartSize.ValueDetermination.Value = "CALC";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void ShouldThrowOnMissingUnitForSingleValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(12.5,"BIT");
            // remove Unit to create expection
            expected.SoftwarePartSize.Unit.Value = null;
            
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected.SoftwarePartSize)
            );
        }
        #endregion

        #region RangeValueProperty Tests
        [TestMethod]
        public void SerializeRangeValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(22.5, 22.5, "BIT");

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void SerializeCompleteRangeValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(22.5, 22.5, "BIT");
            expected.SoftwarePartSize.RecordingDate = DateTime.Now;
            expected.SoftwarePartSize.ValueDetermination.Value = "CALC";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void ShouldThrowOnMissingUnitForRangeValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(22.5, 22.5, "BIT");
            // remove Unit to create expection
            expected.SoftwarePartSize.Unit.Value = null;

            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected.SoftwarePartSize)
            );
        }
        #endregion

        #region ToleranceValueProperty Tests
        [TestMethod]
        public void SerializeToleranceValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(10.5, 2.4, 1.4, "BIT");

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void SerializeCompleteToleranceValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(10.5, 2.4, 1.4, "BIT");
            expected.SoftwarePartSize.RecordingDate = DateTime.Now;
            expected.SoftwarePartSize.ValueDetermination.Value = "CALC";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void ShouldThrowOnMissingUnitForToleranceValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(10.5, 2.4, 1.4, "BIT");
            // remove Unit to create expection
            expected.SoftwarePartSize.Unit.Value = null;

            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected.SoftwarePartSize)
            );
        }
        #endregion

        #region TextValueProperty Tests
        [TestMethod]
        public void SerializeTextValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create("value");

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void SerializeCompleteTextValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create("value");
            expected.SoftwarePartSize.RecordingDate = DateTime.Now;
            expected.SoftwarePartSize.ValueDetermination.Value = "CALC";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }
        #endregion
    
        // TODO: create tests to ensure, that the "last" set property Type wins.
    }
}
