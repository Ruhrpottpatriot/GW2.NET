// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContainer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Container" />.
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

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Container"/>.</summary>
    internal sealed class ConverterForContainer : IConverter<ItemDataContract, Container>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<ContainerDataContract, Container>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForContainer"/> class.</summary>
        internal ConverterForContainer()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForContainer"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        internal ConverterForContainer(IDictionary<string, IConverter<ContainerDataContract, Container>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Container Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var containerDataContract = value.Container;
            if (containerDataContract == null)
            {
                return new UnknownContainer();
            }

            IConverter<ContainerDataContract, Container> converter;
            if (this.typeConverters.TryGetValue(containerDataContract.Type, out converter))
            {
                return converter.Convert(containerDataContract);
            }

            Debug.Assert(false, "Unknown type discriminator: " + containerDataContract.Type);
            return new UnknownContainer();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<ContainerDataContract, Container>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ContainerDataContract, Container>>
            {
                { "Default", new ConverterForDefaultContainer() },
                { "GiftBox", new ConverterForGiftBox() },
                { "OpenUI", new ConverterForOpenUiContainer() },
            };
        }
    }
}