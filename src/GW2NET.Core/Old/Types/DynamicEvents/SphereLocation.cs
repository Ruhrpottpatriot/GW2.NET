// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SphereLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a spherical location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.DynamicEvents
{
    /// <summary>Represents a spherical location.</summary>
    public class SphereLocation : Location
    {
        /// <summary>Gets or sets the location's radius.</summary>
        public virtual double Radius { get; set; }

        /// <summary>Gets or sets the location's rotation.</summary>
        public virtual double Rotation { get; set; }
    }
}