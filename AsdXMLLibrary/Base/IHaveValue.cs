using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public interface IHaveValue
    {
        [XmlIgnore]
        bool HasValue {get;}
    }
}
