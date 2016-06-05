using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects.References;
using System;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    [XmlRoot(ElementName="Descriptor")]
    public class Descriptor : IHaveValue
    {
        [XmlElement(ElementName = "descr")]
        public string Text { get; set; }

        [XmlElement(ElementName = "lang")]
        public Classification Language { get; set; }

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool LanguageSpecified { get { return Language.HasValue; } }
        #endregion

        #region Constructors
        public Descriptor()
            : this(string.Empty)
        { }

        public Descriptor(string text)
            : this(text, string.Empty)
        { }

        public Descriptor(string text, string language)
        {
            Text = text;
            Language = new Classification(typeof(LanguageClassification));
            Language.Value = language;
        }

        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(Text); }
        }
    }
}
