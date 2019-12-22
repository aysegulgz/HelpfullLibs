using NUnit.Framework;
using System;

namespace HelpfullLibs.WorkDayService.Tests
{
    public class WorkDayServiceTests
    {
        WorkingDayService service;

        [SetUp]
        public void Setup()
        {
            service = new WorkingDayService(new MockWorkDayRepository());
        }

        [Test]
        public void should_be_same_day()
        {
            DateTime date = new DateTime(2019, 12, 20, 10, 0, 0);
            var nextday = service.FindDate(date, 65) ;
            var expected = new DateTime(2019,12,20, 11, 5, 0);
            Assert.AreEqual(nextday, expected);
        }

        [Test]
        public void should_be_next_morning()
        {
            DateTime date = new DateTime(2019, 12, 19, 17, 0, 0);
            var nextday = service.FindDate(date, 265) ;//4 hours 25 mins
            var expected = new DateTime(2019,12,20, 10, 25, 0); 
            Assert.AreEqual(nextday, expected);
        }

        [Test]
        public void should_be_next_day()
        {
            DateTime date = new DateTime(2019, 12, 19, 23, 0, 0);
            var nextday = service.FindDate(date, 265) ;//4 hours 25 mins
            var expected = new DateTime(2019,12,20, 13, 25, 0); 
            Assert.AreEqual(nextday, expected);
        }

        [Test]
        public void should_be_two_days_later()
        {
            DateTime date = new DateTime(2019, 12, 19, 14, 0, 0);
            var nextday = service.FindDate(date, 1225) ;//20 hours 25 mins
            var expected = new DateTime(2019,12,21, 13, 25, 0); 
            Assert.AreEqual(nextday, expected);
        }

        [Test]
        public void should_not_work_sunday()
        {
            DateTime date = new DateTime(2019, 12, 20, 14, 0, 0);
            var nextday = service.FindDate(date, 865) ;//14 hours 25 mins
            var expected = new DateTime(2019,12,23, 11, 25, 0); 
            Assert.AreEqual(nextday, expected);
        }

        [Test]
        public void should_not_work_holiday()
        { 
            DateTime date = new DateTime(2019, 12, 30, 14, 0, 0);
            var nextday = service.FindDate(date, 490);//8 hours 10 mins
            var expected = new DateTime(2020,1,2, 11, 10, 0); 
            Assert.AreEqual(nextday, expected);
        }
    }
}