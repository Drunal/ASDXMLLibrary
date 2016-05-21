using DeepEqual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsdXMLLibrary.Tests.Helper
{
    public class DateComparison : IComparison 
    {
        public bool CanCompare(Type type1, Type type2)
        {
            return type1 == typeof(DateTime) && type2 == typeof(DateTime);
        }

        public ComparisonResult Compare(IComparisonContext context, object value1, object value2)
        {
            // use the .Date property because it sets the Time to '00:00:00' which should be considered equal down the road
            if (((DateTime)value1).Date == ((DateTime)value2).Date)
                return ComparisonResult.Pass;
            return ComparisonResult.Fail;
        }
    }
}
