using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models.Utilities
{
    /// <summary>
    /// Determines whether is contain null value, and out the compare result.
    /// </summary>
    public class NullComparer
    {
        /// <summary>
        /// Determines whether [is contain null and equals] [the specified left].
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="compareResult">if set to <c>true</c> [compare equals result].</param>
        /// <returns></returns>
        public static bool IsContainNullAndEquals(object left, object right, out bool compareResult)
        {
            bool _IsContainNullObject = false;
            compareResult = false;
            if (object.Equals(left, null) && object.Equals(right, null))
            {
                _IsContainNullObject = true;
                compareResult = true;
            }
            else if (object.Equals(left, null) || object.Equals(right, null))
            {
                _IsContainNullObject = true;
                compareResult = false;
            }
            return _IsContainNullObject;
        }

        /// <summary>
        /// Determines whether [is contain null and not equals] [the specified left].
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="compareResult">if set to <c>true</c> [compare not equals result].</param>
        /// <returns></returns>
        public static bool IsContainNullAndNotEquals(object left, object right, out bool compareResult)
        {
            bool _IsContainNullObject = false;
            compareResult = false;
            if (object.Equals(left, null) && object.Equals(right, null))
            {
                _IsContainNullObject = true;
                compareResult = false;
            }
            else if (object.Equals(left, null) || object.Equals(right, null))
            {
                _IsContainNullObject = true;
                compareResult = true;
            }
            return _IsContainNullObject;

        }
    }
}
