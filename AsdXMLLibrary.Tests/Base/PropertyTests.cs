using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using AsdXMLLibrary.Objects;
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

        [TestMethod]
        public void LastSingleValueProptySetShouldWin()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(2.5, 10, "BIT");
            expected.SoftwarePartSize.Value = 12.5;

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);

            Assert.AreEqual(expected.SoftwarePartSize.Value, result.SoftwarePartSize.Value);
            Assert.AreEqual(expected.SoftwarePartSize.Unit.Value, result.SoftwarePartSize.Unit.Value);
            Assert.IsNull(result.SoftwarePartSize.LowerLimit);
            Assert.IsNull(result.SoftwarePartSize.UpperLimit);
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

        [TestMethod]
        public void LastRangeValueProptySetShouldWin()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(2.5, 10, 4, "BIT");
            expected.SoftwarePartSize.LowerLimit = 7.5;
            expected.SoftwarePartSize.UpperLimit = 8.6;

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);

            Assert.AreEqual(expected.SoftwarePartSize.LowerLimit, result.SoftwarePartSize.LowerLimit);
            Assert.AreEqual(expected.SoftwarePartSize.UpperLimit, result.SoftwarePartSize.UpperLimit);
            Assert.AreEqual(expected.SoftwarePartSize.Unit.Value, result.SoftwarePartSize.Unit.Value);
            Assert.IsNull(result.SoftwarePartSize.NominalValue);
            Assert.IsNull(result.SoftwarePartSize.LowerOffset);
            Assert.IsNull(result.SoftwarePartSize.UpperOffset);
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

        [TestMethod]
        public void LastToleranceValueProptySetShouldWin()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>("text property");
            expected.SoftwarePartSize.LowerOffset = 7.5;
            expected.SoftwarePartSize.UpperOffset = 8.6;
            expected.SoftwarePartSize.NominalValue = 8;
            expected.SoftwarePartSize.Unit.Value = "BIT";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);

            Assert.AreEqual(expected.SoftwarePartSize.NominalValue, result.SoftwarePartSize.NominalValue);
            Assert.AreEqual(expected.SoftwarePartSize.LowerOffset, result.SoftwarePartSize.LowerOffset);
            Assert.AreEqual(expected.SoftwarePartSize.UpperOffset, result.SoftwarePartSize.UpperOffset);
            Assert.AreEqual(expected.SoftwarePartSize.Unit.Value, result.SoftwarePartSize.Unit.Value);
            Assert.IsNull(result.SoftwarePartSize.Text);
        }
        #endregion

        #region TextValueProperty Tests
        [TestMethod]
        public void SerializeTextValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>("value");

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        [TestMethod]
        public void SerializeCompleteTextValueProperty()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>("value");
            expected.SoftwarePartSize.RecordingDate = DateTime.Now;
            expected.SoftwarePartSize.ValueDetermination.Value = "CALC";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);
            result.SoftwarePartSize.ShouldDeepEqualwithDate(expected.SoftwarePartSize);
        }

        public void LastTextProptySetShouldWin()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.SoftwarePartSize = PropertyFactory.Create<BinaryUnitClassification>(2.5, "BIT");
            expected.SoftwarePartSize.Text = "text property";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result.SoftwarePartSize = ObjectStreamtoObject(expected.SoftwarePartSize);

            Assert.AreEqual(expected.SoftwarePartSize.Text, result.SoftwarePartSize.Text);
            Assert.IsNull(result.SoftwarePartSize.Value);
            Assert.IsNull(result.SoftwarePartSize.Unit);
        }
        #endregion
    }
}
