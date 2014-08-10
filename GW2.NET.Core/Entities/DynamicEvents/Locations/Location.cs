// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for event locations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.DynamicEvents
{
    using GW2DotNET.Entities.Maps;

    /// <summary>Provides the base class for event locations.</summary>
    public abstract class Location
    {
        /// <summary>Gets or sets the center coordinates.</summary>
        public virtual Point3D Center { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Center.ToString();
        }
    }
}