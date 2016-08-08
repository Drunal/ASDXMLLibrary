using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;

namespace AsdXMLLibrary.Objects.References
{
    public class PartReference : IAmReference
    {
        public Identifier<PartIdentifierClassification> PartId { get; set; }

        public PartReference()
        {
            PartId = new Identifier<PartIdentifierClassification>();
        }

        public PartReference(PartAsDesigned part)
            : this()
        {
            PartId = part.PartIds.Primary;
        }
    }
}
