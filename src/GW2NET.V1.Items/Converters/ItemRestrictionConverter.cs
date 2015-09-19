// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRestrictionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="ItemRestrictions" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="ItemRestrictions"/>.</summary>
    public sealed class ItemRestrictionConverter : IConverter<string, ItemRestrictions>
    {
        /// <inheritdoc />
        public ItemRestrictions Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            ItemRestrictions result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(ItemRestrictions);
        }
    }
}