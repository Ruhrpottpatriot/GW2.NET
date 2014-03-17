// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GiftBoxContainerDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a gift box container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Containers.ContainerTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a gift box container.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class GiftBoxContainerDetails : ContainerDetails
    {
        /// <summary>Initializes a new instance of the <see cref="GiftBoxContainerDetails" /> class.</summary>
        public GiftBoxContainerDetails()
            : base(ContainerType.GiftBox)
        {
        }
    }
}