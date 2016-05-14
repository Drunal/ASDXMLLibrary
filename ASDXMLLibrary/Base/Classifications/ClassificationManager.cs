using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDXMLLibrary.Base.Classifications
{
    public static class ClassificationManager
    {
        private static Dictionary<Type, ClassificationBase> classificiations = new Dictionary<Type, ClassificationBase>();

        public static void Add(ClassificationBase validValues)
        {
            Add(validValues, false);
        }

        public static void Add(ClassificationBase validValues, bool overwrite) 
        {
            Type type = validValues.GetType();

            if (classificiations.ContainsKey(type))
            {
                if (overwrite)
                    classificiations.Remove(type);
                else
                    throw new ClassificationException(String.Format("Classification '{0}' already initialized!", type.Name));
            }

            classificiations.Add(type, validValues);
        }

        public static ClassificationBase Get<TValueList>()
        {
            Type type = typeof(TValueList);

            if (!classificiations.ContainsKey(type))
                throw new ClassificationException(String.Format("Classification '{0}' is not initialized!", type.Name));

            return classificiations[type];
        }
        

    }
}
