using ASDXMLLibrary.Base.Classifications;
using ASDXMLLibrary.Objects;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace ASDXMLLibrary
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

            PartAsDesigned part = new PartAsDesigned();
            Organization org = new Organization();

            try {
                org.OrgID.ID = "N1234";
                org.OrgID.Class.Value = "CAGE";
                org.OrgName.Set("HiCo-ICS", "en");
                org.OrgName.ProvidedBy = org.Reference;
                org.OrgName.ProvidedDate = DateTime.Now;
                
                part.PartName.Set("Screw", "de");
                part.PartName.ProvidedDate = DateTime.Now;
                part.PartName.ProvidedBy = org.Reference;

                part.PartID.ID = "934.1234.1234.0";
                part.PartID.Class.Value = "PNR";
                part.PartID.SetBy = org;
            }
            catch (ClassificationException ce)
            {
                System.Console.WriteLine(ce.Message);
            }

            var serializer = new XmlSerializer(typeof(ASDXMLLibrary.Objects.Organization));
            using (var writer = XmlWriter.Create("organization.xml"))
            {
                serializer.Serialize(writer, org);
            }

            PartAsDesigned hwpart = new PartAsDesigned();
            Organization readorg = null;
            using (var reader = XmlReader.Create("organization.xml"))
            {
                readorg = (ASDXMLLibrary.Objects.Organization)serializer.Deserialize(reader);
                //hwpart.PartName = (ASDXMLLibrary.Base.Descriptor)serializer.Deserialize(reader);
            }


            System.Console.WriteLine(String.Format("The part is called '{0}' in language '{1}'", part.PartName.Text, part.PartName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", part.PartID.Class.Value, part.PartID.ID));
            System.Console.WriteLine(String.Format("  provided by {0}", part.PartID.SetBy.OrgID.ID));
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(String.Format("And a organization called '{0}' in langauge '{1}'", org.OrgName.Text, org.OrgName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", org.OrgID.Class.Value, org.OrgID.ID));
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(String.Format("The read part is called '{0}' in language '{1}'", hwpart.PartName.Text, hwpart.PartName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", hwpart.PartID.Class.Value, hwpart.PartID.ID));
            System.Console.ReadKey();
        }
    }
}
