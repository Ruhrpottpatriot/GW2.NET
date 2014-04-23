// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible tool types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Tools
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates the possible tool types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ToolType
    {
        /// <summary>The 'Unknown' tool type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0, 

        /// <summary>The 'Salvage' tool type.</summary>
        [EnumMember(Value = "Salvage")]
        Salvage = 1 << 0
    }
}