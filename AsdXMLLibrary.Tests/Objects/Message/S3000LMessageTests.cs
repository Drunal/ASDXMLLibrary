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
        public void SimpleMessageTest()
        {
            S3000LMessage message = new S3000LMessage();
            message.ContentItems.Parts.Add(TestObjects.SoftwarePartMinimum);
            message.ContentItems.Parts.Add(new HardwarePartAsDesigned());

            message.SupportingItems.Organizations.Add(TestObjects.OrganizationFull);

            manager.SerializeToFile<S3000LMessage>(message, "message.xml", TestRootElementName);
        }
    }
}
