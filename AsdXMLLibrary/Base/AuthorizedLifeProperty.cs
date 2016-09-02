using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using AsdXMLLibrary.Objects.References;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class AuthorizedLifeProperty : SerializeBase, IHaveValue
    {
        public List<Property<TimeCycleUnit>> AuthorizedLifeValues { get; set; }

        public OrganizationReference LifeAuthorizingOrganization { get; set; }

        public AuthorizedLifeProperty()
        {
            AuthorizedLifeValues = new List<Property<TimeCycleUnit>>();
            LifeAuthorizingOrganization = new OrganizationReference();
        }

        /// <summary>
        /// I'm not really happy with this method
        /// But it should ease the process of adding values to the PropertyList, 
        /// without the need of actually defining a PropertyList (yet)
        /// </summary>
        /// <returns></returns>
        public Property<TimeCycleUnit> AddValue()
        {
            var newValue = new Property<TimeCycleUnit>();
            AuthorizedLifeValues.Add(newValue);
            return newValue;
        }

        public bool HasValue
        {
            get { return AuthorizedLifeValues.Count > 0; }
        }

        #region Serialize
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            // one value is mandatory to create the element at all.
            if (!HasValue && !forceElement) return null;
            XElement auth = new XElement(ns + elementName);
            foreach (var value in AuthorizedLifeValues)
                auth.Add(value.CreateXML(Constants.HardwarePartAuthorizedLife, ns));

            if (LifeAuthorizingOrganization.HasValue)
                auth.Add(LifeAuthorizingOrganization.CreateXML(Constants.ReferenceOrganizationElementName, ns));

            return auth;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null) return false;
            AuthorizedLifeValues.Clear();
            foreach (XElement aulElement in element.Elements(ns + Constants.HardwarePartAuthorizedLife))
            {
                Property<TimeCycleUnit> value = new Property<TimeCycleUnit>();
                value.ReadfromXML(aulElement, ns);
                AuthorizedLifeValues.Add(value);
            }

            LifeAuthorizingOrganization.ReadfromXML(element.Element(ns + Constants.ReferenceOrganizationElementName), ns);
            return true; 
        }
        #endregion
    }
}
