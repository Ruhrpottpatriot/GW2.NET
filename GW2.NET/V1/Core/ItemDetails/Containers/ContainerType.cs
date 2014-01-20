// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemDetails.Containers
{
    /// <summary>
    /// Enumerates the possible container types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContainerType
    {
        /// <summary>
        /// The 'Default' container type.
        /// </summary>
        [EnumMember(Value = "Default")]
        Default = 1 << 0,

        /// <summary>
        /// The 'Gift Box' container type.
        /// </summary>
        [EnumMember(Value = "GiftBox")]
        GiftBox = 1 << 1
    }
}