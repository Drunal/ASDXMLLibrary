using System;

namespace AsdXMLLibrary.Base
{
    public static class XmlExtensionMethods
    {
        public static string ToXmlDateString (this DateTime? date)
        {
            if(date.HasValue)
                return date.Value.ToString("yyyy-MM-dd");
            return string.Empty;
        }

    }
}
