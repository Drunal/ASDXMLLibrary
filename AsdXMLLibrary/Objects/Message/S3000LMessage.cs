using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.Message;
using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    [XmlRoot(ElementName = "lsaDataSet")]
    public class S3000LMessage
    {
        [XmlElement(ElementName="msgId", IsNullable=true)]
        public ProvidedIdentifier<MessageIdentifierClassification> Id { get; set; }

        [XmlElement(ElementName="msgDate",DataType="date")]
        public DateTime? CreationDate { get; set; }

        [XmlElement(ElementName="msgLang")]
        public Classification Language { get; set; }

        [XmlArray(ElementName="msgSend")]
        [XmlArrayItem(ElementName = "orgRef")]
        public List<OrganizationReference> Sender { get; set; }

        [XmlArray(ElementName = "msgReceive")]
        [XmlArrayItem(ElementName = "orgRef")]
        public List<OrganizationReference> Receiver { get; set; }

        [XmlElement(ElementName="msgContent")]
        public S3000LMessageContentRoot Content { get; set; }

        #region XMLSeriálize Properties
        [XmlIgnore]
        public bool LanguageSpecified { get { return Language.HasValue; } }
        [XmlIgnore]
        public bool CreationDateSpecified { get { return CreationDate.HasValue; } }
        #endregion

        public S3000LMessage()
        {
            this.Language = new Classification(typeof(LanguageClassification));
            this.Sender = new List<OrganizationReference>();
            this.Receiver = new List<OrganizationReference>();
            this.Content = new S3000LMessageContentRoot();
        }
    }
}
