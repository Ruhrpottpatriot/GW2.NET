// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonusType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates all possible bonus types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Details.Contracts.Maps.Bonuses
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates all possible bonus types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MapBonusType
    {
        /// <summary>The 'bloodlust' bonus type.</summary>
        [EnumMember(Value = "bloodlust")]
        Bloodlust = 1 << 0
    }
}