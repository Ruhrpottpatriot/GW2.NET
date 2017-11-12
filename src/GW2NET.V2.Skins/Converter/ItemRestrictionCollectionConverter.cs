// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictionCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemRestrictions" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="ItemRestrictions"/>.</summary>
    internal sealed class ItemRestrictionCollectionConverter : IConverter<ICollection<string>, ItemRestrictions>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, ItemRestrictions> itemRestrictionConverter;

        /// <summary>Initializes a new instance of the <see cref="ItemRestrictionCollectionConverter"/> class.</summary>
        internal ItemRestrictionCollectionConverter()
            : this(new ItemRestrictionConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ItemRestrictionCollectionConverter"/> class.</summary>
        /// <param name="converterForItemRestriction">The converter for <see cref="ItemRestrictions"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForItemRestriction"/> is a null reference.</exception>
        internal ItemRestrictionCollectionConverter(IConverter<string, ItemRestrictions> converterForItemRestriction)
        {
            if (converterForItemRestriction == null)
            {
                throw new ArgumentNullException("converterForItemRestriction", "Precondition: converterForItemRestriction != null");
            }

            this.itemRestrictionConverter = converterForItemRestriction;
        }

        /// <inheritdoc />
        public ItemRestrictions Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return value.Aggregate(default(ItemRestrictions), (current, s) => current | this.itemRestrictionConverter.Convert(s));
        }
    }
}
