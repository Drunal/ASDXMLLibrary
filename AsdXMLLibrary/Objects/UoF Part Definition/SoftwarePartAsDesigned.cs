using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public class SoftwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        public CodedClassification SoftwareType { get; set; }

        public Property<SoftwareSizeUnit> SoftwarePartSize { get; set; }
        #endregion


        public SoftwarePartAsDesigned()
        {
            SoftwareType = new CodedClassification(typeof(SoftwareTypeClassification));
            SoftwarePartSize = new Property<SoftwareSizeUnit>();
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement swPart = base.CreateXML(elementName, ns);
            if (SoftwareType.HasValue)
                swPart.Add(SoftwareType.CreateXML(Constants.SoftwareTypeElementName, ns));
            if (SoftwarePartSize.HasValue)
                swPart.Add(SoftwarePartSize.CreateXML(Constants.SoftwarePartSizeElementName, ns));

            return swPart;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null) return false;
            // this should read the base information
            base.ReadfromXML(element, ns);
            SoftwareType.ReadfromXML(element.Element(ns + Constants.SoftwareTypeElementName), ns);
            SoftwarePartSize.ReadfromXML(element.Element(ns + Constants.SoftwarePartSizeElementName), ns);
            return true;
        }
        #endregion
    }
}
