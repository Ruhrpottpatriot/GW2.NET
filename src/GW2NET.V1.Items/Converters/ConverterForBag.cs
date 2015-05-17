// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Bag" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Bag"/>.</summary>
    internal sealed class ConverterForBag : IConverter<ItemDataContract, Bag>
    {
        /// <inheritdoc />
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