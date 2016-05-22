using System;
using System.Collections.Generic;

namespace AsdXMLLibrary.Base.Classifications
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
                    throw new ClassificationException(string.Format("Classification '{0}' already initialized!", type.Name));
            }

            classificiations.Add(type, validValues);
        }

        public static ClassificationBase Get<TValueList>()
        {
            Type type = typeof(TValueList);

            if (!classificiations.ContainsKey(type))
                throw new ClassificationException(string.Format("Classification '{0}' is not initialized!", type.Name));

            return classificiations[type];
        }

        public static void FillDefaultValues()
        {
            Add(new LanguageClassification { "en" });
            Add(new PartIdentifierClassification { "PNR" });
            Add(new OrganizationIdentifierClassification { "CAGE" });
            Add(new ProjectIdentifierClassification());
            Add(new ValueDeterminationClassification());
            Add(new UnitClassification());
            Add(new HazardousClassClassification());
            Add(new FitmentRequirementClassification {
                "MINOR", "MAJOR"
            });
        }

        public static void ClearClassifications()
        {
            classificiations.Clear();
        }
    }
}
