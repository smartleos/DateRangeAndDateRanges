using System;
using Project.Models.Utilities;

namespace Project.Models
{
    /// <summary>
    /// Preserves date range and offset.
    /// </summary>
    public class DateRange : IEquatable<DateRange>, IComparable<DateRange>
    {
        /// <summary>
        /// Gets or sets the start UTC time.
        /// </summary>
        /// <value>
        /// The start UTC time.
        /// </value>
        public DateTimeOffset StartUTCTime { get; set; }

        /// <summary>
        /// Gets or sets the end UTC time.
        /// </summary>
        /// <value>
        /// The end UTC time.
        /// </value>
        public DateTimeOffset EndUTCTime { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public TimeSpan Offset { get; set; }

        public string DefaultSeparator = " ~ ";

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startUTCTime">The start UTC time.</param>
        /// <param name="endUTCTime">The end UTC time.</param>
        public DateRange(DateTime startUTCTime, DateTime endUTCTime)
            : this(startUTCTime, endUTCTime, DateTimeOffset.Now.Offset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startLocalTime">The start local time.</param>
        /// <param name="endLocalTime">The end local time.</param>
        /// <param name="localOffset">The local offset.</param>
        public DateRange(DateTime startLocalTime, DateTime endLocalTime, TimeSpan localOffset)
        {
            this.StartUTCTime = new DateTimeOffset(startLocalTime, localOffset).ToUniversalTime();
            this.EndUTCTime = new DateTimeOffset(endLocalTime, localOffset).ToUniversalTime();
            this.Offset = localOffset;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startUTCTime">The start UTC time.</param>
        /// <param name="endUTCTime">The end UTC time.</param>
        public DateRange(DateTimeOffset startUTCTime, DateTimeOffset endUTCTime)
            : this(startUTCTime, endUTCTime, DateTimeOffset.Now.Offset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="startUTCTime">The start UTC time.</param>
        /// <param name="endUTCTime">The end UTC time.</param>
        /// <param name="localOffset">The local offset.</param>
        public DateRange(DateTimeOffset startUTCTime, DateTimeOffset endUTCTime, TimeSpan localOffset)
        {
            this.StartUTCTime = startUTCTime;
            this.EndUTCTime = endUTCTime;
            this.Offset = localOffset;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(DateRange left, DateRange right)
        {
            bool _NullCompareResult = false;
            if (NullComparer.IsContainNullAndEquals(left, right, out _NullCompareResult))
            {
                return _NullCompareResult;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(DateRange left, DateRange right)
        {
            bool _NullCompareResult = false;
            if (NullComparer.IsContainNullAndNotEquals(left, right, out _NullCompareResult))
            {
                return _NullCompareResult;
            }
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            DateRange stakeLimitObj = obj as DateRange;
            if (stakeLimitObj == null)
                return false;

            return this.Equals(stakeLimitObj);
        }

        /// <summary>
        /// Equalses the exact.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool EqualsExact(DateRange other)
        {
            if (!this.StartUTCTime.EqualsExact(other.StartUTCTime) || !this.EndUTCTime.EqualsExact(other.EndUTCTime))
                return false;

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (this.StartUTCTime.Ticks + this.EndUTCTime.Ticks).GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ToString(DefaultSeparator);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string separator)
        {
            return this.StartUTCTime.ToString() + separator + this.EndUTCTime.ToString();
        }

        /// <summary>
        /// To the short date string.
        /// </summary>
        /// <returns></returns>
        public string ToShortDateString()
        {
            return this.ToShortDateString(DefaultSeparator);
        }

        /// <summary>
        /// To the short date string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToShortDateString(string separator)
        {
            return this.StartUTCTime.DateTime.ToShortDateString() + separator + this.EndUTCTime.DateTime.ToShortDateString();
        }

        /// <summary>
        /// To the local string.
        /// </summary>
        /// <returns></returns>
        public string ToLocalString()
        {
            return this.ToLocalString(DefaultSeparator);
        }

        /// <summary>
        /// To the local string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToLocalString(string separator)
        {
            DateTimeOffset _ReturnStartDateTimeOffset = this.StartUTCTime.ToLocalTime();
            DateTimeOffset _ReturnEndDateTimeOffset = this.EndUTCTime.ToLocalTime();
            return _ReturnStartDateTimeOffset.ToString() + separator + _ReturnEndDateTimeOffset.ToString();
        }

        /// <summary>
        /// To the local short date string.
        /// </summary>
        /// <returns></returns>
        public string ToLocalShortDateString()
        {
            return this.ToLocalShortDateString(DefaultSeparator);
        }

        /// <summary>
        /// To the local short date string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToLocalShortDateString(string separator)
        {
            DateTime _ReturnStartDateTime = this.StartUTCTime.ToLocalTime().DateTime;
            DateTime _ReturnEndDateTime = this.EndUTCTime.ToLocalTime().DateTime;
            return _ReturnStartDateTime.ToShortDateString() + separator + _ReturnEndDateTime.ToShortDateString();
        }

        /// <summary>
        /// To the offset string.
        /// </summary>
        /// <returns></returns>
        public string ToOffsetString()
        {
            return this.ToOffsetString(this.Offset, DefaultSeparator);
        }

        /// <summary>
        /// To the offset string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToOffsetString(string separator)
        {
            return this.ToOffsetString(this.Offset, separator);
        }

        /// <summary>
        /// To the offset string.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public string ToOffsetString(TimeSpan offset)
        {
            return this.ToOffsetString(offset, DefaultSeparator);
        }

        /// <summary>
        /// To the offset string.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToOffsetString(TimeSpan offset, string separator)
        {
            DateTimeOffset _ReturnStartDateTimeOffset = this.StartUTCTime.ToOffset(offset);
            DateTimeOffset _ReturnEndDateTimeOffset = this.EndUTCTime.ToOffset(offset);
            return _ReturnStartDateTimeOffset.ToString() + separator + _ReturnEndDateTimeOffset.ToString();
        }

        /// <summary>
        /// To the offset short date string.
        /// </summary>
        /// <returns></returns>
        public string ToOffsetShortDateString()
        {
            return this.ToOffsetShortDateString(this.Offset, DefaultSeparator);
        }

        /// <summary>
        /// To the offset short date string.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToOffsetShortDateString(string separator)
        {
            return this.ToOffsetShortDateString(this.Offset, separator);
        }

        /// <summary>
        /// To the offset short date string.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public string ToOffsetShortDateString(TimeSpan offset)
        {
            return this.ToOffsetShortDateString(offset, DefaultSeparator);
        }

        /// <summary>
        /// To the offset short date string.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public string ToOffsetShortDateString(TimeSpan offset, string separator)
        {
            DateTime _ReturnStartDateTime = this.StartUTCTime.ToOffset(offset).DateTime;
            DateTime _ReturnEndDateTime = this.EndUTCTime.ToOffset(offset).DateTime;
            return _ReturnStartDateTime.ToShortDateString() + separator + _ReturnEndDateTime.ToShortDateString();
        }

        #region IEquatable<ReportDateRange> 成員

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(DateRange other)
        {
            if (!this.StartUTCTime.Equals(other.StartUTCTime) || !this.EndUTCTime.Equals(other.EndUTCTime))
                return false;

            return true;
        }

        #endregion IEquatable<ReportDateRange> 成員

        #region IComparable<ReportDateRange> 成員

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public int CompareTo(DateRange other)
        {
            if (other == null)
                return 1;
            if (this.Equals(other))
                return 0;

            int _CompareStartUTCTime = this.StartUTCTime.CompareTo(other.EndUTCTime);

            if (_CompareStartUTCTime != 0)
                return _CompareStartUTCTime;
            else
                return this.EndUTCTime.CompareTo(other.EndUTCTime);
        }

        #endregion IComparable<ReportDateRange> 成員
    }
}