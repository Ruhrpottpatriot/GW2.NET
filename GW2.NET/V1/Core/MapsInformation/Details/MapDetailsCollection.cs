// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Details
{
    /// <summary>
    /// Represents a collection of maps and their details.
    /// </summary>
    public class MapDetailsCollection : JsonDictionary<int, MapDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsCollection"/> class.
        /// </summary>
        public MapDetailsCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsCollection"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public MapDetailsCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapDetailsCollection"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public MapDetailsCollection(IDictionary<int, MapDetails> dictionary)
            : base(dictionary)
        {
        }
    }
}