using System;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base.Classifications
{
    public class CodedClassification : Classification
    {

        #region Constructor
        public CodedClassification()
            : base()
        { }

        public CodedClassification(Type classificationType)
            : base(classificationType)
        { }

        public CodedClassification(Type classificationType, string value)
            : base(classificationType, value)
        { }
        #endregion

        #region ISerialize
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            // Can't use extension method here, since it would just call this method again. 
            // --> Stack overflow!
            XElement classification = new XElement(ns + elementName);
            XElement code = base.CreateXML(Constants.CodeElementName, ns, forceElement);
            if (code == null)
                return null; // because  the underlaying Classification was not created so we do not need to provide a date for it.
            classification.Add(code);

            return classification;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false; // return here if we dont get any actual content
            // this should read name and language
            if (!base.ReadfromXML(element.Element(ns + Constants.CodeElementName), ns))
                return false; // return here, if the base couldn't read its data probably.

            return true;
        }
        #endregion
    }
}
