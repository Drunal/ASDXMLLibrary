using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsdXMLLibrary.Tests.Objects.UoF_Part_Definition
{
    [TestClass]
    public class PartAsDesignedTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "lsaDataSet"; } }

        [TestMethod]
        public void SerializeSoftwarePartMinimum()
        {
            var expected = TestObjects.BasicMessage;
            expected.ContentItems.Parts.Add(TestObjects.SoftwarePartMinimum);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeSoftwarePartMaximum()
        {
            var expected = TestObjects.BasicMessage;
            expected.ContentItems.Parts.Add(TestObjects.SoftwarePartComplete);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeHardwarePartMinimum()
        {
            var expected = TestObjects.BasicMessage;
            expected.ContentItems.Parts.Add(TestObjects.HardwarePartMinimum);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeHardwarePartMaximum()
        {
            var expected = TestObjects.BasicMessage;
            expected.ContentItems.Parts.Add(TestObjects.HardwarePartComplete);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }
    }
}
