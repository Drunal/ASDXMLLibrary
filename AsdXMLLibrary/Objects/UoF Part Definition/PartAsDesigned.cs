using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned : SerializeBase, ICanBeReferenced<PartReference>
    {
        private PartReference _reference = null;
        
        public MultipleValues<ProvidedIdentifier<PartIdentifierClassification>> PartIds { get; set; }
        public MultipleValues<ProvidedDescriptor> PartNames { get; set; }

        public DatedClassification DemilitarizationClass { get; set; }
        public DatedDescriptor SpecialHandlingRequirement { get; set; }
        public DatedClassification MaturityClass { get; set; }
        public DatedDescriptor ObsolescenceRiskAssessment { get; set; }
        

        #region Constructors
        public PartAsDesigned()
        {
            PartIds = new MultipleValues<ProvidedIdentifier<PartIdentifierClassification>>(
                //() => new ProvidedIdentifier<PartIdentifierClassification>()
                );
            PartNames = new MultipleValues<ProvidedDescriptor>();

            DemilitarizationClass = new DatedClassification(typeof(DemilitarizationClassification));
            SpecialHandlingRequirement = new DatedDescriptor();
            MaturityClass = new DatedClassification(typeof(MaturityClassification));
            ObsolescenceRiskAssessment = new DatedDescriptor();
        }
        public PartAsDesigned(string identifier)
            : this()
        {
            PartIds.Primary.ID = identifier;
        }
        #endregion

        public PartReference GetReference()
        {
            if (_reference == null)
            {
                // TODO: if this is a reference, it would be good to update the _reference when the Primary changes, right?
                _reference = new PartReference(this);
            }
            return _reference;
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement part = new XElement(ns + elementName);
            part.Add(PartIds.CreateXML(Constants.PartAsDesignedPartIdElementName, ns));
            part.Add(PartNames.CreateXML(Constants.PartAsDesignedPartNameElementName, ns));

            // for some reason the elements of the hwPart class need to go in here!
                        
            part.Add(DemilitarizationClass.CreateXML(Constants.PartDemilitarizationClassElementName, ns));
            if(SpecialHandlingRequirement.HasValue)
                part.Add(SpecialHandlingRequirement.CreateXML(Constants.PartSpecialHandlingRequirementElementName, ns));
            part.Add(MaturityClass.CreateXML(Constants.PartMaturityClassElementName, ns));
            if(ObsolescenceRiskAssessment.HasValue)
                part.Add(ObsolescenceRiskAssessment.CreateXML(Constants.PartObsolescenceRiskAssessmentElementName, ns));

            // but the swPart class nees to go in here!

            return part;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null) return false;
            PartIds.ReadfromXML(element.Elements(ns + Constants.PartAsDesignedPartIdElementName), ns);
            PartNames.ReadfromXML(element.Elements(ns + Constants.PartAsDesignedPartNameElementName), ns);
            
            DemilitarizationClass.ReadfromXML(element.Element(ns + Constants.PartDemilitarizationClassElementName), ns);
            SpecialHandlingRequirement.ReadfromXML(element.Element(ns + Constants.PartSpecialHandlingRequirementElementName), ns);
            MaturityClass.ReadfromXML(element.Element(ns + Constants.PartMaturityClassElementName), ns);
            ObsolescenceRiskAssessment.ReadfromXML(element.Element(ns + Constants.PartObsolescenceRiskAssessmentElementName), ns);

            return true;
        }
        #endregion

        
    }
}
