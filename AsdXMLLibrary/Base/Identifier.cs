using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class Identifier<IdentifierClassification> : SerializeBase, IHaveValue
    {
        public string ID { get; set; }

        public Classification Class { get; set; }

        #region Constructors
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
        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(ID); }
        }

        #region Serialize Functions
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement identifier = new XElement(ns + elementName);
            identifier.Add(new XElement(ns + Constants.IdentifierElementName, ID));
            // class is optional
            identifier.Add(Class.GetXML(Constants.ClassElementName, ns));
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
