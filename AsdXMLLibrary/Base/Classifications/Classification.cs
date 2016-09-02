using AsdXMLLibrary.Base.Classifications;
using System;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    /// <summary>
    /// Holds the chosen value and knowledge about the valid Values for this particular value.
    /// </summary>
    public class Classification : SerializeBase, IHaveValue
    {
        private ClassificationBase validValues;
        private bool isDummy = false;

        private string chosenValue;

        public string Value { get { return chosenValue; }
            set
            {
                if (!isDummy && !string.IsNullOrEmpty(value) && !validValues.Contains(value))
                    throw new ClassificationException(string.Format("Value '{0}' is not a valid value for {1}!", value, validValues.GetType().Name));
                chosenValue = value;
            }
        }

        #region Constructors
        public Classification()
            : this(typeof(DummyClassification))
        { 
            isDummy = true;
        }

        public Classification(Type classificationType)
            : this(classificationType, null)
        { }

        public Classification(Type classificationType, string value)
        {
            validValues = ClassificationManager.Get(classificationType);
            Value = value;
        }

        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(chosenValue); }
        }

        #region Serialize Funcctions
        /// <summary>
        /// Creates an XElement for this classification. 
        /// If no value is present, 'null' is returned. 
        /// Unless <paramref name="forceElement"/> is set to <c>True</c>.
        /// In this case the XElement is created and returned with no content. 
        /// </summary>
        /// <param name="ns">The namespace the element should be in.</param>
        /// <param name="forceElement">Define if the element must be created regardless of available content.</param>
        /// <returns></returns>
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement=false)
        {
            return HasValue || forceElement ? new XElement(ns + elementName, chosenValue) : null;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;

            chosenValue = element.Value;

            return true;
        }

        #endregion
    }
}
