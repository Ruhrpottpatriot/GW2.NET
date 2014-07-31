// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a skill challenge location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a skill challenge location.</summary>
    public sealed class SkillChallengeContract : ServiceContract
    {
        /// <summary>Gets or sets the skill challenge's coordinates.</summary>
        [DataMember(Name = "coord", Order = 0)]
        public double[] Coordinates { get; set; }
    }
}