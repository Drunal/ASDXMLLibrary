using AsdXMLLibrary.Base.Classifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsdXMLLibrary.Tests.Helper
{
    [TestClass]
    public abstract class TestBase
    {
        
        [TestInitialize]
        public void Initialize()
        {
            // reset Classifications to defaults
            ClassificationManager.ClearClassifications();
            ClassificationManager.FillDefaultValues();
        }
    }
}
