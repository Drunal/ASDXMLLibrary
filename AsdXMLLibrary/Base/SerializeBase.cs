using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public abstract class SerializeBase
    {
        /// <summary>
        /// Should return an XElement with the given name, in the given namespace.
        /// Will return 'null' if there is no content available.
        /// Creation of the element can be forced with <paramref name="forceElement"/>
        /// </summary>
        /// <param name="elementName">the local name of the wanted element</param>
        /// <param name="ns">the namespace to create the element (and its children) in</param>
        /// <param name="forceElement">a flag to enforce the creation of the element, even if there is not meaningful content</param>
        /// <returns>an XElement object or 'null'.</returns>
        public abstract XElement CreateXML(string elementName, XNamespace ns, bool forceElement=false);

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
