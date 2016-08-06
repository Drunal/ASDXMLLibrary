using AsdXMLLibrary.Base;
using AsdXMLLibrary.Objects.References;

namespace AsdXMLLibrary.Objects
{
    public class Project : ProjectReference
    {
        public Descriptor Name { get; set; }

        public Project()
            : base()
        {
            Name = new Descriptor();
        }
    }
}
