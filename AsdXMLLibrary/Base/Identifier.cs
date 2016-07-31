using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    [XmlRoot(ElementName = "Identifier")]
    public class Identifier<IdentifierClassification> : SerializeBase, IHaveValue
    {
        [XmlElement(ElementName = "id")]
        public string ID { get; set; }

        [XmlElement(ElementName = "class")]
        public Classification Class { get; set; }

        #region XML Handling Properties
        [XmlIgnore]
        public bool ClassSpecified { get { return Class.HasValue; } }
        #endregion

        #region Constructors
        public Identifier()
            : this(Constants.DefaultIdentifierElementName)
        { }

        public Identifier(string elementName)
           : this(elementName, string.Empty)
        { }

        public Identifier(string elementName, string value)
            : this(elementName, value, string.Empty)
        { }

        public Identifier(string elementName, string value, string classification)
            : base(elementName)
        {
            this.ID = value;
            this.Class = new Classification(Constants.ClassElementName, typeof(IdentifierClassification), classification);
        }
        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(ID); }
        }

        #region Serialize Functions
        public override XElement GetXML(XNamespace ns, bool forceElement = false)
        {
            XElement identifier = new XElement(ns + _elementName);
            identifier.Add(new XElement(ns + Constants.IdentifierElementName, ID));
            // class is optional
            identifier.Add(Class.GetXML(ns));
            return identifier;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;

            // this is a mandatory field
            ID = element.Element(ns + Constants.IdentifierElementName).Value;
            Class.ReadfromXML(element.Element(ns + Constants.ClassElementName), ns);
            return true;
        }

        #endregion
    }
}
