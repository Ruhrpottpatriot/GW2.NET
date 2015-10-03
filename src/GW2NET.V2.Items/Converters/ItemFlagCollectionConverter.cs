// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemFlags" />.</summary>
    public sealed class ItemFlagCollectionConverter : IConverter<ICollection<string>, ItemFlags>
    {
        private readonly IConverter<string, ItemFlags> itemFlagConverter;

        /// <summary>Initializes a new instance of the <see cref="ItemFlagCollectionConverter" /> class.</summary>
        /// <param name="itemFlagConverter">The converter for <see cref="ItemFlags" />.</param>
        public ItemFlagCollectionConverter(IConverter<string, ItemFlags> itemFlagConverter)
        {
            if (itemFlagConverter == null)
            {
                throw new ArgumentNullException("itemFlagConverter");
            }

            this.itemFlagConverter = itemFlagConverter;
        }

        /// <summary>
        ///     Converts the given object of type <see cref="T:ICollection{string}" /> to an object of type
        ///     <see cref="ItemFlags" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ItemFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(ItemFlags);
            foreach (var s in value)
            {
                result |= this.itemFlagConverter.Convert(s, state);
            }

            return result;
        }
    }
}