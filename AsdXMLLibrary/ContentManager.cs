using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AsdXMLLibrary
{
    public static class ContentManager
    {
        private static XmlSerializerNamespaces AsdNamespaces = new XmlSerializerNamespaces();

        static ContentManager()
        {
            AsdNamespaces.Add(string.Empty, "http://www.asd-europe.org/s-series/s3000l");
        }

        public static void SerializeToFile<T>(T serializableObject, string filePath)
        {
            using (var writer = new FileStream(filePath, FileMode.Create))
                SerializeToStream<T>(serializableObject, writer);
        }

        public static void SerializeToStream<T>(T serializableObject, Stream stream)
        {
            // TODO: move default namespace to parameter to handle s3000l/s2000m files
            var serializer = new XmlSerializer(typeof(T), "http://www.asd-europe.org/s-series/s3000l");
            serializer.Serialize(stream, serializableObject, AsdNamespaces);
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            T result = default(T);

            using (var reader = new FileStream(filePath, FileMode.Open))
                result = DeserializeFromStream<T>(reader);
            return result;
        }

        public static T DeserializeFromStream<T>(Stream stream)
        {
            // TODO: move default namespace to parameter to handle s3000l/s2000m files
            var serializer = new XmlSerializer(typeof(T), "http://www.asd-europe.org/s-series/s3000l");
            return (T)serializer.Deserialize(stream);
        }
    }
}
