using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public class SoftwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        public Classification SoftwareType { get; set; }

        public Property<SoftwareSizeUnit> SoftwarePartSize { get; set; }
        #endregion


        public SoftwarePartAsDesigned()
        {
            SoftwareType = new Classification(typeof(SoftwareTypeClassification));
            SoftwarePartSize = new Property<SoftwareSizeUnit>();
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement swPart = base.CreateXML(elementName, ns);
            if (SoftwareType.HasValue)
                swPart.Add(SoftwareType.CreateXMLWithAdditionalLevel(Constants.SoftwareTypeElementName, Constants.CodeElementName, ns));
            if (SoftwarePartSize.HasValue)
                swPart.Add(SoftwarePartSize.CreateXML(Constants.SoftwarePartSizeElementName, ns));

            return swPart;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read the base information
            base.ReadfromXML(element, ns);
            SoftwareType.ReadfromXMLWithAdditionalLevel(element.Element(ns + Constants.SoftwareTypeElementName), Constants.CodeElementName, ns);
            SoftwarePartSize.ReadfromXML(element.Element(ns + Constants.SoftwarePartSizeElementName), ns);
            return true;
        }
        #endregion
    }
}
