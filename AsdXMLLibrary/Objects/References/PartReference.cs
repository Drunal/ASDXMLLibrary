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

        #region IAmReference Members

        public void SetTarget(ICanBeReferenced target)
        {
            PartAsDesigned part = (PartAsDesigned)target;
            if (part != null)
            {
                // do a copy of the actual values, otherwise we'd destroy our setting for _elementName in the current context
                PartId.ID = part.PartIds.MainID.ID;
                PartId.Class.Value = part.PartIds.MainID.Class.Value;
            }
        }

        #endregion
    }
}
