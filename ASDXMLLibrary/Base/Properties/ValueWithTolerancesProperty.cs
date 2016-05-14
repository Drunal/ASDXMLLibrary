namespace ASDXMLLibrary.Base.Properties
{
    public class ValueWithTolerancesProperty : NumericalProperty
    {
        public double? Value { get; set; }
        public double? LowerOffset { get; set; }
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
