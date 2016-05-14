﻿using System;
using ASDXMLLibrary.Objects;
using ASDXMLLibrary.Base.Classifications;
using ASDXMLLibrary.Base.Properties;
using System.Xml.Serialization;

namespace ASDXMLLibrary.Base
{
    public class Descriptor
    {
        [XmlElement(ElementName = "descr", Order = 0)]
        public string Text { get; set; }

        [XmlElement(ElementName = "lang", Order = 1)]
        public Classification<LanguageClassification> Language { get; set; }

        [XmlElement(ElementName = "date", Order = 2, DataType = "date")]
        public DateTime ProvidedDate { get; set; }

        [XmlElement(ElementName = "providedBy", Order = 3)]
        public OrganizationReference ProvidedBy { get; set; }


        #region XML Handling Properties
        // these properties control if the respective property is written to the xml or not

        [XmlIgnore]
        protected bool LanguageSpecified { get { return Language.HasValue; } }
        [XmlIgnore] // if Ticks is 0 then the ProvidedDate equal 0001-01-01T00:00:00 and was most likely not set.
        protected bool ProvidedDateSpecified { get { return ProvidedDate.Ticks > 0; } }
        [XmlIgnore]
        protected bool ProvidedBySpecified { get { return ProvidedBy != null; } }

        #endregion

        #region Constructors

        public Descriptor()
        {
            Language = new Classification<LanguageClassification>();
        }

        #endregion


        #region Easy Work Methods

        public void Set(string value, string language)
        {
            Set(value);
            Language.Value = language;
        }
        public void Set(string value)
        {
            Text = value;
        }
        #endregion
    }
}
