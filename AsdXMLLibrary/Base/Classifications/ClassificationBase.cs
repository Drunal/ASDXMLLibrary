using System.Collections.Generic;

namespace AsdXMLLibrary.Base.Classifications
{
    /// <summary>
    /// Base class to handle all classifications. 
    /// Currently its just a derived class from List<string>, 
    /// but if we need to do it more (like XML Reading or Generation) it is already in place
    /// </summary>
    public abstract class ClassificationBase : List<string>
    {
    }
}
