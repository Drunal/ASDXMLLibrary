using AsdXMLLibrary.Base;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AsdXMLLibrary.Tests.Helper
{
    public abstract class SerializeTestBase : TestBase
    {
        protected abstract string TestRootElementName { get; }

        /// <summary>
        /// serializes the given object to a Stream.
        /// Loads that stream as an XDocument, which is validated against the schemas
        /// deserializes the stream and returns the new object.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="input">The actual object to be serialized</param>
        /// <returns>A deserialized object of type T</returns>
        internal T ObjectStreamtoObject<T>(T input) where T : SerializeBase, new()
        {
            MemoryStream ms = new MemoryStream();
            manager.SerializeToStream<T>(input, ms, TestRootElementName);
            manager.SerializeToFile<T>(input, "output.xml", TestRootElementName);

            ms.Position = 0;
            XDocument createdXML = XDocument.Load(ms);
            createdXML.Validate(schemas, null);

            ms.Position = 0;
            return manager.DeserializeFromStream<T>(ms);
        }
    }
}
