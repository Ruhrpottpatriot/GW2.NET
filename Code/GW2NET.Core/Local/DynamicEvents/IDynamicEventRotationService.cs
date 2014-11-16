// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDynamicEventRotationService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the event rotations service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Local.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2NET.DynamicEvents;

    /// <summary>Provides the interface for the event rotations service.</summary>
    [ContractClass(typeof(ContractClassForIDynamicEventRotationService))]
    public interface IDynamicEventRotationService
    {
        /// <summary>Gets a collection of dynamic events and their rotating shifts</summary>
        /// <returns>A collection of dynamic events and their rotating shifts.</returns>
        IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations();
    }
}