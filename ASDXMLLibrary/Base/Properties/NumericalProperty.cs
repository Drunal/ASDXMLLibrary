using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Base.Properties
{
    public class NumericalProperty : Property
    {
        public Classification<UnitClassification> Unit { get; set; }

        public NumericalProperty()
            : base()
        {
            Unit = new Classification<UnitClassification>();
        }
    }
}
