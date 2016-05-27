using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class MultipleDescriptor : List<Descriptor>
    {
        [XmlIgnore]
        public Descriptor MainDescriptor
        {
            get
            {
                if (this.Count == 0)
                    this.Add(new Descriptor());
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
    }
}
