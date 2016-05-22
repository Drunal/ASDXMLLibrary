
using System.Xml.Serialization;
namespace AsdXMLLibrary.Base.Properties
{
    class SingleValueProperty<UnitClassificationType> : NumericalProperty<UnitClassificationType>
    {
        [XmlElement(ElementName="value")]
        public double Value { get; set; }

        public SingleValueProperty() 
            : base()
        {

        }
    }
}
