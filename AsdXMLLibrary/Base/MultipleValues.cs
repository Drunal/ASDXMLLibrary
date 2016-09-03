using System.Collections.Generic;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class MultipleValues<T> : List<T>
         where T : SerializeBase, new()
    {
        private CreateEntry createEntryDelegate;
        //private List<T> values;

        public T Primary
        {
            get
            {
                if (this.Count == 0)
                    this.Add(createEntryDelegate());
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

        public delegate T CreateEntry();
        public T GetNewEntry()
        {
            return createEntryDelegate();
        }

        #region Constructors

        public MultipleValues()
            : this(() => new T())
        {  }

        public MultipleValues(CreateEntry action)
            : base()
        {
            createEntryDelegate = action;
        }

        #endregion

        #region Serialize
        public List<XElement> CreateXML(string elementName, XNamespace ns, string containerElementName=null)
        {
            List<XElement> elements = new List<XElement>();

            foreach (var value in this)
            {
                if (containerElementName != null)
                {
                    XElement container = new XElement(ns + containerElementName);
                    container.Add(value.CreateXML(elementName, ns));
                    elements.Add(container);
                }
                else
                    elements.Add(value.CreateXML(elementName, ns));
            }

            return elements;
        }

        public bool ReadfromXML(IEnumerable<XElement> elements, XNamespace ns, string childElementName=null)
        {
            this.Clear();
            IEnumerable<XElement> enumerator = elements;
            if (childElementName != null)
                enumerator = elements.Elements(ns + childElementName);

            foreach (XElement element in enumerator)
            {
                T entry = createEntryDelegate();
                entry.ReadfromXML(element, ns);
                this.Add(entry);
            }
            return true;
        }
        #endregion

    }
}
