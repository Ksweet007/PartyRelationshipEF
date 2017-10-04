using System.Collections.Generic;

namespace PartyApp.Core
{
    public static class Constants
    {
        public static IList<KeyValuePair<int, string>> Months => GetMonths();

        private static IList<KeyValuePair<int, string>> GetMonths()
        {
            return new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "January"),
                new KeyValuePair<int, string>(2, "February"),
                new KeyValuePair<int, string>(3, "March"),
                new KeyValuePair<int, string>(4, "April"),
                new KeyValuePair<int, string>(5, "May"),
                new KeyValuePair<int, string>(6, "June"),
                new KeyValuePair<int, string>(7, "July"),
                new KeyValuePair<int, string>(8, "August"),
                new KeyValuePair<int, string>(9, "September"),
                new KeyValuePair<int, string>(10, "October"),
                new KeyValuePair<int, string>(11, "November"),
                new KeyValuePair<int, string>(12, "December")
            };
        }
    }
}
