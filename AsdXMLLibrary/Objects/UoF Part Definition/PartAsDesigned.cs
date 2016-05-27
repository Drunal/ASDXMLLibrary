using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned : ICanBeReferenced
    {
        [XmlElement(ElementName = "partId")]
        public Identifier<PartIdentifierClassification> PartId { get; set; }

        [XmlElement(ElementName = "name")]
        public Descriptor PartName { get; set; }

        private PartReference _reference;

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool PartNameSpecified { get { return PartName != null; } }
        #endregion

        public PartAsDesigned()
        {
            PartId = new Identifier<PartIdentifierClassification>();
        }

        public IAmReference GetReference()
        {
            if (_reference == null)
                _reference = new PartReference();
            if (_reference.PartId != this.PartId)
                _reference.PartId = this.PartId;

            return _reference;
        }
    }
}
