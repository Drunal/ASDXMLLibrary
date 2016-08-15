
namespace AsdXMLLibrary.Base
{
    static class Constants
    {
        #region Dummys
        public static readonly string DefaultDescriptorElementName = "Descriptor";
        public static readonly string DefaultClassificationElementName = "Classification";
        public static readonly string DefaultIdentifierElementName = "Identifier";
        public static readonly string DefaultPropertyElementName = "Property";
        #endregion

        #region Generals
        public static readonly string DescriptorTextElementName = "descr";
        public static readonly string LanguageElementName = "lang";
        public static readonly string DateElementName = "date";
        public static readonly string ProvidedByElementName = "providedBy";
        public static readonly string SetByElementName = "setBy";
        public static readonly string ClassElementName = "class";
        public static readonly string IdentifierElementName = "id";
        public static readonly string NameElementName = "name";
        public static readonly string OrganizationIdElementName = "orgId";
        #endregion

        #region Message
        public static readonly string MessageIdElementName = "msgId";
        public static readonly string MessageDateElementName = "msgDate";
        public static readonly string MessageLanguageElementName = "msgLang";
        public static readonly string MessageStatusElementName = "msgStatus";
        public static readonly string MessageSenderElementName = "msgSend";
        public static readonly string MessageReceiverElementName = "msgReceive";
        public static readonly string MessageContentElementName = "msgContent";

        public static readonly string MessageContentItemsElementName = "messageContentItems";
        public static readonly string MessageContentProductsElementName = "products";
        public static readonly string MessageContentBreakdownElementsElementName = "breakdownElements";
        public static readonly string MessageContentPartsElementName = "parts";
        public static readonly string MessageContentTaskRequirementsElementName = "taskRequirements";
        public static readonly string MessageContentTasksElementName = "tasks";
        
        public static readonly string MessageContentSupportingItemsElementName = "supportingContentItems";


        #endregion

        #region References
        public static readonly string ReferenceOrganizationElementName = "orgRef";
        #endregion

        #region Properties
        public static readonly string PropertyValueDeterminationElementName = "vdtm";
        public static readonly string PropertyUnitElementName = "unit";
        public static readonly string PropertyValueElementName = "value";
        public static readonly string PropertyNominalValueElementName = "nomVal";
        public static readonly string PropertyLowerOffsetElementName = "lowOff";
        public static readonly string PropertyUpperOffsetElementName = "uppOff";
        public static readonly string PropertyLowerValueElementName = "lowVal";
        public static readonly string PropertyUpperValueElementName = "uppVal";
        public static readonly string PropertyTextElementName = "txt";

        #endregion

        #region Parts
        public static readonly string PartAsDesignedPartIdElementName = "partId";
        public static readonly string PartAsDesignedPartNameElementName = "name";
        public static readonly string PartSpecialHandlingRequirementElementName = "phstReq";
        public static readonly string PartMaturityClassElementName = "maturity";
        public static readonly string PartObsolescenceRiskAssessmentElementName = "obsRisk";
        public static readonly string PartDemilitarizationClassElementName = "dec";


        public static readonly string HardwarePartAsDesignedElementName = "hwPart";
        public static readonly string HardwarePartHazardousClassElementName = "haz";
        public static readonly string HardwarePartFitmentRequirementElementName = "ftc";

        public static readonly string SoftwarePartAsDesignedElementName = "swPart";
        public static readonly string SoftwareTypeElementName = "swType";
        public static readonly string SoftwarePartSizeElementName = "swSize";
        #endregion
    }
}
