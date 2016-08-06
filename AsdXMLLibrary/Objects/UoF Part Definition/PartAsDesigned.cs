using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    [XmlInclude(typeof(SoftwarePartAsDesigned))]
    [XmlInclude(typeof(HardwarePartAsDesigned))]
    public abstract class PartAsDesigned : SerializeBase, ICanBeReferenced
    {
        [XmlElement(ElementName = "partId")]
        public MultipleIdentifier<PartIdentifierClassification> PartIds { get; set; }

        [XmlElement(ElementName="name")]
        public MultipleDescriptor PartNames { get; set; }

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool PartNameSpecified { get { return PartNames != null && PartNames.Count > 0; } }
        #endregion

        public PartAsDesigned()
        {
            PartIds = new MultipleIdentifier<PartIdentifierClassification>();
            PartNames = new MultipleDescriptor();
        }
        public PartAsDesigned(string identifier)
            : this()
        {
            PartIds.MainID.ID = identifier;
        }

        #region Serialize Functions
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement part = new XElement(ns + elementName);
            foreach (var id in PartIds)
                part.Add(id.GetXML(Constants.PartAsDesignedPartIdElementName, ns));
            foreach (var name in PartNames)
                part.Add(name.GetXML(Constants.PartAsDesignedPartNameElementName, ns));

            return part;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            foreach (XElement idElement in element.Elements(ns + Constants.PartAsDesignedPartIdElementName)) 
            {
                ProvidedIdentifier<PartIdentifierClassification> id = new ProvidedIdentifier<PartIdentifierClassification>();
                id.ReadfromXML(idElement, ns);
                PartIds.Add(id);
            }
                
            foreach (XElement nameElement in element.Elements(ns + Constants.PartAsDesignedPartNameElementName))
            {
                ProvidedDescriptor descr = new ProvidedDescriptor(Constants.PartAsDesignedPartNameElementName);
                descr.ReadfromXML(nameElement, ns);
                PartNames.Add(descr);
            }

            return true;
        }
        #endregion
    }
}
