using System.Collections.Generic;

namespace  HelpfullLibs.WorkDayService{
    public interface IWorkDayRepository
    {
        List<WorkDayConfiguration> GetDayConfiguration();
        List<HolidayConfiguration> GetHolidayConfiguration();
    }
}