using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public abstract class PartAsDesigned
    {
        [XmlElement(ElementName="partId")]
        public Identifier<PartIdentifierClassification> PartID { get; set; }
        [XmlElement(ElementName = "name")]
        public Descriptor PartName { get; set; }

        public PartAsDesigned()
        {
            PartID = new Identifier<PartIdentifierClassification>();
            PartName = new Descriptor();
        }
    }
}
