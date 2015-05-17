// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGizmo.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Gizmo" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Gizmo"/>.</summary>
    internal sealed class ConverterForGizmo : IConverter<ItemDataContract, Gizmo>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<GizmoDataContract, Gizmo>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForGizmo"/> class.</summary>
        internal ConverterForGizmo()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForGizmo"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        internal ConverterForGizmo(IDictionary<string, IConverter<GizmoDataContract, Gizmo>> typeConverters)
        {
            Contract.Requires(typeConverters != null);
            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Gizmo Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
            var gizmoDataContract = value.Gizmo;
            if (gizmoDataContract == null)
            {
                return new UnknownGizmo();
            }

            IConverter<GizmoDataContract, Gizmo> converter;
            if (this.typeConverters.TryGetValue(gizmoDataContract.Type, out converter))
            {
                return converter.Convert(gizmoDataContract);
            }

            return new UnknownGizmo();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<GizmoDataContract, Gizmo>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<GizmoDataContract, Gizmo>>
            {
                { "Default", new ConverterForDefaultGizmo() }, 
                { "ContainerKey", new ConverterForContainerKey() }, 
                { "RentableContractNpc", new ConverterForRentableContractNpc() }, 
                { "UnlimitedConsumable", new ConverterForUnlimitedConsumable() }, 
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
        }
    }
}