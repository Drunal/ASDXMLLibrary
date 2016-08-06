using AsdXMLLibrary.Base;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects.Message
{
    public class S3000LMessageContent : SerializeBase
    {
        public List<string> Products { get; set; }

        public List<string> BreakdownElements { get; set; }

        public List<PartAsDesigned> Parts { get; set; }

        public List<string> TaskRequirements { get; set; }

        public List<string> Tasks { get; set; }

        public S3000LMessageContent()
        {
            Products = new List<string>();
            BreakdownElements = new List<string>();
            Parts = new List<PartAsDesigned>();
            TaskRequirements = new List<string>();
            Tasks = new List<string>();
        }

        public override XElement CreateXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            XElement contentItems = new XElement(ns + elementName);

            contentItems.Add(new XElement(ns + Constants.MessageContentProductsElementName));
            contentItems.Add(new XElement(ns + Constants.MessageContentBreakdownElementsElementName));

            XElement parts = new XElement(ns + Constants.MessageContentPartsElementName);
            foreach (var part in Parts)
            {
                // TODO: not entirly sure, that is a solution i like.
                // but it is necessary, because i have two kind of classes:
                // * Base classes like Descripter, Identifier, Classification
                //      those do not know their respective element name in the XML
                // * Object classes like Product/Part.
                //      those (usually) know their respective element name
                if (part.GetType() == typeof(SoftwarePartAsDesigned))
                    parts.Add(part.CreateXML(Constants.SoftwarePartAsDesignedElementName, ns));
                else if (part.GetType() == typeof(HardwarePartAsDesigned))
                    parts.Add(part.CreateXML(Constants.HardwarePartAsDesignedElementName, ns));
            }
            contentItems.Add(parts);

            contentItems.Add(new XElement(ns + Constants.MessageContentTaskRequirementsElementName));
            contentItems.Add(new XElement(ns + Constants.MessageContentTasksElementName));

            return contentItems;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            throw new NotImplementedException();
        }
    }
}
