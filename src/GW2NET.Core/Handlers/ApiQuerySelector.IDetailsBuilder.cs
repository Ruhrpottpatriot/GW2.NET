// <copyright file="ApiQuerySelector.IDetailsBuilder.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Collections.Generic;
    using System.Linq;

    public partial class ApiQuerySelector : IDetailsBuilder
    {
        /// <inheritdoc />
        ILanguageSelector IDetailsBuilder.ForItem<TKey>(TKey id)
        {
            this.currentRequest.ItemIds.Add(id.ToString());
            return this;
        }

        /// <inheritdoc />
        ILanguageSelector IDetailsBuilder.ForItems<TKey>(IEnumerable<TKey> ids)
        {
            this.currentRequest.ItemIds = ids.Select(i => i.ToString()).ToList();
            return this;
        }

        /// <inheritdoc />
        IPageSizeSelector IDetailsBuilder.ForPages(int start, int count)
        {
            this.currentRequest.PageIndex = start;
            this.currentRequest.PageCount = count;
            return this;
        }
    }
}