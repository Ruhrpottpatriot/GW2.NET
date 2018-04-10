// <copyright file="ApiQuerySelector.ILanguageSelector.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Globalization;

    public partial class ApiQuerySelector : ILanguageSelector
    {
        /// <inheritdoc />
        IMessageBuilder ILanguageSelector.In(string language)
        {
            return ((ILanguageSelector)this).In(new CultureInfo(language));
        }

        /// <inheritdoc />
        IMessageBuilder ILanguageSelector.In(CultureInfo language)
        {
            this.currentRequest.Culture = language;
            return this;
        }
    }
}