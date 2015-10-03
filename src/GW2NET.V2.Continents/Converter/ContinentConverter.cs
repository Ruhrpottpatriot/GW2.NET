// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContinentConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Continents.Converter
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V2.Continents.Json;

    /// <summary>Converts a <see cref="ContinentDTO"/> into the corresponding <see cref="Continent"/>.</summary>
    public sealed class ContinentConverter : IConverter<ContinentDTO, Continent>
    {
        /// <inheritdoc />
        public Continent Convert(ContinentDTO value, object state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            return new Continent
            {
                ContinentDimensions = new Size2D(value.Dimensions[0], value.Dimensions[1]),
                ContinentId = value.Id,
                FloorIds = value.Floors,
                MaximumZoom = value.MaximumZoom,
                MinimumZoom = value.MinimumZoom,
                Name = value.Name,
                Culture = response.Culture
            };
        }
    }
}