using AsdXMLLibrary.Base.Classifications;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    [XmlRoot(ElementName = "Descriptor")]
    public class Descriptor : SerializeBase, IHaveValue
    {
        [XmlElement(ElementName = "descr")]
        public string Text { get; set; }
        [XmlElement(ElementName = "lang")]
        public Classification Language { get; set; }

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool LanguageSpecified { get { return Language.HasValue; } }
        #endregion

        #region Constructors
        public Descriptor()
            : this(Constants.DefaultDescriptorElementName)
        { 
            // TODO: write to logger, that we are using the default name, which is probably not intended.
        }

        public Descriptor(string elementName)
            : this(elementName, string.Empty)
        { }

        public Descriptor(string elementName, string text)
            : this(elementName, text, string.Empty)
        { }

        public Descriptor(string elementName, string text, string language)
            :base (elementName)
        {
            Text = text;
            Language = new Classification(Constants.LanguageElementName, typeof(LanguageClassification));
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
