
using System.Xml.Serialization;
namespace AsdXMLLibrary.Base.Properties
{
    public class TextProperty : Property
    {
        [XmlElement(ElementName = "txt")]
        public string Text { get; set; }

        public TextProperty()
            : base()
        {
        }

        public override bool HasValue
        {
            get { return !string.IsNullOrEmpty(Text); }
        }
    }
}
