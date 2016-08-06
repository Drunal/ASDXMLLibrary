using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class OrganizationReference : SerializeBase, IAmReference, IHaveValue
    {
        [XmlElement(ElementName = "orgId")]
        public Identifier<OrganizationIdentifierClassification> OrgId { get; set; }

        public OrganizationReference()
            : this(Constants.SetByElementName)
        {
            // TODO: write to logger, that we used the default name
        }

        public OrganizationReference(string elementName)
            : base(elementName)
        {
            OrgId = new Identifier<OrganizationIdentifierClassification>(Constants.OrganizationIdElementName);
        }

        public bool HasValue
        {
            get { return OrgId != null && OrgId.HasValue; }
        }

        #region IAmReference Members

        public void SetTarget(ICanBeReferenced target)
        {
            Organization org = (Organization)target;
            if (org != null)
            {
                // do a copy of the actual values, otherwise we'd destroy our setting for _elementName in the current context
                OrgId.ID = org.OrgId.ID;
                OrgId.Class.Value = org.OrgId.Class.Value;
            }
        }

        #endregion

        #region ISerialize Members

        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            return HasValue ? new XElement(ns + elementName, OrgId.GetXML(Constants.OrganizationIdElementName, ns)) : null;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false; // TODO: throw an error here? no element was passed, so the expected element did not exist.

            return OrgId.ReadfromXML(element.Element(ns + Constants.OrganizationIdElementName), ns);
        }

        #endregion
    }
}
