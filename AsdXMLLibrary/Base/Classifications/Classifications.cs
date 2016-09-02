
namespace AsdXMLLibrary.Base.Classifications
{
    // used for serialization
    public class DummyClassification : ClassificationBase { }

    #region MessageClassifications
    public class MessageIdentifierClassification : ClassificationBase { }
    #endregion

    public class LanguageClassification : ClassificationBase { }
    
    public class PartIdentifierClassification : ClassificationBase { }
    public class OrganizationIdentifierClassification : ClassificationBase { }
    public class ProjectIdentifierClassification : ClassificationBase { }
    
    public class ValueDeterminationClassification : ClassificationBase { }

    #region Units
    public class SoftwareSizeUnit : ClassificationBase { }
    public class TimeCycleUnit : ClassificationBase { }
    public class EventUnit : ClassificationBase { }
    public class LengthUnit : ClassificationBase { }
    public class TimeUnit : ClassificationBase { }
    #endregion

    #region PartAsDesigned
    public class DemilitarizationClassification : ClassificationBase { }
    public class MaturityClassification : ClassificationBase { }
    #endregion

    #region HardwarePartAsDesignedDesignData
    public class HazardousClassClassification : ClassificationBase { }
    public class FitmentRequirementClassification : ClassificationBase { }
    #endregion

    #region SoftwarePartAsDesignedDesignData
    public class SoftwareTypeClassification : ClassificationBase { }
    #endregion
}
