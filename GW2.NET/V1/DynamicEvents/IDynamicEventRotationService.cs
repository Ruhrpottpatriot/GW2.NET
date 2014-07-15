// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicEventRotationService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the event rotations service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System.Collections.Generic;

    using GW2DotNET.V1.DynamicEvents.Contracts;

    /// <summary>Provides the interface for the event rotations service.</summary>
    public interface IDynamicEventRotationService
    {
        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        IEnumerable<DynamicEventRotation> GetDynamicEventRotations();
    }
}