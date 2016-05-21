using AsdXMLLibrary.Base.Classifications;
using AsdXMLLibrary.Objects;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace AsdXMLLibrary
{
    public static class Program
    {
        public static void Main()
        {
            LanguageClassification language = new LanguageClassification();
            language.AddRange(new string[]{"de", "en"});

            PartIdentifierClassification partIdent = new PartIdentifierClassification();
            partIdent.Add("PNR");
            partIdent.Add("NSN");

            OrganizationIdentifierClassification orgIdclass = new OrganizationIdentifierClassification();
            orgIdclass.Add("CAGE");

            ClassificationManager.Add(language);
            ClassificationManager.Add(partIdent);
            ClassificationManager.Add(orgIdclass);
            ClassificationManager.FillDefaultValues();

            HardwarePartAsDesigned part = new HardwarePartAsDesigned();
            Organization org = new Organization();

            try {
                org.OrgID.ID = "N1234";
                org.OrgID.Class.Value = "CAGE";
                //org.Name.Set("HiCo-ICS", "en");
                org.Name.ProvidedBy = org.Reference;
                org.Name.ProvidedDate = DateTime.Now;
                
                //part.PartName.Set("Screw", "de");
                part.PartName.ProvidedDate = DateTime.Now;
                part.PartName.ProvidedBy = org.Reference;

                part.PartID.ID = "934.1234.1234.0";
                part.PartID.Class.Value = "PNR";
                part.PartID.SetBy = org.Reference;
                part.ElectrostaticSensitive = true;

            }
            catch (ClassificationException ce)
            {
                System.Console.WriteLine(ce.Message);
            }

            var serializer = new XmlSerializer(typeof(AsdXMLLibrary.Objects.HardwarePartAsDesigned));
            using (var writer = XmlWriter.Create("part.xml"))
            {
                serializer.Serialize(writer, part);
            }

            HardwarePartAsDesigned hwpart = new HardwarePartAsDesigned();
            using (var reader = XmlReader.Create("part.xml"))
            {
                hwpart = (AsdXMLLibrary.Objects.HardwarePartAsDesigned)serializer.Deserialize(reader);
                //hwpart.PartName = (ASDXMLLibrary.Base.Descriptor)serializer.Deserialize(reader);
            }


            System.Console.WriteLine(String.Format("The part is called '{0}' in language '{1}'", part.PartName.Text, part.PartName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", part.PartID.Class.Value, part.PartID.ID));
            System.Console.WriteLine(String.Format("  provided by {0}", part.PartID.SetBy.OrgID.ID));
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(String.Format("And a organization called '{0}' in langauge '{1}'", org.Name.Text, org.Name.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", org.OrgID.Class.Value, org.OrgID.ID));
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(String.Format("The read part is called '{0}' in language '{1}'", hwpart.PartName.Text, hwpart.PartName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", hwpart.PartID.Class.Value, hwpart.PartID.ID));
            System.Console.ReadKey();
        }
    }
}
