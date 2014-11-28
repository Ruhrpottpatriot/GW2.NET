// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSkinCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinCollectionDataContract" /> to objects of type <see cref="T:ICollection{int}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.V1.Skins.Json;

namespace GW2NET.V1.Skins.Converters
{
    /// <summary>Converts objects of type <see cref="SkinCollectionDataContract"/> to objects of type <see cref="T:ICollection{int}"/>.</summary>
    internal sealed class ConverterForSkinCollection : IConverter<SkinCollectionDataContract, ICollection<int>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<int>, ICollection<int>> converterForCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkinCollection"/> class.</summary>
        public ConverterForSkinCollection()
            : this(new ConverterAdapter<ICollection<int>>())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkinCollection"/> class.</summary>
        /// <param name="converterForCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        internal ConverterForSkinCollection(IConverter<ICollection<int>, ICollection<int>> converterForCollection)
        {
            Contract.Requires(converterForCollection != null);
            this.converterForCollection = converterForCollection;
        }

        /// <summary>Converts the given object of type <see cref="SkinCollectionDataContract"/> to an object of type <see cref="T:ICollection{int}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<int> Convert(SkinCollectionDataContract value)
        {
            Contract.Assume(value != null);
            var values = value.Skins;
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