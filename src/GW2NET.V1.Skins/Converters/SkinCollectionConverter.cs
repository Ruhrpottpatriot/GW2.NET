// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinCollectionDTO" /> to objects of type <see cref="T:ICollection{int}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Skins.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.V1.Skins.Json;

    /// <summary>
    ///     Converts objects of type <see cref="SkinCollectionDTO" /> to objects of type <see cref="T:ICollection{int}" />.
    /// </summary>
    public sealed class SkinCollectionConverter : IConverter<SkinCollectionDTO, ICollection<int>>
    {
        /// <summary>
        ///     Converts the given object of type <see cref="SkinCollectionDTO" /> to an object of type
        ///     <see cref="T:ICollection{int}" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ICollection<int> Convert(SkinCollectionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var values = value.Skins;
            if (values == null)
            {
                return new List<int>(0);
            }

            return values;
        }
    }
}