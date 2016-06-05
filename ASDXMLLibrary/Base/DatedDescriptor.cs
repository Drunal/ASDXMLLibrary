using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class DatedDescriptor : Descriptor
    {
        [XmlElement(ElementName = "date", DataType = "date")]
        public DateTime ProvidedDate { get; set; }

        [XmlElement(ElementName = "providedBy")]
        public OrganizationReference ProvidedBy { get; set; }

        [XmlIgnore] // if Ticks is 0 then the ProvidedDate equal 0001-01-01T00:00:00 and was most likely not set.
        public bool ProvidedDateSpecified { get { return ProvidedDate.Ticks > 0; } }
        [XmlIgnore]
        public bool ProvidedBySpecified { get { return ProvidedBy != null; } }

        public DatedDescriptor()
            : base()
        { }

        public DatedDescriptor(string text)
            : base(text)
        { }

        public DatedDescriptor(string text, string language)
            : base(text, language)
        { }
    }
}
