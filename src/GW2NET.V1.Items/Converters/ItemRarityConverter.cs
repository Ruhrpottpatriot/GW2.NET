// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRarityConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="ItemRarity" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="ItemRarity"/>.</summary>
    public sealed class ItemRarityConverter : IConverter<string, ItemRarity>
    {
        /// <inheritdoc />
        public ItemRarity Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            ItemRarity result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(ItemRarity);
        }
    }
}