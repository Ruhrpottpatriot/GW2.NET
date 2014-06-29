// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamColor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates all possible team colors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts.Common
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates all possible team colors.</summary>
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TeamColor
    {
        /// <summary>The 'Blue' color.</summary>
        [EnumMember(Value = "Blue")]
        Blue = 1 << 0, 

        /// <summary>The 'Green' color.</summary>
        [EnumMember(Value = "Green")]
        Green = 1 << 1, 

        /// <summary>The 'Red' color.</summary>
        [EnumMember(Value = "Red")]
        Red = 1 << 2, 

        /// <summary>The 'Neutral' color.</summary>
        [EnumMember(Value = "Neutral")]
        Neutral = 1 << 3
    }
}