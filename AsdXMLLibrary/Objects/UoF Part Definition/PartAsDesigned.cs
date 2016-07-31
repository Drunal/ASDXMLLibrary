using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Collections.Generic;
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

        public PartAsDesigned(string elementName)
            : base(elementName)
        {
            PartIds = new MultipleIdentifier<PartIdentifierClassification>();
            PartNames = new MultipleDescriptor();
        }
        public PartAsDesigned(string elementName, string identifier)
            : this(elementName)
        {
            PartIds.MainID.ID = identifier;
        }

        #region Serialize Functions
        public override XElement GetXML(XNamespace ns, bool forceElement = false)
        {
            throw new System.NotImplementedException();
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
