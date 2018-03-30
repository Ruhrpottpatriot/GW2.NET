// <copyright file="MiniatureConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items.Miniatures;
    using Json;

    public partial class MiniatureConverter
    {
        partial void Merge(Miniature entity, ItemDTO dto, object state)
        {
            entity.MiniatureId = dto.Details.MiniPetId;
        }
    }
}
