using AsdXMLLibrary.Base.Classifications;
using System.Xml.Linq;

namespace AsdXMLLibrary.Base
{
    public class Descriptor : SerializeBase, IHaveValue
    {
        public string Text { get; set; }
        public Classification Language { get; set; }

        #region Constructors
        public Descriptor()
            : this(string.Empty)
        { }

        public Descriptor(string text)
            : this(text, string.Empty)
        { }

        public Descriptor(string text, string language)
        {
            Text = text;
            Language = new Classification(typeof(LanguageClassification));
            Language.Value = language;
        }

        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(Text); }
        }

        #region Serialize
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement descriptor = new XElement(ns + elementName);
            descriptor.Add(new XElement(ns + Constants.DescriptorTextElementName, Text));
            descriptor.Add(Language.GetXML(Constants.LanguageElementName, ns));

            return descriptor;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false; // TODO: throw an error here? no element was passed, so the expected description was not there. At that point we do not know if it is expected or not.

            // it must have a (first) child element called "Constants.DescriptorTextElementName", 
            // its content is the descriptor Text
            // if this failes we should not be here in the first place (see Documentation of ISerialize.ReadFromXml())
            Text = element.Element(ns + Constants.DescriptorTextElementName).Value;
            
            // and it MAY have a language element next, but this is checked in Language.ReadFromXML().
            // this will return false, if the element is not there - which is okay, since it is optional.
            Language.ReadfromXML(element.Element(ns + Constants.LanguageElementName), ns);

            return true; 
        }
        #endregion
    }
}
