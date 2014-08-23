using System;
using System.Collections.Generic;

namespace Project.Models
{
    /// <summary>
    /// Daterange colletion
    /// </summary>
    public class DateRanges
    {
        protected IList<DateRange> s_DateRangeList = null;
        protected IDictionary<DateTimeOffset, DateRange> s_DateRangeMap = null;
        public int IntervalDays = 6;
        public int LocalOffsetHour = 8;
        public DateTimeOffset? RangesStartUTCTime = null;
        public DateTimeOffset? RangesEndUTCTime = null;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            s_DateRangeList = new List<DateRange>();
            s_DateRangeMap = new Dictionary<DateTimeOffset, DateRange>();
            TimeSpan _LocalOffset = new TimeSpan(LocalOffsetHour, 0, 0);

            InitialStartEndTime();

            while (RangesStartUTCTime.Value.AddDays(IntervalDays) <= RangesEndUTCTime.Value)
            {
                DateRange _DateRange = new DateRange
                    (
                        RangesStartUTCTime.Value,
                        RangesStartUTCTime.Value.AddDays(IntervalDays),
                        _LocalOffset
                    );
                s_DateRangeList.Add(_DateRange);
                s_DateRangeMap.Add(RangesStartUTCTime.Value, _DateRange);
                RangesStartUTCTime = RangesStartUTCTime.Value.AddDays(IntervalDays + 1);
            }
        }

        /// <summary>
        /// Initials the start end time.
        /// </summary>
        public void InitialStartEndTime()
        {
            if (!RangesStartUTCTime.HasValue)
                RangesStartUTCTime = DateTimeOffset.Now.ToUniversalTime();
            if (!RangesEndUTCTime.HasValue)
                RangesEndUTCTime = DateTimeOffset.Now.AddDays(IntervalDays).ToUniversalTime();
        }

        /// <summary>
        /// Gets the date range by start UTC time.
        /// </summary>
        /// <param name="startUTCTime">The start UTC time.</param>
        /// <returns></returns>
        public DateRange GetDateRangeByStartUTCTime(DateTimeOffset startUTCTime)
        {
            if (s_DateRangeList == null)
                Initialize();
            DateRange _ReportDateRange;
            if (s_DateRangeMap.TryGetValue(startUTCTime, out _ReportDateRange))
                return _ReportDateRange;
            else
                return null;
        }

        /// <summary>
        /// Gets the date range by date range.
        /// </summary>
        /// <param name="dateRange">The date range.</param>
        /// <returns></returns>
        public DateRange GetDateRangeByDateRange(DateRange dateRange)
        {
            if (dateRange == null)
                return null;

            if (s_DateRangeList == null)
                Initialize();

            DateRange _DateRange = GetDateRangeByStartUTCTime(dateRange.StartUTCTime);
            if (_DateRange.EndUTCTime.Equals(dateRange.EndUTCTime))
                return _DateRange;

            return null;
        }

        /// <summary>
        /// Gets the date ranges.
        /// </summary>
        /// <returns></returns>
        public IList<DateRange> GetDateRanges()
        {
            if (s_DateRangeList == null)
                Initialize();

            return s_DateRangeList;
        }
    }
}