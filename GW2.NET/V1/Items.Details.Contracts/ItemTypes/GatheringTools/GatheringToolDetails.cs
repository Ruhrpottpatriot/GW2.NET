// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a gathering tool.</summary>
    [JsonConverter(typeof(GatheringToolDetailsConverter))]
    public abstract class GatheringToolDetails : ItemDetails
    {
        /// <summary>Initializes a new instance of the <see cref="GatheringToolDetails"/> class.</summary>
        /// <param name="gatheringToolType">The gathering tool type.</param>
        protected GatheringToolDetails(GatheringToolType gatheringToolType)
        {
            this.Type = gatheringToolType;
        }

        /// <summary>Gets or sets the gathering tool's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        protected GatheringToolType Type { get; set; }
    }
}