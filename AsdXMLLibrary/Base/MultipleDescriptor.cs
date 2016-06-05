using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class MultipleDescriptor : List<ProvidedDescriptor>, IHaveValue
    {
        [XmlIgnore]
        public ProvidedDescriptor MainDescriptor
        {
            get
            {
                if (this.Count == 0)
                    this.Add(new ProvidedDescriptor());
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

        public MultipleDescriptor()
            : base()
        { }

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
