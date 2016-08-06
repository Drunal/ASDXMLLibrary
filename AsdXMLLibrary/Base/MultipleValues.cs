using System.Collections.Generic;
using System.Linq;

namespace AsdXMLLibrary.Base
{
    public class MultipleValues<T> : List<T>, IHaveValue
         where T : SerializeBase, IHaveValue, new()
    {
        public T Primary
        {
            get
            {
                if (this.Count == 0)
                    this.Add(new T());
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

        public MultipleValues()
        {

        }

        #endregion

        public bool HasValue
        {
            get { return this.Any(x => x.HasValue); }
        }
    }
}
