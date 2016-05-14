using ASDXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace ASDXMLLibrary.Base.Properties
{
    public class NumericalProperty<UnitClassificationType> : Property
    {
        [XmlElement(ElementName = "unit")]
        public Classification<UnitClassificationType> Unit { get; set; }

        public NumericalProperty()
            : base()
        {
            Unit = new Classification<UnitClassificationType>();
        }
    }
}
