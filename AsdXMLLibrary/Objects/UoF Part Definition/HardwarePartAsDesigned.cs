using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public class HardwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        public AuthorizedLifeProperty AuthorizedLife { get; set; }

        public CodedClassification HazardousClass { get; set; }
        public CodedClassification FitmentRequirement { get; set; }
        // emi
        public bool? ElectromagneticIncompatible { get; set; }
        // ess
        public bool? ElectrostaticSensitive { get; set; }
        // ems
        public bool? ElectromagnecticSensitive { get; set; }
        // mse
        public bool? MagneticSensitive { get; set; }
        // rse
        public bool? RadiationSensitive { get; set; }
        #endregion

        #region SupportData
        public Classification LogisticsCategory { get; set; }
        public Classification Repairability { get; set; }
        public MultipleValues<Classification> RepairabilityStrategy { get; set; }
        public Classification MaintenanceStart { get; set; }
        public MultipleValues<Descriptor> WasteProductsInUseDisposalDescription { get; set; }
        public MultipleValues<Descriptor> WasteProductsPlannedDisposalDescription { get; set; }
        public MultipleValues<DatedClassification> EnvironmentalAspectInUseClass { get; set; }
        public MultipleValues<DatedClassification> EnvironmentalAspectPlannedDisposalClass { get; set; }
        public MultipleValues<Property<TimeUnit>> ScrapRate { get; set; }
        public MultipleValues<Property<TimeUnit>> ConsumptionRate { get; set; }
        #endregion

        public HardwarePartAsDesigned()
        {
            AuthorizedLife = new AuthorizedLifeProperty();
            HazardousClass = new CodedClassification(typeof(HazardousClassClassification));
            FitmentRequirement = new CodedClassification(typeof(FitmentRequirementClassification));
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement hwPart = base.CreateXML(elementName, ns, forceElement);
            if (hwPart == null) return null;
            // actually, this should be added _after_ the partNames but before the other base stuff
            // so we need to find the insert location from the base.
            XElement insertLocation = hwPart.Elements(ns + Constants.PartAsDesignedPartNameElementName, ns + Constants.PartAsDesignedPartIdElementName).LastOrDefault();
            if (insertLocation == null)
            {
                // TODO: write to log, that this part does not have a name or a id, which is kinda mandatory in S3000L v1.1
                return null;
            }

            CreateDesignData(ns, insertLocation);

            return hwPart;
        }

        private void CreateDesignData(XNamespace ns, XElement insertLocation)
        {
            // add in inverse order, so that we do not need to update the insertLocation
            if (RadiationSensitive.HasValue)
                insertLocation.AddAfterSelf(new XElement(ns + Constants.HardwarePartRadiationSensitiveElementName, RadiationSensitive));
            if (MagneticSensitive.HasValue)
                insertLocation.AddAfterSelf(new XElement(ns + Constants.HardwarePartMagneticSensitiveElementName, MagneticSensitive));
            if (ElectromagnecticSensitive.HasValue)
                insertLocation.AddAfterSelf(new XElement(ns + Constants.HardwarePartElectromagneticSensitiveElementName, ElectromagnecticSensitive));
            if (ElectrostaticSensitive.HasValue)
                insertLocation.AddAfterSelf(new XElement(ns + Constants.HardwarePartElectrostaticSensitiveElementName, ElectrostaticSensitive));
            if (ElectromagneticIncompatible.HasValue)
                insertLocation.AddAfterSelf(new XElement(ns + Constants.HardwarePartElectromagneticIncompatibleElementName, ElectromagneticIncompatible));

            if (FitmentRequirement.HasValue)
                insertLocation.AddAfterSelf(FitmentRequirement.CreateXML(Constants.HardwarePartFitmentRequirementElementName, ns));
            if (AuthorizedLife.HasValue)
                insertLocation.AddAfterSelf(AuthorizedLife.CreateXML(Constants.HardwarePartOperationalAuthorizedLife, ns));
            if (HazardousClass.HasValue)
                insertLocation.AddAfterSelf(HazardousClass.CreateXML(Constants.HardwarePartHazardousClassElementName, ns));
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null) return false;
            // this should read the base information
            base.ReadfromXML(element, ns);

            ReadDesignData(element, ns);

            return true;
        }

        private void ReadDesignData(XElement element, XNamespace ns)
        {
			HazardousClass.ReadfromXML(element.Element(ns + Constants.HardwarePartHazardousClassElementName), ns);
            FitmentRequirement.ReadfromXML(element.Element(ns + Constants.HardwarePartFitmentRequirementElementName), ns);
            AuthorizedLife.ReadfromXML(element.Element(ns + Constants.HardwarePartOperationalAuthorizedLife), ns);

            XElement tmp = element.Element(ns + Constants.HardwarePartElectromagneticIncompatibleElementName);
            if (tmp != null)
                ElectromagneticIncompatible = XmlConvert.ToBoolean(tmp.Value);

            tmp = element.Element(ns + Constants.HardwarePartElectrostaticSensitiveElementName);
            if (tmp != null)
                ElectrostaticSensitive = XmlConvert.ToBoolean(tmp.Value);

            tmp = element.Element(ns + Constants.HardwarePartElectromagneticSensitiveElementName);
            if (tmp != null)
                ElectromagnecticSensitive = XmlConvert.ToBoolean(tmp.Value);

            tmp = element.Element(ns + Constants.HardwarePartMagneticSensitiveElementName);
            if (tmp != null)
                MagneticSensitive = XmlConvert.ToBoolean(tmp.Value);

            tmp = element.Element(ns + Constants.HardwarePartRadiationSensitiveElementName);
            if (tmp != null)
                RadiationSensitive = XmlConvert.ToBoolean(tmp.Value);
        }
        #endregion
    }
}
