using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned : SerializeBase, ICanBeReferenced
    {
        public MultipleValues<ProvidedIdentifier<PartIdentifierClassification>> PartIds { get; set; }

        public MultipleValues<ProvidedDescriptor> PartNames { get; set; }

        public PartAsDesigned()
        {
            PartIds = new MultipleValues<ProvidedIdentifier<PartIdentifierClassification>>();
            PartNames = new MultipleValues<ProvidedDescriptor>();
        }
        public PartAsDesigned(string identifier)
            : this()
        {
            PartIds.Primary.ID = identifier;
        }

        #region Serialize Functions
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement part = new XElement(ns + elementName);
            foreach (var id in PartIds)
                part.Add(id.GetXML(Constants.PartAsDesignedPartIdElementName, ns));
            foreach (var name in PartNames)
                part.Add(name.GetXML(Constants.PartAsDesignedPartNameElementName, ns));

            return part;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            foreach (XElement idElement in element.Elements(ns + Constants.PartAsDesignedPartIdElementName)) 
            {
                ProvidedIdentifier<PartIdentifierClassification> id = new ProvidedIdentifier<PartIdentifierClassification>();
                id.ReadfromXML(idElement, ns);
                PartIds.Add(id);
            }
                
            foreach (XElement nameElement in element.Elements(ns + Constants.PartAsDesignedPartNameElementName))
            {
                ProvidedDescriptor descr = new ProvidedDescriptor(Constants.PartAsDesignedPartNameElementName);
                descr.ReadfromXML(nameElement, ns);
                PartNames.Add(descr);
            }

            return true;
        }
        #endregion
    }
}
