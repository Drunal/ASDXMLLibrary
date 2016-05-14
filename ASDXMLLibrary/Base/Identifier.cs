using ASDXMLLibrary.Objects;
using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Base
{
    public class Identifier
    {
        public string ID { get; set; }
        public Classification Class { get; set; }
        public Organization SetBy { get; set; }

        public Identifier(ClassificationBase classification)
        {
            Class = new Classification(classification);
        }
    }
}
