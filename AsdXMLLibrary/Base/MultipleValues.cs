using System.Collections.Generic;

namespace AsdXMLLibrary.Base
{
    public class MultipleValues<T> : List<T>
         where T : SerializeBase, new()
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
    }
}
