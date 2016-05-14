﻿using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
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
        public Classification<HazardousClassClassification> HazardousClass { get; set; }
        // Authorized Life
        [XmlElement(ElementName = "ftc")]
        public Classification<FitmentRequirementClassification> FitmentRequirement { get; set; }
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
        protected bool HazardousClassSpecified { get { return HazardousClass.HasValue; } }
        [XmlIgnore]
        protected bool FitmentRequirementSpecified { get { return FitmentRequirement.HasValue; } }
        [XmlIgnore]
        protected bool ElectromagneticIncompatibleSpecified { get { return ElectromagneticIncompatible.HasValue; } }
        [XmlIgnore]
        protected bool ElectrostaticSensitiveSpecified { get { return ElectrostaticSensitive.HasValue; } }
        [XmlIgnore]
        protected bool ElectromagnecticSensitiveSpecified { get { return ElectromagnecticSensitive.HasValue; } }
        [XmlIgnore]
        protected bool MagneticSensitiveSpecified { get { return MagneticSensitive.HasValue; } }
        [XmlIgnore]
        protected bool RadiationSensitiveSpecified { get { return RadiationSensitive.HasValue; } }
        #endregion

        #endregion

        public HardwarePartAsDesigned()
        {
            HazardousClass = new Classification<HazardousClassClassification>();
            FitmentRequirement = new Classification<FitmentRequirementClassification>();
        }
    }
}
