// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictionCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemRestrictions" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2NET.Common;
using GW2NET.Items;

namespace GW2NET.V1.Skins.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="ItemRestrictions"/>.</summary>
    public sealed class ItemRestrictionCollectionConverter : IConverter<ICollection<string>, ItemRestrictions>
    {
        private readonly IConverter<string, ItemRestrictions> itemRestrictionConverter;

        /// <summary>Initializes a new instance of the <see cref="ItemRestrictionCollectionConverter"/> class.</summary>
        /// <param name="itemRestrictionConverter">The converter for <see cref="ItemRestrictions"/>.</param>
        public ItemRestrictionCollectionConverter(IConverter<string, ItemRestrictions> itemRestrictionConverter)
        {
            if (itemRestrictionConverter == null)
            {
                throw new ArgumentNullException("itemRestrictionConverter");
            }

            this.itemRestrictionConverter = itemRestrictionConverter;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="ItemRestrictions"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ItemRestrictions Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(ItemRestrictions);
            foreach (var s in value)
            {
                result |= this.itemRestrictionConverter.Convert(s, state);
            }

            return result;
        }
    }
}