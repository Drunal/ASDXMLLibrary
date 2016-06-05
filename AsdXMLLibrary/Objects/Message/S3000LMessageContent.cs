using AsdXMLLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.Message
{
    
    public class S3000LMessageContent
    {
        [XmlArray(ElementName="parts")]
        [XmlArrayItem(ElementName = "swPart", Type = typeof(SoftwarePartAsDesigned))]
        [XmlArrayItem(ElementName = "hwPart", Type = typeof(HardwarePartAsDesigned))]
        public List<PartAsDesigned> Parts { get; set; }

        #region XML Serialization Properties
       
        #endregion

        public S3000LMessageContent()
        {
            Parts = new List<PartAsDesigned>();
        }
    }
}
