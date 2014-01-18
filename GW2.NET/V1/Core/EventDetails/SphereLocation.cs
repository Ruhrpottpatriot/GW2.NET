// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SphereLocation.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using GW2DotNET.V1.Core.Drawing;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.EventDetails
{
    /// <summary>
    /// Represents a spherical location of an event on the map.
    /// </summary>
    public class SphereLocation : Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SphereLocation"/> class.
        /// </summary>
        public SphereLocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SphereLocation"/> class using the specified values.
        /// </summary>
        /// <param name="type">The location's shape.</param>
        /// <param name="center">The location's center.</param>
        /// <param name="radius">The location's radius.</param>
        /// <param name="rotation">The location's rotation.</param>
        public SphereLocation(Shape type, Point3D center, double radius, double rotation)
            : base(type, center)
        {
            this.Radius = radius;
            this.Rotation = rotation;
        }

        /// <summary>
        /// Gets or sets the location's radius.
        /// </summary>
        [JsonProperty("radius", Order = 4)]
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets the location's rotation.
        /// </summary>
        [JsonProperty("rotation", Order = 5)]
        public double Rotation { get; set; }
    }
}