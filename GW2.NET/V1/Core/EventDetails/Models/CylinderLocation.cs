// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CylinderLocation.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.Drawing;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.EventDetails.Models
{
    /// <summary>
    /// Represents a cylindrical location of an event on the map.
    /// </summary>
    public class CylinderLocation : Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CylinderLocation"/> class.
        /// </summary>
        public CylinderLocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CylinderLocation"/> class using the specified values.
        /// </summary>
        /// <param name="type">The location's shape.</param>
        /// <param name="center">The location's center.</param>
        /// <param name="height">The location's height.</param>
        /// <param name="radius">The location's radius.</param>
        /// <param name="rotation">The location's rotation.</param>
        public CylinderLocation(Shape type, Point3D center, double height, double radius, double rotation)
            : base(type, center)
        {
            this.Height = height;
            this.Radius = radius;
            this.Rotation = rotation;
        }

        /// <summary>
        /// Gets or sets the location's height.
        /// </summary>
        [JsonProperty("height", Order = 3)]
        [JsonConverter(typeof(DecimalWholeNumberConverter<double>))]
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the location's radius.
        /// </summary>
        [JsonProperty("radius", Order = 4)]
        [JsonConverter(typeof(DecimalWholeNumberConverter<double>))]
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the location's rotation.
        /// </summary>
        [JsonProperty("rotation", Order = 5)]
        [JsonConverter(typeof(DecimalWholeNumberConverter<double>))]
        public double Rotation { get; set; }
    }
}