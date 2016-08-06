using AsdXMLLibrary.Base;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AsdXMLLibrary.Objects.Message
{
    public class S3000LSupportingContent : SerializeBase
    {
        public List<Organization> Organizations { get; set; }


        public S3000LSupportingContent()
        {
            Organizations = new List<Organization>();
        }

        public override XElement GetXML(string elementName, XNamespace ns, bool forceElement = false)
        {
            throw new NotImplementedException();
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            throw new NotImplementedException();
        }
    }
}
