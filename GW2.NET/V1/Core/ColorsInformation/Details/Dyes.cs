// --------------------------------------------------------------------------------------------------------------------<param name="capacity">The initial number of elements that the new dictionary can contain.</param>
// <copyright file="Dyes.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.ColorsInformation.Details
{
    /// <summary>
    /// Represents a collection of dyes and their color component information.
    /// </summary>
    public class Dyes : JsonDictionary<int, Dye>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dyes"/> class.
        /// </summary>
        public Dyes()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dyes"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public Dyes(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dyes"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public Dyes(IDictionary<int, Dye> dictionary)
            : base(dictionary)
        {
        }
    }
}