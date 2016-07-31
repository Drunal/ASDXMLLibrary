using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public class MultipleIdentifier<IdentifierClassification> : List<ProvidedIdentifier<IdentifierClassification>>, IHaveValue
    {
        private string _elementName;

        [XmlIgnore]
        public ProvidedIdentifier<IdentifierClassification> MainID
        {
            get
            {
                if (this.Count == 0)
                    this.Add(new ProvidedIdentifier<IdentifierClassification>(_elementName));
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
            : this(Constants.IdentifierElementName)
        { 
            // TODO: log the usage of the default name
        }

        public MultipleIdentifier(string elementName)
            : base()
        {
            _elementName = elementName;
        }

        #endregion

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
