using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    [XmlRoot(ElementName = "Descriptor")]
    public class ProvidedDescriptor : Descriptor
    {
        [XmlElement(ElementName = "providedBy")]
        public OrganizationReference ProvidedBy { get; private set; }

        [XmlIgnore]
        public bool ProvidedBySpecified { get { return ProvidedBy.HasValue; } }

        #region Constructors
        public ProvidedDescriptor()
            : base()
        {
            Initialize();
        }

        public ProvidedDescriptor(string elementName)
            : base(elementName)
        {
            Initialize();
        }

        public ProvidedDescriptor(string elementName, string text)
            : base(elementName, text)
        {
            Initialize();
        }

        public ProvidedDescriptor(string elementName, string text, string language)
            : base(elementName, text, language)
        {
            Initialize();
        }

        private void Initialize()
        {
            ProvidedBy = new OrganizationReference(Constants.ProvidedByElementName);
        }
        #endregion

        #region Serialize Functions
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement descriptor = base.GetXML(elementName, ns);
            descriptor.Add(ProvidedBy.GetXML(Constants.ProvidedByElementName, ns));

            return descriptor;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read name and language
            base.ReadfromXML(element, ns);
            ProvidedBy.ReadfromXML(element.Element(ns + Constants.ProvidedByElementName), ns);
            return true;
        }
        #endregion
    }
}
