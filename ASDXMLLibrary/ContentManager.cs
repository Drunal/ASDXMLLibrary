using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AsdXMLLibrary
{
    public static class ContentManager
    {
        public static void SerializeToFile<T>(T serializableObject, string filePath)
        {
            using (var writer = new FileStream(filePath, FileMode.Create))
                SerializeToStream<T>(serializableObject, writer);
        }

        public static T DeserializeFromFile<T>(string filePath)
        {
            T result = default(T);

            using (var reader = new FileStream(filePath, FileMode.Open))
                result = DeserializeFromStream<T>(reader);
            return result;
        }

        public static void SerializeToStream<T>(T serializableObject, Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, serializableObject);
        }

        public static T DeserializeFromStream<T>(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
}
