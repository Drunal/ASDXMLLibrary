using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class PartReference : IAmReference
    {
        [XmlElement(ElementName = "partId")]
        public Identifier<PartIdentifierClassification> PartId { get; set; }

        public PartReference()
        {
            PartId = new Identifier<PartIdentifierClassification>();
        }
    }
}
