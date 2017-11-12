// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGizmo.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Gizmo" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

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
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
    }
            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Gizmo Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

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

            Debug.Assert(false, "Unknown type discriminator: " + gizmoDataContract.Type);
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
    }
}