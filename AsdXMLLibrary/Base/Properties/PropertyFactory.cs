

namespace AsdXMLLibrary.Base.Properties
{
    public static class PropertyFactory
    {
        /// <summary>
        /// Creates a Single Value Property with the given unit.
        /// </summary>
        /// <typeparam name="ClassificationType"></typeparam>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static Property Create<ClassificationType>(double value, string unit)
        {
            return new Property(typeof(ClassificationType), value, unit);
        }

        /// <summary>
        /// Creates a Range Value Property with the given unit.
        /// </summary>
        /// <typeparam name="ClassificationType"></typeparam>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static Property Create<ClassificationType>(double lowerLimit, double upperLimit, string unit)
        {
            return new Property(typeof(ClassificationType), lowerLimit, upperLimit, unit);
        }

        /// <summary>
        /// Creates a Tolerance Value Property with the given unit.
        /// </summary>
        /// <typeparam name="ClassificationType"></typeparam>
        /// <param name="nominalValue"></param>
        /// <param name="lowerOffset"></param>
        /// <param name="upperOffset"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static Property Create<ClassificationType>(double nominalValue, double lowerOffset, double upperOffset, string unit)
        {
            return new Property(typeof(ClassificationType), nominalValue, lowerOffset, upperOffset, unit);
        }

        /// <summary>
        /// Creates a Text Value Property.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Property Create(string text)
        {
            return new Property(text);
        }
    }
}
