using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    [XmlRoot(ElementName="swPart")]
    public class SoftwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        [XmlElement(ElementName = "swType")]
        public Classification SoftwareType { get; set; }

        [XmlElement(ElementName="swSize")]
        public Property<BinaryUnitClassification> SoftwarePartSize { get; set; }
        
        #endregion

        #region XML Handling Properties
        [XmlIgnore]
        public bool SoftwareTypeSpecified { get { return SoftwareType.HasValue; } }
        [XmlIgnore]
        public bool SoftwarePartSizeSpecified { get { return SoftwarePartSize != null && SoftwarePartSize.HasValue; } }
        #endregion

        public SoftwarePartAsDesigned()
            : base(Constants.SoftwarePartAsDesignedElementName)
        {
            SoftwareType = new Classification(typeof(SoftwareTypeClassification));
            SoftwarePartSize = new Property<BinaryUnitClassification>();
        }

        #region Serialize Functions
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement swPart = base.GetXML(elementName, ns);
            if (SoftwareTypeSpecified)
                swPart.Add(SoftwareType.GetXML(Constants.SoftwareTypeElementName, ns));
            if (SoftwarePartSizeSpecified)
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
