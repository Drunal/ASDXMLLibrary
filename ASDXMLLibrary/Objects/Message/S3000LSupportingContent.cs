using AsdXMLLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects.Message
{
    public class S3000LSupportingContent
    {
        [XmlArray(ElementName = "organizations")]
        [XmlArrayItem(ElementName = "org")]
        public List<Organization> Organizations { get; set; }

        #region XML Serialization Properties
       
        #endregion

        public S3000LSupportingContent()
        {
            Organizations = new List<Organization>();
        }
    }
}
