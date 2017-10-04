using PartyApp.Core.Enum;
using System;
using System.Linq;

namespace PartyApp.Core.Model
{
    public class PartyDate : EntityBase
    {
        public CalendarType CalendarType { get; set; }
        public int? CMIId { get; set; }
        public EventTypeValues DateType { get; set; }
        public string CalendarEndValue { get; private set; }
        public DateTime? CalendarEndDate { get; set; }
        public string CalendarStartValue { get; private set; }
        public DateTime? CalendarStartDate { get; set; }

        //Reference Properties
        public int PartyId { get; set; }

        //Methods
        public void SetStartDateString(DateTime? startDate)
        {
            if (startDate == null) { CalendarStartValue = null; }

            var startDateValue = startDate.Value;

            var monthDigit = startDateValue.Month;
            var monthString = Constants.Months.Single(m => m.Key == monthDigit).Value;

            var day = startDateValue.Day;
            var year = startDateValue.Year;

            CalendarStartValue = $"{monthString} {day}, {year}";
        }
    }
}
