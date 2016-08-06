using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.Message;
using AsdXMLLibrary.Objects.References;
using System;
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
        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement message = new XElement(ns + elementName);
            message.Add(Id.GetXML(Constants.MessageIdElementName, ns));
            if (CreationDate.HasValue)
                message.Add(new XElement(ns + Constants.MessageDateElementName, CreationDate.ToXmlDateString()));
            message.Add(Language.GetXML(Constants.MessageLanguageElementName, ns));
            // TODO: we probably need a container around this
            foreach (var sender in Sender)
                message.Add(sender.GetXML(Constants.ReferenceOrganizationElementName, ns));
            foreach (var receiver in Receiver)
                message.Add(receiver.GetXML(Constants.ReferenceOrganizationElementName, ns));
           
            XElement messageContent = new XElement(ns + Constants.MessageContentElementName);
            messageContent.Add(ContentItems.GetXML(Constants.MessageContentItemsElementName, ns));
            //messageContent.Add(SupportingItems.GetXML(Constants.MessageContentSupportingItemsElementName, ns));

            message.Add(messageContent);

            return message;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
