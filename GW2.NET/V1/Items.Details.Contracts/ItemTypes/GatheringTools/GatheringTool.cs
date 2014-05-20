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

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a gathering tool.</summary>
    [JsonConverter(typeof(GatheringToolConverter))]
    public abstract class GatheringTool : Item, ISkinnable
    {
        /// <summary>Initializes a new instance of the <see cref="GatheringTool"/> class.</summary>
        /// <param name="gatheringToolType">The gathering tool type.</param>
        protected GatheringTool(GatheringToolType gatheringToolType)
            : base(ItemType.Gathering, "gathering")
        {
            this.GatheringToolType = gatheringToolType;
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public int DefaultSkin { get; set; }

        /// <summary>Gets or sets the gathering tool's type.</summary>
        [DataMember(Name = "gathering_type")]
        protected GatheringToolType GatheringToolType { get; set; }
    }
}