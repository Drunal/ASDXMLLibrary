using AsdXMLLibrary.Base;
using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Base.Properties;
using AsdXMLLibrary.Objects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Objects
{
    [XmlRoot(ElementName="swPart")]
    public class SoftwarePartAsDesigned : PartAsDesigned
    {
        #region Design Data
        [XmlElement(ElementName = "swType")]
        public Classification SoftwareType { get; set; }

        [XmlElement(ElementName="swSize")]
        public Property<BinaryUnitClassification> SoftwarePartSize { get; set; }
        
        #endregion

        #region XML Handling Properties
        [XmlIgnore]
        public bool SoftwareTypeSpecified { get { return SoftwareType.HasValue; } }
        [XmlIgnore]
        public bool SoftwarePartSizeSpecified { get { return SoftwarePartSize != null && SoftwarePartSize.HasValue; } }
        #endregion

        public SoftwarePartAsDesigned()
            : base()
        {
            SoftwareType = new Classification(typeof(SoftwareTypeClassification));
            SoftwarePartSize = null;
        }

        public PartReference Reference
        {
            get
            {
                return (PartReference)this.GetReference();
            }
        }
    }
}
