using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using System.Xml.Serialization;
using AsdXMLLibrary.Objects.References;

namespace AsdXMLLibrary.Base
{
    [XmlRoot(ElementName = "Identifier")]
    public class Identifier<IdentifierClassification> 
    {
        [XmlElement(ElementName = "id")]
        public string ID { get; set; }

        [XmlElement(ElementName = "class")]
        public Classification<IdentifierClassification> Class { get; set; }

        [XmlElement(ElementName = "setBy")]
        public OrganizationReference SetBy { get; set; }

        #region XML Handling Properties

        [XmlIgnore]
        public bool ClassSpecified { get { return Class.HasValue; } }
        [XmlIgnore] 
        public bool SetBySpecified { get { return SetBy != null; } }

        #endregion

        public Identifier()
        {
            Class = new Classification<IdentifierClassification>();
        }
    }
}
