using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class ProjectReference
    {
        [XmlElement(ElementName = "prjId")]
        public Identifier<ProjectIdentifierClassification> ProjectID { get; set; }

        public ProjectReference()
        {
            ProjectID = new Identifier<ProjectIdentifierClassification>();
        }
    }
}
