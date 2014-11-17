// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSkinFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="SkinFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="SkinFlags"/>.</summary>
    internal sealed class ConverterForSkinFlagCollection : IConverter<ICollection<string>, SkinFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, SkinFlags> converterForSkinFlags;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkinFlagCollection"/> class.</summary>
        internal ConverterForSkinFlagCollection()
            : this(new ConverterForSkinFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSkinFlagCollection"/> class.</summary>
        /// <param name="converterForSkinFlags">The converter for <see cref="SkinFlags"/>.</param>
        internal ConverterForSkinFlagCollection(IConverter<string, SkinFlags> converterForSkinFlags)
        {
            Contract.Requires(converterForSkinFlags != null);
            this.converterForSkinFlags = converterForSkinFlags;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="SkinFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public SkinFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(SkinFlags);
            foreach (var s in value)
            {
                result |= this.converterForSkinFlags.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForSkinFlags != null);
        }
    }
}