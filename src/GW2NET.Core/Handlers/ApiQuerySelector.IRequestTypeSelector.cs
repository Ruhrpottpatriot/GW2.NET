// <copyright file="ApiQuerySelector.IRequestTypeSelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    public partial class ApiQuerySelector : IRequestTypeSelector
    {
        /// <inheritdoc />
        IDetailsBuilder IRequestTypeSelector.GetDetails()
        {
            // Simply delegate to the next method to provide additional details
            return this;
        }

        /// <inheritdoc />
        IMessageBuilder IRequestTypeSelector.Discover()
        {
            // We don't need to to anything, since discovery requests stop at the base endpoint url
            return this;
        }
    }
}