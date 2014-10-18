// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIDynamicEventRotationService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIDynamicEventRotationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Local.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Entities.DynamicEvents;

    [ContractClassFor(typeof(IDynamicEventRotationService))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIDynamicEventRotationService : IDynamicEventRotationService
    {
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventRotation>>() != null);
            throw new NotImplementedException();
        }
    }
}