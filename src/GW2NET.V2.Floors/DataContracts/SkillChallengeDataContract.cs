// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChallengeDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the skill challenge object from the api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Runtime.Serialization;

    /// <summary>Represents the skill challenge object from the api.</summary>
    [DataContract]
    internal sealed class SkillChallengeDataContract
    {
        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        [DataMember(Name = "coord", Order = 0)]
        internal double[] Coordinates { get; set; }
    }
}