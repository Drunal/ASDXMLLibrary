using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class ClassificationTests : SerializeTestBase
    {
        protected override string TestRootElementName { get { return "Classification"; } }

        [TestMethod]
        public void SerializeSimpleDatedClassification()
        {

            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.MaturityClass.Value = "COTS";

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();

            result.MaturityClass = ObjectStreamtoObject(expected.MaturityClass);
            result.MaturityClass.ShouldDeepEqualwithDate(expected.MaturityClass);
        }

        [TestMethod]
        public void SerializeFullDatedClassification()
        {

            SoftwarePartAsDesigned expected = TestObjects.SoftwarePartMinimum;
            expected.MaturityClass.Value = "COTS";
            expected.MaturityClass.ProvidedDate = DateTime.Now;

            SoftwarePartAsDesigned result = new SoftwarePartAsDesigned();

            result.MaturityClass = ObjectStreamtoObject(expected.MaturityClass);
            result.MaturityClass.ShouldDeepEqualwithDate(expected.MaturityClass);
        }
    }
}
