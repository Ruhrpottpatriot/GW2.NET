// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownItem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown item..
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents an unknown item..</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class UnknownItem : Item
    {
        /// <summary>Initializes a new instance of the <see cref="UnknownItem" /> class.</summary>
        public UnknownItem()
            : base(ItemType.Unknown, "unknown")
        {
        }
    }
}