using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class ProvidedIdentifier<T> : Identifier<T>
    {
        [XmlElement(ElementName = "setBy")]
        public OrganizationReference SetBy { get; set; }

        [XmlIgnore]
        public bool SetBySpecified { get { return SetBy != null; } }

        public ProvidedIdentifier()
            : base()
        { }

        public ProvidedIdentifier(string value)
            : base(value)
        { }

        public ProvidedIdentifier(string value, string classification)
            : this(value, classification, null)
        { }

        public ProvidedIdentifier(string value, string classification, OrganizationReference setBy)
            : base(value, classification)
        {
            this.SetBy = setBy;
        }
    }
}
