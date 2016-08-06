using AsdXMLLibrary.Base;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AsdXMLLibrary
{
    public class ContentManager
    {
        private XmlSerializerNamespaces AsdNamespaces = new XmlSerializerNamespaces();
        private XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());

        private XmlSchemaSet _schemas;

        public static ContentManager Initialize(XmlSchemaSet schemas)
        {
            return new ContentManager(schemas);
        }

        public ContentManager(XmlSchemaSet schemas)
        {
            _schemas = schemas;
            AsdNamespaces.Add(string.Empty, "http://www.asd-europe.org/s-series/s3000l");
            AsdNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            namespaces.AddNamespace(string.Empty, "http://www.asd-europe.org/s-series/s3000l");
            namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        }

        public void SerializeToFile<T>(T serializableObject, string filePath, string rootElementName) //where T:ISerialize
        {
            using (var writer = new FileStream(filePath, FileMode.Create))
                SerializeToStream<T>(serializableObject, writer, rootElementName);
        }

        public void SerializeToStream<T>(T serializableObject, Stream stream, string rootElementName) //where T : ISerialize
        {
            // TODO: move default namespace to parameter to handle s3000l/s2000m files
            if (false)
            {
                var serializer = new XmlSerializer(typeof(T), "http://www.asd-europe.org/s-series/s3000l");
                serializer.Serialize(stream, serializableObject, AsdNamespaces);
            }
            else
            {
                XNamespace ns = "http://www.asd-europe.org/s-series/s3000l";
                new XDocument((serializableObject as SerializeBase).GetXML(rootElementName, ns)).Save(stream);
            }
        }

        public T DeserializeFromFile<T>(string filePath) where T : SerializeBase, new()
        {
            T result = default(T);

            using (var reader = new FileStream(filePath, FileMode.Open))
                result = DeserializeFromStream<T>(reader);
            return result;
        }

        public T DeserializeFromStream<T>(Stream stream) where T : SerializeBase, new()
        {
            // TODO: move default namespace to parameter to handle s3000l/s2000m files

            if (false)
            {
                var serializer = new XmlSerializer(typeof(T), "http://www.asd-europe.org/s-series/s3000l");
                return (T)serializer.Deserialize(stream);
            }
            else
            {
                
                XNamespace ns = "http://www.asd-europe.org/s-series/s3000l";
                XDocument createdXML = XDocument.Load(stream);

                // execute a schema validation prior to deserializing
                // this way we can ensure that the file is schema compliant and we don't need to validate the schema implicitly at every ReadfromXML method.
                createdXML.Validate(_schemas, null);

                T result = new T();
                result.ReadfromXML(createdXML.Root, ns);


                return result;
            }
        }
    }
}
