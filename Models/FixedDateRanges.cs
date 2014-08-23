using System;
using System.Collections.Generic;
using Project.Models.Utilities;

namespace Project.Models
{
    /// <summary>
    /// To fix dateranges for leaderboard of poker cash race.
    /// </summary>
    public class ReportDateRanges : DateRanges
    {
        private static DateRanges s_DateRanges = null;

        /// <summary>
        /// Initializes the <see cref="ReportDateRanges"/> class.
        /// </summary>
        static ReportDateRanges()
        {
            s_DateRanges = new DateRanges();
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected static new void Initialize()
        {
            InitialStartEndTime();
        }

        /// <summary>
        /// Initials the start end time.
        /// </summary>
        public static new void InitialStartEndTime()
        {
            TimeSpan _LocalOffset = TimeZoneHelper.GetLocalOffset();
            s_DateRanges.RangesStartUTCTime =
                new DateTimeOffset(2014, 9, 15, 0, 0, 0, _LocalOffset).ToUniversalTime();
            s_DateRanges.RangesEndUTCTime =
                new DateTimeOffset(2014, 12, 7, 0, 0, 0, _LocalOffset).ToUniversalTime();
            s_DateRanges.Initialize();
        }

        /// <summary>
        /// Gets the date range by start UTC time.
        /// </summary>
        /// <param name="startUTCTime">The start UTC time.</param>
        /// <returns></returns>
        public static new DateRange GetDateRangeByStartUTCTime(DateTimeOffset startUTCTime)
        {
            return s_DateRanges.GetDateRangeByStartUTCTime(startUTCTime);
        }

        /// <summary>
        /// Gets the date range by date range.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <returns></returns>
        public static new DateRange GetDateRangeByDateRange(DateRange dateRange)
        {
            return s_DateRanges.GetDateRangeByDateRange(dateRange);
        }

        /// <summary>
        /// Gets the date ranges.
        /// </summary>
        /// <returns></returns>
        public static new IList<DateRange> GetDateRanges()
        {
            return s_DateRanges.GetDateRanges();
        }
    }
}