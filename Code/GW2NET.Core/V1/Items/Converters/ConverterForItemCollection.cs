﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemCollectionDataContract" /> to objects of type <see cref="T:ICollection{int}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;

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
            Contract.Requires(converterForCollection != null);
            this.converterForCollection = converterForCollection;
        }

        /// <summary>Converts the given object of type <see cref="ItemCollectionDataContract"/> to an object of type <see cref="T:ICollection{int}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<int> Convert(ItemCollectionDataContract value)
        {
            Contract.Assume(value != null);
            var values = value.Items;
            if (values == null)
            {
                return new List<int>(0);
            }

            return this.converterForCollection.Convert(values);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForCollection != null);
        }
    }
}