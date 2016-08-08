
namespace AsdXMLLibrary.Objects.References
{
    public interface ICanBeReferenced<out T> 
        where T : IAmReference
    {
        T GetReference();
    }
}
