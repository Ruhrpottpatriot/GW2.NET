// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Tools
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a tool.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Tool : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private ToolDetails detail;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Tool" /> class.
        /// </summary>
        public Tool()
            : base(ItemType.Tool)
        {
        }

        /// <summary>
        ///     Gets or sets the item details.
        /// </summary>
        [JsonProperty("tool", Order = 100)]
        public ToolDetails Detail
        {
            get
            {
                return this.detail;
            }

            set
            {
                this.detail = value;
                value.Tool = this;
            }
        }
    }
}