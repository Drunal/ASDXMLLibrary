using AsdXMLLibrary.Base;
using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class DescriptorTests : TestBase
    {
        [TestMethod]
        public void SerializeMinimalDescriptor()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            Organization result = new Organization();

            result.Name = ObjectStreamtoObjectNew(expected.Name);
            result.Name.ShouldDeepEqualwithDate(expected.Name);
        }

        [TestMethod]
        public void SerializeCompleteDescriptor()
        {
            Organization expected = TestObjects.OrganizationFull;
            Organization result = new Organization();
            result.Name = ObjectStreamtoObjectNew(expected.Name);
            result.Name.ShouldDeepEqualwithDate(expected.Name);
        }

        [TestMethod]
        public void SerializeMinimalDatedDescriptor()
        {
            // TODO: take this from Testobjects
            DatedDescriptor expected = new DatedDescriptor();
            expected.Text = "datedDescriptorText";
            expected.ProvidedDate = DateTime.Now;

            DatedDescriptor result = ObjectStreamtoObjectNew(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteDatedDescriptor()
        {
            // TODO: take this from Testobjects
            DatedDescriptor expected = new DatedDescriptor();
            expected.Text = "datedDescriptorText";
            expected.Language.Value = "EN";
            expected.ProvidedDate = DateTime.Now;
            expected.ProvidedBy.SetTarget(TestObjects.OrganizationMinimum);
            
            DatedDescriptor result = ObjectStreamtoObjectNew(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeMinimalProvidedDescriptor()
        {
            // TODO: take this from Testobjects
            ProvidedDescriptor expected = new ProvidedDescriptor();
            expected.Text = "providedDescriptorText";

            ProvidedDescriptor result = ObjectStreamtoObjectNew(expected);
            result.ShouldDeepEqualwithDate(expected);
        }

        [TestMethod]
        public void SerializeCompleteProvidedDescriptor()
        {
            // TODO: take this from Testobjects
            ProvidedDescriptor expected = new ProvidedDescriptor();
            expected.Text = "providedDescriptorText";
            expected.Language.Value = "EN";
            expected.ProvidedBy.SetTarget(TestObjects.OrganizationMinimum);

            ProvidedDescriptor result = ObjectStreamtoObjectNew(expected);
            result.ShouldDeepEqualwithDate(expected);
        }
       

        [TestMethod]
        public void ShouldThrowOnMissingName()
        {
            Organization expected = TestObjects.OrganizationMinimum;
            // remove the Name;
            expected.Name.Text = string.Empty;
            Organization result = new Organization();
            ExceptionAssert.Throws<XmlSchemaValidationException>(
                () => ObjectStreamtoObjectNew(expected.Name)                
            );
        }

        [TestMethod]
        public void SerializeMultipleDescriptors()
        {
            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMultipleNames;

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();
            result = ObjectStreamtoObject(expected);
            result.PartNames.ShouldDeepEqualwithDate(expected.PartNames);
        }
    }
}
