using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AsdXMLLibrary
{
    public static class ContentManager
    {
        public static void Serialize<T>(T serializableObject, string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = XmlWriter.Create(filePath))
                serializer.Serialize(writer, serializableObject);
        }

        public static T Deserialize<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            T result = default(T);
            
            using (var reader = XmlReader.Create(filePath))
                result = (T)serializer.Deserialize(reader);
            return result;
        }
    }
}
