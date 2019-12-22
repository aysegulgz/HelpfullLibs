using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpfullLibs.WorkDayService.Tests{

    public class MockWorkDayRepository : IWorkDayRepository
    {      
        public List<WorkDayConfiguration> GetDayConfiguration()
        {
            var dayConfigurations = new List<WorkDayConfiguration>();
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Monday,
                IsWorkDay = true,
                StartHour = 9,
                EndHour = 20
            });
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Tuesday,
                IsWorkDay = true,
                StartHour = 9,
                EndHour = 20
            });
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Wednesday,
                IsWorkDay = true,
                StartHour = 9,
                EndHour = 20
            });
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Thursday,
                IsWorkDay = true,
                StartHour = 9,
                EndHour = 20
            });
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Friday,
                IsWorkDay = true,
                StartHour = 9,
                EndHour = 20
            });
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Saturday,
                IsWorkDay = true,
                StartHour = 10,
                EndHour = 16
            });
            dayConfigurations.Add(new WorkDayConfiguration(){
                Day = DayOfWeek.Sunday,
                IsWorkDay = false
            });
            return dayConfigurations;
        }

        List<HolidayConfiguration> IWorkDayRepository.GetHolidayConfiguration()
        {
            var holidayConfigurations = new List<HolidayConfiguration>();
            holidayConfigurations.Add(new HolidayConfiguration(){
                Date = new DateTime(2019, 12, 31)
            });
            holidayConfigurations.Add(new HolidayConfiguration(){
                Date = new DateTime(2020, 1, 1)
            });
            return holidayConfigurations;
        }
    }
}