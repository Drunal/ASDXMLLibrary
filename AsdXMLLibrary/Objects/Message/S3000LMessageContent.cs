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
        [XmlArray(ElementName = "products")]
        [XmlArrayItem(ElementName = "prod")]
        public List<string> Products { get; set; }

        [XmlArray(ElementName = "breakdownElements")]
        [XmlArrayItem(ElementName = "beHw", Type = typeof(string))]
        public List<string> BreakdownElements { get; set; }

        [XmlArray(ElementName="parts")]
        [XmlArrayItem(ElementName = "swPart", Type = typeof(SoftwarePartAsDesigned))]
        [XmlArrayItem(ElementName = "hwPart", Type = typeof(HardwarePartAsDesigned))]
        public List<PartAsDesigned> Parts { get; set; }

        [XmlArray(ElementName = "taskRequirements")]
        [XmlArrayItem(ElementName = "taskReq", Type = typeof(string))]
        public List<string> TaskRequirements { get; set; }

        [XmlArray(ElementName = "tasks")]
        [XmlArrayItem(ElementName = "task", Type = typeof(string))]
        public List<string> Tasks { get; set; }

        public S3000LMessageContent()
        {
            Products = new List<string>();
            BreakdownElements = new List<string>();
            Parts = new List<PartAsDesigned>();
            TaskRequirements = new List<string>();
            Tasks = new List<string>();
        }
    }
}
