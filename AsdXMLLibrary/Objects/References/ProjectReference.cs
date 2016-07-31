using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.References
{
    public class ProjectReference : IAmReference
    {
        [XmlElement(ElementName = "prjId")]
        public Identifier<ProjectIdentifierClassification> ProjectId { get; set; }

        public ProjectReference()
        {
            ProjectId = new Identifier<ProjectIdentifierClassification>();
        }

        #region IAmReference Members

        public void SetTarget(ICanBeReferenced target)
        {
            Project project = (Project)target;
            if (project != null)
            {
                // do a copy of the actual values, otherwise we'd destroy our setting for _elementName in the current context
                ProjectId.ID = project.ProjectId.ID;
                ProjectId.Class.Value = project.ProjectId.Class.Value;
            }
        }

        #endregion
    }
}
