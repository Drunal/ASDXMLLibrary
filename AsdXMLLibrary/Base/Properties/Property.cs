using AsdXMLLibrary.Base.Classifications;
using System;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base.Properties
{
    public abstract class Property
    {
        [XmlElement(ElementName = "date", DataType = "date")]
        public DateTime RecordingDate { get; set; }

        [XmlElement(ElementName="vdtm")]
        public Classification<ValueDeterminationClassification> ValueDetermination { get; set; }

        #region XML Handling Properties
        // these properties control if the respective property is written to the xml or not
        [XmlIgnore] // if Ticks is 0 then the ProvidedDate equal 0001-01-01T00:00:00 and was most likely not set.
        protected bool RecordingDateSpecified { get { return RecordingDate.Ticks > 0; } }
        [XmlIgnore] 
        protected bool ValueDeterminationSpecified { get { return ValueDetermination.HasValue; } }

        #endregion

        public Property()
        {
            ValueDetermination = new Classification<ValueDeterminationClassification>();
        }

        [XmlIgnore]
        public abstract bool HasValue { get; }
    }
}
