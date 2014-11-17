// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Bag" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Bags;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Bag"/>.</summary>
    internal sealed class ConverterForBag : IConverter<ItemDataContract, Bag>
    {
        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="Bag"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Bag Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
            var bagDataContract = value.Bag;
            if (bagDataContract == null)
            {
                return new Bag();
            }

            var bag = new Bag();
            int size;
            if (int.TryParse(bagDataContract.Size, out size))
            {
                bag.Size = size;
            }

            int noSellOrSort;
            if (int.TryParse(bagDataContract.NoSellOrSort, out noSellOrSort))
            {
                bag.NoSellOrSort = noSellOrSort == 1;
            }

            return bag;
        }
    }
}