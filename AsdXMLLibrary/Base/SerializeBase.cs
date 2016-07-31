using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public abstract class SerializeBase
    {
        protected readonly string _elementName;

        public SerializeBase(string elementName)
        {
            this._elementName = elementName;
        }


        public abstract XElement GetXML(XNamespace ns, bool forceElement=false);

        /// <summary>
        /// Reads data from the passed XElement element. 
        /// This method assumes that the given XElement is schema valid. 
        /// This means it only checks for optional elements, but not if the elements are actually named or ordered correctly. This check should happen beforehand through schema.
        /// </summary>
        /// <param name="element">The XElement to extract the data from.</param>
        /// <param name="ns">The default namespace of the passed xml. Can be used to adress elements properly.</param>
        /// <returns><value>True</value> if the data could be extracted, <value>False</value> otherwise.
        /// <remarks>Note that <value>False</value> can also mean, that there was no element and therefore not data was exported.</remarks>
        /// </returns>
        public abstract bool ReadfromXML(XElement element, XNamespace ns);
    }
}
