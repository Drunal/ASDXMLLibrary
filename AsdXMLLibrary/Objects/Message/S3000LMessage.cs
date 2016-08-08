using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.Message;
using AsdXMLLibrary.Objects.References;
using System;
using System.Xml;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects
{
    public class S3000LMessage : SerializeBase
    {
        public ProvidedIdentifier<MessageIdentifierClassification> Id { get; set; }

        public DateTime? CreationDate { get; set; }

        public Classification Language { get; set; }

        public MultipleValues<OrganizationReference> Sender { get; set; }

        public MultipleValues<OrganizationReference> Receiver { get; set; }

        public S3000LMessageContent ContentItems { get; set; }

        public S3000LSupportingContent SupportingItems { get; set; }

        public S3000LMessage()
        {
            this.Id = new ProvidedIdentifier<MessageIdentifierClassification>();
            this.Language = new Classification(typeof(LanguageClassification));
            this.Sender = new MultipleValues<OrganizationReference>();
            this.Receiver = new MultipleValues<OrganizationReference>();
            this.ContentItems = new S3000LMessageContent();
            this.SupportingItems = new S3000LSupportingContent();
        }

        #region Serialize Methods
        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement message = new XElement(ns + elementName);
            message.Add(Id.CreateXML(Constants.MessageIdElementName, ns));
            if (CreationDate.HasValue)
                message.Add(new XElement(ns + Constants.MessageDateElementName, CreationDate.ToXmlDateString()));
            message.Add(Language.CreateXML(Constants.MessageLanguageElementName, ns));
            // TODO: we probably need a container around this
            XElement senderList = new XElement(ns + Constants.MessageSenderElementName);
            foreach (var sender in Sender)
                senderList.Add(sender.CreateXML(Constants.ReferenceOrganizationElementName, ns));
            XElement receiverList = new XElement(ns + Constants.MessageReceiverElementName);
            foreach (var receiver in Receiver)
                receiverList.Add(receiver.CreateXML(Constants.ReferenceOrganizationElementName, ns));

            message.Add(senderList);
            message.Add(receiverList);

            XElement messageContent = new XElement(ns + Constants.MessageContentElementName);
            messageContent.Add(ContentItems.CreateXML(Constants.MessageContentItemsElementName, ns));
            messageContent.Add(SupportingItems.CreateXML(Constants.MessageContentSupportingItemsElementName, ns));

            message.Add(messageContent);

            return message;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false;

            Id.ReadfromXML(element.Element(ns + Constants.MessageIdElementName), ns);
            XElement date = element.Element(ns + Constants.MessageDateElementName);
            if (date != null)
                CreationDate = XmlConvert.ToDateTime(date.Value, XmlDateTimeSerializationMode.Local);
            Language.ReadfromXML(element.Element(ns + Constants.MessageLanguageElementName), ns);

            Sender.Clear();
            foreach (XElement senderElement in element.Element(ns + Constants.MessageSenderElementName).Elements(ns + Constants.ReferenceOrganizationElementName))
            {
                OrganizationReference orgRef = new OrganizationReference();
                orgRef.ReadfromXML(senderElement, ns);
                Sender.Add(orgRef);
            }

            Receiver.Clear();
            foreach (XElement receiverElement in element.Element(ns + Constants.MessageReceiverElementName).Elements(ns + Constants.ReferenceOrganizationElementName))
            {
                OrganizationReference orgRef = new OrganizationReference();
                orgRef.ReadfromXML(receiverElement, ns);
                Receiver.Add(orgRef);
            }

            ContentItems.ReadfromXML(element.Element(ns + Constants.MessageContentElementName).Element(ns + Constants.MessageContentItemsElementName), ns);
            SupportingItems.ReadfromXML(element.Element(ns + Constants.MessageContentElementName).Element(ns + Constants.MessageContentSupportingItemsElementName), ns);

            return true;
        }
        #endregion
    }
}
