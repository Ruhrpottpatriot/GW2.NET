// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SalvageToolDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a salvaging tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.Tools.ToolTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a salvaging tool.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class SalvageToolDetails : ToolDetails
    {
        /// <summary>Initializes a new instance of the <see cref="SalvageToolDetails" /> class.</summary>
        public SalvageToolDetails()
            : base(ToolType.Salvage)
        {
        }
    }
}