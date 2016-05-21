using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class ProjectReference
    {
        [XmlElement(ElementName = "prjId")]
        public Identifier<ProjectIdentifierClassification> ProjectId { get; set; }

        public ProjectReference()
        {
            ProjectId = new Identifier<ProjectIdentifierClassification>();
        }
    }
}
