using System;

namespace HelpfullLibs.WorkDayService
{
    public class WorkingDayService
    {
        IWorkDayRepository repository;
        WorkDayProvider provider;
        public WorkingDayService(IWorkDayRepository workDayRepository){
            if(workDayRepository == null)
                throw new ArgumentNullException("workDayRepository");

            repository = workDayRepository;
            provider = new WorkDayProvider(repository);
        }

        public DateTime FindDate(DateTime source, int minutes)
        {
            DateTime date = source;
            while(minutes > 0){

                // are we working today ?
                if(!IsWorkingDay(date)){
                    date = date.NextDay().WorkingTime(provider);
                    continue;
                }

                // today ?
                var remainingMinsToday = date.RemainingWorkTimeInMinutes(provider);
                if(remainingMinsToday >= minutes){
                    date = date.AddMinutes(minutes);
                    minutes = 0;
                    continue;
                }

                // not today, decrement minutes ans move next day
                minutes -= remainingMinsToday;
                date = date.NextDay().WorkingTime(provider);
            }
            return date;
        }        

        private bool IsWorkingDay(DateTime date){
            if(IsHoliday(date))
                return false;
            return date.DayOfWeek.IsWorkDay(provider);
        } 

        private bool IsHoliday(DateTime date){
            return date.IsHoliday(provider);
        }
    }
}