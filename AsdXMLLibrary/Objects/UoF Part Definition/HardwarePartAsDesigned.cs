using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
	/// <summary>
	/// Chapter 19 - 4.4 UoF Part Definition
	/// Not supported yet: 
	/// <list type="simple">
	///     <item>PartAsDesignedPartsList</item>
	///     <item>ContainedSubstance</item>
	///     <item>AlternatePartAsDesigned</item>
	/// </list>
	/// </summary>
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
		public CodedClassification LogisticsCategory { get; set; }
		public CodedClassification Repairability { get; set; }
		public MultipleValues<CodedClassification> RepairabilityStrategy { get; set; }
		public CodedClassification MaintenanceStart { get; set; }
		public MultipleValues<Descriptor> WasteProductsInUseDisposalDescription { get; set; }
		public MultipleValues<Descriptor> WasteProductsPlannedDisposalDescription { get; set; }
		public MultipleValues<DatedClassification> EnvironmentalAspectInUseClass { get; set; }
		public MultipleValues<DatedClassification> EnvironmentalAspectPlannedDisposalClass { get; set; }
		public MultipleValues<Property<RelativeUnit>> ScrapRate { get; set; }
		public MultipleValues<Property<RelativeUnit>> ConsumptionRate { get; set; }
		#endregion

		public HardwarePartAsDesigned()
		{
			AuthorizedLife = new AuthorizedLifeProperty();
			HazardousClass = new CodedClassification(typeof(HazardousClassClassification));
			FitmentRequirement = new CodedClassification(typeof(FitmentRequirementClassification));

			LogisticsCategory = new CodedClassification(typeof(LogisticsCategoryClassification));
			Repairability = new CodedClassification(typeof(RepairabilityClassification));
			RepairabilityStrategy = new MultipleValues<CodedClassification>(
				() => new CodedClassification(typeof(RepairabilityStrategyClassification))
				);
			MaintenanceStart = new CodedClassification(typeof(MaintenanceStartClassification));
			WasteProductsInUseDisposalDescription = new MultipleValues<Descriptor>();
			WasteProductsPlannedDisposalDescription = new MultipleValues<Descriptor>();
			EnvironmentalAspectInUseClass = new MultipleValues<DatedClassification>(
				() => new DatedClassification(typeof(EnvironmentalAspectInUseClassification))
				);
			EnvironmentalAspectPlannedDisposalClass = new MultipleValues<DatedClassification>(
				() => new DatedClassification(typeof(EnvironmentalAspectPlannedDisposalClassification))
				);
			ScrapRate = new MultipleValues<Property<RelativeUnit>>();
			ConsumptionRate = new MultipleValues<Property<RelativeUnit>>();
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
			// add in inverse order, so that we do not need to update the insertLocation all the time.
			insertLocation.AddAfterSelf(CreateSupportData(ns));
			insertLocation.AddAfterSelf(CreateDesignData(ns));

			return hwPart;
		}

		private IEnumerable<XElement> CreateSupportData(XNamespace ns)
		{
			List<XElement> result = new List<XElement>();
			
			result.Add(LogisticsCategory.CreateXML(Constants.HardwarePartLogisticsCategoryElementName, ns));
			result.Add(Repairability.CreateXML(Constants.HardwarePartRepairabilityElementName, ns));
			result.AddRange(ScrapRate.CreateXML(Constants.HardwarePartScrapRateElementName, ns));
			result.AddRange(RepairabilityStrategy.CreateXML(Constants.HardwarePartRepairabilityStrategyElementName, ns));
			result.Add(MaintenanceStart.CreateXML(Constants.HardwarePartMaintenanceStartElementName, ns));
			result.AddRange(WasteProductsInUseDisposalDescription.CreateXML(Constants.HardwarePartWasteProductsInUseDisposalDescriptionElementName, ns));
			result.AddRange(WasteProductsPlannedDisposalDescription.CreateXML(Constants.HardwarePartWasteProductsPlannedDisposalDescriptionElementName, ns));
			result.AddRange(EnvironmentalAspectInUseClass.CreateXML(Constants.HardwarePartEnvironmentalAspectInUseClassElementName, ns));
			result.AddRange(EnvironmentalAspectPlannedDisposalClass.CreateXML(Constants.HardwarePartEnvironmentalAspectPlannedDisposalClassElementName, ns));
			result.AddRange(ConsumptionRate.CreateXML(Constants.HardwarePartConsumptionRateElementName, ns));

			return result;
		}

		private IEnumerable<XElement> CreateDesignData(XNamespace ns)
		{
			
			yield return HazardousClass.CreateXML(Constants.HardwarePartHazardousClassElementName, ns);
			yield return AuthorizedLife.CreateXML(Constants.HardwarePartOperationalAuthorizedLife, ns);
			yield return FitmentRequirement.CreateXML(Constants.HardwarePartFitmentRequirementElementName, ns);
			
			if (ElectromagneticIncompatible.HasValue)
				yield return new XElement(ns + Constants.HardwarePartElectromagneticIncompatibleElementName, ElectromagneticIncompatible);
			if (ElectrostaticSensitive.HasValue)
				yield return new XElement(ns + Constants.HardwarePartElectrostaticSensitiveElementName, ElectrostaticSensitive);
			if (ElectromagnecticSensitive.HasValue)
				yield return new XElement(ns + Constants.HardwarePartElectromagneticSensitiveElementName, ElectromagnecticSensitive);
			if (MagneticSensitive.HasValue)
				yield return new XElement(ns + Constants.HardwarePartMagneticSensitiveElementName, MagneticSensitive);
			if (RadiationSensitive.HasValue)
				yield return new XElement(ns + Constants.HardwarePartRadiationSensitiveElementName, RadiationSensitive);
			
		}

		public override bool ReadfromXML(XElement element, XNamespace ns)
		{
			if (element == null) return false;
			// this should read the base information
			base.ReadfromXML(element, ns);

			ReadDesignData(element, ns);
			ReadSupportData(element, ns);

			return true;
		}

		private void ReadSupportData(XElement element, XNamespace ns)
		{
			LogisticsCategory.ReadfromXML(element.Element(ns + Constants.HardwarePartLogisticsCategoryElementName), ns);
			Repairability.ReadfromXML(element.Element(ns + Constants.HardwarePartRepairabilityElementName), ns);
			ScrapRate.ReadfromXML(element.Elements(ns + Constants.HardwarePartScrapRateElementName), ns);
			RepairabilityStrategy.ReadfromXML(element.Elements(ns + Constants.HardwarePartRepairabilityStrategyElementName), ns);
			MaintenanceStart.ReadfromXML(element.Element(ns + Constants.HardwarePartMaintenanceStartElementName), ns);
			WasteProductsInUseDisposalDescription.ReadfromXML(element.Elements(ns + Constants.HardwarePartWasteProductsInUseDisposalDescriptionElementName), ns);
			WasteProductsPlannedDisposalDescription.ReadfromXML(element.Elements(ns + Constants.HardwarePartWasteProductsPlannedDisposalDescriptionElementName), ns);
			EnvironmentalAspectInUseClass.ReadfromXML(element.Elements(ns + Constants.HardwarePartEnvironmentalAspectInUseClassElementName), ns);
			EnvironmentalAspectPlannedDisposalClass.ReadfromXML(element.Elements(ns + Constants.HardwarePartEnvironmentalAspectPlannedDisposalClassElementName), ns);
			ConsumptionRate.ReadfromXML(element.Elements(ns + Constants.HardwarePartConsumptionRateElementName), ns);
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
