// <copyright file="ApiQuerySelector.IMessageBuilder.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public partial class ApiQuerySelector : IMessageBuilder
    {
        IEnumerable<HttpRequestMessage> IMessageBuilder.Build()
        {
            this.SaveCurrent();
            return this.BuildRequests();
        }

        /// <inheritdoc />
        HttpRequestMessage IMessageBuilder.BuildSingle()
        {
            this.SaveCurrent();
            return this.BuildRequests().Single();
        }

        /// <inheritdoc />
        IVersionSelector IMessageBuilder.Also()
        {
            this.SaveCurrent();
            return this;
        }
    }
}
