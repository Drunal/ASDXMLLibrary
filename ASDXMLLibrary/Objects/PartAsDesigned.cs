using ASDXMLLibrary.Base;
using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Objects
{
    public class PartAsDesigned
    {
        public Identifier<PartIdentifierClassification> PartID { get; set; }
        public Descriptor PartName { get; set; }

        public PartAsDesigned()
        {
            PartID = new Identifier<PartIdentifierClassification>();
            PartName = new Descriptor();
        }
    }
}
