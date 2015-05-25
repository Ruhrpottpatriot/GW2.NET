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
    using System;
    using System.Collections.Generic;
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
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForSkinFlags"/> is a null reference.</exception>
        internal SkinFlagCollectionConverter(IConverter<string, SkinFlags> converterForSkinFlags)
        {
            if (converterForSkinFlags == null)
            {
                throw new ArgumentNullException("converterForSkinFlags", "Precondition: converterForSkinFlags != null");
            }

            this.converterForSkinFlags = converterForSkinFlags;
        }

        /// <inheritdoc />
        public SkinFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return value.Aggregate(default(SkinFlags), (current, s) => current | this.converterForSkinFlags.Convert(s, state));
        }
    }
}