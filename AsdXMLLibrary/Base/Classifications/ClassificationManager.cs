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

        public static ClassificationBase Get(Type classificationType)
        {
            if (!classificiations.ContainsKey(classificationType))
                throw new ClassificationException(string.Format("Classification '{0}' is not initialized!", classificationType.Name));

            return classificiations[classificationType];
        }

        public static void FillDefaultValues()
        {
            Add(new LanguageClassification { "en", "de", "es" });
            Add(new PartIdentifierClassification { "PNO", "NSN", "OEM" });
            Add(new OrganizationIdentifierClassification { "CAGE" });
            Add(new ProjectIdentifierClassification { "PID", "MOI" });
            Add(new ValueDeterminationClassification {
                "ALC", "CALC", "CONTR", "DSG", "EMP", "EST", "MEAS", "PLAN", "REQ", "SET", "SPEC"
            });
            Add(new UnitClassification {
                "BIT", "B", "GB", "KB", "MB", "OC", "PB", "TB"
            });
            Add(new BinaryUnitClassification {
                "BIT", "B", "GB", "KB", "MB", "OC", "PB", "TB"
            });
            Add(new HazardousClassClassification());
            Add(new FitmentRequirementClassification {
                "MINOR", "MAJOR"
            });
            Add(new SoftwareTypeClassification { 
                "D", "E", "L"
            });
            Add(new DummyClassification());
        }

        public static void ClearClassifications()
        {
            classificiations.Clear();
        }
    }
}
