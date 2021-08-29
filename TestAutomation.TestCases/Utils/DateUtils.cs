using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestAutomation.TestCases.Utils
{
    public class DateUtils
    {
        public static string TodayDay()
        {
            var date = DateTime.Today.Day.ToString();
            return date;
        }

        public static string TodayDay(int addDays)
        {
            var date = DateTime.Today.AddDays(addDays).Day.ToString();
            return date;
        }

        public static string MonthShortString(int addDays = 0)
        {
            var date = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Today.AddDays(addDays).Month);
            return date;
        }
    }
}
