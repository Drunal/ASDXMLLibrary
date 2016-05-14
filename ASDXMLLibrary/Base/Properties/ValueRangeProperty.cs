
using System.Xml.Serialization;
namespace ASDXMLLibrary.Base.Properties
{
    public class ValueRangeProperty : NumericalProperty
    {
        [XmlElement(ElementName = "lowVal")]
        public double? LowerLimit { get; set; }
        [XmlElement(ElementName = "uppVal")]
        public double? UpperLimit { get; set; }

        public ValueRangeProperty()
            : base()
        {
            LowerLimit = null;
            UpperLimit = null;
        }
    }
}
