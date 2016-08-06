using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class PropertyTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "Property"; } }
        
        [TestInitialize]
        public void InitializeTest()
        {
            // make sure that the DummyClassification is properly filled
            ClassificationManager.Add(new DummyClassification {
                "TEST"
            }, true);
        }

        #region SingleValueProperty Tests
        [TestMethod]
        public void SerializeSingleValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateSingleValueProperty(12.5, "TEST");
            Property<DummyClassification> result = new Property<DummyClassification>();

            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteSingleValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateSingleValueProperty(12.5, "TEST");
            expected.RecordingDate = DateTime.Now;
            expected.ValueDetermination.Value = "CALC";

            Property<DummyClassification> result = new Property<DummyClassification>();
            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void ShouldThrowOnMissingUnitForSingleValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateSingleValueProperty(12.5, "TEST");
            // remove Unit to create expection
            expected.Unit.Value = null;
            
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected)
            );
        }

        [TestMethod]
        public void LastSingleValueProptySetShouldWin()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateRangeProperty(2.5, 10, "TEST");
            expected.Value = 12.5;

            Property<DummyClassification> result = new Property<DummyClassification>();
            result = ObjectStreamtoObject(expected);

            Assert.AreEqual(expected.Value, result.Value);
            Assert.AreEqual(expected.Unit.Value, result.Unit.Value);
            Assert.IsNull(result.LowerLimit);
            Assert.IsNull(result.UpperLimit);
        }
        #endregion

        #region RangeValueProperty Tests
        [TestMethod]
        public void SerializeRangeValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateRangeProperty(22.5, 22.5, "TEST");
            Property<DummyClassification> result = new Property<DummyClassification>();

            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteRangeValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateRangeProperty(22.5, 22.5, "TEST");
            expected.RecordingDate = DateTime.Now;
            expected.ValueDetermination.Value = "CALC";

            Property<DummyClassification> result = new Property<DummyClassification>();
            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void ShouldThrowOnMissingUnitForRangeValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateRangeProperty(22.5, 22.5, "TEST");
            // remove Unit to create expection
            expected.Unit.Value = null;

            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected)
            );
        }

        [TestMethod]
        public void LastRangeValueProptySetShouldWin()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateToleranceValueProperty(2.5, 10, 4, "TEST");
            expected.LowerLimit = 7.5;
            expected.UpperLimit = 8.6;

            Property<DummyClassification> result = new Property<DummyClassification>();
            result = ObjectStreamtoObject(expected);

            Assert.AreEqual(expected.LowerLimit, result.LowerLimit);
            Assert.AreEqual(expected.UpperLimit, result.UpperLimit);
            Assert.AreEqual(expected.Unit.Value, result.Unit.Value);
            Assert.IsNull(result.NominalValue);
            Assert.IsNull(result.LowerOffset);
            Assert.IsNull(result.UpperOffset);
        }

        #endregion

        #region ToleranceValueProperty Tests
        [TestMethod]
        public void SerializeToleranceValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateToleranceValueProperty(10.5, 2.4, 1.4, "TEST");
            Property<DummyClassification> result = new Property<DummyClassification>();

            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteToleranceValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateToleranceValueProperty(10.5, 2.4, 1.4, "TEST");
            expected.RecordingDate = DateTime.Now;
            expected.ValueDetermination.Value = "CALC";

            Property<DummyClassification> result = new Property<DummyClassification>();            
            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void ShouldThrowOnMissingUnitForToleranceValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateToleranceValueProperty(10.5, 2.4, 1.4, "TEST");
            // remove Unit to create expection
            expected.Unit.Value = null;

            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObject(expected)
            );
        }

        [TestMethod]
        public void LastToleranceValueProptySetShouldWin()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateTextProperty("text property");
            expected.LowerOffset = 7.5;
            expected.UpperOffset = 8.6;
            expected.NominalValue = 8;
            expected.Unit.Value = "TEST";

            Property<DummyClassification> result = new Property<DummyClassification>();  
            result = ObjectStreamtoObject(expected);

            Assert.AreEqual(expected.NominalValue, result.NominalValue);
            Assert.AreEqual(expected.LowerOffset, result.LowerOffset);
            Assert.AreEqual(expected.UpperOffset, result.UpperOffset);
            Assert.AreEqual(expected.Unit.Value, result.Unit.Value);
            Assert.IsNull(result.Text);
        }
        #endregion

        #region TextValueProperty Tests
        [TestMethod]
        public void SerializeTextValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateTextProperty("value");
            Property<DummyClassification> result = new Property<DummyClassification>();

            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteTextValueProperty()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateTextProperty("value");
            expected.RecordingDate = DateTime.Now;
            expected.ValueDetermination.Value = "CALC";

            Property<DummyClassification> result = new Property<DummyClassification>();
            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        public void LastTextProptySetShouldWin()
        {
            Property<DummyClassification> expected = new Property<DummyClassification>();
            expected.CreateSingleValueProperty(2.5, "TEST");
            expected.Text = "text property";

            Property<DummyClassification> result = new Property<DummyClassification>();
            result = ObjectStreamtoObject(expected);

            Assert.AreEqual(expected.Text, result.Text);
            Assert.IsNull(result.Value);
            Assert.IsNull(result.Unit);
        }
        #endregion
    }
}
