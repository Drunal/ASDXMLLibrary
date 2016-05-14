using System.Collections.Generic;

namespace ASDXMLLibrary.Base.Classifications
{
    /// <summary>
    /// Base class to handle all classifications. 
    /// A classification is typically a list of values to choose from.
    /// </summary>
    public class ClassificationBase
    {
        private static ClassificationBase _instance = new ClassificationBase();
        public List<string> Values { get; private set; }  

        // Constructor is 'protected'
        protected ClassificationBase()
        {
            Values = new List<string>();
        }

        public static ClassificationBase Instance
        {
            get
            {
                // Uses lazy initialization.
                // Note: this is not thread safe.
                if (_instance == null)
                {
                    _instance = new ClassificationBase();
                }
                return _instance;
            }
        }

        public bool Contains(string value)
        {
            return Values.Contains(value);
        }
    }
}
