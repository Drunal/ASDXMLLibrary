﻿
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
    
    public class UnitClassification : ClassificationBase { }
    public class BinaryUnitClassification : ClassificationBase { }

    #region HardwarePartAsDesignedDesignData
    public class HazardousClassClassification : ClassificationBase { }
    public class FitmentRequirementClassification : ClassificationBase { }
    #endregion

    #region SoftwarePartAsDesignedDesignData
    public class SoftwareTypeClassification : ClassificationBase { }
    #endregion
}
