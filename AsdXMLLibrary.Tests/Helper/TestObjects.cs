using AsdXMLLibrary.Objects;
using System;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class TestObjects
    {
        
        public static S3000LMessage BasicMessage
        {
            get
            {
                var msg = new S3000LMessage();
                msg.Id.ID = "0001";

                msg.Sender.Add(OrganizationMinimum.GetReference());
                msg.Receiver.Add(OrganizationMinimum.GetReference());

                return msg;
            }
        }
        
        /// <summary>
        /// creates a NEW MockOrganization with Name and ID
        /// </summary>
        /// <returns>an Organization with Name and ID</returns>
        public static Organization OrganizationMinimum
        {
            get
            {
                var org = new Organization();
                org.Name.Text = "OrgMini";
                org.OrgIds.Primary.ID = "N1234";
                return org;
            }
        }

        /// <summary>
        /// Create a NEW MockOrganization with a localized Name and a classified ID
        /// </summary>
        public static Organization OrganizationFull
        {
            get
            {
                var org = TestObjects.OrganizationMinimum;
                org.Name.Language.Value = "EN";
                org.OrgIds.Primary.Class.Value = "CAGE";
                return org;
            }
        }

        /// <summary>
        /// Create a NEW Mock SoftwarePart As Designed with PartID set by a <see cref="OrganizationMinimum"/>
        /// </summary>
        public static SoftwarePartAsDesigned SoftwarePartMinimum
        {
            get
            {
                var sw = new SoftwarePartAsDesigned();
                sw.PartIds.Primary.ID = "PartNumber-1234";
                sw.PartIds.Primary.SetBy = OrganizationMinimum.GetReference();
                return sw;
            }
        }

        /// <summary>
        /// Creates a NEW Mock SoftwarePart as Designed with two PartIds - set by noone.
        /// </summary>
        public static SoftwarePartAsDesigned SoftwarePartMultipleIds
        {
            get
            {
                var sw = new SoftwarePartAsDesigned();
                sw.PartIds.Primary.ID = "Partnumber-1234";
                sw.PartIds.Add(new AsdXMLLibrary.Base.ProvidedIdentifier<AsdXMLLibrary.Base.Classifications.PartIdentifierClassification>("Partnumber-9876"));
                return sw;
            }
        }

        /// <summary>
        /// Create a NEW Mock Software as Designed with two PartNames
        /// </summary>
        public static SoftwarePartAsDesigned SoftwarePartMultipleNames
        {
            get
            {
                var sw = TestObjects.SoftwarePartMinimum;
                sw.PartNames.Primary.Text = "PartName1";
                sw.PartNames.Add(new AsdXMLLibrary.Base.ProvidedDescriptor("Partname2", "EN"));
                return sw;
            }
        }

        public static SoftwarePartAsDesigned SoftwarePartComplete
        {
            get
            {
                var sw = TestObjects.SoftwarePartMinimum;
                sw.PartNames.Primary.Text = "Partname";
                sw.PartNames.Primary.Language.Value = "EN";

                sw.MaturityClass.Value = "COTS";
                sw.MaturityClass.ProvidedDate = DateTime.Now;
                sw.ObsolescenceRiskAssessment.Text = "obsolescenceRiskAssessment";
                sw.DemilitarizationClass.Value = "NAT";
                sw.SpecialHandlingRequirement.Text = "specialhandlingrequirement";
                sw.SoftwarePartSize.CreateRangeProperty(12.5, 17.5, "KB");
                sw.SoftwareType.Value = "L";

                return sw;
            }
        }

        public static HardwarePartAsDesigned HardwarePartMinimum
        {
            get
            {
                var hw = new HardwarePartAsDesigned();
                hw.PartIds.Primary.ID = "PartNumber-1234";
                hw.PartIds.Primary.SetBy = OrganizationMinimum.GetReference();
                return hw;
            }
        }

        public static HardwarePartAsDesigned HardwarePartComplete
        {
            get
            {
                var hw = TestObjects.HardwarePartMinimum;
                hw.PartIds.Add(new AsdXMLLibrary.Base.ProvidedIdentifier<AsdXMLLibrary.Base.Classifications.PartIdentifierClassification>("PartID-2"));

                hw.PartNames.Primary.Text = "Partname";
                hw.PartNames.Primary.Language.Value = "EN";
                hw.PartNames.Add(new AsdXMLLibrary.Base.ProvidedDescriptor("Partname-2", "DE"));

                hw.MaturityClass.Value = "COTS";
                hw.MaturityClass.ProvidedDate = DateTime.Now;
                hw.ObsolescenceRiskAssessment.Text = "obsolescenceRiskAssessment";
                hw.DemilitarizationClass.Value = "NAT";
                hw.SpecialHandlingRequirement.Text = "specialhandlingrequirement";

                //Authorized Life
                var value = hw.AuthorizedLife.AddValue();
                value.CreateRangeProperty(12.5, 17.5, "DAY");
                value = hw.AuthorizedLife.AddValue();
                value.CreateTextProperty("something funny");
                hw.AuthorizedLife.LifeAuthorizingOrganization = OrganizationMinimum.GetReference();

                // SupportData
                hw.LogisticsCategory.Value = "SY";
                hw.Repairability.Value = "R";
                hw.RepairabilityStrategy.Primary.Value = "REP";
                hw.MaintenanceStart.Value = "ENDITEM";
                hw.WasteProductsInUseDisposalDescription.Primary.Text = "wasteproducts in Use";
                hw.WasteProductsPlannedDisposalDescription.Primary.Text = "wasteproducts planned";
                hw.EnvironmentalAspectInUseClass.Primary.Value = "BURN";
                hw.EnvironmentalAspectPlannedDisposalClass.Primary.Value = "ACID";
                hw.ScrapRate.Primary.CreateRangeProperty(10, 12, "PCT");
                hw.ConsumptionRate.Primary.CreateRangeProperty(12, 14, "PCT");

                // Design Data
                hw.HazardousClass.Value = "HAZ";
                hw.FitmentRequirement.Value = "MINOR";
                hw.ElectromagneticIncompatible = true;
                hw.ElectrostaticSensitive = false;
                hw.ElectromagnecticSensitive = true;
                hw.MagneticSensitive = false;
                hw.RadiationSensitive = true;

                return hw;
            }
        }
    }
}
