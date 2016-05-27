using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public class HardwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        [XmlElement(ElementName = "haz")]
        public Classification HazardousClass { get; set; }
        // Authorized Life
        [XmlElement(ElementName = "ftc")]
        public Classification FitmentRequirement { get; set; }
        [XmlElement(ElementName = "emi")]
        public bool? ElectromagneticIncompatible { get; set; }
        [XmlElement(ElementName = "ess")]
        public bool? ElectrostaticSensitive { get; set; }
        [XmlElement(ElementName = "ems")]
        public bool? ElectromagnecticSensitive { get; set; }
        [XmlElement(ElementName = "mse")]
        public bool? MagneticSensitive { get; set; }
        [XmlElement(ElementName = "rse")]
        public bool? RadiationSensitive { get; set; }
                
        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool HazardousClassSpecified { get { return HazardousClass.HasValue; } }
        [XmlIgnore]
        public bool FitmentRequirementSpecified { get { return FitmentRequirement.HasValue; } }
        [XmlIgnore]
        public bool ElectromagneticIncompatibleSpecified { get { return ElectromagneticIncompatible.HasValue; } }
        [XmlIgnore]
        public bool ElectrostaticSensitiveSpecified { get { return ElectrostaticSensitive.HasValue; } }
        [XmlIgnore]
        public bool ElectromagnecticSensitiveSpecified { get { return ElectromagnecticSensitive.HasValue; } }
        [XmlIgnore]
        public bool MagneticSensitiveSpecified { get { return MagneticSensitive.HasValue; } }
        [XmlIgnore]
        public bool RadiationSensitiveSpecified { get { return RadiationSensitive.HasValue; } }
        #endregion

        #endregion

        public HardwarePartAsDesigned()
        {
            HazardousClass = new Classification(typeof(HazardousClassClassification));
            FitmentRequirement = new Classification(typeof(FitmentRequirementClassification));
        }


        public PartReference Reference
        {
            get
            {
                return (PartReference)this.GetReference();
            }
        }
    }
}
