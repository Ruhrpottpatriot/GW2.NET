// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a skill challenge location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents a skill challenge location.</summary>
    [DataContract]
    public sealed class SkillChallengeContract
    {
        /// <summary>Gets or sets the skill challenge's coordinates.</summary>
        [DataMember(Name = "coord", Order = 0)]
        public double[] Coordinates { get; set; }
    }
}