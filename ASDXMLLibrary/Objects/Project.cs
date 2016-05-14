using AsdXMLLibrary.Base;
using AsdXMLLibrary.Objects.References;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    public class Project : ProjectReference
    {
        [XmlElement(ElementName="name")]
        public Descriptor Name { get; set; }

        private ProjectReference _reference;

        public Project()
            : base()
        {
            Name = new Descriptor();
        }

        [XmlIgnore]
        public ProjectReference Reference
        {
            get
            {
                if (_reference == null)
                    _reference = new ProjectReference();
                if (_reference.ProjectID != this.ProjectID)
                    _reference.ProjectID = this.ProjectID;

                return _reference;
            }
        }
    }
}
