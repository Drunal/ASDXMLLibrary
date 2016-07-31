using AsdXMLLibrary.Base;
using AsdXMLLibrary.Objects.References;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public class Project : ProjectReference
    {
        [XmlElement(ElementName="name")]
        public Descriptor Name { get; set; }

        public Project()
            : base()
        {
            Name = new Descriptor();
        }
    }
}
