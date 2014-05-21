// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchCollectionResult.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of matches.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;

    /// <summary>Wraps a collection of matches.</summary>
    public class MatchCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a collection of matches.</summary>
        [DataMember(Name = "wvw_matches", Order = 0)]
        public MatchCollection Matches { get; set; }
    }
}