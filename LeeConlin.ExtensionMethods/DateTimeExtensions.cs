using System;

namespace LeeConlin.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Is the dateTimeToTest between the other dates
        /// </summary>
        /// <param name="dateTimeToTest"></param>
        /// <param name="d1">One end of the range</param>
        /// <param name="d2">The other end of the range</param>
        /// <returns></returns>
        public static bool Between(this DateTime dateTimeToTest, DateTime d1, DateTime d2)
        {
            DateTime start;
            DateTime end;
            if (d1 <= d2)
            {
                start = d1;
                end = d2;
            }
            else
            {
                start = d2;
                end = d1;
            }
            
            return dateTimeToTest.Ticks >= start.Ticks && dateTimeToTest.Ticks <= end.Ticks;
        }

        /// <summary>
        /// Calculates the age in years given a date of birth. Accurate to the day.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static int ToAgeInYears(this DateTime dateOfBirth)
        {
            // normalise the dates to the same known timezone and we only care about the day.
            var now = DateTime.Now.ToUniversalTime().Date;
            dateOfBirth = dateOfBirth.ToUniversalTime().Date;
            
            var age = now.Year - dateOfBirth.Year;
            if (now < dateOfBirth.AddYears(age))
                age--;
            return age;
        }

        public static bool IsWeekday(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
        
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        
        public static DateTime NextWeekday(this DateTime date)
        {
            var nextDay = date.AddDays(1);
            while (!nextDay.IsWeekday())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }
    }
    
}