using System;
using System.Collections.Generic;
using System.Xml.Linq;

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

        /// <summary>
        /// Returns a filtered collection of the child elements of this element or document, in document order. 
        /// Only elements that have a matching <see cref="System.Xml.Linq.XName"/> are included in the collection.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> Elements( this XContainer element, params XName[] names)
        {
            List<XElement> result = new List<XElement>();
            foreach (var name in names)
                result.AddRange(element.Elements(name));
            return result.InDocumentOrder();
        }
    }
}
