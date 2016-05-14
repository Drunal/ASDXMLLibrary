using ASDXMLLibrary.Base;
using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Objects
{
    public class PartAsDesigned
    {
        public Identifier PartID { get; set; }
        public Descriptor PartName { get; set; }

        public PartAsDesigned()
        {
            PartID = new Identifier(PartIdentifierClassification.Instance);
            PartName = new Descriptor();
        }
    }
}
