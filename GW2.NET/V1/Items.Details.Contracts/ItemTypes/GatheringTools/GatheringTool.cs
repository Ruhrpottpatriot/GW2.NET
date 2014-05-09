// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringTool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a gathering tool.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class GatheringTool : SkinnedItem
    {
        /// <summary>Initializes a new instance of the <see cref="GatheringTool" /> class.</summary>
        public GatheringTool()
            : base(ItemType.Gathering)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "gathering", Order = 100)]
        [JsonConverter(typeof(GatheringToolDetailsConverter))]
        public new virtual GatheringToolDetails Details
        {
            get
            {
                return base.Details as GatheringToolDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}