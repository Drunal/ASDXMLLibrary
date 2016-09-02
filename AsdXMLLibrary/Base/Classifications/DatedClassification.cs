using System;
using System.Xml;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base.Classifications
{
    public class DatedClassification : CodedClassification
    {
        public DateTime? ProvidedDate { get; set; }

        #region Constructor
        public DatedClassification()
            : base()
        { }

        public DatedClassification(Type classificationType)
            : base(classificationType)
        { }

        public DatedClassification(Type classificationType, string value)
            : base(classificationType, value)
        { }
        #endregion

        #region ISerialize
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement classification = base.CreateXML(elementName, ns, forceElement);
            if (classification == null) return null;
            if (ProvidedDate.HasValue)
                classification.Add(new XElement(ns + Constants.DateElementName, ProvidedDate.ToXmlDateString()));

            return classification;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false; // return here if we dont get any actual content
            // this should read name and language
            if (!base.ReadfromXML(element, ns))
                return false; // return here, if the base couldn't read its data probably.
            // date is optional
            XElement date = element.Element(ns + Constants.DateElementName);
            if (date != null)
                ProvidedDate = XmlConvert.ToDateTime(date.Value, XmlDateTimeSerializationMode.Local);
            return true;
        }

        #endregion
    }
}
