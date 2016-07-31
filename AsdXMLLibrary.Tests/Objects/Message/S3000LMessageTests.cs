using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsdXMLLibrary.Tests.Objects.Message
{
    [TestClass]
    public class S3000LMessageTests : TestBase
    {
        [TestMethod]
        public void SimpleMessageTest()
        {
            S3000LMessage message = new S3000LMessage();
            message.Content.ContentItems.Parts.Add(TestObjects.SoftwarePartMinimum);
            message.Content.ContentItems.Parts.Add(new HardwarePartAsDesigned());

            message.Content.SupportingItems.Organizations.Add(TestObjects.OrganizationFull);

            manager.SerializeToFile<S3000LMessage>(message, "message.xml");
        }
    }
}
