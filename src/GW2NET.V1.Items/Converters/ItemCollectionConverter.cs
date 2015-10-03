// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemCollectionDTO" /> to objects of type <see cref="T:ICollection{int}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemCollectionDTO"/> to objects of type <see cref="T:ICollection{int}"/>.</summary>
    public sealed class ItemCollectionConverter : IConverter<ItemCollectionDTO, ICollection<int>>
    {
        /// <inheritdoc />
        public ICollection<int> Convert(ItemCollectionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Items ?? new List<int>(0);
        }
    }
}