using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using System.Xml.Serialization;
using AsdXMLLibrary.Objects.References;

namespace AsdXMLLibrary.Base
{
    [XmlRoot(ElementName = "Identifier")]
    public class Identifier<IdentifierClassification> : IHaveValue
    {
        [XmlElement(ElementName = "id")]
        public string ID { get; set; }

        [XmlElement(ElementName = "class")]
        public Classification Class { get; set; }

        #region XML Handling Properties
        [XmlIgnore]
        public bool ClassSpecified { get { return Class.HasValue; } }
        #endregion

        public Identifier()
           : this(string.Empty)
        { }

        public Identifier(string value)
            : this(value, string.Empty)
        { }

        public Identifier(string value, string classification) 
        {
            this.ID = value;
            this.Class = new Classification(typeof(IdentifierClassification), classification);
        }

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(ID); }
        }
    }
}
