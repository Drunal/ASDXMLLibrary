using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class ProvidedDescriptor : Descriptor
    {
        public OrganizationReference ProvidedBy { get; set; }

        #region Constructors
        public ProvidedDescriptor()
        {
            Initialize();
        }

        public ProvidedDescriptor(string text)
            : base(text)
        {
            Initialize();
        }

        public ProvidedDescriptor(string text, string language)
            : base(text, language)
        {
            Initialize();
        }

        private void Initialize()
        {
            ProvidedBy = new OrganizationReference();
        }
        #endregion

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement descriptor = base.CreateXML(elementName, ns);
            if (descriptor == null)
                return null; // no need/possibilty to add something if the base didn't create anything.
            descriptor.Add(ProvidedBy.CreateXML(Constants.ProvidedByElementName, ns));

            return descriptor;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read name and language
            if (!base.ReadfromXML(element, ns))
                return false; // return here, because the base wasn't able to read its data
            ProvidedBy.ReadfromXML(element.Element(ns + Constants.ProvidedByElementName), ns);
            return true;
        }
        #endregion
    }
}
