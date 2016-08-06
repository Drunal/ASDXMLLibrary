using AsdXMLLibrary.Objects.References;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
     [XmlRoot(ElementName = "Descriptor")]
    public class DatedDescriptor : Descriptor
    {
        [XmlElement(ElementName = "date", DataType = "date")]
        public DateTime? ProvidedDate { get; set; }

        [XmlElement(ElementName = "providedBy")]
        public OrganizationReference ProvidedBy { get; private set; }

        [XmlIgnore] // if Ticks is 0 then the ProvidedDate equal 0001-01-01T00:00:00 and was most likely not set.
        public bool ProvidedDateSpecified { get { return ProvidedDate.HasValue; } }
        [XmlIgnore]
        public bool ProvidedBySpecified { get { return ProvidedBy.HasValue; } }

        #region Constructor
        public DatedDescriptor()
        {
            Initialize();
        }

        public DatedDescriptor(string text)
            : base(text)
        {
            Initialize();
        }

        public DatedDescriptor(string text, string language)
            : base(text, language)
        {
            Initialize();
        }
        
        private void Initialize()
        {
            ProvidedBy = new OrganizationReference();
        }
        #endregion
        
        #region ISerialize
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement descriptor = base.GetXML(elementName, ns);
            if (ProvidedDateSpecified)
                descriptor.Add(new XElement(ns + Constants.DateElementName, ProvidedDate.ToXmlDateString()));
            // providedBy.GetXML returns 'null' if no value
            descriptor.Add(ProvidedBy.GetXML(Constants.ProvidedByElementName, ns));

            return descriptor;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read name and language
            base.ReadfromXML(element, ns);
            // date is optional
            XElement date = element.Element(ns + Constants.DateElementName);
            if (date != null)
                ProvidedDate = XmlConvert.ToDateTime(date.Value, XmlDateTimeSerializationMode.Local);
            ProvidedBy.ReadfromXML(element.Element(ns + Constants.ProvidedByElementName), ns);
            return true;
        }

        #endregion
    }
}
