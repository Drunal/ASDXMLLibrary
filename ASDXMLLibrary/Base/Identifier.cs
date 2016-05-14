using ASDXMLLibrary.Objects;
using ASDXMLLibrary.Base.Classifications;
using ASDXMLLibrary.Base.Properties;
using System.Xml.Serialization;

namespace ASDXMLLibrary.Base
{
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
        protected bool ClassSpecified { get { return Class.HasValue; } }
        [XmlIgnore] 
        protected bool SetBySpecified { get { return SetBy != null; } }

        #endregion

        public Identifier()
        {
            Class = new Classification<IdentifierClassification>();
        }
    }
}
