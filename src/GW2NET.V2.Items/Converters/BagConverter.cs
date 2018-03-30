// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDTO" /> to objects of type <see cref="Bag" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items.Bags;
    using GW2NET.V2.Items.Json;

    public partial class BagConverter
    {
        partial void Merge(Bag entity, ItemDTO dto, object state)
        {
            var details = dto.Details;
            if (details == null)
            {
                return;
            }

            if (details.Size.HasValue)
            {
                entity.Size = details.Size.Value;
            }

            if (details.NoSellOrSort.HasValue)
            {
                entity.NoSellOrSort = details.NoSellOrSort.Value;
            }
        }
    }
}