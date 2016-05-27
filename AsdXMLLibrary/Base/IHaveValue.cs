using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    public interface IHaveValue
    {
        [XmlIgnore]
        bool HasValue {get;}
    }
}
