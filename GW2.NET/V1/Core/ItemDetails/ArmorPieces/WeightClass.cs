// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeightClass.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2DotNET.V1.Core.ItemDetails.ArmorPieces
{
    /// <summary>
    /// Enumerates the possible armor piece weight classes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WeightClass
    {
        /// <summary>
        /// The 'Clothing' weight class.
        /// </summary>
        [EnumMember(Value = "Clothing")]
        Clothing = 1 << 0,

        /// <summary>
        /// The 'Light' weight class.
        /// </summary>
        [EnumMember(Value = "Light")]
        Light = 1 << 1,

        /// <summary>
        /// The 'Medium' weight class.
        /// </summary>
        [EnumMember(Value = "Medium")]
        Medium = 1 << 2,

        /// <summary>
        /// The 'Heavy' weight class.
        /// </summary>
        [EnumMember(Value = "Heavy")]
        Heavy = 1 << 3
    }
}