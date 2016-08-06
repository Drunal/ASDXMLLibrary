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
            this.SetBy.SetTarget(setBy);
        }

        #endregion

        public void Initialize() 
        {
            SetBy = new OrganizationReference();
        }

        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement idenetifier = base.CreateXML(elementName, ns);
            idenetifier.Add(SetBy.CreateXML(Constants.SetByElementName, ns));

            return idenetifier;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            // this should read id and class
            base.ReadfromXML(element, ns);
            SetBy.ReadfromXML(element.Element(ns + Constants.SetByElementName), ns);
            return true;
        }
        #endregion
    }
}
