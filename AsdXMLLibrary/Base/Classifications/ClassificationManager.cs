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
            Add(new MessageIdentifierClassification { "MSN", "MID" });
            
            Add(new LanguageClassification { "EN", "DE", "ES" });
            Add(new PartIdentifierClassification { "PNO", "NSN", "OEM" });
            Add(new OrganizationIdentifierClassification { "CAGE" });
            Add(new ProjectIdentifierClassification { "PID", "MOI" });
            Add(new ValueDeterminationClassification {
                "ALC", "CALC", "CONTR", "DSG", "EMP", "EST", "MEAS", "PLAN", "REQ", "SET", "SPEC"
            });
            Add(new SoftwareSizeUnit {
                "KB", "MB", "GB"
            });
            Add(new EventUnit {
                "C", "FC", "OH", "FH", "S", "LA", "LD", "DL", "OP", "SO", "FI", "RD"
            });
            Add(new LengthUnit {
                "M2", "CM", "KM", "MI", "NM"
            });
            Add(new TimeUnit {
                "SEC", "MIN", "HR", "DAY", "MON", "YR", "WK"
            });
            Add(new HazardousClassClassification()
            {
                "HAZ"
            });
            Add(new FitmentRequirementClassification {
                "MINOR", "MAJOR"
            });
            Add(new SoftwareTypeClassification { 
                "D", "E", "L"
            });

            Add(new DemilitarizationClassification {
                "N/A", "TSC", "KEY", "MUT", "NAT", "IBD", "PRI", "SEC"
            });
            Add(new MaturityClassification { 
                "NEW", "MOD-L", "MOD-M", "COTS", "CFE", "OBS"
            });

            TimeCycleUnit tcu = new TimeCycleUnit();
            tcu.AddRange(Get(typeof(EventUnit)));
            tcu.AddRange(Get(typeof(LengthUnit)));
            tcu.AddRange(Get(typeof(TimeUnit)));
            Add(tcu);
            
            Add(new DummyClassification());
        }

        public static void ClearClassifications()
        {
            classificiations.Clear();
        }
    }
}
