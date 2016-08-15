using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsdXMLLibrary.Tests.Objects.UoF_Part_Definition
{
    [TestClass]
    public class PartAsDesignedTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "lsaDataSet"; } }

        [TestMethod]
        public void SoftwarePartMinimumTest()
        {
            var expected = TestObjects.BasicMessage;
            expected.ContentItems.Parts.Add(TestObjects.SoftwarePartMinimum);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SoftwarePartMaximumTest()
        {
            var expected = TestObjects.BasicMessage;
            expected.ContentItems.Parts.Add(TestObjects.SoftwarePartComplete);

            var result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        }
    }
}
