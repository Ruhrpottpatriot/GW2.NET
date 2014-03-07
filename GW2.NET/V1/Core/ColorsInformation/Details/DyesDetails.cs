// --------------------------------------------------------------------------------------------------------------------<param name="capacity">The initial number of elements that the new dictionary can contain.</param>
// <copyright file="DyesDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.ColorsInformation.Details
{
    /// <summary>
    /// Represents a collection of dyes and their color component information.
    /// </summary>
    public class DyesDetails : JsonDictionary<int, DyeDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DyesDetails"/> class.
        /// </summary>
        public DyesDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DyesDetails"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public DyesDetails(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DyesDetails"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public DyesDetails(IDictionary<int, DyeDetails> dictionary)
            : base(dictionary)
        {
        }
    }
}