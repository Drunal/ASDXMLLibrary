using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned : ICanBeReferenced
    {
        /// <summary>
        /// provides access to the "main Id", this is the first entry in the PartIds list
        /// </summary>
        [XmlIgnore]
        public Identifier<PartIdentifierClassification> PartId
        {
            get
            {
                if (PartIds.Count == 0)
                    PartIds.Add(new Identifier<PartIdentifierClassification>());
                return PartIds[0];
            }
            set 
            {
                if(PartIds.Count > 0)
                    PartIds[0] = value;
                else 
                    PartIds.Add(value);
            }
        }

        [XmlElement(ElementName = "partId")]
        public List<Identifier<PartIdentifierClassification>> PartIds { get; set; }

        /// <summary>
        /// provides access to the "main Name", this is the first entry in <see cref="PartNames"/>.
        /// </summary>
        [XmlIgnore]
        public Descriptor PartName
        {
            get
            {
                if (PartNames.Count == 0)
                    PartNames.Add(new Descriptor());
                return PartNames[0];
            }
            set
            {
                if (PartNames.Count > 0)
                    PartNames[0] = value;
                else
                    PartNames.Add(value);
            }
        }

        [XmlElement(ElementName = "name")]
        public List<Descriptor> PartNames { get; set; }

        private PartReference _reference;

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool PartNameSpecified { get { return PartName != null; } }
        #endregion

        public PartAsDesigned()
        {
            PartIds = new List<Identifier<PartIdentifierClassification>>();
            PartNames = new List<Descriptor>();
        }
        public PartAsDesigned(string identifier)
            : this()
        {
            PartId.ID = identifier;
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
