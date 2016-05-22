using System.Xml.Serialization;
namespace AsdXMLLibrary.Base.Properties
{
    public class ValueWithTolerancesProperty<UnitClassificationType> : NumericalProperty<UnitClassificationType>
    {
        [XmlElement(ElementName="nomVal")]
        public double? Value { get; set; }
        [XmlElement(ElementName = "lowOff")]
        public double? LowerOffset { get; set; }
        [XmlElement(ElementName = "uppOff")]
        public double? UpperOffset { get; set; }

        public ValueWithTolerancesProperty()
            : base()
        {
            Value = null;
            LowerOffset = null;
            UpperOffset = null;
        }
        
    }
}
