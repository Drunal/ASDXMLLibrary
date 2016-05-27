using AsdXMLLibrary.Base.Classifications;
using System;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    /// <summary>
    /// Holds the chosen value and knowledge about the valid Values for this particular value.
    /// </summary>
    public class Classification : IHaveValue
    {
        private ClassificationBase validValues;
        private bool isDummy = false;

        private string chosenValue;

        [XmlText]
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
    }
}
