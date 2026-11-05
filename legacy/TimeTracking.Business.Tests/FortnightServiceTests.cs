using System;
using NUnit.Framework;

namespace TimeTracking.Business.Tests
{
    [TestFixture]
    public class FortnightServiceTests
    {
        private FortnightService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new FortnightService();
        }

        [Test]
        public void GetFortnightByDate_FirstFortnight_ReturnsDays1To15()
        {
            var date = new DateTime(2026, 3, 10);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(1, result.FortnightNumber);
            Assert.AreEqual(new DateTime(2026, 3, 1), result.StartDate);
            Assert.AreEqual(new DateTime(2026, 3, 15), result.EndDate);
            Assert.AreEqual(15, result.DaysInFortnight);
        }

        [Test]
        public void GetFortnightByDate_SecondFortnight_ReturnsDays16ToEnd()
        {
            var date = new DateTime(2026, 3, 20);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(2, result.FortnightNumber);
            Assert.AreEqual(new DateTime(2026, 3, 16), result.StartDate);
            Assert.AreEqual(new DateTime(2026, 3, 31), result.EndDate);
            Assert.AreEqual(16, result.DaysInFortnight);
        }

        [Test]
        public void GetFortnightByDate_Day1_IsFirstFortnight()
        {
            var date = new DateTime(2026, 1, 1);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(1, result.FortnightNumber);
            Assert.AreEqual(new DateTime(2026, 1, 1), result.StartDate);
        }

        [Test]
        public void GetFortnightByDate_Day15_IsFirstFortnight()
        {
            var date = new DateTime(2026, 6, 15);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(1, result.FortnightNumber);
            Assert.AreEqual(new DateTime(2026, 6, 15), result.EndDate);
        }

        [Test]
        public void GetFortnightByDate_Day16_IsSecondFortnight()
        {
            var date = new DateTime(2026, 6, 16);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(2, result.FortnightNumber);
            Assert.AreEqual(new DateTime(2026, 6, 16), result.StartDate);
        }

        [Test]
        public void GetFortnightByDate_February_SecondFortnightHas13Days()
        {
            var date = new DateTime(2026, 2, 20);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(2, result.FortnightNumber);
            Assert.AreEqual(new DateTime(2026, 2, 28), result.EndDate);
            Assert.AreEqual(13, result.DaysInFortnight);
        }

        [Test]
        public void GetFortnightByDate_LeapYearFebruary_SecondFortnightHas14Days()
        {
            var date = new DateTime(2028, 2, 20);
            var result = _service.GetFortnightByDate(date);

            Assert.AreEqual(new DateTime(2028, 2, 29), result.EndDate);
            Assert.AreEqual(14, result.DaysInFortnight);
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Monday_ReturnsMon()
        {
            Assert.AreEqual("Mon", _service.GetDayOfWeekAbbreviation(DayOfWeek.Monday));
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Tuesday_ReturnsTue()
        {
            Assert.AreEqual("Tue", _service.GetDayOfWeekAbbreviation(DayOfWeek.Tuesday));
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Wednesday_ReturnsWed()
        {
            Assert.AreEqual("Wed", _service.GetDayOfWeekAbbreviation(DayOfWeek.Wednesday));
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Thursday_ReturnsThu()
        {
            Assert.AreEqual("Thu", _service.GetDayOfWeekAbbreviation(DayOfWeek.Thursday));
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Friday_ReturnsFri()
        {
            Assert.AreEqual("Fri", _service.GetDayOfWeekAbbreviation(DayOfWeek.Friday));
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Saturday_ReturnsSat()
        {
            Assert.AreEqual("Sat", _service.GetDayOfWeekAbbreviation(DayOfWeek.Saturday));
        }

        [Test]
        public void GetDayOfWeekAbbreviation_Sunday_ReturnsSun()
        {
            Assert.AreEqual("Sun", _service.GetDayOfWeekAbbreviation(DayOfWeek.Sunday));
        }

        [Test]
        public void GetFortnightDays_FirstFortnight_Returns15Days()
        {
            var fortnight = _service.GetFortnightByDate(new DateTime(2026, 3, 5));
            var days = _service.GetFortnightDays(fortnight);

            Assert.AreEqual(15, days.Length);
            Assert.AreEqual(new DateTime(2026, 3, 1), days[0]);
            Assert.AreEqual(new DateTime(2026, 3, 15), days[14]);
        }

        [Test]
        public void GetFortnightDays_SecondFortnightMarch_Returns16Days()
        {
            var fortnight = _service.GetFortnightByDate(new DateTime(2026, 3, 20));
            var days = _service.GetFortnightDays(fortnight);

            Assert.AreEqual(16, days.Length);
            Assert.AreEqual(new DateTime(2026, 3, 16), days[0]);
            Assert.AreEqual(new DateTime(2026, 3, 31), days[15]);
        }

        [Test]
        public void GetCurrentFortnight_ReturnsNonNull()
        {
            var result = _service.GetCurrentFortnight();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.DaysInFortnight > 0);
        }

        [Test]
        public void FortnightInfo_Description_HasCorrectFormat()
        {
            var fortnight = _service.GetFortnightByDate(new DateTime(2026, 3, 5));

            Assert.IsTrue(fortnight.Description.Contains("Fortnight 1"));
            Assert.IsTrue(fortnight.Description.Contains("01/03/2026"));
            Assert.IsTrue(fortnight.Description.Contains("15/03/2026"));
        }
    }
}
