// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemCollectionDataContract" /> to objects of type <see cref="T:ICollection{int}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemCollectionDataContract"/> to objects of type <see cref="T:ICollection{int}"/>.</summary>
    internal sealed class ConverterForItemCollection : IConverter<ItemCollectionDataContract, ICollection<int>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<int>, ICollection<int>> converterForCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemCollection"/> class.</summary>
        public ConverterForItemCollection()
            : this(new ConverterAdapter<ICollection<int>>())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemCollection"/> class.</summary>
        /// <param name="converterForCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        internal ConverterForItemCollection(IConverter<ICollection<int>, ICollection<int>> converterForCollection)
        {
            if (converterForCollection == null)
            {
                throw new ArgumentNullException("converterForCollection", "Precondition: converterForCollection != null");
            }

            this.converterForCollection = converterForCollection;
        }

        /// <inheritdoc />
        public ICollection<int> Convert(ItemCollectionDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var values = value.Items;
            if (values == null)
            {
                return new List<int>(0);
            }

            return this.converterForCollection.Convert(values);
        }
    }
}