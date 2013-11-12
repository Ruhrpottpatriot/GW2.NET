// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchList.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.WvW.Models
{
    /// <summary>A list of all matches currently running on the world versus world servers.</summary>
    [JsonObject]
    public class MatchList : IEnumerable<MatchListEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchList"/> class.
        /// </summary>
        /// <param name="matches">
        /// The list of matches.
        /// </param>
        [JsonConstructor]
        public MatchList(List<MatchListEntry> matches)
        {
            this.Matches = matches;
        }

        /// <summary>
        /// Gets a collection of all matches.
        /// </summary>
        [JsonProperty("wvw_matches")]
        public List<MatchListEntry> Matches
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the total number of matches currently running.
        /// </summary>
        public int Count
        {
            get
            {
                return this.Matches.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<MatchListEntry> GetEnumerator()
        {
            return this.Matches.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
