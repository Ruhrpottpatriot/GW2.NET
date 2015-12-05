// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="FloorDTO" /> to objects of type <see cref="Floor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="FloorDTO"/> to objects of type <see cref="Floor"/>.</summary>
    public sealed class FloorConverter : IConverter<FloorDTO, Floor>
    {
        private readonly IConverter<double[][], Rectangle> rectangleConverter;

        private readonly IConverter<IDictionary<string, RegionDTO>, IDictionary<int, Region>> regionCollectionConverter;

        private readonly IConverter<double[], Size2D> size2DConverter;

        /// <summary>Initializes a new instance of the <see cref="FloorConverter"/> class.</summary>
        /// <param name="size2DConverter">The converter for <see cref="Size2D"/>.</param>
        /// <param name="rectangleConverter">The converter for <see cref="Rectangle"/>.</param>
        /// <param name="regionCollectionConverter">The converter for <see cref="T:IDictionary{int,Region}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="size2DConverter"/> or <paramref name="rectangleConverter"/> or <paramref name="regionCollectionConverter"/> is a null reference.</exception>
        public FloorConverter(IConverter<double[], Size2D> size2DConverter, IConverter<double[][], Rectangle> rectangleConverter, IConverter<IDictionary<string, RegionDTO>, IDictionary<int, Region>> regionCollectionConverter)
        {
            if (size2DConverter == null)
            {
                throw new ArgumentNullException("size2DConverter");
            }

            if (rectangleConverter == null)
            {
                throw new ArgumentNullException("rectangleConverter");
            }

            if (regionCollectionConverter == null)
            {
                throw new ArgumentNullException("regionCollectionConverter");
            }

            this.size2DConverter = size2DConverter;
            this.rectangleConverter = rectangleConverter;
            this.regionCollectionConverter = regionCollectionConverter;
        }

        /// <inheritdoc />
        public Floor Convert(FloorDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Create a new floor object
            var floor = new Floor();

            // Set the texture dimensions
            var textureDimensions = value.TextureDimensions;
            if (textureDimensions != null && textureDimensions.Length == 2)
            {
                floor.TextureDimensions = this.size2DConverter.Convert(textureDimensions, value);
            }

            // Set the clamped view dimensions
            var clampedView = value.ClampedView;
            if (clampedView != null && clampedView.Length == 2)
            {
                floor.ClampedView = this.rectangleConverter.Convert(clampedView, value);
            }

            // Set the regions
            var regions = value.Regions;
            if (regions == null)
            {
                floor.Regions = new Dictionary<int, Region>(0);
            }
            else
            {
                floor.Regions = this.regionCollectionConverter.Convert(regions, value);
            }

            // Return the floor object
            return floor;
        }
    }
}