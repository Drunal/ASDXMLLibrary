using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public class HardwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        public Classification HazardousClass { get; set; }
        // Authorized Life
        public Classification FitmentRequirement { get; set; }
        //[XmlElement(ElementName = "emi")]
        public bool? ElectromagneticIncompatible { get; set; }
        //[XmlElement(ElementName = "ess")]
        public bool? ElectrostaticSensitive { get; set; }
        //[XmlElement(ElementName = "ems")]
        public bool? ElectromagnecticSensitive { get; set; }
        //[XmlElement(ElementName = "mse")]
        public bool? MagneticSensitive { get; set; }
        //[XmlElement(ElementName = "rse")]
        public bool? RadiationSensitive { get; set; }
        #endregion

        public HardwarePartAsDesigned()
            : base(Constants.HardwarePartAsDesignedElementName)
        {
            HazardousClass = new Classification(typeof(HazardousClassClassification));
            FitmentRequirement = new Classification(typeof(FitmentRequirementClassification));
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement hwPart = base.CreateXML(elementName, ns);
            if (HazardousClass.HasValue)
                hwPart.Add(HazardousClass.CreateXML(Constants.HardwarePartHazardousClassElementName, ns));
            if (FitmentRequirement.HasValue)
                hwPart.Add(FitmentRequirement.CreateXML(Constants.HardwarePartFitmentRequirementElementName, ns));

            return hwPart;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read the base information
            base.ReadfromXML(element, ns);
            HazardousClass.ReadfromXML(element.Element(ns + Constants.HardwarePartHazardousClassElementName), ns);
            FitmentRequirement.ReadfromXML(element.Element(ns + Constants.HardwarePartFitmentRequirementElementName), ns);
            return true;
        }
        #endregion
    }
}
