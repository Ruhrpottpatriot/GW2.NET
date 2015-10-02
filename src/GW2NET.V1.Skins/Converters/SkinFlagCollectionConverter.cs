// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="SkinFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="SkinFlags"/>.</summary>
    public sealed class SkinFlagCollectionConverter : IConverter<ICollection<string>, SkinFlags>
    {
        private readonly IConverter<string, SkinFlags> skinFlagsConverter;

        /// <summary>Initializes a new instance of the <see cref="SkinFlagCollectionConverter"/> class.</summary>
        /// <param name="skinFlagsConverter">The converter for <see cref="SkinFlags"/>.</param>
        public SkinFlagCollectionConverter(IConverter<string, SkinFlags> skinFlagsConverter)
        {
            if (skinFlagsConverter == null)
            {
                throw new ArgumentNullException("skinFlagsConverter");
            }

            this.skinFlagsConverter = skinFlagsConverter;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="SkinFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public SkinFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(SkinFlags);
            foreach (var s in value)
            {
                result |= this.skinFlagsConverter.Convert(s, state);
            }

            return result;
        }
    }
}