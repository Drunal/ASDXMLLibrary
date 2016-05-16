using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using AsdXMLLibrary.Objects;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace AsdXMLLibrary.Tests
{
    [TestClass]
    public class BaseTests
    {
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

            var ms = new MemoryStream();
            ContentManager.SerializeToStream<Descriptor>(org.Name, ms);
            ms.Position = 0;
            XDocument result = XDocument.Load(ms);

//<Descriptor xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">
//  <descr>OrgName</descr>
//  <lang>en</lang>
//  <date>2016-05-14</date>
//  <providedBy>
//    <orgId>
//      <id>N1234</id>
//      <class>CAGE</class>
//    </orgId>
//  </providedBy>
//</Descriptor>"

            Assert.AreEqual(org.Name.Text, result.XPathSelectElement("/*", "descr", 1).Value);
            Assert.AreEqual(org.Name.Language.Value, result.XPathSelectElement("/*", "lang", 2).Value);
            Assert.AreEqual(org.Name.ProvidedDate.ToXmlDateString(), result.XPathSelectElement("/*", "date", 3).Value);
            XElement providedBy = result.XPathSelectElement("/*", "providedBy", 4);
            Assert.IsNotNull(providedBy);
            Assert.AreEqual(org.Name.ProvidedBy.OrgID.ID, providedBy.XPathSelectElement("orgId", "id", 1).Value);
            Assert.AreEqual(org.Name.ProvidedBy.OrgID.Class.Value, providedBy.XPathSelectElement("orgId", "class", 2).Value);
        }
    }
}
