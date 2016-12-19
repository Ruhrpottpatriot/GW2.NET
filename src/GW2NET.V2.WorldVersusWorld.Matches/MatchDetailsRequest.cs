// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding the specified match, including the total score and further details for each map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.WorldVersusWorld.Matches
{
    using GW2NET.Common;
    using System.Collections.Generic;

    /// <summary>Represents a request for details regarding the specified match, including the total score and further details for each map.</summary>
    public sealed class MatchDetailsRequest : DetailsRequest
    {
        public int WorldId { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "v2/wvw/matches";
            }
        }

        protected override IEnumerable<KeyValuePair<string, string>> GetParameters(string id)
        {
            var world = this.WorldId;
            if (world != 0)
            {
                yield return new KeyValuePair<string, string>("world", world.ToString());
            }
        }
    }
}