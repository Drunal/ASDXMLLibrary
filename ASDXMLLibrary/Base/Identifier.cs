using ASDXMLLibrary.Objects;
using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Base
{
    public class Identifier<IdentifierClassification>
    {
        public string ID { get; set; }
        public Classification<IdentifierClassification> Class { get; set; }
        public Organization SetBy { get; set; }

        public Identifier()
        {
            Class = new Classification<IdentifierClassification>();
        }
    }
}
