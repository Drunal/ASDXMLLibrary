using AsdXMLLibrary.Objects.References;
using System;
using System.Xml;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class DatedDescriptor : Descriptor
    {
        public DateTime? ProvidedDate { get; set; }

        public OrganizationReference ProvidedBy { get; set; }

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
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement descriptor = base.CreateXML(elementName, ns, forceElement);
            if (descriptor == null) // if there is no base, why create the rest?
                return null;

            if (ProvidedDate.HasValue)
                descriptor.Add(new XElement(ns + Constants.DateElementName, ProvidedDate.ToXmlDateString()));
            // providedBy.GetXML returns 'null' if no value
            descriptor.Add(ProvidedBy.CreateXML(Constants.ProvidedByElementName, ns));

            return descriptor;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read name and language
            if (!base.ReadfromXML(element, ns))
                return false; // return here, if the base couldn't read its data probably.
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
