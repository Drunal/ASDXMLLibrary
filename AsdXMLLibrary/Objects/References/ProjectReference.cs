using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;

namespace AsdXMLLibrary.Objects.References
{
    public class ProjectReference : IAmReference
    {
        public Identifier<ProjectIdentifierClassification> ProjectId { get; set; }

        public ProjectReference()
        {
            ProjectId = new Identifier<ProjectIdentifierClassification>();
        }
    }
}
