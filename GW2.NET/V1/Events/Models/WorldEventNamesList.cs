// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldEventNamesList.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldEventNamesList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Events.Models
{
    /// <summary>A collection of all event names.</summary>
    [JsonObject]
    internal class WorldEventNamesList : IEnumerable<WorldEventName>
    {
        /// <summary>The event names.</summary>
        private readonly List<WorldEventName> eventNames;

        /// <summary>Initializes a new instance of the <see cref="WorldEventNamesList"/> class.</summary>
        /// <param name="eventNames">The event names.</param>
        [JsonConstructor]
        public WorldEventNamesList(List<WorldEventName> eventNames)
        {
            this.eventNames = eventNames;
        }

        /// <summary>Gets the number of event names.</summary>
        public int Count
        {
            get
            {
                return this.eventNames.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<WorldEventName> GetEnumerator()
        {
            return this.eventNames.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
