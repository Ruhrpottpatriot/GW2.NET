// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemBuffContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item buff.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents an item buff.</summary>
    [DataContract]
    public sealed class ItemBuffContract
    {
        /// <summary>Gets or sets the buff's description.</summary>
        [DataMember(Name = "description", Order = 0)]
        public string Description { get; set; }

        /// <summary>Gets or sets the buff's skill identifier.</summary>
        [DataMember(Name = "skill_id", Order = 1)]
        public string SkillId { get; set; }
    }
}