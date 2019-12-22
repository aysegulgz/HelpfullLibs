using System;

namespace HelpfullLibs.WorkDayService
{
    internal static class DateTimeExtensions
    {
        public static DateTime NextDay(this DateTime value){
            return value.Date.AddDays(1);
        }

        public static DateTime WorkingTime(this DateTime value, WorkDayProvider config){
            var dayConfig = config.GetDayConfiguration(value.DayOfWeek);
            return value.Date.AddHours(dayConfig.StartHour);
        }

        public static int RemainingWorkTimeInMinutes(this DateTime value, WorkDayProvider config){
            var dayConfig = config.GetDayConfiguration(value.DayOfWeek);
            DateTime endTime = value.Date.AddHours(dayConfig.EndHour);
            if(value >= endTime)
                return 0;
            return (int)endTime.Subtract(value).TotalMinutes;
        }

        public static bool IsWorkDay(this DayOfWeek day, WorkDayProvider config){
            var dayConfig = config.GetDayConfiguration(day);
            return dayConfig.IsWorkDay;
        }

        public static bool IsHoliday(this DateTime value, WorkDayProvider config){
            return config.IsHoliday(value);
        }
    }
}