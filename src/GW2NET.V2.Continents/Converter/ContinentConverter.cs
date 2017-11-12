// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Continents
{
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts a <see cref="ContinentDataContract"/> into the corresponding <see cref="Continent"/>.</summary>
    internal sealed class ContinentConverter : IConverter<ContinentDataContract, Continent>
    {
        /// <inheritdoc />
        public Continent Convert(ContinentDataContract value)
        {
            return new Continent
                       {
                           ContinentDimensions = new Size2D(value.Dimensions[0], value.Dimensions[1]),
                           ContinentId = value.Id,
                           FloorIds = value.Floors,
                           MaximumZoom = value.MaximumZoom,
                           MinimumZoom = value.MinimumZoom,
                           Name = value.Name
                       };
        }
    }
}
