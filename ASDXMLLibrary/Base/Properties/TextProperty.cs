
using System.Xml.Serialization;
namespace ASDXMLLibrary.Base.Properties
{
    public class TextProperty : Property
    {
        [XmlElement(ElementName = "txt")]
        public string Text { get; set; }

        public TextProperty()
            : base()
        {
        }
    }
}
