// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemBuff.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item buff.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Common
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Represents an item buff.</summary>
    public class ItemBuff : JsonObject
    {
        /// <summary>Gets or sets the buff's description.</summary>
        [DataMember(Name = "description", Order = 1)]
        public string Description { get; set; }

        /// <summary>Gets or sets the buff's skill ID.</summary>
        [DataMember(Name = "skill_id", Order = 0)]
        public string SkillId { get; set; }
    }
}