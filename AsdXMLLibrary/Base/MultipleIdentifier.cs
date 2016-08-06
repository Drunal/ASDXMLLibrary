using System.Collections.Generic;
using System.Linq;

namespace AsdXMLLibrary.Base
{
    public class MultipleIdentifier<IdentifierClassification> : List<ProvidedIdentifier<IdentifierClassification>>, IHaveValue
    {
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

        #region Constructors

        public MultipleIdentifier()
        {
        }

        #endregion

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
