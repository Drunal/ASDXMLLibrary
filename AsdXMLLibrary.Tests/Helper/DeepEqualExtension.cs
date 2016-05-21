using DeepEqual;
using DeepEqual.Syntax;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class DeepEqualExtensions
    {
        public static void ShouldDeepEqualwithDate(this object actual, object expected)
        {
            var comparison = new ComparisonBuilder().Create();
            // insert at the beginning to make sure it is picked up before the fallback comparison
            comparison.Comparisons.Insert(0, new DateComparison());

            actual.ShouldDeepEqual(expected, comparison);
        }
    }
}
