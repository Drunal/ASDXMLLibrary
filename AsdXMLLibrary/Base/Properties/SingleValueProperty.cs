
using System.Xml.Serialization;
namespace AsdXMLLibrary.Base.Properties
{
    class SingleValueProperty<UnitClassificationType> : NumericalProperty<UnitClassificationType>
    {
        [XmlElement(ElementName="value")]
        public double? Value { get; set; }

        public SingleValueProperty() 
            : base()
        {
            Value = null;
        }

        public SingleValueProperty(double value)
        {
            Value = value;
        }

        public override bool HasValue
        {
            get { return Value.HasValue; }
        }
    }
}
