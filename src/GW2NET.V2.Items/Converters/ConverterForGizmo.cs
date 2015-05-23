// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGizmo.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Gizmo" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Gizmo"/>.</summary>
    internal sealed class ConverterForGizmo : IConverter<DetailsDataContract, Gizmo>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Gizmo>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForGizmo"/> class.</summary>
        internal ConverterForGizmo()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForGizmo"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        internal ConverterForGizmo(IDictionary<string, IConverter<DetailsDataContract, Gizmo>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Gizmo"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Gizmo Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<DetailsDataContract, Gizmo> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                return converter.Convert(value);
            }

            return new UnknownGizmo();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Gizmo>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Gizmo>>
            {
                { "Default", new ConverterForDefaultGizmo() }, 
                { "ContainerKey", new ConverterForContainerKey() }, 
                { "RentableContractNpc", new ConverterForRentableContractNpc() }, 
                { "UnlimitedConsumable", new ConverterForUnlimitedConsumable() }, 
            };
        }
    }
}