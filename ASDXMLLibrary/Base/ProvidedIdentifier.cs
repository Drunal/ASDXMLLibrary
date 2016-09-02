using AsdXMLLibrary.Objects;
using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class ProvidedIdentifier<T> : Identifier<T>
    {
        public OrganizationReference SetBy { get; set; }

        #region Constructor
        public ProvidedIdentifier()
        { 
            Initialize();
        }

        public ProvidedIdentifier(string value)
            : base(value)
        {
            Initialize();
        }

        public ProvidedIdentifier(string value, string classification)
            : base(value, classification)
        {
            Initialize();
        }

        public ProvidedIdentifier(string value, string classification, Organization setBy)
            : base(value, classification)
        {
            Initialize();
            this.SetBy = new OrganizationReference(setBy);
        }

        #endregion

        public void Initialize() 
        {
            SetBy = new OrganizationReference();
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement identifier = base.CreateXML(elementName, ns);
            if (identifier == null)
                return null; // no need to add anythin if the base did not create anything
            identifier.Add(SetBy.CreateXML(Constants.SetByElementName, ns));

            return identifier;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null) return false;
            // this should read id and class
            if (!base.ReadfromXML(element, ns))
                return false; // no need to read anything if the base didn't read anything
            SetBy.ReadfromXML(element.Element(ns + Constants.SetByElementName), ns);
            return true;
        }
        #endregion
    }
}
