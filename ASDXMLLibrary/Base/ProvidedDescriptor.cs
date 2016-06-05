using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class ProvidedDescriptor : Descriptor
    {
        [XmlElement(ElementName = "providedBy")]
        public OrganizationReference ProvidedBy { get; set; }

        [XmlIgnore]
        public bool ProvidedBySpecified { get { return ProvidedBy != null; } }

        public ProvidedDescriptor()
            : base()
        { }

        public ProvidedDescriptor(string text)
            : base(text)
        { }

        public ProvidedDescriptor(string text, string language)
            : base(text, language)
        { }
    }
}
