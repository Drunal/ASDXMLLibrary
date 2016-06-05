using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class MultipleIdentifier<IdentifierClassification> : List<ProvidedIdentifier<IdentifierClassification>>, IHaveValue
    {
        [XmlIgnore]
        public ProvidedIdentifier<IdentifierClassification> MainID
        {
            get
            {
                if (this.Count == 0)
                    this.Add(new ProvidedIdentifier<IdentifierClassification>());
                return this[0];
            }
            set
            {
                if (this.Count > 0)
                    this[0] = value;
                else
                    this.Add(value);
                
            }
        }

        public MultipleIdentifier()
            : base()
        { }

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
