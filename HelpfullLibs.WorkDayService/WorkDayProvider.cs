using System;
using System.Collections.Generic;
using System.Linq;

namespace  HelpfullLibs.WorkDayService
{
    internal class WorkDayProvider {

        private List<WorkDayConfiguration> dayConfigurations;
        private List<HolidayConfiguration> holidayConfigurations;
        private IWorkDayRepository repository;

        public WorkDayProvider(IWorkDayRepository workDayRepository){
            repository = workDayRepository;
        }

        public WorkDayConfiguration GetDayConfiguration(DayOfWeek day)
        {
            EnsureConfiguration();

            var config = dayConfigurations.FirstOrDefault(q => q.Day == day);
            if(config != null)
                return config;

            return new WorkDayConfiguration(){
                IsWorkDay = false,
                Day = day
            };
        }

        public bool IsHoliday(DateTime date)
        {
            EnsureConfiguration();
            return holidayConfigurations.Any(q => q.Date == date.Date);
        }

        private void EnsureConfiguration(){
            if(dayConfigurations == null)
                dayConfigurations = repository.GetDayConfiguration();
            if(holidayConfigurations == null)
                holidayConfigurations = repository.GetHolidayConfiguration();
        }
    }
}