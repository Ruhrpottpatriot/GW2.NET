// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CylinderLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a cylindrical location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.DynamicEvents.Locations
{
    /// <summary>Represents a cylindrical location of an event on the map.</summary>
    public class CylinderLocation : Location
    {
        /// <summary>Gets or sets the location's height.</summary>
        public virtual double Height { get; set; }

        /// <summary>Gets or sets the location's radius.</summary>
        public virtual double Radius { get; set; }

        /// <summary>Gets or sets the location's rotation.</summary>
        public virtual double Rotation { get; set; }
    }
}