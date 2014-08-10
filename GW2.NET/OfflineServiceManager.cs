// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OfflineServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to specialty services that do not require a connection to a remote service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2DotNET.Entities.DynamicEvents;
    using GW2DotNET.Local.DynamicEvents;

    /// <summary>Provides access to specialty services that do not require a connection to a remote service.</summary>
    public class OfflineServiceManager : IDynamicEventRotationService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IDynamicEventRotationService dynamicEventRotationService;

        /// <summary>Initializes a new instance of the <see cref="OfflineServiceManager"/> class.</summary>
        public OfflineServiceManager()
        {
            this.dynamicEventRotationService = new DynamicEventRotationService();
        }

        /// <summary>Initializes a new instance of the <see cref="OfflineServiceManager"/> class.</summary>
        /// <param name="dynamicEventRotationService">The dynamic event rotation service.</param>
        public OfflineServiceManager(IDynamicEventRotationService dynamicEventRotationService)
        {
            Contract.Requires(dynamicEventRotationService != null);
            this.dynamicEventRotationService = dynamicEventRotationService;
        }

        /// <summary>Gets a collection of dynamic events and their rotating shifts</summary>
        /// <returns>A collection of dynamic events and their rotating shifts.</returns>
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            return this.dynamicEventRotationService.GetDynamicEventRotations();
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dynamicEventRotationService != null);
        }
    }
}