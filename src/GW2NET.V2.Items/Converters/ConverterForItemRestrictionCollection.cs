// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemRestrictionCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemRestrictions" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="ItemRestrictions"/>.</summary>
    internal sealed class ConverterForItemRestrictionCollection : IConverter<ICollection<string>, ItemRestrictions>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, ItemRestrictions> converterForItemRestriction;

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemRestrictionCollection"/> class.</summary>
        internal ConverterForItemRestrictionCollection()
            : this(new ConverterForItemRestriction())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemRestrictionCollection"/> class.</summary>
        /// <param name="converterForItemRestriction">The converter for <see cref="ItemRestrictions"/>.</param>
        internal ConverterForItemRestrictionCollection(IConverter<string, ItemRestrictions> converterForItemRestriction)
        {
            if (converterForItemRestriction == null)
            {
                throw new ArgumentNullException("converterForItemRestriction", "Precondition: converterForItemRestriction != null");
            }

            this.converterForItemRestriction = converterForItemRestriction;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="ItemRestrictions"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ItemRestrictions Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var result = default(ItemRestrictions);
            foreach (var s in value)
            {
                result |= this.converterForItemRestriction.Convert(s, state);
            }

            return result;
        }
    }
}