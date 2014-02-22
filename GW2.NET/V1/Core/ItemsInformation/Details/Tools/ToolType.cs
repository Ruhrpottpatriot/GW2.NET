// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Tools
{
    /// <summary>
    /// Enumerates the possible tool types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ToolType
    {
        /// <summary>The 'Salvage' tool type.</summary>
        [EnumMember(Value = "Salvage")]
        Salvage = 1 << 0
    }
}