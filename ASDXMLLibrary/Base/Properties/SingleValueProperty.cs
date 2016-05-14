
using System.Xml.Serialization;
namespace ASDXMLLibrary.Base.Properties
{
    class SingleValueProperty : NumericalProperty
    {
        [XmlElement(ElementName="value")]
        public double Value { get; set; }

        public SingleValueProperty() 
            : base()
        {

        }
    }
}
