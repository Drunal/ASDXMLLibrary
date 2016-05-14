
namespace ASDXMLLibrary.Base.Properties
{
    public class ValueRangeProperty : NumericalProperty
    {
        public double? LowerLimit { get; set; }
        public double? UpperLimit { get; set; }

        public ValueRangeProperty()
            : base()
        {
            LowerLimit = null;
            UpperLimit = null;
        }
    }
}
