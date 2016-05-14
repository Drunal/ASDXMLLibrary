using AsdXMLLibrary.Base.Classifications;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    /// <summary>
    /// Holds the chosen value and knowledge about the valid Values for this particular value.
    /// </summary>
    public class Classification<TValueList>
    {
        [XmlIgnore]
        private ClassificationBase validValues;

        private string chosenValue;

        public Classification()
        {
            validValues = ClassificationManager.Get<TValueList>();
            chosenValue = null;
        }

        [XmlText]
        public string Value { get { return chosenValue; }
            set
            {
                if (!validValues.Contains(value))
                    throw new ClassificationException(string.Format("Value '{0}' is not a valid value for {1}!", value, validValues.GetType().Name));
                chosenValue = value;
            }
        }
        [XmlIgnore]
        public bool HasValue { get { return chosenValue != null;} }
   }
}
