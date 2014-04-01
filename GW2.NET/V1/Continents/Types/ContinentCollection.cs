// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentCollection.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents.Types
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Represents a collection of continents.</summary>
    public class ContinentCollection : JsonDictionary<int, Continent>
    {
        /// <summary>Initializes a new instance of the <see cref="ContinentCollection" /> class.</summary>
        public ContinentCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentCollection"/> class.</summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public ContinentCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentCollection"/> class.</summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public ContinentCollection(IDictionary<int, Continent> dictionary)
            : base(dictionary)
        {
        }

        /// <summary>Sets each value's ID property to its corresponding key.</summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            foreach (var kvp in this)
            {
                kvp.Value.ContinentId = kvp.Key;
            }
        }
    }
}