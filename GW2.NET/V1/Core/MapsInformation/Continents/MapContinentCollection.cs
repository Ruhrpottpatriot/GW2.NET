// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapContinentCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.MapsInformation.Continents
{
    /// <summary>
    /// Represents a collection of continents.
    /// </summary>
    public class MapContinentCollection : JsonDictionary<int, MapContinent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapContinentCollection"/> class.
        /// </summary>
        public MapContinentCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapContinentCollection"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public MapContinentCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapContinentCollection"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public MapContinentCollection(IDictionary<int, MapContinent> dictionary)
            : base(dictionary)
        {
        }
    }
}
