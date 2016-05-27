using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned : ICanBeReferenced
    {
        [XmlElement(ElementName = "partId")]
        public MultipleIdentifier<PartIdentifierClassification> PartIds { get; set; }

        [XmlElement(ElementName="name")]
        public MultipleDescriptor PartNames { get; set; }

        private PartReference _reference;

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool PartNameSpecified { get { return PartNames != null && PartNames.Count > 0; } }
        #endregion

        public PartAsDesigned()
        {
            //PartIds = new List<Identifier<PartIdentifierClassification>>();
            PartIds = new MultipleIdentifier<PartIdentifierClassification>();
            PartNames = new MultipleDescriptor();
        }
        public PartAsDesigned(string identifier)
            : this()
        {
            PartIds.MainID.ID = identifier;
        }

        public IAmReference GetReference()
        {
            if (_reference == null)
                _reference = new PartReference();
            if (_reference.PartId != this.PartIds[0])
                _reference.PartId = this.PartIds[0];

            return _reference;
        }
    }
}
