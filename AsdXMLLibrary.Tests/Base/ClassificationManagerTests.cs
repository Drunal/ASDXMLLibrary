using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsdXMLLibrary.Tests.Base
{
    [TestClass]
    public class ClassificationManagerTests : TestBase
    {

        private readonly string TestValue = "value";

        [TestInitialize]
        public void TestSetup()
        {
            // setup Classification Manager to avoid "already initialized" exception, when not tested for.
            ClassificationManager.ClearClassifications();
        }

        [TestMethod]
        public void SetExistingClassification()
        {
            ClassificationManager.Add(new TestClassification { TestValue });
            var testClass = new Classification(typeof(TestClassification));
            testClass.Value = TestValue;
            Assert.AreEqual(TestValue, testClass.Value);
        }

        [TestMethod]
        public void ShouldThrowOnNotConfiguredClassification()
        {
            Classification testClass = null;
            ExceptionAssert.Throws<ClassificationException>(
                () => testClass = new Classification(typeof(TestClassification)),
                string.Format("Classification '{0}' is not initialized!", typeof(TestClassification).Name)
            );
        }

        [TestMethod]
        public void ShouldThrowOnInvalidClassificationValue()
        {
            string invalidValue = "invalid";

            ClassificationManager.Add(new TestClassification { TestValue });
            Classification testClass = new Classification(typeof(TestClassification));
            ExceptionAssert.Throws<ClassificationException>(
                () =>  testClass.Value = invalidValue,
                string.Format("Value '{0}' is not a valid value for {1}!", invalidValue, typeof(TestClassification).Name)
            );
        }

        [TestMethod]
        public void ShouldThrowOnDoublicatedClassificationConfiguration()
        {
            ClassificationManager.Add(new TestClassification { TestValue });
            ExceptionAssert.Throws<ClassificationException>(
                () => ClassificationManager.Add(new TestClassification { TestValue }),
                string.Format("Classification '{0}' already initialized!", typeof(TestClassification).Name)
            );
        }


        [TestCleanup]
        public void TestCleanup()
        {
            // reset Classification Manager to avoid conflicts with other tests.
            ClassificationManager.FillDefaultValues();
        }


        private class TestClassification : ClassificationBase { }
    }
}
