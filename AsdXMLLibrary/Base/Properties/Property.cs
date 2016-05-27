using AsdXMLLibrary.Base.Classifications;
using System;
using System.IO;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base.Properties
{
    [XmlRoot(ElementName="Property")]
    public class Property<T>
    {
        [XmlIgnore]
        public PropertyType Type { get; private set; }

        [XmlElement(ElementName = "date", DataType = "date")]
        public DateTime? RecordingDate { get; set; }

        [XmlElement(ElementName="vdtm")]
        public Classification ValueDetermination { get; set; }

        [XmlElement(ElementName = "unit")]
        public Classification Unit { get; set; }

        #region Property Values
        private double? _value;
        // TODO: I really don't like this solution to handle the choices!
        // but i'm tired and the generic approach caused problems with deserialization
        [XmlElement(ElementName = "value")]
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
        [XmlElement(ElementName = "lowVal")]
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
        [XmlElement(ElementName = "uppVal")]
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
        [XmlElement(ElementName = "nomVal")]
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
        [XmlElement(ElementName = "lowOff")]
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
        [XmlElement(ElementName = "uppOff")]
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
        [XmlElement(ElementName = "txt")]
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

        #region XML Handling Properties
        // these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool RecordingDateSpecified { get { return RecordingDate.HasValue; } }
        [XmlIgnore] 
        public bool ValueDeterminationSpecified { get { return ValueDetermination.HasValue; } }
        [XmlIgnore]
        public bool UnitSpecified { get { return Type != PropertyType.TextProperty; } }
        [XmlIgnore]
        public bool ValueSpecified { get { return Value.HasValue && Type == PropertyType.SingleValueProperty; } }
        // Lower and Upper have the same condition, because both should only be written if both are set
        [XmlIgnore]
        public bool LowerLimitSpecified { get { return LowerLimit.HasValue && UpperLimit.HasValue && Type == PropertyType.ValueRangeProperty; } }
        [XmlIgnore]
        public bool UpperLimitSpecified { get { return LowerLimit.HasValue && UpperLimit.HasValue && Type == PropertyType.ValueRangeProperty; } }
        [XmlIgnore]
        public bool NominalValueSpecified { get { return LowerOffset.HasValue && UpperOffset.HasValue && NominalValue.HasValue && Type == PropertyType.ValueWithTolerancesProperty; } }
        [XmlIgnore]
        public bool LowerOffsetSpecified { get { return LowerOffset.HasValue && UpperOffset.HasValue && NominalValue.HasValue && Type == PropertyType.ValueWithTolerancesProperty; } }
        [XmlIgnore]
        public bool UpperOffsetSpecified { get { return LowerOffset.HasValue && UpperOffset.HasValue && NominalValue.HasValue && Type == PropertyType.ValueWithTolerancesProperty; } }
        [XmlIgnore]
        public bool TextSpecified { get { return !string.IsNullOrEmpty(Text) && Type == PropertyType.TextProperty; } }
        #endregion

        public bool HasValue
        {
            get
            {
                return ValueSpecified ||
                    LowerLimitSpecified || UpperLimitSpecified ||
                    NominalValueSpecified || LowerOffsetSpecified || UpperOffsetSpecified ||
                    TextSpecified;
            }
        }

        public Property()
        {
            ValueDetermination = new Classification(typeof(ValueDeterminationClassification));
            Unit = new Classification(typeof(T));
        }

        #region SingleValue Constructor
        public Property(double? singleValue)
            : this(singleValue, string.Empty)
        { }

        public Property(double? singleValue, string unit)
            : this(singleValue, unit, null, null)
        { }

        public Property(double? singleValue, string unit, DateTime? recordingDate, string determinationType)
        {
            SetOptionalAttributes(recordingDate, determinationType);
            Unit = new Classification(typeof(T));
            Unit.Value = unit;

            Value = singleValue;
        }
        #endregion

        #region RangeValue Constructor
        public Property(double? lowerLimit, double? upperLimit)
            : this(lowerLimit, upperLimit, string.Empty)
        { }

        public Property(double? lowerLimit, double? upperLimit, string unit)
            : this(lowerLimit, upperLimit, unit, null, null)
        { }

        public Property(double? lowerLimit, double? upperLimit, string unit, DateTime? recordingDate, string determinationType)
        {
            SetOptionalAttributes(recordingDate, determinationType);
            Unit = new Classification(typeof(T));
            Unit.Value = unit;

            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
        #endregion

        #region Tolerance Constructor

        public Property(double? nominalValue, double? lowerOffset, double? upperOffset)
            : this(nominalValue, lowerOffset, upperOffset, string.Empty)
        { }

        public Property(double? nominalValue, double? lowerOffset, double? upperOffset, string unit)
            : this(nominalValue, lowerOffset, upperOffset, unit, null, null)
        { }
        
        public Property(double? nominalValue, double? lowerOffset, double? upperOffset, string unit, DateTime? recordingDate, string determinationType)
        {
            SetOptionalAttributes(recordingDate, determinationType);
            Unit = new Classification(typeof(T));
            Unit.Value = unit;

            NominalValue = nominalValue;
            LowerOffset = lowerOffset;
            UpperOffset = upperOffset;
        }
        #endregion

        #region Text Constructor
        public Property(string text)
            : this(text, null, null)
        { }
        
        public Property(string text, DateTime? recordingDate, string determinationType) 
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
    }
}
