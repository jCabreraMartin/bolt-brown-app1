using System;
using System.Collections.Generic;
using NUnit.Framework;
using TimeTracking.Data.Models;

namespace TimeTracking.Business.Tests
{
    [TestFixture]
    public class TimeEntryServiceTests : TestBase
    {
        private TimeEntryService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new TimeEntryService();
        }

        // --- ValidateHoursFormat ---

        [Test]
        public void ValidateHoursFormat_ValidInteger_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat("8"));
        }

        [Test]
        public void ValidateHoursFormat_OneDecimal_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat("7.5"));
        }

        [Test]
        public void ValidateHoursFormat_Zero_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat("0"));
        }

        [Test]
        public void ValidateHoursFormat_Empty_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat(""));
        }

        [Test]
        public void ValidateHoursFormat_Null_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat(null));
        }

        [Test]
        public void ValidateHoursFormat_Whitespace_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat("   "));
        }

        [Test]
        public void ValidateHoursFormat_TwoDecimals_ReturnsFalse()
        {
            Assert.IsFalse(_service.ValidateHoursFormat("7.55"));
        }

        [Test]
        public void ValidateHoursFormat_Text_ReturnsFalse()
        {
            Assert.IsFalse(_service.ValidateHoursFormat("abc"));
        }

        [Test]
        public void ValidateHoursFormat_Negative_ReturnsFalse()
        {
            Assert.IsFalse(_service.ValidateHoursFormat("-1"));
        }

        [Test]
        public void ValidateHoursFormat_GreaterThan24_ReturnsFalse()
        {
            Assert.IsFalse(_service.ValidateHoursFormat("25"));
        }

        [Test]
        public void ValidateHoursFormat_Exactly24_ReturnsTrue()
        {
            Assert.IsTrue(_service.ValidateHoursFormat("24"));
        }

        [Test]
        public void ValidateHoursFormat_Comma_ReturnsFalse()
        {
            Assert.IsFalse(_service.ValidateHoursFormat("7,5"));
        }

        // --- ParseHours ---

        [Test]
        public void ParseHours_ValidInteger_ReturnsValue()
        {
            Assert.AreEqual(8m, _service.ParseHours("8"));
        }

        [Test]
        public void ParseHours_ValidDecimal_ReturnsValue()
        {
            Assert.AreEqual(7.5m, _service.ParseHours("7.5"));
        }

        [Test]
        public void ParseHours_Empty_ReturnsZero()
        {
            Assert.AreEqual(0m, _service.ParseHours(""));
        }

        [Test]
        public void ParseHours_Null_ReturnsZero()
        {
            Assert.AreEqual(0m, _service.ParseHours(null));
        }

        [Test]
        public void ParseHours_InvalidText_ReturnsZero()
        {
            Assert.AreEqual(0m, _service.ParseHours("abc"));
        }

        // --- CalculateTotalByAccount ---

        [Test]
        public void CalculateTotalByAccount_WithEntries_ReturnsSum()
        {
            var entries = new List<TimeEntry>
            {
                new TimeEntry { ChargeAccountId = 1, Hours = 4m },
                new TimeEntry { ChargeAccountId = 1, Hours = 3.5m },
                new TimeEntry { ChargeAccountId = 2, Hours = 8m }
            };

            var total = _service.CalculateTotalByAccount(entries, 1);
            Assert.AreEqual(7.5m, total);
        }

        [Test]
        public void CalculateTotalByAccount_NoMatchingEntries_ReturnsZero()
        {
            var entries = new List<TimeEntry>
            {
                new TimeEntry { ChargeAccountId = 2, Hours = 8m }
            };

            var total = _service.CalculateTotalByAccount(entries, 1);
            Assert.AreEqual(0m, total);
        }

        [Test]
        public void CalculateTotalByAccount_EmptyList_ReturnsZero()
        {
            var total = _service.CalculateTotalByAccount(new List<TimeEntry>(), 1);
            Assert.AreEqual(0m, total);
        }

        // --- CalculateTotalByDay ---

        [Test]
        public void CalculateTotalByDay_WithEntries_ReturnsSum()
        {
            var date = new DateTime(2026, 3, 2);
            var entries = new List<TimeEntry>
            {
                new TimeEntry { Date = date, Hours = 4m },
                new TimeEntry { Date = date, Hours = 4m },
                new TimeEntry { Date = date.AddDays(1), Hours = 8m }
            };

            var total = _service.CalculateTotalByDay(entries, date);
            Assert.AreEqual(8m, total);
        }

        [Test]
        public void CalculateTotalByDay_NoEntriesForDate_ReturnsZero()
        {
            var entries = new List<TimeEntry>
            {
                new TimeEntry { Date = new DateTime(2026, 3, 1), Hours = 8m }
            };

            var total = _service.CalculateTotalByDay(entries, new DateTime(2026, 3, 2));
            Assert.AreEqual(0m, total);
        }

        // --- CalculateGrandTotal ---

        [Test]
        public void CalculateGrandTotal_WithEntries_ReturnsTotalSum()
        {
            var entries = new List<TimeEntry>
            {
                new TimeEntry { Hours = 4m },
                new TimeEntry { Hours = 3.5m },
                new TimeEntry { Hours = 8m }
            };

            var total = _service.CalculateGrandTotal(entries);
            Assert.AreEqual(15.5m, total);
        }

        [Test]
        public void CalculateGrandTotal_EmptyList_ReturnsZero()
        {
            var total = _service.CalculateGrandTotal(new List<TimeEntry>());
            Assert.AreEqual(0m, total);
        }

        // --- SaveHours and GetFortnightEntries (integration with DB) ---

        [Test]
        public void SaveHours_NewEntry_IsStoredCorrectly()
        {
            var fortnight = new FortnightService().GetFortnightByDate(new DateTime(2026, 3, 5));
            var date = new DateTime(2026, 3, 5);

            _service.SaveHours(3, 1, date, 6.5m);

            var entries = _service.GetFortnightEntries(3, fortnight);
            Assert.IsTrue(entries.Exists(e => e.ChargeAccountId == 1 && e.Date.Date == date.Date && e.Hours == 6.5m));
        }

        [Test]
        public void SaveHours_ZeroHours_DeletesEntry()
        {
            var fortnight = new FortnightService().GetFortnightByDate(new DateTime(2026, 3, 5));
            var date = new DateTime(2026, 3, 5);

            _service.SaveHours(3, 1, date, 8m);
            _service.SaveHours(3, 1, date, 0m);

            var entries = _service.GetFortnightEntries(3, fortnight);
            Assert.IsFalse(entries.Exists(e => e.ChargeAccountId == 1 && e.Date.Date == date.Date));
        }

        [Test]
        public void GetFortnightEntries_UserWithData_ReturnsEntries()
        {
            var fortnight = new FortnightService().GetFortnightByDate(DateTime.Today);
            var entries = _service.GetFortnightEntries(1, fortnight);

            Assert.IsNotNull(entries);
            Assert.IsTrue(entries.Count > 0);
        }

        [Test]
        public void GetFortnightEntries_UserWithNoData_ReturnsEmptyList()
        {
            var fortnight = new FortnightService().GetFortnightByDate(DateTime.Today);
            var entries = _service.GetFortnightEntries(99, fortnight);

            Assert.IsNotNull(entries);
            Assert.AreEqual(0, entries.Count);
        }
    }
}
