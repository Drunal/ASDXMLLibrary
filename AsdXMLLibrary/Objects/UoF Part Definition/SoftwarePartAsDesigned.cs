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

        public Property<BinaryUnitClassification> SoftwarePartSize { get; set; }
        #endregion


        public SoftwarePartAsDesigned()
        {
            SoftwareType = new Classification(typeof(SoftwareTypeClassification));
            SoftwarePartSize = new Property<BinaryUnitClassification>();
        }

        #region Serialize Functions
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement swPart = base.GetXML(elementName, ns);
            if (SoftwareType.HasValue)
                swPart.Add(SoftwareType.GetXML(Constants.SoftwareTypeElementName, ns));
            if (SoftwarePartSize.HasValue)
                swPart.Add(SoftwarePartSize.GetXML(Constants.SoftwarePartSizeElementName, ns));

            return swPart;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read the base information
            base.ReadfromXML(element, ns);
            SoftwareType.ReadfromXML(element.Element(ns + Constants.SoftwareTypeElementName), ns);
            return true;
        }
        #endregion
    }
}
