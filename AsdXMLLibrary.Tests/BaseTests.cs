using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using AsdXMLLibrary.Objects;
using System.Xml.Linq;

namespace AsdXMLLibrary.Tests
{
    [TestClass]
    public class BaseTests
    {
        private const string tempFileName = "serialized.xml";

        private Organization createMockOrganization()
        {
            Organization organization = new Organization();
            organization.Name.Text = "OrgName";
            organization.Name.Language.Value = "en";
            organization.OrgID.ID = "N1234";
            organization.OrgID.Class.Value = "CAGE";
            return organization;
        }


        [TestInitialize]
        public void TestSetup()
        {
            ClassificationManager.FillDefaultValues();
        }

        [TestMethod]
        public void SerializeFullDescriptor()
        {

            Organization org = createMockOrganization();

            org.Name.ProvidedDate = DateTime.Today;
            org.Name.ProvidedBy = org.Reference;

            ContentManager.Serialize<Descriptor>(org.Name, tempFileName);
            XDocument result = XDocument.Load(tempFileName);

            Assert.AreEqual("Descriptor", result.Root.Name);
            Assert.AreEqual(org.Name.Text, result.Root.Element("descr").Value);
            Assert.AreEqual(org.Name.Language.Value, result.Root.Element("lang").Value, org.Name.Language.Value);
            Assert.AreEqual(org.Name.ProvidedDate.ToXmlDateString(), result.Root.Element("date").Value);
            Assert.IsNotNull(result.Root.Element("providedBy"));

            
//            Assert.AreEqual(result.ToString(),"<Descriptor xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">
//  <descr>OrgName</descr>
//  <lang>en</lang>
//  <date>2016-05-14</date>
//  <providedBy>
//    <orgId>
//      <id>N1234</id>
//      <class>CAGE</class>
//    </orgId>
//  </providedBy>
//</Descriptor>")
        }
    }

    public static class DateTimeExtensions
    {
        public static string ToXmlDateString(this DateTime dateTime)
        {
            return String.Format("{0}-{1}-{2}", dateTime.Year.ToString("0000"), dateTime.Month.ToString("00"), dateTime.Day.ToString("00"));
        }
    }
}
