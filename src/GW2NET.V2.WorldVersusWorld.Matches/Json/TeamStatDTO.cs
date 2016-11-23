// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MatchDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches.Json
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class TeamStatDTO
    {
        /// <summary>Gets or sets the value for the Red team.</summary>
        [DataMember(Name = "red", Order = 0)]
        public int Red { get; set; }

        /// <summary>Gets or sets the value for the Blue team.</summary>
        [DataMember(Name = "blue", Order = 1)]
        public int Blue { get; set; }

        /// <summary>Gets or sets the value for the Green team.</summary>
        [DataMember(Name = "green", Order = 2)]
        public int Green { get; set; }
   }
}