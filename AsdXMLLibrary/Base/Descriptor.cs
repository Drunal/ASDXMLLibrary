﻿using AsdXMLLibrary.Base.Classifications;
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

        [XmlElement(ElementName = "date", DataType = "date")]
        public DateTime ProvidedDate { get; set; }

        [XmlElement(ElementName = "providedBy")]
        public OrganizationReference ProvidedBy { get; set; }

        #region XML Handling Properties
        /// these properties control if the respective property is written to the xml or not
        [XmlIgnore]
        public bool LanguageSpecified { get { return Language.HasValue; } }
        [XmlIgnore] // if Ticks is 0 then the ProvidedDate equal 0001-01-01T00:00:00 and was most likely not set.
        public bool ProvidedDateSpecified { get { return ProvidedDate.Ticks > 0; } }
        [XmlIgnore]
        public bool ProvidedBySpecified { get { return ProvidedBy != null; } }

        #endregion

        #region Constructors

        public Descriptor()
        {
            Language = new Classification(typeof(LanguageClassification));
        }

        public Descriptor(string text)
            : this()
        {
            Text = text;
        }

        public Descriptor(string text, string language)
            : this(text)
        {
            Language.Value = language;
        }

        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(Text); }
        }
    }
}
