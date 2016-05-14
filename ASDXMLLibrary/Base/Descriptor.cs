using System;
using ASDXMLLibrary.Objects;
using ASDXMLLibrary.Base.Classifications;

namespace ASDXMLLibrary.Base
{
    public class Descriptor
    {
        public string Text { get; private set; }
        public Classification<LanguageClassification> Language { get; private set; }
        public Organization ProvidedBy { get; set; }
        public DateTime ProvidedDate { get; set; }

        public Descriptor()
        {
            Language = new Classification<LanguageClassification>();
            ProvidedDate = new DateTime();
        }

        public void Set(string value, string language)
        {
            Set(value);
            Language.Set(language);
        }
        public void Set(string value)
        {
            Text = value;
        }

    }
}
