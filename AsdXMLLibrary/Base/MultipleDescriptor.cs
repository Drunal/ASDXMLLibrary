using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class MultipleDescriptor : List<ProvidedDescriptor>, IHaveValue
    {
        private string _elementName;

        [XmlIgnore]
        public ProvidedDescriptor MainDescriptor
        {
            get
            {
                if (this.Count == 0)
                    this.Add(new ProvidedDescriptor(_elementName));
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
            : this(Constants.NameElementName)
        { 
            // TODO: tell someone that we used the default element name, which is a sign of wrong initialization
        }

        public MultipleDescriptor(string elementName)
            : base()
        {
            _elementName = elementName;
        }
            

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
