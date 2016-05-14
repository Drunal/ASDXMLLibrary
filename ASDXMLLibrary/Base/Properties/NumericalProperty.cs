using ASDXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace ASDXMLLibrary.Base.Properties
{
    public class NumericalProperty : Property
    {
        [XmlElement(ElementName = "unit")]
        public Classification<UnitClassification> Unit { get; set; }

        public NumericalProperty()
            : base()
        {
            Unit = new Classification<UnitClassification>();
        }
    }
}
