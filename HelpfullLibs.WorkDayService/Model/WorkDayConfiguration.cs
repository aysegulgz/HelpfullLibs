using System;

namespace HelpfullLibs.WorkDayService
{
    public class WorkDayConfiguration{
        public DayOfWeek Day{get;set;}
        public bool IsWorkDay{get;set;}
        public int StartHour{get;set;}
        public int EndHour{get;set;}
    }
}