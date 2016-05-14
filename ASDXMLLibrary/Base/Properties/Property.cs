using ASDXMLLibrary.Base.Classifications;
using System;

namespace ASDXMLLibrary.Base.Properties
{
    public abstract class Property
    {
        public DateTime RecordingDate { get; set; }

        public Classification<ValueDeterminationClassification> ValueDetermination { get; set; }

        public Property()
        {
            RecordingDate = new DateTime();
            ValueDetermination = new Classification<ValueDeterminationClassification>();
        }
    }
}
