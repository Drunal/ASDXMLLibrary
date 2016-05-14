using ASDXMLLibrary.Base.Classifications;
using ASDXMLLibrary.Objects;
using System;

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
                part.PartName.Set("Screw", "de");
                part.PartID.ID = "934.1234.1234.0";
                part.PartID.Class.Set("PNR");

                org.OrgID.ID = "N1234";
                org.OrgID.Class.Set("CAGE");
                org.OrgName.Set("HiCo-ICS");
            }
            catch (ClassificationException ce)
            {
                System.Console.WriteLine(ce.Message);
            }

            System.Console.WriteLine(String.Format("The part is called '{0}' in language '{1}'", part.PartName.Text, part.PartName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", part.PartID.Class.Value, part.PartID.ID));
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(String.Format("And a organization called '{0}' in langauge '{1}'", org.OrgName.Text, org.OrgName.Language.Value));
            System.Console.WriteLine(String.Format("  with the {0} identification of '{1}'", org.OrgID.Class.Value, org.OrgID.ID));
            System.Console.ReadKey();
        }
    }
}
