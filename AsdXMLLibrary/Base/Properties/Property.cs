using AsdXMLLibrary.Base.Classifications;
using System;
using System.Xml;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base.Properties
{
    public class Property<T> : SerializeBase, IHaveValue
    {
        public PropertyType Type { get; private set; }

        public DateTime? RecordingDate { get; set; }

        public Classification ValueDetermination { get; set; }

        public Classification Unit { get; set; }

        #region Property Values
        private double? _value;
        // TODO: I really don't like this solution to handle the choices!
        // but i'm tired and the generic approach caused problems with deserialization
        public double? Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Type = PropertyType.SingleValueProperty;
            }
        }

        private double? _lowerLimit;
        public double? LowerLimit
        {
            get { return _lowerLimit; }
            set
            {
                _lowerLimit = value;
                Type = PropertyType.ValueRangeProperty;
            }
        }
        private double? _upperLimit;
        public double? UpperLimit
        {
            get { return _upperLimit; }
            set
            {
                _upperLimit = value;
                Type = PropertyType.ValueRangeProperty;
            }
        }

        private double? _nominalValue;
        public double? NominalValue
        {
            get { return _nominalValue; }
            set
            {
                _nominalValue = value;
                Type = PropertyType.ValueWithTolerancesProperty;
            }
        }
        private double? _lowerOffset;
        public double? LowerOffset
        {
            get { return _lowerOffset; }
            set
            {
                _lowerOffset = value;
                Type = PropertyType.ValueWithTolerancesProperty;
            }
        }
        private double? _upperOffset;
        public double? UpperOffset
        {
            get { return _upperOffset; }
            set
            {
                _upperOffset = value;
                Type = PropertyType.ValueWithTolerancesProperty;
            }
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Type = PropertyType.TextProperty;
            }
        }
        #endregion

        public bool HasValue
        {
            get
            {
                return Value.HasValue ||
                    (LowerLimit.HasValue && UpperLimit.HasValue) ||
                    (NominalValue.HasValue && LowerOffset.HasValue && UpperOffset.HasValue) ||
                    !string.IsNullOrEmpty(Text);
            }
        }
        public Property()
        {
            ValueDetermination = new Classification(typeof(ValueDeterminationClassification));
            Unit = new Classification(typeof(T));
        }

        #region SingleValue Creation
        public void CreateSingleValueProperty(double? singleValue)
        { 
            CreateSingleValueProperty(singleValue, string.Empty);
        }

        public void CreateSingleValueProperty(double? singleValue, string unit)
        {
            CreateSingleValueProperty(singleValue, unit, null, null);
        }

        public void CreateSingleValueProperty(double? singleValue, string unit, DateTime? recordingDate, string determinationType)
        {
            SetOptionalAttributes(recordingDate, determinationType);
            SetUnit(unit);
            Value = singleValue;
        }
        #endregion

        #region RangeValue Constructor
        public void CreateRangeProperty(double? lowerLimit, double? upperLimit)
        { 
            CreateRangeProperty(lowerLimit, upperLimit, string.Empty);
        }

        public void CreateRangeProperty(double? lowerLimit, double? upperLimit, string unit)
        { 
            CreateRangeProperty(lowerLimit, upperLimit, unit, null, null);
        }

        public void CreateRangeProperty(double? lowerLimit, double? upperLimit, string unit, DateTime? recordingDate, string determinationType)
        {
            SetOptionalAttributes(recordingDate, determinationType);
            SetUnit(unit);
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
        #endregion

        #region Tolerance Constructor

        public void CreateToleranceValueProperty(double? nominalValue, double? lowerOffset, double? upperOffset)
        { 
            CreateToleranceValueProperty(nominalValue, lowerOffset, upperOffset, string.Empty);
        }   

        public void CreateToleranceValueProperty(double? nominalValue, double? lowerOffset, double? upperOffset, string unit)
        { 
            CreateToleranceValueProperty(nominalValue, lowerOffset, upperOffset, unit, null, null);
        }

        public void CreateToleranceValueProperty(double? nominalValue, double? lowerOffset, double? upperOffset, string unit, DateTime? recordingDate, string determinationType)
        {
            SetOptionalAttributes(recordingDate, determinationType);
            SetUnit(unit);

            NominalValue = nominalValue;
            LowerOffset = lowerOffset;
            UpperOffset = upperOffset;
        }
        #endregion

        #region Text Constructor
        public void CreateTextProperty(string text)
        {
            CreateTextProperty(text, null, null);
        }

        
        public void CreateTextProperty(string text, DateTime? recordingDate, string determinationType) 
        {
            SetOptionalAttributes(recordingDate, determinationType);
            Text = text;
            Unit = new Classification(typeof(T));
        }

        #endregion

        private void SetOptionalAttributes(DateTime? recordingDate, string determinationType)
        {
            ValueDetermination = new Classification(typeof(ValueDeterminationClassification));
            ValueDetermination.Value = determinationType;
            RecordingDate = recordingDate;
            
        }

        private void SetUnit(string unit)
        {
            Unit = new Classification(typeof(T));
            Unit.Value = unit;
        }


        #region Serialize Functions
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            if (!HasValue) return null;

            XElement property = new XElement(ns + elementName);
            if (RecordingDate.HasValue)
                property.Add(new XElement(ns + Constants.DateElementName, RecordingDate.ToXmlDateString()));
            property.Add(ValueDetermination.CreateXML(Constants.PropertyValueDeterminationElementName, ns));

            if (Type != PropertyType.TextProperty)
                property.Add(Unit.CreateXML(Constants.PropertyUnitElementName, ns, true)); // force the element, even if the value is not set.

            switch (Type)
            {
                case PropertyType.SingleValueProperty:
                    property.Add(new XElement(ns + Constants.PropertyValueElementName, XmlConvert.ToString(Value.Value)));
                    break;
                case PropertyType.ValueWithTolerancesProperty:
                    property.Add(new XElement(ns + Constants.PropertyNominalValueElementName, XmlConvert.ToString(NominalValue.Value)));
                    property.Add(new XElement(ns + Constants.PropertyLowerOffsetElementName, XmlConvert.ToString(LowerOffset.Value)));
                    property.Add(new XElement(ns + Constants.PropertyUpperOffsetElementName, XmlConvert.ToString(UpperOffset.Value)));
                    break;
                case PropertyType.ValueRangeProperty:
                    property.Add(new XElement(ns + Constants.PropertyLowerValueElementName, XmlConvert.ToString(LowerLimit.Value)));
                    property.Add(new XElement(ns + Constants.PropertyUpperValueElementName, XmlConvert.ToString(UpperLimit.Value)));
                    break;
                case PropertyType.TextProperty:
                    property.Add(new XElement(ns + Constants.PropertyTextElementName, Text));
                    break;
                default:
                    break;
            }

            return property;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;
            XElement date = element.Element(ns + Constants.DateElementName);
            if (date != null)
                RecordingDate = XmlConvert.ToDateTime(date.Value, XmlDateTimeSerializationMode.Local);
            ValueDetermination.ReadfromXML(element.Element(ns + Constants.PropertyValueDeterminationElementName), ns);
            Unit.ReadfromXML(element.Element(ns + Constants.PropertyUnitElementName), ns);

            // just check all of them one after each other. the schema should have made sure, that only one of them is actually there.
            // Single Value
            XElement singleValue = element.Element(ns + Constants.PropertyValueElementName);
            if (singleValue != null)
                Value = XmlConvert.ToDouble(singleValue.Value);
            
            // Tolerance
            XElement nomValue = element.Element(ns + Constants.PropertyNominalValueElementName);
            if (nomValue != null)
                NominalValue = XmlConvert.ToDouble(nomValue.Value);
            XElement lowerOff = element.Element(ns + Constants.PropertyLowerOffsetElementName);
            if (lowerOff != null)
                LowerOffset = XmlConvert.ToDouble(lowerOff.Value);
            XElement upperOff = element.Element(ns + Constants.PropertyUpperOffsetElementName);
            if (upperOff != null)
                UpperOffset = XmlConvert.ToDouble(upperOff.Value);
            
            // Range
            XElement lowerLimit = element.Element(ns + Constants.PropertyLowerValueElementName);
            if (lowerLimit != null)
                LowerLimit = XmlConvert.ToDouble(lowerLimit.Value);
            XElement upperLimit = element.Element(ns + Constants.PropertyUpperValueElementName);
            if (upperLimit != null)
                UpperLimit = XmlConvert.ToDouble(upperLimit.Value);

            // Text
            XElement text = element.Element(ns + Constants.PropertyTextElementName);
            if (text != null)
                Text = text.Value;

            return true;
        }
        #endregion
    }
}
