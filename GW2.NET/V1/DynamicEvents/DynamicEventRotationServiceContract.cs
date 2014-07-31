// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRotationServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The dynamic event rotation service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2DotNET.DynamicEvents;

    /// <summary>The dynamic event rotation service contract.</summary>
    [ContractClassFor(typeof(IDynamicEventRotationService))]
    internal abstract class DynamicEventRotationServiceContract : IDynamicEventRotationService
    {
        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventRotation>>() != null);
            throw new NotImplementedException();
        }
    }
}