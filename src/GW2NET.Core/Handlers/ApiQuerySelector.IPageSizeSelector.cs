// <copyright file="ApiQuerySelector.IPageSizeSelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    public partial class ApiQuerySelector : IPageSizeSelector
    {
        /// <inheritdoc />
        ILanguageSelector IPageSizeSelector.AtSize(int size)
        {
            this.currentRequest.PageSize = size;
            return this;
        }
    }
}