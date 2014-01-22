// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BonusType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.WvW.MatchDetails.Models
{
    /// <summary>
    /// Enumerates all possible bonus types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BonusType
    {
        /// <summary>The 'bloodlust' bonus type.</summary>
        [EnumMember(Value = "bloodlust")]
        Bloodlust = 1 << 0
    }
}