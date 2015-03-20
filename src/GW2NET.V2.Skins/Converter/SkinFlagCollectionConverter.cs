// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="SkinFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="SkinFlags"/>.</summary>
    internal sealed class SkinFlagCollectionConverter : IConverter<ICollection<string>, SkinFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, SkinFlags> converterForSkinFlags;

        /// <summary>Initializes a new instance of the <see cref="SkinFlagCollectionConverter"/> class.</summary>
        internal SkinFlagCollectionConverter()
            : this(new SkinFlagConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkinFlagCollectionConverter"/> class.</summary>
        /// <param name="converterForSkinFlags">The converter for <see cref="SkinFlags"/>.</param>
        internal SkinFlagCollectionConverter(IConverter<string, SkinFlags> converterForSkinFlags)
        {
            Contract.Requires(converterForSkinFlags != null);
            this.converterForSkinFlags = converterForSkinFlags;
        }

        /// <inheritdoc />
        public SkinFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);

            return value.Aggregate(default(SkinFlags), (current, s) => current | this.converterForSkinFlags.Convert(s));
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when CodeContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForSkinFlags != null);
        }
    }
}