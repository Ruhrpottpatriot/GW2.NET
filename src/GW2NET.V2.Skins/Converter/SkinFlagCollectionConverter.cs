// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="SkinFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins.Converters
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
        /// <exception cref="ArgumentNullException">The value of <paramref name="skinFlagsConverter"/> is a null reference.</exception>
        public SkinFlagCollectionConverter(IConverter<string, SkinFlags> skinFlagsConverter)
        {
            if (skinFlagsConverter == null)
            {
                throw new ArgumentNullException("skinFlagsConverter");
            }

            this.skinFlagsConverter = skinFlagsConverter;
        }

        /// <inheritdoc />
        public SkinFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            SkinFlags result = default(SkinFlags);
            foreach (var s in value)
            {
                result = result | this.skinFlagsConverter.Convert(s, state);
            }

            return result;
        }
    }
}