using ASDXMLLibrary.Base.Classifications;
using ASDXMLLibrary.Objects;
using System;

namespace ASDXMLLibrary
{
    public static class Program
    {
        public static void Main()
        {
            LanguageClassification.Instance.Values.AddRange(new string[]{"de", "en"});
            PartIdentifierClassification.Instance.Values.Add("PNR");
            PartIdentifierClassification.Instance.Values.Add("NSN");

            PartAsDesigned part = new PartAsDesigned();

            try { 
                part.PartName.Set("Screw", "de");
                part.PartID.ID = "934.1234.1234.0";
                part.PartID.Class.Set("PNR");
            }
            catch (ClassificationException ce)
            {
                System.Console.WriteLine(ce.Message);
            }

            System.Console.WriteLine(String.Format("The part is called '{0}' in language '{1}'", part.PartName.Text, part.PartName.Language.Value));
            System.Console.WriteLine(String.Format("and has the {0} identification of '{1}'", part.PartID.Class.Value, part.PartID.ID));
            System.Console.ReadKey();
        }
    }
}
