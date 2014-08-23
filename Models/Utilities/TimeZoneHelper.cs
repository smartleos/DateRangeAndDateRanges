using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Utilities
{
    public class TimeZoneHelper
    {
        private static TimeSpan? s_ASTOffset = null;
        private static TimeSpan? s_EATOffset = null;

        /// <summary>
        /// Gets the database time offset.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetASTOffset()
        {
            if (s_ASTOffset == null)
                s_ASTOffset = new TimeSpan(-4, 0, 0);

            return s_ASTOffset.Value;
        }

        /// <summary>
        /// Gets the eat offset.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetEATOffset()
        {
            if (s_EATOffset == null)
                s_EATOffset = new TimeSpan(+8, 0, 0);

            return s_EATOffset.Value;
        }

        /// <summary>
        /// Gets the local time offset.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetLocalOffset()
        {
            return GetEATOffset();
        }
    }
}
