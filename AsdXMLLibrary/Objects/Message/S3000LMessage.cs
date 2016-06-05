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
        [XmlElement(ElementName="msgId")]
        public Identifier<MessageIdentifierClassification> Id { get; set; }

        [XmlElement(ElementName="msgDate",DataType="date")]
        public DateTime? CreationDate { get; set; }

        [XmlElement(ElementName="msgLang")]
        public Classification Language { get; set; }

        [XmlElement(ElementName="msgSend")]
        public OrganizationReference Sender { get; set; }

        [XmlElement(ElementName = "msgReceive")]
        public OrganizationReference Receiver { get; set; }

        [XmlElement(ElementName="msgContent")]
        public S3000LMessageContentRoot Content { get; set; }

        #region XMLSeriálize Properties
        [XmlIgnore]
        public bool IdSpecified { get { return Id.HasValue; } }
        [XmlIgnore]
        public bool CreationDateSpecified { get { return CreationDate.HasValue; } }
        [XmlIgnore]
        public bool LangaugeSpecified { get { return Language.HasValue; } }
        [XmlIgnore]
        public bool SenderSpecified { get { return Sender.HasValue; } }
        [XmlIgnore]
        public bool ReceiverSpecified { get { return Receiver.HasValue; } }
        #endregion

        public S3000LMessage()
        {
            this.Id = new Identifier<MessageIdentifierClassification>();
            this.Language = new Classification(typeof(LanguageClassification));
            this.Sender = new OrganizationReference();
            this.Receiver = new OrganizationReference();
            this.Content = new S3000LMessageContentRoot();
        }
    }
}
