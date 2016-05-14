using System.Xml.Serialization;
namespace ASDXMLLibrary.Base.Properties
{
    public class ValueWithTolerancesProperty : NumericalProperty
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
