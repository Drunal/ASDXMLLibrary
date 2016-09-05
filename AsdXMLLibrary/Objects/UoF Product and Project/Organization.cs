using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    
    public class Organization : SerializeBase,  ICanBeReferenced<OrganizationReference>
    {
        public MultipleValues<Identifier<OrganizationIdentifierClassification>> OrgIds { get; set; }

        public Descriptor Name { get; set; }

        private OrganizationReference _reference = null;

        public Organization()
        {
            OrgIds = new MultipleValues<Identifier<OrganizationIdentifierClassification>>();
            Name = new Descriptor();

        }

        public OrganizationReference GetReference()
        {
            if(_reference == null)
            {
                _reference = new OrganizationReference(this);
            }
            return _reference;
        }

        #region Serialze
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement element = new XElement(ns + elementName);
            element.Add(OrgIds.CreateXML(Constants.OrganizationIdElementName, ns, null, true));
            element.Add(Name.CreateXML(Constants.OrganizationNameElementName, ns));
            return element;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;
            OrgIds.ReadfromXML(element.Elements(ns + Constants.OrganizationIdElementName), ns);
            Name.ReadfromXML(element.Element(ns + Constants.OrganizationNameElementName), ns);
            return true;
        }
        #endregion
    }
}
