// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiningToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a mining tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.GatheringTools.GatheringToolsTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a mining tool.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class MiningToolDetails : GatheringToolDetails
    {
        /// <summary>Initializes a new instance of the <see cref="MiningToolDetails" /> class.</summary>
        public MiningToolDetails()
            : base(GatheringToolType.Mining)
        {
        }
    }
}