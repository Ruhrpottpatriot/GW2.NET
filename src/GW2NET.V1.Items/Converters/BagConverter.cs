// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDTO" /> to objects of type <see cref="Bag" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDTO"/> to objects of type <see cref="Bag"/>.</summary>
    public partial class BagConverter
    {
        partial void Merge(Bag entity, ItemDTO dto, object state)
        {
            var bag = dto.Bag;
            if (bag == null)
            {
                return;
            }

            int size;
            if (int.TryParse(bag.Size, out size))
            {
                entity.Size = size;
            }

            int noSellOrSort;
            if (int.TryParse(bag.NoSellOrSort, out noSellOrSort))
            {
                entity.NoSellOrSort = noSellOrSort == 1;
            }
        }
    }
}