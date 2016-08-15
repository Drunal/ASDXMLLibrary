using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsdXMLLibrary.Tests.Objects.Message
{
    [TestClass]
    public class S3000LMessageTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "lsaDataSet"; } }

        [TestMethod]
        public void MessageBasicsTest()
        {
            S3000LMessage expected = new S3000LMessage();
            expected.Id.ID = "0001";

            expected.Sender.Add(TestObjects.OrganizationMinimum.GetReference());
            expected.Receiver.Add(TestObjects.OrganizationFull.GetReference());
            expected.ContentItems.Parts.Add(TestObjects.SoftwarePartMultipleNames);

            S3000LMessage result = new S3000LMessage();
            
            result = ObjectStreamtoObject(expected);
            result.ShouldDeepEqualwithDate(expected);
        } 
    }
}
