using System;

namespace AsdXMLLibrary.Tests.Helper
{
    public static class DateTimeExtensions
    {
        public static string ToXmlDateString(this DateTime dateTime)
        {
            return String.Format("{0}-{1}-{2}", dateTime.Year.ToString("0000"), dateTime.Month.ToString("00"), dateTime.Day.ToString("00"));
        }
    }
}
