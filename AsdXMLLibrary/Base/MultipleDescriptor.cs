using System.Collections.Generic;
using System.Linq;

namespace AsdXMLLibrary.Base
{
    public class MultipleDescriptor : List<ProvidedDescriptor>, IHaveValue
    {
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
        {
        }
            

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
