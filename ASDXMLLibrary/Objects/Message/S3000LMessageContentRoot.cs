using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.Message
{
    public class S3000LMessageContentRoot
    {
        [XmlElement(ElementName="messageContentItems")]
        public S3000LMessageContent ContentItems { get; set; }

        [XmlElement(ElementName="supportingContentItems")]
        public S3000LSupportingContent SupportingItems { get; set; }

        public S3000LMessageContentRoot()
        {
            ContentItems = new S3000LMessageContent();
            SupportingItems = new S3000LSupportingContent();
        }

    }
}
