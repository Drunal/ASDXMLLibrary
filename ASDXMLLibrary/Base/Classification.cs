using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Base
{
    /// <summary>
    /// Holds the chosen value and knowledge about the valid Values for this particular value.
    /// </summary>
    public class Classification<TValueList>
    {
        private ClassificationBase validValues;
        private string chosenValue;

        public Classification()
        {
            validValues = ClassificationManager.Get<TValueList>();
            chosenValue = null;
        }

        public void Set(string value)
        {
            if (!validValues.Contains(value))
                throw new ClassificationException(string.Format("Value '{0}' is not a valid value for {1}!", value, validValues.GetType().Name));
            chosenValue = value;
        }

        public string Value { get { return chosenValue; } }
        public bool IsSet { get { return chosenValue != null;} }
   }
}
