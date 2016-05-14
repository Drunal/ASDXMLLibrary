using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned
    {
        [XmlElement(ElementName="partId")]
        public Identifier<PartIdentifierClassification> PartID { get; set; }
        [XmlElement(ElementName = "name")]
        public Descriptor PartName { get; set; }

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool PartNameSpecified { get { return PartName != null; } }
        #endregion

        public PartAsDesigned()
        {
            PartID = new Identifier<PartIdentifierClassification>();
        }
    }
}
